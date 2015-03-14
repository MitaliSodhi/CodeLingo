
//  Celsius.cs  (c) 2003 Kari Laitinen

using System ;

class Celsius
{
   static void Main()
   {
      int[]  array_of_degrees_fahrenheit  =

      { 32, 34, 36, 37, 39, 41, 43, 45, 46, 48,
        50, 52, 54, 55, 57, 59, 61, 63, 64, 66,
        68, 70, 72, 73, 75, 77, 79, 81, 82, 84,
        86, 88, 90, 91, 93, 95, 97, 99, 100, 102 } ;

      Console.Write(
          "\n This program converts temperatures given in"
        + "\n degrees Celsius to degrees Fahrenheit."
        + "\n Please, give a temperature in degrees Celsius:  " ) ;

      int degrees_celsius  =  Convert.ToInt32( Console.ReadLine() ) ;

      Console.Write(
          "\n " +  degrees_celsius  +  " degrees Celsius is "
        +  array_of_degrees_fahrenheit[ degrees_celsius ]
        + " degrees Fahrenheit. \n" ) ;
   }
}



