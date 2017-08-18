using System.Collections.ObjectModel;
using System.Net.Http.Headers;
using Meaning.Infrastructure.Database.Manage_Db;
using Meaning.Infrastructure.Database.Tables;
using Meaning.Model;

namespace Meaning.Logic
{
    public class PurposesFromDb
    {
        public static string ReturnMotivationItemText()
        {
            var mim = new ManageItemsMotivations();
            return mim.ReturnItemMotivationForItemType(ItemType.Purpose).Content;
        }

        public static ObservableCollection<PurposeForInterface> ReturnPurposesCollection()
        {
            var purposesCollection = new ObservableCollection<PurposeForInterface>();

            var managePuporses = new ManagePurposes();
            var dbPurposes = managePuporses.ReturnPurposes();
            foreach (var purpose in dbPurposes)
            {
                var interfacePurpose = new PurposeForInterface()
                {
                    Id = purpose.Id,
                    Content = purpose.Content,
                    Notes = purpose.Notes,
                    ProgressValue = purpose.ProgressLevel,
                    DueDateTime = purpose.DueDate
                };
                purposesCollection.Add(interfacePurpose);
            }

            return purposesCollection;
        }
    }
}