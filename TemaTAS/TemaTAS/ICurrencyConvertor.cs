using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TemaTAS
{
    public interface ICurrencyConvertor
    {
        float ConvertFromEuroToRon(float ValueInEur);

        float ConvertFromRonToEur(float ValueInRon);
    }
}
