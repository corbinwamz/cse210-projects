using System;
using System.Globalization;
using System.Runtime.InteropServices;

class Program
{
    static void Main(string[] args)
    {
        Fraction frac = new Fraction(1);
        string number = frac.GetFractionString();
        Console.WriteLine(number);
        double dec = frac.GetDecimalValue();
        Console.WriteLine(dec);
        
        Fraction frac2 = new Fraction(5);
        string number2 = frac2.GetFractionString();
        Console.WriteLine(number2);
        double dec2 = frac2.GetDecimalValue();
        Console.WriteLine(dec2);
        
        Fraction frac3 = new Fraction(3,4);
        string number3 = frac3.GetFractionString();
        Console.WriteLine(number3);
        double dec3 = frac3.GetDecimalValue();
        Console.WriteLine(dec3);
        
        Fraction frac4 = new Fraction(1,3);
        string number4 = frac4.GetFractionString();
        Console.WriteLine(number4);
        double dec4 = frac4.GetDecimalValue();
        Console.WriteLine(dec4);
    }
}