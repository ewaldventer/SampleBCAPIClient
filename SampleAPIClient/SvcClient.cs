using System.Net.Http.Headers;
using System.Net;
using System.Text;
using Newtonsoft.Json;
using SampleAPIClient.Models;

namespace SampleAPIClient
{
    public class SvcClient
    {
        private readonly string Url;
        private HttpClient HttpClient;

        public SvcClient(bool WinAuth, string Domain, string UserName, string Password, string _Url, string _ComanpayId)
        {
            Url = _Url.EndsWith("/") ? _Url : _Url + "/";
            Url += $"companies({_ComanpayId})/";

            if (WinAuth)
            {
                if (string.IsNullOrEmpty(UserName))
                {
                    HttpClient = HttpClient ?? new HttpClient(new HttpClientHandler() { UseDefaultCredentials = true });
                }
                else
                {
                    HttpClient = HttpClient ?? new HttpClient(new HttpClientHandler() { Credentials = new NetworkCredential(UserName, Password, Domain) });
                }
            }
            else if (!string.IsNullOrWhiteSpace(UserName))
            {
                HttpClient = new HttpClient();
                HttpClient.DefaultRequestHeaders.Authorization =
                    new AuthenticationHeaderValue("Basic", Convert.ToBase64String(
                        ASCIIEncoding.ASCII.GetBytes($"{UserName}:{Password}")));
            }
            else
                throw new Exception("Either use Windows authentication or specify a UserName and Password for basic authentication");

            HttpClient.Timeout = TimeSpan.FromMinutes(1);

            HttpClient.DefaultRequestHeaders.Add("Accept", "application/json");
        }

        public async Task<T> SendAsync<T>(HttpMethod method, string Service, T entity, string Filters = "", string Expand = "")
        {
            T result;
            string requestUrl = Url + Service;

            if (method == HttpMethod.Get)
            {
                var hasExpand = !string.IsNullOrEmpty(Expand);
                var hasFilter = !string.IsNullOrEmpty(Filters);

                if (hasFilter || hasExpand)
                    requestUrl += "?";

                if (hasExpand)
                    requestUrl += $"$expand={Expand}";

                if (hasFilter)
                    requestUrl += (hasExpand ? "&" : "") + $"$filter={Filters}";
            }


            HttpRequestMessage message = new HttpRequestMessage
            {
                Method = method,
                RequestUri = new Uri(requestUrl)
            };

            if(method == HttpMethod.Post)
            {
                var jsonString = JsonConvert.SerializeObject(entity, Formatting.None, new JsonSerializerSettings
                           {
                               NullValueHandling = NullValueHandling.Ignore
                           });
                message.Content = new StringContent(jsonString, Encoding.UTF8, "application/json");
            }

            using (var response = await HttpClient.SendAsync(message))
            {
                string body = "";

                try
                {
                    body = await response.Content.ReadAsStringAsync();
                    response.EnsureSuccessStatusCode();
                    result = JsonConvert.DeserializeObject<T>(body);
                }
                catch (Exception ex) when (response.StatusCode == HttpStatusCode.Unauthorized)
                {
                    throw new Exception("The username or password provided in custom setup is incorrect, please check the Custom setups under Tools > Options > Custom Setups > Nav Integrations", ex);
                }
                catch (Exception ex)
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
                    {
                        var errorResult = JsonConvert.DeserializeObject<ErrorResponse>(body);
                        if (errorResult.error.code == "BadRequest_ResourceNotFound")
                            result = default(T);
                        else
                            throw ex;
                    }
                    else
                        throw ex;
                }
            }

            return result;
        }
    }
}
