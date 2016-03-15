using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSD.WingLoadCalculator
{
    class WingLoadModel
    {
        public double BodyWeight_kg { get; set; }
        public double BodyWeight_lb { get; set; }
        public double GearWeight_kg { get; set; }
        public double GearWeight_lb { get; set; }
        public double WingSize_sqm { get; set; }
        public double WingSize_sqft { get; set; }
        public double WingLoad_kg_sqm { get; set; }
        public double WingLoad_psf { get; set; }
    }
}
