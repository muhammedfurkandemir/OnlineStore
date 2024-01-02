namespace OnlineStore.Utilities.Helpers.FileHelper
{
    public interface IFileHelper
    {
        string Upload(IFormFile file, string root);

        string Update(IFormFile file, string root, string filePath);

        void Delete(string filePath);
    }
}
