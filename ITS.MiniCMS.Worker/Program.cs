using ITS.MiniCMS.Models;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Auth;
using Microsoft.WindowsAzure.Storage.Blob;
using Microsoft.WindowsAzure.Storage.Table;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITS.MiniCMS.Worker
{
    class Program
    {
        static void Main(string[] args)
        {
            var storageCredentials = new StorageCredentials(
                   ConfigurationManager.AppSettings["storageName"]
                   , ConfigurationManager.AppSettings["storageKey"]
               );
            var storageAccount = new CloudStorageAccount(storageCredentials, true);

            var blobClient = storageAccount.CreateCloudBlobClient();
            var imagesContainer = blobClient.GetContainerReference("marcoparenzanuploadimage");
            imagesContainer.CreateIfNotExists();

            var thumbnamilsContainer = blobClient.GetContainerReference("marcoparenzanthumbnails");
            thumbnamilsContainer.CreateIfNotExists();
            thumbnamilsContainer.SetPermissions(new BlobContainerPermissions
            {
                PublicAccess = BlobContainerPublicAccessType.Blob
            });

            var queueClient = storageAccount.CreateCloudQueueClient();
            var uploadImageQueue = queueClient.GetQueueReference("marcoparenzanuploadimages");
            uploadImageQueue.CreateIfNotExists();

            var tableClient = storageAccount.CreateCloudTableClient();
            var imagesTable = tableClient.GetTableReference("marcoparenzanimages");
            imagesTable.CreateIfNotExists();

            while (true)
            {
                var message = uploadImageQueue.GetMessage();
                if (message == null) break;

                var viewModel = JsonConvert.DeserializeObject<UploadImageViewModel>(message.AsString);

                var blob = imagesContainer.GetBlockBlobReference(viewModel.Name);
                var ms = new MemoryStream();
                blob.DownloadToStream(ms);

                var imageTableEntity = new ImageTableEntity
                {
                    PartitionKey = "default"
                    ,
                    RowKey = Guid.NewGuid().ToString()
                    ,
                    Name = viewModel.Name
                    ,
                    Description = viewModel.Description
                    ,
                    Created = DateTime.Now
                    ,
                    Size = (int) ms.Length
                };
                // process message
                var insertImageOperation = TableOperation.Insert(imageTableEntity);
                imagesTable.Execute(insertImageOperation);

                ms.Seek(0, SeekOrigin.Begin);
                var image = Image.FromStream(ms);
                var targetX = 64;
                var targetY = (int) (image.Height * targetX / image.Width);

                var thumbnail = new Bitmap(targetX, targetY);
                using (Graphics graphicsHandle = Graphics.FromImage(thumbnail))
                {
                    graphicsHandle.InterpolationMode = InterpolationMode.HighQualityBicubic;
                    graphicsHandle.DrawImage(image, 0, 0, targetX, targetY);
                }
                var thumbnailMS = new MemoryStream();
                thumbnail.Save(thumbnailMS, ImageFormat.Png);

                thumbnailMS.Seek(0, SeekOrigin.Begin);
                var thumbNailBlob = thumbnamilsContainer.GetBlockBlobReference(imageTableEntity.RowKey);
                thumbNailBlob.UploadFromStream(thumbnailMS);

                uploadImageQueue.DeleteMessage(message);
            }
        }
    }
}
