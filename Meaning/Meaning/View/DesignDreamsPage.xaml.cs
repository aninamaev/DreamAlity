using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Meaning.ViewModel;
using Xamarin.Forms;

namespace Meaning.View
{
    public partial class DesignDreamsPage : ContentPage
    {
        public DesignDreamsPage()
        {
            var designDreamsViewModel = new DesignDreamsViewModel()
            {
                PageColor = GeneralSettings.CustomColor,
                PagePadding = GeneralSettings.CustomPagePadding,
                GeneralVisualItemsSpacing = GeneralSettings.CustomVisualItemsSpacing,
                DesignImageSource = "c2.jpg",
                DesignItemText = "Remember to design The Reality from Your Dreams!"
            };

            BindingContext = designDreamsViewModel;

            InitializeComponent();
        }

        public void MyPurposesClicked(object sender, EventArgs e)
        {
            var purposesPage = new PurposesPage() {Title = "Purposes"};
            Navigation.PushAsync(purposesPage);
        }
    }
}
