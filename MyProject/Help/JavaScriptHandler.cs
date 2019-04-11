using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security.Permissions;
using System.Runtime.InteropServices;
using System.Windows;

namespace MyProject.Help
{

    [PermissionSet(SecurityAction.Demand, Name = "FullTrust")]
    [ComVisible(true)]
    public class JavaScriptHandler
    {
        public void CheckIsTutorialFollowedJS()
        {
            MainWindow mainWindow = (MainWindow)Application.Current.MainWindow;
            mainWindow.CheckIsTutorialFollowed();
        }
    }
}
