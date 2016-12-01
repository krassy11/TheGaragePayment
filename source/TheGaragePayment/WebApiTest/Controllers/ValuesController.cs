using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Web.Http;

namespace WebApiTest.Controllers
{
    [AllowAnonymous]
    public class ValuesController : ApiController
    {
        // GET api/values
        public Animal Get()
        {
            var newAdimal = new Animal() { Name = "Jivotnoto" };
            string name = "pesho";
            //return new string[] { "value1", "value2" };
            return newAdimal;
        }

        // GET api/values/5
        public string Get(int id)
        {
            return "value";
        }

        //// POST api/values
        //public void Post([FromBody]Animal Name)
        //{
        //}

        public string Post([FromBody]Animal Name)
        {
            //var newAdimal = new Animal() { Name = "Jivotnoto" };
            string response = "Demo";
            return response;
        }

        public IHttpActionResult Add([FromBody]Animal name)
        {
            return this.Ok();
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}
