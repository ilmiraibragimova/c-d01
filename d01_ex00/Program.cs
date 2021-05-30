using System;
using d01_ex00;
using d01_ex00.Models;

ExchangeSum exchangeSum;
string[] pars = args[0].Split(" ");
if ( args.Length != 2 )
{
    Console.WriteLine("Ошибка ввода. Проверьте входные данные и повторите запрос.");
    return;
}
try
{
    exchangeSum = new ExchangeSum(Double.Parse(pars[0]),
        Enum.Parse<Valuta>(pars[1]));
}
catch (Exception)
{
    Console.WriteLine("Ошибка ввода. Проверьте входные данные и повторите запрос.");
    return;
}

var exchanger = new Exchanger();
exchanger.Reader(args[1], exchangeSum._valuta);
Console.WriteLine("Сумма в исходной валюте: {0:N2} {1}",
    exchangeSum.sum, exchangeSum._valuta);
int i = 0;
foreach (ExchangeRate a in exchanger.metod(2))
{
     
    Console.WriteLine("Сумма в {0}: {1:N2} {0}", exchanger.exchangeRate[i].valTo,
        exchanger.exchangeRate[i].koef * exchangeSum.sum);
    i++;
}
public enum Valuta
{
    EUR,
    RUB,
    USD
}    
