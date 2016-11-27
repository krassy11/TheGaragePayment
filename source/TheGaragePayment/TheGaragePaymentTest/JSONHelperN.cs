using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheGaragePaymentTest
{
    public class JSONHelperN<T>
    {
        public string getJSONObject(T data)
        {
            var jsonObj = Newtonsoft.Json.JsonConvert.SerializeObject(data);
            return jsonObj;
        }

        public T fromJson(string jsonInput)
        {
            var obj = Newtonsoft.Json.JsonConvert.DeserializeObject<T>(jsonInput);
            return obj;
        }
    }
}
