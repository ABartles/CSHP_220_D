using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PartDB;

namespace PartRepository
{
    public class DatabaseManager
    {
        private static readonly PartWarehouseEntities entities;

        // Initialize and open the database connection
        static DatabaseManager()
        {
            entities = new PartWarehouseEntities();
            entities.Database.Connection.Open();
        }

        // Provide an accessor to the database
        public static PartWarehouseEntities Instance
        {
            get
            {
                return entities;
            }
        }
    }
}
