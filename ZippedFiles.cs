using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.IO.Compression;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ImageSourceTester
{
    public class ZippedFiles
    {
        const string HIRES_IMAGES_FOLDER_NAME = "HiresImages";
        const string HIRES_IMAGES_ZIP_FILE_NAME = "hires_images.zip";
        public static string FullFolderName { get; set; }
        public static void Extract()
        {
            var workFolder = GetWorkFolderFullName();
            FullFolderName = Path.Combine(workFolder, HIRES_IMAGES_FOLDER_NAME);
            if (Directory.Exists(FullFolderName))
            {
                Directory.Delete(FullFolderName, true);
            }
            Directory.CreateDirectory(FullFolderName);

            var zipPath = Path.Combine(workFolder, HIRES_IMAGES_ZIP_FILE_NAME);
            var assemblyName = Assembly.GetAssembly(typeof(App)).GetName().Name;
            WriteResourceToFile($"{assemblyName}.Data.{HIRES_IMAGES_ZIP_FILE_NAME}", zipPath);
            ZipFile.ExtractToDirectory(zipPath, FullFolderName);
            File.Delete(zipPath);
        }

        private static void WriteResourceToFile(string resourceName, string fileName)
        {
            using (var resource = Assembly.GetExecutingAssembly().GetManifestResourceStream(resourceName))
            {
                using (var file = new FileStream(fileName, FileMode.Create, FileAccess.Write))
                {
                    resource.CopyTo(file);
                }
            }
        }

        private static string GetWorkFolderFullName()
        {
            var workFolder = System.Environment.GetFolderPath(System.Environment.SpecialFolder.ApplicationData);
            workFolder = Path.Combine(workFolder, "WorkFolder");
            if (!Directory.Exists(workFolder))
            {
                Directory.CreateDirectory(workFolder);
            }
            return workFolder;
        }

        public static string GetFullFilename(string filename)
        {
            if (string.IsNullOrEmpty(FullFolderName))
            {
                var workFolder = GetWorkFolderFullName();
                FullFolderName = Path.Combine(workFolder, HIRES_IMAGES_FOLDER_NAME);
            }
            return Path.Combine(FullFolderName, filename);
        }

        public static void ListAllFiles()
        {
            var workFolder = GetWorkFolderFullName();
            var folderFullName = Path.Combine(workFolder, HIRES_IMAGES_FOLDER_NAME);
            foreach (var fileFullName in Directory.EnumerateFiles(folderFullName))
            {
                Debug.WriteLine(fileFullName);
            }
        }
    }
}
