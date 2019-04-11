using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace MyProject.Entities
{
    public class Tag : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        public Tag() { }
        public Tag(string iD, string description, Color color, string colorCode)
        {
            ID = iD;
            Description = description;
            Color = color;
            ColorCode = colorCode;
        }

        private string _id;
        private string _description;
        private Color _color;
        private string _colorCode;

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

        public Color Color
        {
            get
            {
                return _color;
            }
            set
            {
                if (value != _color)
                {
                    _color = value;
                    OnPropertyChanged("Color");
                }
            }
        }

        public string ColorCode
        {
            get
            {
                return _colorCode;
            }
            set
            {
                if (value != _colorCode)
                {
                    _colorCode = value;
                    OnPropertyChanged("ColorCode");
                }
            }
        }
    }
}