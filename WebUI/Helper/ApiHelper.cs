using Newtonsoft.Json;
using System.Collections.Specialized;
using System.Net;
using System.Text;

namespace WebUI.Helper
{
    public static class ApiHelper
    {
        public static ResponseModel<T> Request<T>(string url, string methodType, NameValueCollection header = null, object requestObj = null, bool isResponseModel = true, int timeout = 60000, string contentType = "application/json") where T : class
        {
            try
            {
                using (var client = new HttpClient()
                {
                    Timeout = TimeSpan.FromMilliseconds(timeout)
                })
                {
                    var content = new StringContent(string.Empty);

                    if (requestObj != null)
                        content = new StringContent(JsonConvert.SerializeObject(requestObj), Encoding.UTF8, contentType);

                    client.BaseAddress = new Uri(url);
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.ExpectContinue = false;

                    if (header != null)
                    {
                        foreach (var key in header.AllKeys)
                            client.DefaultRequestHeaders.TryAddWithoutValidation(key, header[key]);
                    }

                    Task<HttpResponseMessage> responseTask;

                    if (methodType == WebRequestMethods.Http.Post)
                        responseTask = client.PostAsync(url, content);
                    else
                        responseTask = client.GetAsync(url);

                    responseTask.Wait();

                    var httpResponseMessage = responseTask.Result;

                    var readTask = httpResponseMessage.Content.ReadAsStringAsync();
                    readTask.Wait();

                    if (!isResponseModel)
                        return new ResponseModel<T>()
                        {
                            Succeeded = true,
                            Data = JsonConvert.DeserializeObject<T>(readTask.Result)
                        };

                    return JsonConvert.DeserializeObject<ResponseModel<T>>(readTask.Result);
                }
            }
            catch
            {
                return null;
            }
        }
    }
}
