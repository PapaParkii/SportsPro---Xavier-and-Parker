﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SportsPro.Properties
{
    public class Country
    {
        [Required]
        public string CountryID { get; set; }

        [Required]
        public string Name { get; set; }
    }
}
