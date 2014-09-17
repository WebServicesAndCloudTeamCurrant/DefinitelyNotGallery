namespace DNG.Web.Controllers
{
    using System.Collections.Generic;
    using System.Web.Http;

    // TODO: Delete me ;)
    [Authorize]
    public class ValuesController : ApiController
    {
        private readonly string[] values = { "value1", "value2", "value3", "value4", "value5", };
        // GET api/values
        public IEnumerable<string> Get()
        {
            return values;
        }

        // GET api/values/5
        public string Get(int id)
        {
            if (id >= values.Length || id < 0)
            {
                return "Not found value with id: " + id;
            }

            return values[id];
        }

        // POST api/values
        public void Post([FromBody]string value)
        {
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