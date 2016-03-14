using System;
using System.ComponentModel;

namespace SSD.WingLoadCalculator
{
    class WingLoadViewModel : INotifyPropertyChanged
    {
        private double _bodyWeight_kg;
        private double _bodyWeight_lb;
        private double _gearWeight_kg;
        private double _gearWeight_lb;
        private double _wingSize_sqm;
        private double _wingSize_sqft;
        private double _wingLoad_kg_sqm;
        private double _wingLoad_lb_sqft;

        public event PropertyChangedEventHandler PropertyChanged;

        public WingLoadViewModel()
        {

        }

        protected virtual void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        public double BodyWeight_kg
        {
            get { return _bodyWeight_kg; }
            set
            {
                if (_bodyWeight_kg != value)
                {
                    _bodyWeight_kg = value;
                    _bodyWeight_lb = Kg2Lb(_bodyWeight_kg);

                    OnPropertyChanged("BodyWeight_kg");
                    OnPropertyChanged("BodyWeight_lb");

                    CalculateWingLoad();
                }
            }
        }

        public double BodyWeight_lb
        {
            get { return _bodyWeight_lb; }
            set
            {
                if (_bodyWeight_lb != value)
                {
                    _bodyWeight_lb = value;
                    _bodyWeight_kg = Lb2Kg(_bodyWeight_lb);

                    OnPropertyChanged("BodyWeight_lb");
                    OnPropertyChanged("BodyWeight_kg");

                    CalculateWingLoad();
                }
            }
        }

        public double GearWeight_lb
        {
            get { return _gearWeight_lb; }
            set
            {
                if (_gearWeight_lb != value)
                {
                    _gearWeight_lb = value;
                    _gearWeight_kg = Lb2Kg(_gearWeight_lb);

                    OnPropertyChanged("GearWeight_lb");
                    OnPropertyChanged("GearWeight_kg");

                    CalculateWingLoad();
                }
            }
        }

        public double GearWeight_kg
        {
            get { return _gearWeight_kg; }
            set
            {
                if (_gearWeight_kg != value)
                {
                    _gearWeight_kg = value;
                    _gearWeight_lb = Kg2Lb(_gearWeight_kg);

                    OnPropertyChanged("GearWeight_lb");
                    OnPropertyChanged("GearWeight_kg");

                    CalculateWingLoad();
                }
            }
        }

        public double WingSize_sqm
        {
            get { return _wingSize_sqm; }
            set
            {
                if (_wingSize_sqm != value)
                {
                    _wingSize_sqm = value;
                    _wingSize_sqft = Sqm2Sqft(_wingSize_sqm);

                    OnPropertyChanged("WingSize_sqm");
                    OnPropertyChanged("WingSize_sqft");

                    CalculateWingLoad();
                }
            }
        }

        public double WingSize_sqft
        {
            get { return _wingSize_sqft; }
            set
            {
                if (_wingSize_sqft != value)
                {
                    _wingSize_sqft = value;
                    _wingSize_sqm = Sqft2Sqm(_wingSize_sqft);

                    OnPropertyChanged("WingSize_sqm");
                    OnPropertyChanged("WingSize_sqft");

                    CalculateWingLoad();
                }
            }
        }

        public double WingLoad_kg_sqm
        {
            get { return Math.Round(_wingLoad_kg_sqm, 2); }
            set
            {
                if (_wingLoad_kg_sqm != value)
                {
                    _wingLoad_kg_sqm = value;
                    if (_wingLoad_kg_sqm > 0)
                        _wingSize_sqm = (_bodyWeight_kg + _gearWeight_kg) / _wingLoad_kg_sqm;
                    _wingSize_sqft = Sqm2Sqft(_wingSize_sqm);
                    if (_wingSize_sqft > 0)
                        _wingLoad_lb_sqft = (_bodyWeight_lb + _gearWeight_lb) / _wingSize_sqft;

                    OnPropertyChanged("WingLoad_kg_sqm");
                    OnPropertyChanged("WingLoad_lb_sqft");
                    OnPropertyChanged("WingSize_sqft");
                    OnPropertyChanged("WingSize_sqm");
                }
            }
        }

        public double WingLoad_lb_sqft
        {
            get { return Math.Round(_wingLoad_lb_sqft, 2); }
            set
            {
                if (_wingLoad_lb_sqft != value)
                {
                    _wingLoad_lb_sqft = value;
                    if (_wingLoad_lb_sqft > 0)
                        _wingSize_sqft = (_bodyWeight_lb + _gearWeight_lb) / _wingLoad_lb_sqft;
                    _wingSize_sqm = Sqft2Sqm(_wingSize_sqft);
                    if (_wingSize_sqm > 0)
                        _wingLoad_kg_sqm = (_bodyWeight_kg + _gearWeight_kg) / _wingSize_sqm;

                    OnPropertyChanged("WingLoad_kg_sqm");
                    OnPropertyChanged("WingLoad_lb_sqft");
                    OnPropertyChanged("WingSize_sqft");
                    OnPropertyChanged("WingSize_sqm");
                }
            }
        }

        private void CalculateWingLoad()
        {
            if (_wingSize_sqft > 0 && _wingSize_sqm > 0)
            {
                _wingLoad_kg_sqm = (_bodyWeight_kg + _gearWeight_kg) / _wingSize_sqm;
                _wingLoad_lb_sqft = (_bodyWeight_lb + _gearWeight_lb) / _wingSize_sqft;

                OnPropertyChanged("WingLoad_kg_sqm");
                OnPropertyChanged("WingLoad_lb_sqft");
            }
        }

        private double Kg2Lb(double value)
        {
            return value * 2.2;
        }

        private double Lb2Kg(double value)
        {
            return value * 0.45;
        }

        private double Sqm2Sqft(double value)
        {
            return value * 10.76;
        }

        private double Sqft2Sqm(double value)
        {
            return value * 0.09;
        }
    }
}
