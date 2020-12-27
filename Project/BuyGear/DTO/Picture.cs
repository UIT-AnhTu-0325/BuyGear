using Google.Apis.Auth.OAuth2;
using Google.Apis.Drive.v3;
using Google.Apis.Services;
using Google.Apis.Util.Store;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Net;
using System.Threading;
using System.Windows.Forms;
using File = Google.Apis.Drive.v3.Data.File;
using System.Configuration;

namespace BuyGear
{

    public class Picture
    {
        static protected string[] Scopes = { DriveService.Scope.Drive };
        static protected string ApplicationName = "Up Image BuyGear";
        static public void UpPicture(string path, string PictureName = "")
        {
            UserCredential credential;
            credential = GetCredentials();
            var service = new DriveService(new BaseClientService.Initializer()
            {
                HttpClientInitializer = credential,
                ApplicationName = ApplicationName,
            });
            string folderid = ConfigurationManager.AppSettings["ID_Driver"].ToString();
            UploadImage(path, service, folderid, PictureName);
        }

        static public string GetIDPicturebyName(string pictureName)
        {
            UserCredential credential;
            credential = GetCredentials();
            var service = new DriveService(new BaseClientService.Initializer()
            {
                HttpClientInitializer = credential,
                ApplicationName = ApplicationName,
            });
            string folderid = ConfigurationManager.AppSettings["ID_Driver"].ToString();
            FilesResource.ListRequest request = service.Files.List();
            request.Q = "'" + folderid + "' in parents and trashed=false";
            request.Fields = "nextPageToken, files(*)";
            IList<File> files = request.Execute().Files;
            foreach (var v in files)
            {
                if (v.Name.Contains(pictureName))
                {
                    return v.Id;
                }
            }
            return null;
        }
        static public void DeletePicture_by_ID(string ID)
        {
            UserCredential credential;
            credential = GetCredentials();
            var service = new DriveService(new BaseClientService.Initializer()
            {
                HttpClientInitializer = credential,
                ApplicationName = ApplicationName,
            });
            string folderid = ID;
            try
            {
                service.Files.Delete(folderid).Execute();
            }
            catch
            {

            }
        }
        static public Image LoadImage_by_ID(string ID)
        {
            string[] allpicture = Directory.GetFiles("../../BuyGear.exe".Replace("BuyGear.exe", "Temp_DataPicture"));
            foreach (var v in allpicture)
            {
                if (v.Contains(ID))
                {
                    Image im = Image.FromFile(v);
                    return im;
                }
            }
            UserCredential credential;
            credential = GetCredentials();
            var service = new DriveService(new BaseClientService.Initializer()
            {
                HttpClientInitializer = credential,
                ApplicationName = ApplicationName,
            });
            var stream = new MemoryStream();
            var rq = service.Files.Get(ID);
            rq.Download(stream);
            SaveStream(stream, "../../BuyGear.exe/".Replace("BuyGear.exe", "Temp_DataPicture") + ID + ".jpg");
            Image i = Image.FromFile("../../BuyGear.exe/".Replace("BuyGear.exe", "Temp_DataPicture") + ID + ".jpg");
            return i;

        }
        static void SaveStream(System.IO.MemoryStream stream, string saveTo)
        {
            using (System.IO.FileStream file = new System.IO.FileStream(saveTo, System.IO.FileMode.Create, System.IO.FileAccess.Write))
            {
                stream.WriteTo(file);
            }
        }
        static private UserCredential GetCredentials()
        {
            UserCredential credential;
            using (var stream = new FileStream("conect_API.json", FileMode.Open, FileAccess.Read))
            {
                string credPath = "../../BuyGear.exe".Replace("BuyGear.exe", "client_secreta.json");
                credential = GoogleWebAuthorizationBroker.AuthorizeAsync(
                    GoogleClientSecrets.Load(stream).Secrets,
                    Scopes,
                    "user",
                    CancellationToken.None,
                    new FileDataStore("../../BuyGear.exe".Replace("BuyGear.exe", "client_secreta.json"), true)).Result;
            }
            return credential;
        }
        static private void UploadImage(string path, DriveService service, string folderUpload, string PictureName)
        {
            var fileMetadata = new Google.Apis.Drive.v3.Data.File();
            if (PictureName == "")
            {
                fileMetadata.Name = Path.GetFileName(path);
            }
            else
            {
                fileMetadata.Name = PictureName + Path.GetExtension(path);
            }
            fileMetadata.MimeType = "image/*";

            fileMetadata.Parents = new List<string>
            {
                folderUpload
            };
            FilesResource.CreateMediaUpload request;
            using (var stream = new FileStream(path, FileMode.Open))
            {
                request = service.Files.Create(fileMetadata, stream, "image/*");
                request.Fields = "id";
                request.Upload();
            }
        }
        static public string getLinkFromDialog()
        {
            OpenFileDialog open = new OpenFileDialog();
            open.Filter = "Image Files(*.jpg; *.png; *.jpeg; *.gif; *.bmp)|*.jpg; *.png;*.jpeg; *.gif; *.bmp";
            if (open.ShowDialog() == DialogResult.OK)
            {
                return open.FileName;
            }
            else
            {
                return "";
            }
        }
        static public Image FromFile(string path)
        {
            if (path == "")
            {
                return null;
            }
            else
            {
                var bytes = System.IO.File.ReadAllBytes(path);
                var ms = new MemoryStream(bytes);
                var img = Image.FromStream(ms);
                return img;
            }
        }
    }

}
