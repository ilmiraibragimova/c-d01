using System;

namespace d01_ex00.Models
{
    public struct ExchangeSum
    {
       public Double sum;
       public Valuta _valuta;

        public ExchangeSum(double sum, Valuta valuta)
        {
            this.sum = sum;
            _valuta = valuta;
        }
    }
}