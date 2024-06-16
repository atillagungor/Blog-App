using Core.Utilities.Helpers.GuidHelpers;
using Microsoft.AspNetCore.Http;

namespace Core.Utilities.Helpers.FileHelper;

public class FileHelperManager : IFileHelper
{
    public string Upload(IFormFile file, string root)
    {
        if (file == null || file.Length == 0)
            return null;

        if (!Directory.Exists(root))
            Directory.CreateDirectory(root);

        string extension = Path.GetExtension(file.FileName);
        string guid = GuidHelper.CreateGuid();
        string filePath = Path.Combine(root, guid + extension);

        using (FileStream fileStream = File.Create(filePath))
        {
            file.CopyTo(fileStream);
            fileStream.Flush();
        }

        return filePath;
    }

    public void Delete(string filePath)
    {
        if (File.Exists(filePath))
            File.Delete(filePath);
    }

    public string Update(IFormFile file, string filePath, string root)
    {
        if (file == null || file.Length == 0)
            return null;

        Delete(filePath);

        return Upload(file, root);
    }
}