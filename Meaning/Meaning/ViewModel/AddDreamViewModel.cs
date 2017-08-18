using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Meaning.Annotations;
using Xamarin.Forms;

namespace Meaning.ViewModel
{
    public class AddDreamViewModel 
    {
        public Color PageColor { get; set; } = GeneralSettings.CustomColor;
        public Color ContrastColor { get; set; } = GeneralSettings.ContrastColor;
        public Thickness PagePadding { get; set; } = GeneralSettings.CustomPagePadding;

        public string AddDreamLabel { get; set; }
        public string Content { get; set; }

        public string NotesLabelText { get; set; }
        public string Notes { get; set; }

        public string DueDateLabel { get; set; }
        public DateTime CurrentDisplayedDate { get; set; }
        public DateTime MinimumDate { get; set; } = DateTime.Now.AddDays(1);

        public string ProgressTextLabel { get; set; }
        public double ProgressValue { get; set; }

        public string AddDreamImageSource { get; set; }
        public string AddDreamMotivationText { get; set; }
    }
}
