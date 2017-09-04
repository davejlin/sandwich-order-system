﻿namespace SandwichOrderingSystemShared.DataAccess.Deserializer
{
    public interface IFileSystemManager
    {
        string[] GetItemNames();
        string GetContents(string fileName);
    }
}
