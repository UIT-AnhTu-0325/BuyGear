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

namespace BuyGear
{

    public class Picture
    {
        static protected string[] Scopes = { DriveService.Scope.Drive };
        static protected string ApplicationName = "Up Image BuyGear";
        static public void UpPicture(string PictureName = "")
        {
            UserCredential credential;
            credential = GetCredentials();
            var service = new DriveService(new BaseClientService.Initializer()
            {
                HttpClientInitializer = credential,
                ApplicationName = ApplicationName,
            });
            string folderid = "1cLmyNnZPvlbo6DdF77VW5OO0oGkmxBQ7";
            OpenFileDialog select = new OpenFileDialog();
            if (select.ShowDialog() == DialogResult.OK)
            {
                foreach (string filename in select.FileNames)
                {
                    Thread thread = new Thread(() =>
                    {
                        UploadImage(filename, service, folderid, PictureName);
                    });
                    thread.IsBackground = true;
                    thread.Start();
                }
            }
        }



        static public void ListPicture()
        {
            UserCredential credential;
            credential = GetCredentials();
            var service = new DriveService(new BaseClientService.Initializer()
            {
                HttpClientInitializer = credential,
                ApplicationName = ApplicationName,
            });
            string folderid = "1cLmyNnZPvlbo6DdF77VW5OO0oGkmxBQ7";
            FilesResource.ListRequest request = service.Files.List();
            request.Q = "'" + folderid + "' in parents and trashed=false";
            request.Fields = "nextPageToken, files(*)";
            IList<File> files = request.Execute().Files;
            var stream = new System.IO.MemoryStream();
            var rq = service.Files.Get(files[0].Id);
            rq.Download(stream);
            SaveStream(stream, "../../Temp_DataPicture/" + files[0].Name);
        }
        static public Image LoadImage_by_ID(string ID)
        {
            string[] allpicture = Directory.GetFiles("../../Temp_DataPicture");
            foreach(var v in allpicture)
            {
                if(v.Contains(ID))
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
            SaveStream(stream, "../../Temp_DataPicture/" + ID + ".jpg");
            Image i = Image.FromFile("../../Temp_DataPicture/" + ID + ".jpg");
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
                string credPath = "../../client_secreta.json";
                credential = GoogleWebAuthorizationBroker.AuthorizeAsync(
                    GoogleClientSecrets.Load(stream).Secrets,
                    Scopes,
                    "user",
                    CancellationToken.None,
                    new FileDataStore(credPath, true)).Result;
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
    }

}
