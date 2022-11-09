using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAZADAKS.DATA.DATA_ACCESS_LAYER.MODELS
{
    public  class ItemCategory : BaseEntity
    {

        public string CategoryName { get; set; }
        public bool IsActive { get; set; } = true;
        public string AddedBy { get; set; }

        [Column(TypeName = "Date")]
        public DateTime DateAdded { get; set; } = DateTime.Now;





    }
}
