using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Synthesizer.DataLayer
{
    class DataContext : DbContext
    {
        public DataContext() : base("DBConnection") { }

        public DbSet<Synthesis> Syntheses { get; set; }
    }
}
