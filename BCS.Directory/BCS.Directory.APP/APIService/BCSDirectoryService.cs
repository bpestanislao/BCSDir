using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using BCS.Directory.APP.Mapper;
using BCS.Directory.CORE.Entity;

namespace BCS.Directory.APP.APIService
{
    public class BCSDirectoryService : IBCSDirectoryService
    {
        public APIResponse AddEmployee(Employee employee)
        {
            APIResponse response = new APIResponse();
            try
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri("http://localhost:57110/api/Employee/");
                    var postTask = client.PostAsJsonAsync<Employee>("SaveEmployee", employee);
                    postTask.Wait();

                    var result = postTask.Result;
                    if (result.IsSuccessStatusCode)
                    {
                        response.IsSuccess = result.IsSuccessStatusCode;
                        response.Message = "Save Successfully";
                    }
                }
            }
            catch (Exception)
            {

                response.IsSuccess = false;
                response.Message = "Error Encountered";
            }

            return response;
        }

        public List<Country> GetCountry()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:57110/api/Employee/");
                //HTTP GET
                var responseTask = client.GetAsync("GetCoutries");
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<List<Country>>();
                    readTask.Wait();
                    return readTask.Result;
                }
            }
            return new List<Country>() { };
        }
    }
}
