using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Herramientas.Earn
{
    public class ForeignEarn : IEarn
    {
        private decimal _percentage;
        private decimal _extra;


        public ForeignEarn(decimal percentage, decimal extra)
        {
            _extra = extra;
            _percentage = percentage;
        }

        public decimal Earn(decimal amount)
        {
            return (amount * _percentage) + _extra;
        }
    }
}
