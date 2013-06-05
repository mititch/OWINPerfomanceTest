using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.WindowsAzure.Storage.Table;

namespace Core
{
    public class Entity : TableEntity
    {
        public Entity(string partitionKey, string rowKey)
        {
            this.PartitionKey = partitionKey;
            this.RowKey = rowKey;
        }

        public Entity()
        {
        }

        public string Data { get; set; }

    }
}
