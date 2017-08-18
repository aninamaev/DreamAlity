using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Meaning.Infrastructure.Database.Manage_Db;
using Meaning.Infrastructure.Database.Tables;
using Meaning.Model;
using Meaning.ViewModel;
using Xamarin.Forms;

namespace Meaning.View
{
    public partial class AddItemPage : ContentPage
    {
        private ItemforInterface item;
        private ItemType itemType;

        public Action RefreshItemsAction;

        public AddItemPage(ItemforInterface item, ItemType itemType, string imageSource, string motivationText)
        {
            this.item = item;
            this.itemType = itemType;

            var addItemsViewModel = new AddItemViewModel()
            {
                ContentLabelText = item == null ? $"Writing an interesting new {itemType}:" : $"Editing this {itemType}",
                Content = item == null ? "" : item.Content,
                NotesLabelText = $"What do I think about this {itemType}?",
                Notes = item == null ? "" : item.Notes,
                AddItemImageSource = imageSource,
                AddItemMotivationText = motivationText
            };
            addItemsViewModel.PickerIndex = item == null ? 0 : Array.IndexOf(addItemsViewModel.PickerItems, item.Status);
            BindingContext = addItemsViewModel;

            InitializeComponent();
        }

        public void SaveItemClicked(object sender, EventArgs e)
        {
            var itemStatus = ItemStatus.Wow;
            switch (StatusPicker.SelectedIndex)
            {
                case 0:
                    itemStatus = ItemStatus.Wow;
                    break;
                case 1:
                    itemStatus = ItemStatus.Interesting;
                    break;
                case 2:
                    itemStatus = ItemStatus.Cool;
                    break;
                case 3:
                    itemStatus = ItemStatus.ToRemember;
                    break;
                case 4:
                    itemStatus = ItemStatus.Touching;
                    break;
            }

            var purposeItem = new PurposeItem()
            {
                Content = ContentText.Text,
                Notes = NotesText.Text,
                Status = itemStatus,
                Type = itemType
            };
            
            var manageItems = new ManageItems();
            if (item == null)
                // new item
                manageItems.AddItem(purposeItem);
            else
            {
                //edit item
                purposeItem.Id = item.Id;
                manageItems.UpdateItem(purposeItem);
            }

            RefreshItemsAction?.Invoke();
            Navigation.PopAsync();
        }
    }
}