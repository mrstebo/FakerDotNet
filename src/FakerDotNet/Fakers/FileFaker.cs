using FakerDotNet.Data;

namespace FakerDotNet.Fakers
{
    public interface IFileFaker
    {
        string Extension();
        string MimeType();
        string FileName(string dir = null, string name = null, string ext = null, string directorySeparator = "/");
    }

    internal class FileFaker : IFileFaker
    {
        private readonly IFakerContainer _fakerContainer;

        public FileFaker(IFakerContainer fakerContainer)
        {
            _fakerContainer = fakerContainer;
        }

        public string Extension()
        {
            return _fakerContainer.Random.Element(FileData.Extensions);
        }

        public string MimeType()
        {
            return _fakerContainer.Random.Element(FileData.MimeTypes);
        }

        public string FileName(string dir = null, string name = null, string ext = null, string directorySeparator = "/")
        {
            dir = string.IsNullOrEmpty(dir) ? _fakerContainer.Internet.Slug() : dir;
            name = string.IsNullOrEmpty(name) ? _fakerContainer.Lorem.Word().ToLowerInvariant() : name;
            ext = string.IsNullOrEmpty(ext) ? Extension() : ext;
            return $"{string.Join(directorySeparator, dir, name)}.{ext}";
        }
    }
}
