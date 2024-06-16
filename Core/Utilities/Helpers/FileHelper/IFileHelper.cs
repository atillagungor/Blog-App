using Microsoft.AspNetCore.Http;

namespace Core.Utilities.Helpers.FileHelper;

/// <summary>
/// Defines methods for file operations such as upload, delete, and update.
/// </summary>
public interface IFileHelper
{
    /// <summary>
    /// Uploads a file to the specified root directory.
    /// </summary>
    /// <param name="file">The file to upload.</param>
    /// <param name="root">The root directory to upload the file to.</param>
    /// <returns>The relative path of the uploaded file.</returns>
    string Upload(IFormFile file, string root);

    /// <summary>
    /// Deletes the file located at the specified file path.
    /// </summary>
    /// <param name="filePath">The file path to delete.</param>
    void Delete(string filePath);

    /// <summary>
    /// Updates the existing file with the new file at the specified root directory.
    /// </summary>
    /// <param name="file">The new file to upload.</param>
    /// <param name="filePath">The file path of the file to update.</param>
    /// <param name="root">The root directory to upload the new file to.</param>
    /// <returns>The relative path of the updated file.</returns>
    string Update(IFormFile file, string filePath, string root);
}