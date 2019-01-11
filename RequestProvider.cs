using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;
using Castle.Models;
using Castle.DataServices;
using Castle.Helpers;
using System;

namespace Castle.DataServices
{
    public class RequestProvider : IRequestProvider
    {
        private readonly JsonSerializerSettings _serializerSettings;

        public RequestProvider()
        {
            _serializerSettings = new JsonSerializerSettings
            {
                ContractResolver = new CamelCasePropertyNamesContractResolver(),
                DateTimeZoneHandling = DateTimeZoneHandling.Utc,
                NullValueHandling = NullValueHandling.Ignore
            };

            _serializerSettings.Converters.Add(new StringEnumConverter());
        }

        public async Task<TResult> GetAsync<TResult>(string uri)
        {
            HttpClient httpClient = CreateHttpClient();
            //+Settings.AccessToken
            httpClient.DefaultRequestHeaders.Add("Authorization", "Bearer eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJzdWIiOiIxMSIsImp0aSI6IjI4ZmJmYTNhLTA5NTQtNGQzYi04ZDE4LTVhZWJmODg1YmViNCIsIkVudGl0eUlkIjoiMTAwMSIsIkRpc3BsYXlOYW1lIjoiIiwiVXNlck5hbWUiOiIiLCJSb2xlSWQiOiIwIiwiRW1haWwiOiIiLCJQcm9maWxlSW1hZ2UiOiIiLCJpYXQiOjE0ODc4NTA5ODMsIm5iZiI6MTQ4Nzg1MDk4MiwiZXhwIjoxNDkxNDUwOTgyLCJpc3MiOiJDYXN0bGVJc3N1ZXIiLCJhdWQiOiJDYXN0bGVBdWRpZW5jZSJ9.mtwPKp1azxVZWoqAZ9WY35XpUTZbdnmf8Ni4_mSGB2A");
            //httpClient.DefaultRequestHeaders.TryAddWithoutValidation("Authorization", "Bearer eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJzdWIiOiIxMSIsImp0aSI6IjI4ZmJmYTNhLTA5NTQtNGQzYi04ZDE4LTVhZWJmODg1YmViNCIsIkVudGl0eUlkIjoiMTAwMSIsIkRpc3BsYXlOYW1lIjoiIiwiVXNlck5hbWUiOiIiLCJSb2xlSWQiOiIwIiwiRW1haWwiOiIiLCJQcm9maWxlSW1hZ2UiOiIiLCJpYXQiOjE0ODc4NTA5ODMsIm5iZiI6MTQ4Nzg1MDk4MiwiZXhwIjoxNDkxNDUwOTgyLCJpc3MiOiJDYXN0bGVJc3N1ZXIiLCJhdWQiOiJDYXN0bGVBdWRpZW5jZSJ9.mtwPKp1azxVZWoqAZ9WY35XpUTZbdnmf8Ni4_mSGB2A");
            HttpResponseMessage response = await httpClient.GetAsync(uri);

            await HandleResponse(response);

            string serialized = await response.Content.ReadAsStringAsync();

            //var content = httpClient.GetStringAsync(uri);

            TResult result = await Task.Run(() => JsonConvert.DeserializeObject<TResult>(serialized, _serializerSettings));

            return result;
        }

        public async Task<TResult> DeleteAsync<TResult>(string uri)
        {
            HttpClient httpClient = CreateHttpClient();
            HttpResponseMessage response = await httpClient.DeleteAsync(uri);

            await HandleResponse(response);

            string serialized = await response.Content.ReadAsStringAsync();
            TResult result = await Task.Run(() => JsonConvert.DeserializeObject<TResult>(serialized, _serializerSettings));

            return result;
        }

        //added specifically for authentication request
        public async Task<TResult> PostAsync<TResult>(string uri, FormUrlEncodedContent formContent)
        {
            HttpClient httpClient = CreateHttpClient();


            //string serialized = await Task.Run(() => JsonConvert.SerializeObject(data, _serializerSettings));
            HttpResponseMessage response = await httpClient.PostAsync(uri, formContent);

            await HandleResponse(response);

            string responseData = await response.Content.ReadAsStringAsync();

            return await Task.Run(() => JsonConvert.DeserializeObject<TResult>(responseData, _serializerSettings));
        }

