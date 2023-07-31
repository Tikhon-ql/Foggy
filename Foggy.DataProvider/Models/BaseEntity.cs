﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Foggy.DataProvider.Models
{
    public abstract class BaseEntity
    {
        [Required]
        public Guid Id { get; set; }
    }
}
