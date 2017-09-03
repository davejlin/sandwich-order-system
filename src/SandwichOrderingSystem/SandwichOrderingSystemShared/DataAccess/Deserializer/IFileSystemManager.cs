﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SandwichOrderingSystemShared.DataAccess.Deserializer
{
    public interface IFileSystemManager
    {
        string[] GetItemNames();
        string GetContents(string fileName);
    }
}