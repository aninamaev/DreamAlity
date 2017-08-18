using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Meaning.Infrastructure.Database.Manage_Db;
using Meaning.Infrastructure.Database.Tables;
using Meaning.Logic;
using Meaning.Model;
using Meaning.ViewModel;
using Xamarin.Forms;

namespace Meaning.View
{
    public partial class ItemsPage : ContentPage
    {
        private readonly ItemType itemType;
        private readonly ItemsViewModel itemsViewModel;
        private readonly string imageSource;

        public ItemsPage(ObservableCollection<ItemforInterface> itemsCollection, string itemMotivation, string imageSource, ItemType itemType)
        {
            this.itemType = itemType;
            this.imageSource = imageSource;
            itemsViewModel = new ItemsViewModel()
            {
                PageColor = GeneralSettings.CustomColor,
                ContrastColor = GeneralSettings.ContrastColor,
                PagePadding = GeneralSettings.CustomPagePadding,
                ItemImageSource = imageSource,
                ItemMotivation = itemMotivation,
                ItemsCollection = itemsCollection
            };
            BindingContext = itemsViewModel;

            InitializeComponent();
        }

        public async void OnDeleteItem(object sender, EventArgs e)
        {
            var mi = ((MenuItem)sender);
            var response = await DisplayAlert($"Delete {itemType}", $"Are you sure you want to delete this {itemType}", "Yes", "No");
            if (!response) return;
            var mit = new ManageItems();
            mit.DeleteItem((int)mi.CommandParameter);
            RefreshItemsListAction();
        }

        public void OneItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem != null) ItemsListView.SelectedItem = null;

            var item = e.SelectedItem as ItemforInterface;
            if (item != null)
            {
                var motivationText = "Become a person you would enjoy spending time with!";
                var editItemPage = new AddItemPage(item, itemType, imageSource, motivationText) { Title = $"Edit {itemType}", RefreshItemsAction = RefreshItemsListAction };
                Navigation.PushAsync(editItemPage);
            }
        }

        public void AddNewItemClicked(object sender, EventArgs e)
        {
            var addNewItemPage = new AddItemPage(null, itemType, imageSource, "motivation text") { Title = $"New {itemType}", RefreshItemsAction = RefreshItemsListAction};
            Navigation.PushAsync(addNewItemPage);
        }

        private void RefreshItemsListAction()
        {
            itemsViewModel.ItemsCollection = ItemsFromDb.ReturnItemsForInterface(itemType);
        }
    }
}
