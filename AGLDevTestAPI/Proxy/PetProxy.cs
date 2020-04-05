using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace AGLDevTestAPI.Proxy
{
    public interface IPetProxy
    {
        Task<string> GetAsync(string path);
    }
    public class PetProxy : IPetProxy
    {
        public async Task<string> GetAsync(string path)
        {
            using (var client = new HttpClient())
            {
                HttpResponseMessage result = await client.GetAsync(path);
                if (result.IsSuccessStatusCode)
                {
                    return await result.Content.ReadAsStringAsync();
                }
                else
                {
                    throw new Exception((int)result.StatusCode + "-" + result.StatusCode.ToString());
                }
            }
        }

    }
}
