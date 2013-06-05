using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.WindowsAzure.Storage.Table;

namespace DAL
{
    public class StorageRepository<T> where T : TableEntity, new()
    {
        public IEnumerable<T> GetAll(string partitionKey)
        {
            var table = StorageManager.Instance.GetCloudTable();

            TableQuery<T> query = new TableQuery<T>()
                .Where(TableQuery.GenerateFilterCondition("PartitionKey", QueryComparisons.Equal, partitionKey));

            return table.ExecuteQuery(query);
        }
        
        public T Get(string partitionKey, string rowKey)
        {
            var table = StorageManager.Instance.GetCloudTable();
            TableOperation retrieveOperation = TableOperation.Retrieve<T>(partitionKey, rowKey);
            TableResult retrievedResult = table.Execute(retrieveOperation);
            var result = retrievedResult.Result;
            return result != null ? (T)result : null;
        }

        public void Add(T entity)
        {
            var table = StorageManager.Instance.GetCloudTable();
            TableOperation insertOperation = TableOperation.Insert(entity);
            table.Execute(insertOperation);
        }
    }
}
