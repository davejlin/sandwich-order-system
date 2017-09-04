namespace SandwichOrderSystemShared.DataAccess.Deserializer
{
    public interface IFileSystemManager
    {
        string[] GetItemNames();
        string GetContents(string fileName);
    }
}
