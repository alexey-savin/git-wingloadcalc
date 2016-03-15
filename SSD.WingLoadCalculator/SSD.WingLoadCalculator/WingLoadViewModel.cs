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
        private double _wingLoad_psf;

        public event PropertyChangedEventHandler PropertyChanged;

        public WingLoadViewModel()
        {

        }

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
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

                    OnPropertyChanged(nameof(BodyWeight_kg));
                    OnPropertyChanged(nameof(BodyWeight_lb));

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

                    OnPropertyChanged(nameof(BodyWeight_kg));
                    OnPropertyChanged(nameof(BodyWeight_lb));

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

                    OnPropertyChanged(nameof(GearWeight_kg));
                    OnPropertyChanged(nameof(GearWeight_lb));

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

                    OnPropertyChanged(nameof(GearWeight_kg));
                    OnPropertyChanged(nameof(GearWeight_lb));

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

                    OnPropertyChanged(nameof(WingSize_sqm));
                    OnPropertyChanged(nameof(WingSize_sqft));

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

                    OnPropertyChanged(nameof(WingSize_sqm));
                    OnPropertyChanged(nameof(WingSize_sqft));

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
                        _wingLoad_psf = (_bodyWeight_lb + _gearWeight_lb) / _wingSize_sqft;

                    OnPropertyChanged(nameof(WingLoad_kg_sqm));
                    OnPropertyChanged(nameof(WingLoad_psf));
                    OnPropertyChanged(nameof(WingSize_sqft));
                    OnPropertyChanged(nameof(WingSize_sqm));
                }
            }
        }

        public double WingLoad_psf
        {
            get { return Math.Round(_wingLoad_psf, 2); }
            set
            {
                if (_wingLoad_psf != value)
                {
                    _wingLoad_psf = value;
                    if (_wingLoad_psf > 0)
                        _wingSize_sqft = (_bodyWeight_lb + _gearWeight_lb) / _wingLoad_psf;
                    _wingSize_sqm = Sqft2Sqm(_wingSize_sqft);
                    if (_wingSize_sqm > 0)
                        _wingLoad_kg_sqm = (_bodyWeight_kg + _gearWeight_kg) / _wingSize_sqm;

                    OnPropertyChanged(nameof(WingLoad_kg_sqm));
                    OnPropertyChanged(nameof(WingLoad_psf));
                    OnPropertyChanged(nameof(WingSize_sqft));
                    OnPropertyChanged(nameof(WingSize_sqm));
                }
            }
        }

        private void CalculateWingLoad()
        {
            if (_wingSize_sqft > 0 && _wingSize_sqm > 0)
            {
                _wingLoad_kg_sqm = (_bodyWeight_kg + _gearWeight_kg) / _wingSize_sqm;
                _wingLoad_psf = (_bodyWeight_lb + _gearWeight_lb) / _wingSize_sqft;

                OnPropertyChanged(nameof(WingLoad_kg_sqm));
                OnPropertyChanged(nameof(WingLoad_psf));
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
