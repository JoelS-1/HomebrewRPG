﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomebrewRPG.Models.WeaponModels
{
    public class WeaponListItem
    {
        public int WeaponId { get; set; }
        public string WeaponName { get; set; }
        public string Description { get; set; }
        public string WeaponType { get; set; }
    }
}