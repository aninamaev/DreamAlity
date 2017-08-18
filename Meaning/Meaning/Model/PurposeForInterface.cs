using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Meaning.Annotations;
using Xamarin.Forms;

namespace Meaning.Model
{
    public class PurposeForInterface
    {
        public int Id { get; set; }

        public Color PageColor { get; set; } = GeneralSettings.CustomColor;

        public Color ContrastColor { get; set; } = GeneralSettings.ContrastColor;

        public string Content { get; set; }

        public string Notes { get; set; }

        public DateTime DueDateTime { get; set; }
        public string DueDate => DueDateTime.ToString("yyyy MMMM dd");

        public double ProgressValue { get; set; }
        public string ProgressLevel
        {
            get
            {
                if (ProgressValue < 0.2)
                    return "Started";
                if (ProgressValue < 0.4)
                    return "On it's way";
                if (ProgressValue < 0.6)
                    return "Half the way done";
                if (ProgressValue < 0.8)
                    return "Yet a few steps";
                if (ProgressValue < 1)
                    return "Almost there";
                return "Accomplished!";
            }
        }
    }
}
