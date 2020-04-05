using AGLDevTestAPI.Model;
using AGLDevTestAPI.Proxy;
using AGLDevTestAPI.Service;
using Microsoft.Extensions.Options;
using Moq;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace AGLDevTestAPI.Test
{
    public class PetServiceTest
    {
        IOptions<Settings> appSettings = Options.Create(new Settings() { BaseUrl = "" });
        Mock<IPetProxy> moqPetProxy;
        JArray petJArray; 

        public PetServiceTest()
        {
            moqPetProxy = new Mock<IPetProxy>();
            petJArray = new JArray(JObject.FromObject(new PetModel()
            {
                age = 18,
                gender = "male",
                name = "sree",
                pets = new List<Pet>{ new Pet()
            {
                name = "molly",
                type = "cat"
            } }
            }));           

        }

        internal void Dispose()
        {
            moqPetProxy = null;
        }

        [Fact]
        public void GetPetTypes_returns_all_pettypes()
        {
            //given
            moqPetProxy.Setup(m => m.GetAsync(It.IsAny<string>())).Returns(Task.FromResult<string>(petJArray.ToString()));
            var sut = new PetService(appSettings,moqPetProxy.Object);
            //when
            var result = sut.GetPetTypes();
            //then
            Assert.IsAssignableFrom<IEnumerable<string>>(result.Result);
        }

        [Fact]
        public void GetListofPetsByOwnerGender_returns_all_petnames_by_owner_gender()
        {
            //given
            moqPetProxy.Setup(m => m.GetAsync(It.IsAny<string>())).Returns(Task.FromResult<string>(petJArray.ToString()));

            var sut = new PetService(appSettings,moqPetProxy.Object);
            //when
            var result = sut.GetListofPetsByOwnerGender("Cat");
            //then
            Assert.IsAssignableFrom<IEnumerable<PetNamesbyOwnerGender>>(result.Result);

        }
    }
}
