using System;
using System.Collections;
using System.Globalization;
using System.IO;
using d01_ex00.Models;

namespace d01_ex00
{
    public class Exchanger
    {
        private Valuta valFrom;
        private string path;
        public ExchangeRate[] exchangeRate;
        private ExchangeSum exchangeSum;

        public void Reader(string path, Valuta paht1)
        {
            path = path + "/" + paht1 + ".txt";
            exchangeRate = new ExchangeRate[2];
            try
            {
                using (var sr = new StreamReader(path, System.Text.Encoding.Default))
                {
                    string line;
                    for (int i = 0; i < 2; i ++)
                    {
                        if ((line = sr.ReadLine()) == null)
                        {
                            Console.WriteLine("Ошибка ввода. Проверьте входные данные и повторите запрос.");
                            Environment.Exit(1);
                        }
                        string[] lineP = line.Split(":");
                    
                        exchangeRate[i].valFrom = paht1;
                        exchangeRate[i].valTo = Enum.Parse<Valuta>(lineP[0]);
                        if (!(Double.TryParse(lineP[1], NumberStyles.Float,
                            new CultureInfo("ru-ru"), out exchangeRate[i].koef)))
                        {
                            Console.WriteLine("Ошибка ввода. Проверьте входные данные и повторите запрос.");
                            Environment.Exit(1);
                        }
                    }
                }

            }
            catch (Exception e)
            {
                Console.WriteLine("Ошибка ввода. Проверьте входные данные и повторите запрос.");
                Environment.Exit(1);
            }
           
        }

        public IEnumerable metod (int max)
        {
            for (int i = 0; i < max; i++)
            {
                if (i == exchangeRate.Length)
                {
                    yield break;
                }
                else
                {
                    yield return (exchangeRate[i]);
                }
            }
        }
    }
}

