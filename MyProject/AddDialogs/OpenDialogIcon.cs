using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyProject.AddDialogs
{
    public class OpenDialogIcon
    {
        public static string OpenDialog()
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "PNG Images (*.png)|*.png|JPG Images (*.jpg)|*.jpg|JPEG Images (*.JPEG)|*.jpeg";
            if (openFileDialog.ShowDialog() == true && 
                (openFileDialog.FileName.ToLower().EndsWith(".png") ||
                 openFileDialog.FileName.ToLower().EndsWith(".jpg") ||
                 openFileDialog.FileName.ToLower().EndsWith(".jpeg")))
            {
                return openFileDialog.FileName;
            }
            else
            {
                return null;
            }
        }
    }
}