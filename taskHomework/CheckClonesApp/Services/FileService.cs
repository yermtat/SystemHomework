using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckClonesApp.Services;

class FileService
{
    public string GetFolderPath()
    {
        Microsoft.Win32.OpenFolderDialog dialog = new();

        dialog.Multiselect = false;
        dialog.Title = "Select a folder";

        // Show open folder dialog box
        bool? result = dialog.ShowDialog();

        // Process open folder dialog box results
        if (result == true)
        {
            // Get the selected folder
            return dialog.FolderName;
        }

        return null;
    }

    public List<string> CheckClones(string sourcePath)
    {
        var sourceFiles = Directory.GetFiles(sourcePath);

        byte[] mainFile, checkFile;
        FileInfo mainInfo, checkInfo;
        bool isOriginal;
        List<string> fileToMove = new();

        for (int i = 0; i < sourceFiles.Length; i++)
        {
            isOriginal = true;
            mainInfo = new FileInfo(sourceFiles[i]);
            mainFile = File.ReadAllBytes(mainInfo.FullName);

            for (int j = 0; j < sourceFiles.Length; j++)
            {
                checkInfo = new FileInfo(sourceFiles[j]);
                checkFile = File.ReadAllBytes(checkInfo.FullName);

                if (mainInfo.Length == checkFile.Length && mainInfo.Name != checkInfo.Name) 
                {
                    if (Enumerable.SequenceEqual(mainFile, checkFile))
                    {
                        isOriginal = false;
                        break;
                    }
                }

            }

            if (isOriginal)
            {
                //File.Move(mainInfo.FullName, directionPath + "\\" + mainInfo.Name);
                fileToMove.Add(mainInfo.FullName);
            }


        }

        return fileToMove;
    }

    public string MoveFiles(List<string> files, string direction)
    {
        for (int i = 0; i < files.Count; i++)
        {
            File.Move(files[i], direction + '\\' + files[i][(files[i].LastIndexOf('\\') +1 )..]);
        }

        return "Finished";
    }
}
