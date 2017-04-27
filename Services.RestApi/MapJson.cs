using System.Collections.Generic;
using Domain.Entities;
using Newtonsoft.Json;

namespace Services.RestApi
{
    public class MapJson<T> where T:Entity
    {
        public string MapJsonSerialize(T entity)
        {
            return MapJsonSerializeCommon(entity);
        }

        public string MapJsonSerialize(List<T> entities)
        {
            return MapJsonSerializeCommon(entities);
        }

        private static string MapJsonSerializeCommon(object entity)
        {
            return JsonConvert.SerializeObject(entity, Formatting.Indented,
                        new JsonSerializerSettings()
                        {
                            ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                        });
        }
    }
}
