using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Web.Http.Results;
using Domain.Entities;
using Newtonsoft.Json;

namespace Services.RestApi
{
    public class MapJson<T> where T : Entity
    {
        private readonly Encoding _encoding;
        private readonly JsonSerializerSettings _jsonSerializerSettings;
        private readonly HttpRequestMessage _httpRequestMessage;

        public MapJson()
        {
            _encoding = Encoding.UTF8;
            _jsonSerializerSettings = new JsonSerializerSettings
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            };
            _httpRequestMessage = new HttpRequestMessage();
        }

        public JsonResult<T> MapJsonSerialize(T entity)
        {
            return new JsonResult<T>(entity, _jsonSerializerSettings, _encoding, _httpRequestMessage);
        }

        public JsonResult<List<T>> MapJsonSerializeList(List<T> entity)
        {
            return new JsonResult<List<T>>(entity, _jsonSerializerSettings, _encoding, _httpRequestMessage);
        }
    }
}