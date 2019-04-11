using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MyProject.Commands
{
    public class RoutedCommands
    {
        public static InputGestureCollection igcMonumentType = new InputGestureCollection() { new KeyGesture(Key.M, ModifierKeys.Control | ModifierKeys.Shift) };
        public static InputGestureCollection igcMonument = new InputGestureCollection() { new KeyGesture(Key.M, ModifierKeys.Control) };
        public static InputGestureCollection igcTag = new InputGestureCollection() { new KeyGesture(Key.T, ModifierKeys.Control) };
        public static InputGestureCollection igcExit = new InputGestureCollection() { new KeyGesture(Key.F4, ModifierKeys.Alt) };
        public static InputGestureCollection igcShowMonuments = new InputGestureCollection() { new KeyGesture(Key.D2, ModifierKeys.Control)};
        public static InputGestureCollection igcShowMonumentTypes = new InputGestureCollection() { new KeyGesture(Key.D1, ModifierKeys.Control) };
        public static InputGestureCollection igcShowTags = new InputGestureCollection() { new KeyGesture(Key.D3, ModifierKeys.Control) };
        public static InputGestureCollection igcRemoveAllMonumentsFromMap = new InputGestureCollection() { new KeyGesture(Key.R, ModifierKeys.Control) };
        public static InputGestureCollection igcTutorial = new InputGestureCollection() { new KeyGesture(Key.F2) };
        public static InputGestureCollection igcEsc = new InputGestureCollection() { new KeyGesture(Key.Escape) };
        public static InputGestureCollection igcEdit = new InputGestureCollection() { new KeyGesture(Key.E, ModifierKeys.Control) };
        public static InputGestureCollection igcDelete = new InputGestureCollection() { new KeyGesture(Key.Delete) };

        public static readonly RoutedUICommand MonumentType = new RoutedUICommand("Monument Type", "MonumentType", typeof(RoutedCommands), igcMonumentType);
        public static readonly RoutedUICommand Monument = new RoutedUICommand("Monument", "MonumentType", typeof(RoutedCommands), igcMonument);
        public static readonly RoutedUICommand Tag = new RoutedUICommand("Tag", "Tag", typeof(RoutedCommands), igcTag);
        public static readonly RoutedUICommand Exit = new RoutedUICommand("Exit", "Exit", typeof(RoutedCommands), igcExit);
        public static readonly RoutedUICommand ShowMonuments = new RoutedUICommand("Show Monuments", "ShowMonuments", typeof(RoutedCommands), igcShowMonuments);
        public static readonly RoutedUICommand ShowMonumentTypes = new RoutedUICommand("Show Monument Types", "ShowMonumentTypes", typeof(RoutedCommands), igcShowMonumentTypes);
        public static readonly RoutedUICommand ShowTags = new RoutedUICommand("Show Tags", "ShowTags", typeof(RoutedCommands), igcShowTags);
        public static readonly RoutedUICommand Tutorial = new RoutedUICommand("Tutorial", "Tutorial", typeof(RoutedCommands), igcTutorial);
        public static readonly RoutedUICommand RemoveAllMonumentsFromMap = new RoutedUICommand("Remove All Monuments From Map", "RemoveAllMonumentsFromMap", typeof(RoutedCommands), igcRemoveAllMonumentsFromMap);
        public static readonly RoutedUICommand EditMonument = new RoutedUICommand("Edit Monument", "EditMonument", typeof(RoutedCommands), igcEdit);
        public static readonly RoutedUICommand DeleteMonument = new RoutedUICommand("Delete Monument", "DeleteMonument", typeof(RoutedCommands), igcDelete);
        public static readonly RoutedUICommand Add = new RoutedUICommand("Add", "Add", typeof(RoutedCommands));
        public static readonly RoutedUICommand Cancel = new RoutedUICommand("Cancel", "Cancel", typeof(RoutedCommands), igcEsc);
    }
}
