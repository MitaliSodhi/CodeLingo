
//  ConvertTemperature.cs  (c) 2004 Kari Laitinen

//  This file is a solution to Exercise 5-7.

//  www.naturalprogramming.com

using System ;

class ConvertTemperature
{
   static void Main()
   {
      double  given_temperature ;
      double  temperature_in_degrees_fahrenheit,
              temperature_in_degrees_celsius ;

      Console.Write( "\n This program converts temperatures." 
                  +  "\n Please, give a temperature:  " ) ;

      given_temperature  =  Convert.ToDouble( Console.ReadLine() ) ;

      temperature_in_degrees_fahrenheit  =
                  32  +  ( ( given_temperature  *  18 ) / 10 ) ;

      temperature_in_degrees_celsius  =
                  ( ( ( given_temperature  -  32 )  *  10 )  /  18 ) ;

      Console.Write( "\n  "  +  given_temperature  
                  +  " degrees Celsius is "
                  +  temperature_in_degrees_fahrenheit
                  +  " degrees Fahrenheit. \n"  ) ;

      Console.Write( "\n  "  +  given_temperature  
                  +  " degrees Fahrenheit is "
                  +  temperature_in_degrees_celsius
                  +  " degrees Celsius. \n"  ) ;
   }
}



