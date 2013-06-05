using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.WindowsAzure;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Table;

namespace DAL
{
    internal class StorageManager
    {
        private static readonly Lazy<StorageManager> _instance = new Lazy<StorageManager>(() => new StorageManager());

        public object Locker = new object();

        public static StorageManager Instance
        {
            get
            {
                return _instance.Value;
            }
        }

        private CloudStorageAccount storageAccount;
        private string tableAddress;

        public CloudTable GetCloudTable()
        {
            var table = storageAccount.CreateCloudTableClient().GetTableReference(tableAddress);
            table.CreateIfNotExists();
            return table;
        }

        private StorageManager()
        {
            //tableAddress = CloudConfigurationManager.GetSetting("ClientTableName");
            //var connectionString = CloudConfigurationManager.GetSetting("StorageConnectionString");
            tableAddress = "ClientTable";
            var connectionString = @"DefaultEndpointsProtocol=https;AccountName=iishosting;AccountKey=50pNAL68Mf8+v6qRpvkSGE7afARTXRacc8VhRKrnAzXafl7OKWiHPqDvRrIMBN9eJEOFo0o2wLytjMxBQQfWMw==";
            storageAccount = Microsoft.WindowsAzure.Storage.CloudStorageAccount.Parse(connectionString);
        }
    }
}
