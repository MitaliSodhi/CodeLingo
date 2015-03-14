
//  CelsiusToFahrenheitTable.cs  (c) 2004 Kari Laitinen

//  http://www.naturalprogramming.com

//  2004-10-29  File created.
//  2004-10-29  Last modification.

//  This file is a solution to Exercise 6-10.


using System ;

class CelsiusToFahrenheitTable
{
   static void Main()
   {
      double  temperature_in_degrees_fahrenheit ;
      double  temperature_in_degrees_celsius  ;

      Console.Write(  "\n      Celsius     Fahrenheit  \n"  ) ;

      for ( temperature_in_degrees_celsius  =  - 30 ;
            temperature_in_degrees_celsius  <    40 ;
            temperature_in_degrees_celsius  =
                      temperature_in_degrees_celsius  +  5 )
      {
         temperature_in_degrees_fahrenheit  =
                  32  +  ( ( temperature_in_degrees_celsius  *  18 ) / 10 ) ;

         Console.Write( "\n {0, 10:f0}  {1, 10:f2}",
                        temperature_in_degrees_celsius,
                        temperature_in_degrees_fahrenheit ) ;
      }
   }
}



