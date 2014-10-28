using ITS.IoC.Domain.Contracts;
using ITS.IoC.Domain.Entities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITS.IoC.FileSystem
{
    public class MyEntityFileSystemRepository:
        IMyEntityRepository
    {
        private DirectoryInfo _di;

        public MyEntityFileSystemRepository(DirectoryInfo di)
        {
            _di = di;
        }

        Domain.Entities.MyEntity IRepository<MyEntity>.GetById(string id)
        {
            var fi = _di.EnumerateFiles()
               .SingleOrDefault(xx => xx.Name == (id + ".json"));
            if (fi != null)
            {
                var streamReader = fi.OpenText();
                var json = streamReader.ReadToEnd();
                streamReader.Close();

                var entity =
                    JsonConvert.DeserializeObject<MyEntity>(json);
                return entity;
            }
            else
            {
                throw new ArgumentOutOfRangeException("Id not found");
            }
        }
    }
}
