using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace Meaning.Infrastructure.Database.Tables
{
    [Table("Purpose")]
    public class Purpose
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        public string Content { get; set; }

        public string Notes { get; set; }

        public DateTime DueDate { get; set; }

        public double ProgressLevel { get; set; }
    }
}
