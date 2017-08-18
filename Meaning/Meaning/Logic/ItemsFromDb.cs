using System.Collections.ObjectModel;
using Meaning.Infrastructure.Database.Manage_Db;
using Meaning.Infrastructure.Database.Tables;
using Meaning.Model;

namespace Meaning.Logic
{
    public class ItemsFromDb
    {
        public static string ReturnItemMotivation(ItemType type)
        {
            var mim = new ManageItemsMotivations();
            return mim.ReturnItemMotivationForItemType(type).Content;
        }

        public static ObservableCollection<ItemforInterface> ReturnItemsForInterface(ItemType type)
        {
            var itemCollection = new ObservableCollection<ItemforInterface>();

            var manageItems = new ManageItems();
            var itemsFromDb = manageItems.ReturnTypeItems(type);
            foreach (var dbItem in itemsFromDb)
            {
                var interfaceItem = new ItemforInterface()
                {
                    Id = dbItem.Id,
                    Content = dbItem.Content,
                    Notes = dbItem.Notes,
                    Status = dbItem.Status.ToString()
                };
                itemCollection.Add(interfaceItem);
            }

            return itemCollection;
        }
    }
}