using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Meaning.Infrastructure.Database.Tables;

namespace Meaning.Infrastructure.Database.Manage_Db
{
    public class ManageItems
    {
        private static readonly MeanDatabase database = MeanDatabase.GetInstance();
        private static readonly object syncObject = MeanDatabase.Locker;

        public void AddItem(PurposeItem item)
        {
            lock (syncObject)
            {
                database.Database.Insert(item);
            }
        }

        public void DeleteItem(int itemId)
        {
            lock (syncObject)
            {
                var itemToDelete = database.Database.Table<PurposeItem>().FirstOrDefault(i => i.Id == itemId);
                if (itemToDelete != null)
                    database.Database.Delete(itemToDelete);
            }
        }

        public List<PurposeItem> ReturnAllItems()
        {
            lock (syncObject)
            {
                return database.Database.Table<PurposeItem>().ToList();
            }
        }

        public List<PurposeItem> ReturnTypeItems(ItemType type)
        {
            lock (syncObject)
            {
                return database.Database.Table<PurposeItem>().Where(p => p.Type == type).ToList();
            }
        }

        public void UpdateItem(PurposeItem item)
        {
            lock (syncObject)
            {
                var itemToUpdate = database.Database.Table<PurposeItem>().FirstOrDefault(i => i.Id == item.Id);
                if (itemToUpdate != null)
                {
                    itemToUpdate.Content = item.Content;
                    itemToUpdate.Notes = item.Notes;
                    itemToUpdate.Status = item.Status;

                    database.Database.Update(itemToUpdate);
                }
            }
        }
    }
}