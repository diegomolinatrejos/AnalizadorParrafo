﻿using System.Runtime.CompilerServices;

namespace DTO.Models
{
    public class Texto
    {
        public string parentRow { get; set; }
        public List<Parrafo> paragraphsList { get; set; }

    }

    public class Parrafo
    {
        public string paragraphValue { get; set; }

    }
}
