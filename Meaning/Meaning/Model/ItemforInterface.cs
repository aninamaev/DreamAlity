using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Meaning.Model
{
    public class ItemforInterface
    {
        public int Id { get; set; }

        public Color PageColor { get; set; } = GeneralSettings.CustomColor;

        public Color ContrastColor { get; set; } = GeneralSettings.ContrastColor;

        public string Content { get; set; }

        public string Notes { get; set; }

        public string Status { get; set; } 
    }
}
