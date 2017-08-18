using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Meaning.Logic;
using Meaning.ViewModel;
using Xamarin.Forms;

namespace Meaning.View
{
    public partial class MotivationPage : ContentPage
    {
        public MotivationPage()
        {
            var motivationViewModel = new MotivationViewModel()
            {
                ImageSource = "m1.jpg",
                ImageText = "Always look for inspiration!",
                WhyMotivationText = AppMotivationFromDb.ReturnAppMotivation()
            };
            BindingContext = motivationViewModel;

            InitializeComponent();
        }
    }
}
