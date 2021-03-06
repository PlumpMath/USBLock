﻿using System;
using System.IO;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary;

namespace USB.Config
{
    [Serializable]
    public class Settings
    {
        public bool IsStartUp { get; set; }
        public bool IsShowSlideShow { get; set; }
        public double FormOpacity { get; set; }
        public List<USBDeviceInfo> AcceptedSerials { get; set; }

        public static Settings LoadFrom(string path)
        {
            using (FileStream fs = new FileStream(path, FileMode.Open))
            {
                BinaryFormatter bf = new BinaryFormatter();
                return (Settings)bf.Deserialize(fs);
            }
        }

        public void Save(string path)
        {
            using (FileStream fs = new FileStream(path, FileMode.Create))
            {
                BinaryFormatter bf = new BinaryFormatter();
                bf.Serialize(fs, this);
            }
        }

        public static Settings Default = new Settings()
        {
            IsStartUp = false,
            IsShowSlideShow = true,
            FormOpacity = 0.9,
            AcceptedSerials = new List<USBDeviceInfo>()
        };
    }
}
