using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyProject.Entities
{
    public class MonumentType : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        public MonumentType() { }

        public MonumentType(string iD, string name, string description, Image image, string iconPath)
        {
            ID = iD;
            Name = name;
            Description = description;
            Image = image;
            IconPath = iconPath;
        }

        private string _id;
        private string _name;
        private string _description;
        private Image _image;
        private string _iconPath;

        public string ID
        {
            get
            {
                return _id;
            }
            set
            {
                if (value != _id)
                {
                    _id = value;
                    OnPropertyChanged("ID");
                }
            }
        }
        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                if (value != _name)
                {
                    _name = value;
                    OnPropertyChanged("Name");
                }
            }
        }

        public string Description
        {
            get
            {
                return _description;
            }
            set
            {
                if (value != _description)
                {
                    _description = value;
                    OnPropertyChanged("Description");
                }
            }
        }

        public Image Image
        {
            get
            {
                return _image;
            }
            set
            {
                if (value != _image)
                {
                    _image = value;
                    OnPropertyChanged("Image");
                }
            }
        }

        public string IconPath
        {
            get
            {
                return _iconPath;
            }
            set
            {
                if (value != _iconPath)
                {
                    _iconPath = value;
                    OnPropertyChanged("IconPath");
                }
            }
        }
    }
}
