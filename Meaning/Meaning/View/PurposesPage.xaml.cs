using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Meaning.Infrastructure.Database.Manage_Db;
using Meaning.Logic;
using Meaning.Model;
using Meaning.ViewModel;
using Xamarin.Forms;

namespace Meaning.View
{
    public partial class PurposesPage : ContentPage
    {
        private PurposesViewModel purposeViewModel;

        public PurposesPage()
        {
            purposeViewModel = new PurposesViewModel
            {
                PageColor = GeneralSettings.CustomColor,
                ContrastColor = GeneralSettings.ContrastColor,
                PagePadding = GeneralSettings.CustomPagePadding,
                GeneralVisualItemsSpacing = GeneralSettings.CustomVisualItemsSpacing,
                PurposesImageSource = "m2.jpg",
                MotivationItemText = PurposesFromDb.ReturnMotivationItemText(),
                PurposesCollection = PurposesFromDb.ReturnPurposesCollection()
            };
            BindingContext = purposeViewModel;

            InitializeComponent();
        }

        public async void  OnDeletePurpose(object sender, EventArgs e)
        {
            try
            {
                var mi = ((MenuItem)sender);
                var response = await DisplayAlert("Delete this dream", "Are you sure you want to delete this dream?", "Yes", "No");
                if (!response) return;
                var mp = new ManagePurposes();
                mp.DeletePurpose((int)mi.CommandParameter);
                RefreshPurposeListAction();
            }
            catch (Exception) {}
            
        }

        public void PurposeSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem != null) PurposesListView.SelectedItem = null;
            var purpose = e.SelectedItem as PurposeForInterface;
            if (purpose != null)
            {
                var imageSource = "m2.jpg";
                var editPurposePage = new AddPurposePage(purpose, imageSource, "Always reinvet yourself!") {Title = "Edit purpose", RefreshPurposeAction = RefreshPurposeListAction};
                Navigation.PushAsync(editPurposePage);
            }
        }

        public void AddNewPurposeClicked(object sender, EventArgs e)
        {
            var newPurposePage = new AddPurposePage(null, "m2.jpg", "Do not ever forget to dream!") {Title = "New Purpose", RefreshPurposeAction = RefreshPurposeListAction};
            Navigation.PushAsync(newPurposePage);
        }

        private void RefreshPurposeListAction()
        {
            purposeViewModel.PurposesCollection = PurposesFromDb.ReturnPurposesCollection();
        }
    }
}
