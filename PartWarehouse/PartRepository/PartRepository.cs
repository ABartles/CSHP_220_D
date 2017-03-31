using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PartDB;


namespace PartRepository
{
    public class PartModel
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public decimal UnitPrice { get; set; }
        public int QtyOnHand { get; set; }
        public decimal StockValue { get; set; }
        public System.DateTime CreatedDate { get; set; }
    }

    public class PartRepository
    {
        public PartModel Add(PartModel partModel)
        {
            var partDb = ToDbModel(partModel);

            DatabaseManager.Instance.Parts.Add(partDb);
            DatabaseManager.Instance.SaveChanges();

            partModel = new PartModel
            {

                Id = partDb.Part_ID,
                Description = partDb.Part_Description,
                UnitPrice = partDb.Part_UnitPrice,
                QtyOnHand = partDb.Part_QtyOnHand,
                StockValue = partDb.Part_StockValue,
                CreatedDate = partDb.Part_AddedDate

            };
            return partModel;
        }

        public List<PartModel> GetAll()
        {
            // Map the database part(s) to PartModel
            var items = DatabaseManager.Instance.Parts
              .Select(t => new PartModel
              {

                  Id = t.Part_ID,
                  Description = t.Part_Description,
                  UnitPrice = t.Part_UnitPrice,
                  QtyOnHand = t.Part_QtyOnHand,
                  StockValue = t.Part_StockValue,
                  CreatedDate = t.Part_AddedDate,

              }).ToList();

            return items;
        }

        public bool Update(PartModel partModel)
        {
            var original = DatabaseManager.Instance.Parts.Find(partModel.Id);

            if (original != null)
            {
                DatabaseManager.Instance.Entry(original).CurrentValues.SetValues(ToDbModel(partModel));
                DatabaseManager.Instance.SaveChanges();
            }

            return false;
        }



        public bool Remove(int partId)
        {
            var items = DatabaseManager.Instance.Parts
                                .Where(t => t.Part_ID == partId);

            if (items.Count() == 0)
            {
                return false;
            }

            DatabaseManager.Instance.Parts.Remove(items.First());
            DatabaseManager.Instance.SaveChanges();

            return true;
        }

        private Part ToDbModel(PartModel partModel)
        {
            var partDb = new Part
            {
                Part_ID = partModel.Id,
                Part_Description = partModel.Description,
                Part_UnitPrice = partModel.UnitPrice,
                Part_QtyOnHand = partModel.QtyOnHand,
                Part_StockValue = (partModel.UnitPrice * partModel.QtyOnHand),  
                Part_AddedDate = partModel.CreatedDate,
            };

            return partDb;
        }
    }
}
