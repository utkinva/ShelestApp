using ShelestApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShelestApp.Utilities
{
    internal class DBContext
    {
        private static ModelDB _context { get; set; }
        public static ModelDB Context { get => _context ?? (_context = new ModelDB()); }
    }
}
