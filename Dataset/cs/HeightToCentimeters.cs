
//  HeightToCentimeters.cs  (c) 2004 Kari Laitinen

//  This file is a solution to Exercise 5-5.

//  www.naturalprogramming.com

using System ;

class HeightToCentimeters
{
   static void Main()
   {
      double  feet_of_height, inches_of_height ;
      double  height_in_centimeters ;

      Console.Write( 
            "\n This program can convert a height given as" 
         +  "\n feets and remaining inches to centimeters.  "
         +  "\n Please, give the feet of your height:  " ) ;

      feet_of_height  =  Convert.ToDouble( Console.ReadLine() ) ;

      Console.Write( "\n Please, give the remaining inches:   " ) ;

      inches_of_height  =  Convert.ToDouble( Console.ReadLine() ) ;

      height_in_centimeters  = 
               ( feet_of_height  *  12  + inches_of_height )  *  2.54 ;

      Console.Write( "\n  "  +  feet_of_height  +  " feet and "
                  +  inches_of_height  +  " inches is "
                  +  height_in_centimeters  +  "\n"  ) ;

   }
}



