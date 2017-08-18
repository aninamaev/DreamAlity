using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace Meaning.Infrastructure.Database.Tables
{
    [Table("ItemMotivation")]
    public class ItemMotivation
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        public string Content { get; set; }

        public ItemType Type { get; set; }
    }
}
