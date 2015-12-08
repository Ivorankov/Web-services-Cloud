using System.Drawing;
using System.IO;
using System.Net.Mime;
using System.Threading.Tasks;
using Dropbox.Api;
using Dropbox.Api.Files;

namespace DropBoxImageService
{
    internal class Program
    {

        private const string FileLocation = "../../image.png";

        static void Main()
        {
            Image img = Image.FromFile(FileLocation);
            byte[] arr;
            using (MemoryStream ms = new MemoryStream())
            {
                img.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                arr = ms.ToArray();
            }

           UploadImageForUser("User", arr, "png");
        }

        private static async Task UploadImageForUser(string username, byte[] image, string extension)
        {

            DropboxClient dropboxClient = new DropboxClient("-hdwkYPSNoAAAAAAAAAABlXkLt1kdzpof3B8j3n090qRW6wW8cKJdR-_hYDdSFN8");
            using (MemoryStream memStream = new MemoryStream(image))
            {
                await dropboxClient.Files.UploadAsync(
                    string.Format(FileLocation, username, extension),
                    WriteMode.Overwrite.Instance,
                    body: memStream);
            }
        }
    }
}
