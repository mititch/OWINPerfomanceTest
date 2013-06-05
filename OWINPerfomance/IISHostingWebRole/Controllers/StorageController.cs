using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using Core;
using DAL;

namespace IISHostingWebRole.Controllers
{
    //ApiContriller implementation with CRUD
    public class StorageController : ApiController
    {
        private const string PARTITION_NAME = "defaultPartition";

        // GET api/<controller>
        public IEnumerable<Entity> Get()
        {
            return new StorageRepository<Entity>().GetAll(PARTITION_NAME);
        }

        //GET api/<controller>/5
        public Entity Get(int id)
        {
            return new StorageRepository<Entity>().Get(PARTITION_NAME, id.ToString());

        }

        // POST api/<controller>
        public void Post([FromBody] Entity value)
        {
            if (string.IsNullOrEmpty(value.PartitionKey))
            {
                value.PartitionKey = PARTITION_NAME;
            }
            new StorageRepository<Entity>().Add(value);
        }
    }
}
