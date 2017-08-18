using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Meaning.Infrastructure.Database.Manage_Db;
using Meaning.Infrastructure.Database.Tables;

namespace Meaning.Logic
{
    public class AppMotivationFromDb
    {
        public static string ReturnAppMotivation()
        {
            var mim = new ManageItemsMotivations();
            return mim.ReturnItemMotivationForItemType(ItemType.App).Content;
        }
    }
}
