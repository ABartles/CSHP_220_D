using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PartWarehouseApp.Models
{
    public class PartModel
    {
        // Properties
        public int Id { get; set; }
        public string Description { get; set; }
        public decimal UnitPrice { get; set; }
        public int QtyOnHand { get; set; }
        public decimal StockValue { get; set; }
        public System.DateTime CreatedDate { get; set; }




        public PartRepository.PartModel ToRepositoryModel()
        {
            var repositoryModel = new PartRepository.PartModel
            {
                Id = Id,
                Description = Description,
                UnitPrice = Convert.ToDecimal(UnitPrice),
                QtyOnHand = Convert.ToInt16(QtyOnHand),
                StockValue = StockValue,
                CreatedDate = CreatedDate

            };

            return repositoryModel;
        }

        public static PartModel ToModel(PartRepository.PartModel respositoryModel)
        {
            var partModel = new PartModel
            {
                Id = respositoryModel.Id,
                Description = respositoryModel.Description,
                UnitPrice = respositoryModel.UnitPrice,
                QtyOnHand = respositoryModel.QtyOnHand,
                StockValue = respositoryModel.StockValue,
                CreatedDate = respositoryModel.CreatedDate,
            };

            return partModel;
        }
    }
}
