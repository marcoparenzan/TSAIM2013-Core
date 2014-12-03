using Microsoft.WindowsAzure.Storage.Table;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITS.MiniCMS.Models
{
    public class ImageTableEntity: TableEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int Size { get; set; }
        public DateTime Created { get; set; }
    }
}
