﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAZADAKS.DATA.DATA_ACCESS_LAYER.DTOs.SETUP_DTO
{
    public  class ItemCategoryDto
    {
        public int Id { get; set; }
        public string ItemCategoryName { get; set; }
        public string AddedBy { get; set; }
        public string DateAdded { get; set; }
        public bool IsActive { get; set; }



    }
}
