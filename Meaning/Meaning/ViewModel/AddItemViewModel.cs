using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Meaning.Infrastructure.Database.Tables;
using Meaning.Model;
using Xamarin.Forms;

namespace Meaning.ViewModel
{
    public class AddItemViewModel
    {
        public Color PageColor { get; set; } = GeneralSettings.CustomColor;
        public Color ContrastColor { get; set; } = GeneralSettings.ContrastColor;
        public Thickness PagePadding { get; set; } = GeneralSettings.CustomPagePadding;

        public string ContentLabelText { get; set; }
        public string Content { get; set; }

        public string NotesLabelText { get; set; }
        public string Notes { get; set; }

        public string[] PickerItems { get; set; } = new[] {ItemStatus.Wow.ToString(), ItemStatus.Interesting.ToString(), ItemStatus.Interesting.ToString(), ItemStatus.ToRemember.ToString(), ItemStatus.Touching.ToString()};
        public int PickerIndex { get; set; }

        public string AddItemImageSource { get; set; }
        public string AddItemMotivationText { get; set; }

    }
}
