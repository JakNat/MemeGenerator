using Server.Infrastructure.Extensions;
using System;
using System.Collections.Generic;
using System.Text;

namespace Server.Infrastructure.Settings
{
    public class ImageStorageSettings
    {
        private string _storagePath;
        public string StoragePath
        {
            get
            {
                if (DefaultPath || _storagePath.IsEmpty())
                    return $"{Environment.CurrentDirectory}\\DefaultStorage";
                else
                    return _storagePath;
            }
            set { _storagePath = value; }
        }

        public bool DefaultPath { get; set; }


    }
}
