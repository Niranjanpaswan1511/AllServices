﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AllServices.Models
{
    public class Contactus
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Mobile { get; set; }
        public string Message {  get; set; }
        public string DateTime { get; set; }
        public string IsActive { get; set; }

    }
    
}