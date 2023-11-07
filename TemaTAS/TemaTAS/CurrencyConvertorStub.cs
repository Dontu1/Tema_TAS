using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TemaTAS
{
    public class CurrencyConvertorStub : ICurrencyConvertor
    {
        private float euroToRonRate;

        public CurrencyConvertorStub(float euroToRonRate)
        {
            this.euroToRonRate = euroToRonRate;
        }

        public float ConvertFromEuroToRon(float ValueInEur)
        {
            return ValueInEur * euroToRonRate;
        }
        public float ConvertFromRonToEur(float ValueInRon)
        {
            return ValueInRon / euroToRonRate;
        }
    }
}
