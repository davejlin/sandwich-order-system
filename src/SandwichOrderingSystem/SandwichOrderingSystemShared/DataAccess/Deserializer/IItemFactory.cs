﻿using SandwichOrderingSystemShared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SandwichOrderingSystemShared.DataAccess.Deserializer
{
    public interface IItemFactory
    {
        T CreateItem<T>(string[] properties) where T : class;
    }
}