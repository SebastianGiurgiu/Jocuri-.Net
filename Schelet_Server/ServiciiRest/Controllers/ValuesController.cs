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

        private JumpingEntities2 db = new JumpingEntities2();

        // GET api/values
        public IEnumerable<Participant> Get()
        {

            return db.Participants.ToList();
           // return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        public IEnumerable<Participant> Get(string id)
        {
            List<Participant> participants = new List<Participant>();
            string status = Convert.ToString(id);

            foreach(var part in db.Participants.ToList())
            {
                if (part.status.Equals(id))
                {
                    participants.Add(part);
                }

            }

            return participants;


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
