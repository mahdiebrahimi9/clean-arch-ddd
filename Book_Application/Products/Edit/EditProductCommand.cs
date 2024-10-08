﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Book_Application.Products.Edit
{
    public class EditProductCommand : IRequest
    {
     
        public long Id { get; set; }
        public string BookName { get; set; }
        public int Price { get; set; }
        public string Description { get; set; }
    }
}
