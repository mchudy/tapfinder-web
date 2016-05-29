using System;
using System.IO;
using System.Web;

namespace PubApp.Web.Services
{
    public class ImageSaver
    {
        public const string ImageDefaultExtension = "jpg";
        public const string FilesRelativePath = "/images";
        public const string FilesBasePath = "~/images";

        private readonly string AbsBasePath;

        public ImageSaver()
        {
            AbsBasePath = HttpContext.Current.Server.MapPath(FilesBasePath);
        }

        public string SaveFile(string source)
        {
            var bytes = Convert.FromBase64String(source);
            var id = Guid.NewGuid();
            var filename = id + "." + ImageDefaultExtension;
            var finalPath = Path.Combine(this.AbsBasePath, filename);
            var relPath = Path.Combine(FilesRelativePath, filename).Replace('\\', '/');
            File.WriteAllBytes(finalPath, bytes);
            return relPath;
        }
    }
}