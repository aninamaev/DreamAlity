using Meaning.Infrastructure.Database.Tables;

namespace Meaning.Infrastructure.Database.Manage_Db
{
    public class ManageItemsMotivations
    {
        private static readonly MeanDatabase database = MeanDatabase.GetInstance();
        private static readonly object syncObject = MeanDatabase.Locker;

        public ItemMotivation ReturnItemMotivationForItemType(ItemType type)
        {
            lock (syncObject)
            {
                return database.Database.Table<ItemMotivation>().FirstOrDefault(im => im.Type == type);
            }
        }
    }
}