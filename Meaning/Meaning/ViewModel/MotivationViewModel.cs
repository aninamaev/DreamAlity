using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Meaning.ViewModel
{
    public class MotivationViewModel
    {
        public Color PageColor { get; set; } = GeneralSettings.CustomColor;
        public Color ContrastColor { get; set; } = GeneralSettings.ContrastColor;
        public Thickness PagePadding { get; set; } = GeneralSettings.CustomPagePadding;

        public string ImageSource { get; set; }
        public string ImageText { get; set; }

        public string WhyMotivationText { get; set; }
    }
}
