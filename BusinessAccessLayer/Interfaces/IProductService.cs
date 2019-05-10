﻿using BusinessAccessLayer.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessAccessLayer.Interfaces
{
    interface IProductService
    {
        List<ProductDTO> GetProducts();
    }
}
