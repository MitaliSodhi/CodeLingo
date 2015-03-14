
//  HeightToLightYears.cs  (c) 2004 Kari Laitinen

//  This file is a solution to Exercise 5-6.

//  www.naturalprogramming.com

using System ;

class HeightToLightYears
{
   static void Main()
   {
      double  height_in_centimeters, height_in_light_years ;

      Console.Write( 
            "\n This program converts your height to light years." 
         +  "\n Please, enter your height in centimeters:  " ) ;

      height_in_centimeters  =  Convert.ToDouble( Console.ReadLine() ) ;

      height_in_light_years  =  height_in_centimeters /
                       ( 2.99793e8 * (( 365 * 24 ) + 6 ) * 3600 * 100 ) ;

      Console.Write( "\n  Your height in light years is {0, 12:e5} \n",
                                                 height_in_light_years ) ;
   }
}



