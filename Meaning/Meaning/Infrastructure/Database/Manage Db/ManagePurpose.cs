using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Meaning.Infrastructure.Database.Tables;

namespace Meaning.Infrastructure.Database.Manage_Db
{
    public class ManagePurposes
    {
        private static readonly MeanDatabase database = MeanDatabase.GetInstance();
        private static readonly object syncObject = MeanDatabase.Locker;

        public void AddPurpose(Purpose purpose)
        {
            lock (syncObject)
            {
                database.Database.Insert(purpose);
            }
        }

        public void DeletePurpose(int purposeId)
        {
            lock (syncObject)
            {
                var purposeToDelete = database.Database.Table<Purpose>().FirstOrDefault(p => p.Id == purposeId);
                if (purposeToDelete != null)
                    database.Database.Delete(purposeToDelete);
            }
        }

        public List<Purpose> ReturnPurposes()
        {
            lock (syncObject)
            {
                return database.Database.Table<Purpose>().ToList();
            }
        }

        public void UpdatePurpose(Purpose purpose)
        {
            lock (syncObject)
            {
                var purposeToUpdate = database.Database.Table<Purpose>().FirstOrDefault(p => p.Id == purpose.Id);
                if (purposeToUpdate != null)
                {
                    purposeToUpdate.Content = purpose.Content;
                    purposeToUpdate.Notes = purpose.Notes;
                    purposeToUpdate.DueDate = purpose.DueDate;
                    purposeToUpdate.ProgressLevel = purpose.ProgressLevel;

                    database.Database.Update(purposeToUpdate);
                }
            }
        }
    }
}