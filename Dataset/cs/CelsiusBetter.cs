
//  CelsiusBetter.cs  (c) 2003 Kari Laitinen

//  http://www.naturalprogramming.com

//  2004-10-30  File created.
//  2004-10-30  Last modification.

//  Solution to Exercise 7-8.

using System ;

class CelsiusBetter
{
   static void Main()
   {
      int[]  array_of_degrees_fahrenheit  =

      { 32, 34, 36, 37, 39, 41, 43, 45, 46, 48,
        50, 52, 54, 55, 57, 59, 61, 63, 64, 66,
        68, 70, 72, 73, 75, 77, 79, 81, 82, 84,
        86, 88, 90, 91, 93, 95, 97, 99, 100, 102 } ;

      int[]  small_degrees_fahrenheit  =

       { 32, 30, 28, 27, 25, 23, 21, 19, 18, 16,
         14, 12, 10,  9,  7,  5,  3,  1,  0, -2,
        -4, -6, -8,  -9,-11,-13,-14,-16,-18,-20,
       -22,-24,-26, -27,-29,-31,-33,-35,-36,-38,
       -40  } ;
       

      Console.Write(
          "\n This program converts temperatures given in"
        + "\n degrees Celsius to degrees Fahrenheit."
        + "\n Please, give a temperature in degrees Celsius:  " ) ;

      int degrees_celsius  =  Convert.ToInt32( Console.ReadLine() ) ;

      if ( degrees_celsius  >=  0 )
      {
         Console.Write(
            "\n " +  degrees_celsius  +  " degrees Celsius is "
            +  array_of_degrees_fahrenheit[ degrees_celsius ]
            + " degrees Fahrenheit. \n" ) ;
      }
      else
      {
         Console.Write(
            "\n " +  degrees_celsius  +  " degrees Celsius is "
            +  small_degrees_fahrenheit[ - degrees_celsius ]
            + " degrees Fahrenheit. \n" ) ;
      }
      
   }
}



