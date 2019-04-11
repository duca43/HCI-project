using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace MyProject.Entities
{
    public class Monument : INotifyPropertyChanged
    {
        public Monument()
        {
            tags = new ObservableCollection<Tag>();
        }

        public Monument(string iD, string name, string description, string type, Image image, string climate, bool ecologicallyEndangered, bool habitat, bool populatedRegion, string touristStatus, double income, string discoveryDate, string imagePreview, bool iconTaken)
        {
            ID = iD;
            Name = name;
            Description = description;
            Type = type;
            Image = image;
            Climate = climate;
            EcologicallyEndangered = ecologicallyEndangered;
            Habitat = habitat;
            PopulatedRegion = populatedRegion;
            TouristStatus = touristStatus;
            Income = income;
            DiscoveryDate = discoveryDate;
            ImagePreview = imagePreview;
            IconTaken = iconTaken;
            tags = new ObservableCollection<Tag>();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
        private string _id;
        private string _name;
        private string _description;
        private string _type;
        private string _climate = climates[0];
        private Image _image;
        private bool _ecologicallyEndangered;
        private bool _habitat;
        private bool _populatedRegion;
        private string _touristStatus = touristStatuses[0];
        private double _income;
        private string _discoveryDate = DateTime.Now.Date.ToShortDateString(); //put the current date in date picker textbox
        private string _imagePreview;
        private bool _iconTaken;

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

        public string Type
        {
            get
            {
                return _type;
            }
            set
            {
                if (value != _type)
                {
                    _type = value;
                    OnPropertyChanged("Type");
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

        public string Climate
        {
            get
            {
                return _climate;
            }
            set
            {
                if (value != _climate)
                {
                    _climate = value;
                    OnPropertyChanged("Climate");
                }
            }
        }

        public bool EcologicallyEndangered
        {
            get
            {
                return _ecologicallyEndangered;
            }
            set
            {
                if (value != _ecologicallyEndangered)
                {
                    _ecologicallyEndangered = value;
                    OnPropertyChanged("EcologicallyEndangered");
                }
            }
        }

        public bool Habitat
        {
            get
            {
                return _habitat;
            }
            set
            {
                if (value != _habitat)
                {
                    _habitat = value;
                    OnPropertyChanged("Habitat");
                }
            }
        }
        public bool PopulatedRegion
        {
            get
            {
                return _populatedRegion;
            }
            set
            {
                if (value != _populatedRegion)
                {
                    _populatedRegion = value;
                    OnPropertyChanged("PopulatedRegion");
                }
            }
        }

        public string TouristStatus
        {
            get
            {
                return _touristStatus;
            }
            set
            {
                if (value != _touristStatus)
                {
                    _touristStatus = value;
                    OnPropertyChanged("TouristStatus");
                }
            }
        }
        public double Income
        {
            get
            {
                return _income;
            }
            set
            {
                if (value != _income)
                {
                    _income = value;
                    OnPropertyChanged("Income");
                }
            }
        }
        public string DiscoveryDate
        {
            get
            {
                return _discoveryDate;
            }
            set
            {
                if (value != _discoveryDate)
                {
                    _discoveryDate = value;
                    OnPropertyChanged("DiscoveryDate");
                }
            }
        }

        public string ImagePreview
        {
            get
            {
                return _imagePreview;
            }
            set
            {
                if (value != _imagePreview)
                {
                    _imagePreview = value;
                    OnPropertyChanged("ImagePreview");
                }
            }
        }

        public bool IconTaken
        {
            get
            {
                return _iconTaken;
            }
            set
            {
                if (value != _iconTaken)
                {
                    _iconTaken = value;
                    OnPropertyChanged("IconTaken");
                }
            }
        }

        public static readonly List<String> climates = new List<string> { "Polar", "Continental", "HumidContinental", "Desert", "Subtropical", "Tropical" };
        public static readonly List<String> touristStatuses = new List<string> {"Exploited", "Available", "Unavailable"};

        public static ObservableCollection<String> types;
        public ObservableCollection<Tag> tags;
    }
}