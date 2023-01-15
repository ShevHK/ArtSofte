﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArtsofteDbModel.Entities
{
    public class Department
    {
        public int Id { get; set; }

        [StringLength(50)]
        public string? Name { get; set; }
        public int floor { get; set; }
    }
}
