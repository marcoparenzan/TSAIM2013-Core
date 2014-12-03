using ITS.MiniCMS.Models;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Auth;
using Microsoft.WindowsAzure.Storage.Queue;
using Microsoft.WindowsAzure.Storage.Table;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ITS.MiniCMS.Controllers
{
    public class CMSController : Controller
    {
        // GET: CMS
        public ActionResult Index()
        {
            var storageCredentials = new StorageCredentials(
              ConfigurationManager.AppSettings["storageName"]
              , ConfigurationManager.AppSettings["storageKey"]
            );
            var storageAccount = new CloudStorageAccount(storageCredentials, true);

            var tableClient = storageAccount.CreateCloudTableClient();
            var imagesTable = tableClient.GetTableReference("marcoparenzanimages");
            imagesTable.CreateIfNotExists();

            var query = new TableQuery<ImageTableEntity>();
            var result = imagesTable.ExecuteQuery<ImageTableEntity>(query).ToList();
            
            return View(result);
        }

        public ActionResult UploadImage()
        {
            return View();
        }

        [HttpPost]
        public ActionResult UploadImage(UploadImageViewModel viewModel)
        {
            var storageCredentials = new StorageCredentials(
                ConfigurationManager.AppSettings["storageName"]
                , ConfigurationManager.AppSettings["storageKey"]
            );
            var storageAccount = new CloudStorageAccount(storageCredentials, true);

            var blobClient = storageAccount.CreateCloudBlobClient();
            var blobContainer = blobClient.GetContainerReference("marcoparenzanuploadimage");
            blobContainer.CreateIfNotExists();

            var file = Request.Files[0];
            var blob = blobContainer.GetBlockBlobReference(viewModel.Name);
            blob.UploadFromStream(file.InputStream);

            var queueClient = storageAccount.CreateCloudQueueClient();
            var uploadImageQueue = queueClient.GetQueueReference("marcoparenzanuploadimages");
            uploadImageQueue.CreateIfNotExists();
            uploadImageQueue.AddMessage(new CloudQueueMessage(JsonConvert.SerializeObject(viewModel))
            {
            });

            return RedirectToAction("Index");
        }
    }
}