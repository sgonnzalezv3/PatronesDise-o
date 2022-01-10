﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Herramientas.Earn
{
    /* Producto */
    public class LocalEarn : IEarn
    {
        private decimal _percentage;
        public LocalEarn(decimal percentage)
        {
            _percentage = percentage;
        }
        public decimal Earn(decimal amount)
        {
            return amount * _percentage;
        }
    }
}