        public Task<TResult> PostAsync<TResult>(string uri, TResult data)
        {
            return PostAsync<TResult, TResult>(uri, data);
        }

        public async Task<TResult> PostAsync<TRequest, TResult>(string uri, TRequest data)
        {
            HttpClient httpClient = CreateHttpClient();
            string serialized = await Task.Run(() => JsonConvert.SerializeObject(data, _serializerSettings));
            HttpResponseMessage response = null;
            //add authtoken to each request
            //httpClient.DefaultRequestHeaders.Add("Authorization", $"Bearer {Settings.AccessToken}");
            //httpClient.DefaultRequestHeaders.Add("Authorization", "Bearer eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJzdWIiOiIxMSIsImp0aSI6IjI4ZmJmYTNhLTA5NTQtNGQzYi04ZDE4LTVhZWJmODg1YmViNCIsIkVudGl0eUlkIjoiMTAwMSIsIkRpc3BsYXlOYW1lIjoiIiwiVXNlck5hbWUiOiIiLCJSb2xlSWQiOiIwIiwiRW1haWwiOiIiLCJQcm9maWxlSW1hZ2UiOiIiLCJpYXQiOjE0ODc4NTA5ODMsIm5iZiI6MTQ4Nzg1MDk4MiwiZXhwIjoxNDkxNDUwOTgyLCJpc3MiOiJDYXN0bGVJc3N1ZXIiLCJhdWQiOiJDYXN0bGVBdWRpZW5jZSJ9.mtwPKp1azxVZWoqAZ9WY35XpUTZbdnmf8Ni4_mSGB2A");
            try
            {
                httpClient.DefaultRequestHeaders.Add("Authorization", "Bearer eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJzdWIiOiIxMSIsImp0aSI6IjI4ZmJmYTNhLTA5NTQtNGQzYi04ZDE4LTVhZWJmODg1YmViNCIsIkVudGl0eUlkIjoiMTAwMSIsIkRpc3BsYXlOYW1lIjoiIiwiVXNlck5hbWUiOiIiLCJSb2xlSWQiOiIwIiwiRW1haWwiOiIiLCJQcm9maWxlSW1hZ2UiOiIiLCJpYXQiOjE0ODc4NTA5ODMsIm5iZiI6MTQ4Nzg1MDk4MiwiZXhwIjoxNDkxNDUwOTgyLCJpc3MiOiJDYXN0bGVJc3N1ZXIiLCJhdWQiOiJDYXN0bGVBdWRpZW5jZSJ9.mtwPKp1azxVZWoqAZ9WY35XpUTZbdnmf8Ni4_mSGB2A");
                response = await httpClient.PostAsync(uri, new StringContent(serialized, Encoding.UTF8, "application/json"));

            }
            catch (Exception ex)
            {
                ex.Message.ToString();
            }

            await HandleResponse(response);

            string responseData = await response.Content.ReadAsStringAsync();

            return await Task.Run(() => JsonConvert.DeserializeObject<TResult>(responseData, _serializerSettings));
        }

        public Task<TResult> PutAsync<TResult>(string uri, TResult data)
        {
            return PutAsync<TResult, TResult>(uri, data);
        }

        public async Task<TResult> PutAsync<TRequest, TResult>(string uri, TRequest data)
        {
            HttpClient httpClient = CreateHttpClient();
            string serialized = await Task.Run(() => JsonConvert.SerializeObject(data, _serializerSettings));
            HttpResponseMessage response = await httpClient.PutAsync(uri, new StringContent(serialized, Encoding.UTF8, "application/json"));

            await HandleResponse(response);

            string responseData = await response.Content.ReadAsStringAsync();

            return await Task.Run(() => JsonConvert.DeserializeObject<TResult>(responseData, _serializerSettings));
        }

        private HttpClient CreateHttpClient()
        {
            var httpClient = new HttpClient();

            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            return httpClient;
        }

        private async Task HandleResponse(HttpResponseMessage response)
        {
            if (!response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();

                if (response.StatusCode == HttpStatusCode.Forbidden || response.StatusCode == HttpStatusCode.Unauthorized)
                {
                    throw new ServiceAuthenticationException(content);
                }

                throw new HttpRequestException(content);
            }
        }
    }
}
