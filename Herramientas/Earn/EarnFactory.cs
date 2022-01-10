using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Herramientas.Earn
{
    public abstract class EarnFactory
    {
        public abstract IEarn GetEarn();
    }
}
