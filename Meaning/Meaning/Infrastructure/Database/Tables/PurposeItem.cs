using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace Meaning.Infrastructure.Database.Tables
{
    [Table("PurposeItem")]
    public class PurposeItem
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        public string Content { get; set; }

        public string Notes { get; set; }

        public ItemStatus Status { get; set; }

        public ItemType Type { get; set; }
    }
}
