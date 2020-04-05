using AGLDevTestAPI.Model;
using AGLDevTestAPI.Proxy;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AGLDevTestAPI.Service
{
    public interface IPetService
    {
        public Task<IEnumerable<string>> GetPetTypes();
        public Task<IEnumerable<PetNamesbyOwnerGender>> GetListofPetsByOwnerGender(string petType);


    }
    public class PetService : IPetService
    {
        private readonly Settings _appSettings;
        private IPetProxy _petProxy;

        public PetService(IOptions<Settings> appSettings, IPetProxy petProxy)
        {
            _appSettings = appSettings.Value;
            _petProxy = petProxy;
        }
        public async Task<IEnumerable<PetNamesbyOwnerGender>> GetListofPetsByOwnerGender(string petType)
        {
            List<PetNamesbyOwnerGender> ListofPetsByOwnerGender = new List<PetNamesbyOwnerGender>();
            try
            {
                //if (Enum.TryParse(petType, true, out enumType))
                //{

                //}
                var response = await _petProxy.GetAsync(_appSettings.BaseUrl);
                List<PetModel> petList = JsonData.DeserializeObject<List<PetModel>>(response);
                petList.Where(pets => pets.pets != null).Select(p => new PetNamesbyOwnerGender
                {
                    gender = p.gender,
                    petnames = p.pets.Where(a => a.type.Equals(petType, StringComparison.InvariantCultureIgnoreCase))
                                .Select(b => b.name).ToList()
                }).GroupBy(g => g.gender).ToList().
                ForEach(a => ListofPetsByOwnerGender.Add(new PetNamesbyOwnerGender
                {
                    gender = a.Key,
                    petnames = a.ToList().SelectMany(x => x.petnames).OrderBy(o => o).ToList()
                }));

            }
            catch(Exception ex)
            {
                //log
                return null;         
            }

            return ListofPetsByOwnerGender;
        }

        public async Task<IEnumerable<string>> GetPetTypes()
        {
            try
            {
                var response = await _petProxy.GetAsync(_appSettings.BaseUrl);
                List<PetModel> petList = JsonData.DeserializeObject<List<PetModel>>(response);                
                return petList.Where(a => a.pets != null).SelectMany(c => c.pets.Select(p => p.type)).Distinct();
            }
            catch
            {
                //shout/catch/throw/log
                return null;
            }
        }

    }

    public static class JsonData
    {
        public static T DeserializeObject<T>(string data)
        {
            return JsonConvert.DeserializeObject<T>(data);
        }
    }
}
