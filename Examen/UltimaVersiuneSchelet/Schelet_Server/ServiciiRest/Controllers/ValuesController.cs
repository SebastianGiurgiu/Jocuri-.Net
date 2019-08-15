using ServiciiRest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ServiciiRest.Controllers
{
    public class ValuesController : ApiController
    {

        private ExamenEntities1 db = new ExamenEntities1();
        // GET api/values
        public IEnumerable<tablerest> Get()
        {
            //  return new string[] { "value1", "value2" };
            
            return db.tablerests.ToList();
        }

        // GET api/values/5
        public IEnumerable<tablerest> Get(int id)
        {
            List<tablerest> list = new List<tablerest>();
            foreach (var t in db.tablerests.ToList())
            {
                if (t.id_participant1 == id || t.id_participant2 == id)
                    list.Add(t);
            }

            return list;
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
