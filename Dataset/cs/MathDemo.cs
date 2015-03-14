
//  MathDemo.cs  (c) 2006 Kari Laitinen

//  http://www.naturalprogramming.com

//  2006-06-08  File created.
//  2006-06-08  Last modification.

//  This program demonstrates the use of mathematical methods.
//  This is not presented in "A Natural Introduction to Computer
//  Programming with C#".

using System ;

class MathDemo
{
   const double  EARTH_RADIUS_IN_KILOMETERS  =  6379  ;

   static double degrees_to_radians( int  given_degrees,
                                     int  given_minutes )
   {
      return
   
      ( (double) (( given_degrees  *  60 ) + given_minutes ) /
                          (double) ( 360 * 60 ) )
   
          * 2.0 * Math.PI ;
   }

   static void Main()
   {
      double  an_angle_in_radians  =  degrees_to_radians( 45, 00 ) ;

      double  sine_of_an_angle  =  Math.Sin( an_angle_in_radians ) ;

      Console.Write( "\n The sine of an angle of 45 degrees is "
                  +  sine_of_an_angle  +  "\n" ) ;

      double  diameter_of_the_earth  =
                  2  *  Math.PI  *  EARTH_RADIUS_IN_KILOMETERS ;

      //  Because our planet Earth is not exactly a ball, the
      //  diameters and areas calculated below are approximate.

      Console.Write( "\n Earth diameter in kilometers:   {0, 15:f0}", 
                      diameter_of_the_earth ) ;

      Console.Write( "\n Earth diameter in miles:        {0, 15:f0}",
                      diameter_of_the_earth / 1.6093 ) ;

      double  surface_area_of_the_earth  =
                  4  *  Math.PI  *  Math.Pow( EARTH_RADIUS_IN_KILOMETERS, 2 );

      Console.Write( "\n Earth area in square kilometers:{0, 15:f0}",
                      surface_area_of_the_earth ) ;
      Console.Write( "\n Earth area in square miles:     {0, 15:f0}\n",
                      surface_area_of_the_earth / Math.Pow( 1.6093, 2 ) );

      Random  random_number_generator  =  new  Random() ;

      int  a_random_integer  =  (int) ( random_number_generator.NextDouble() * 50 ) ;

      Console.Write( "\n And here is a random integer in the range "
                  +  "from 0 to 49:  "  +  a_random_integer  +  "\n\n" ) ;


      //  Method Math.round() is able round numbers as humans do.
      //  Otherwise, computers always round downwards.

      Console.Write( "\n ((int) 34.56 ) evaluates to      "
                      + ( (int) 34.56 )
                      + "\n Math.Round( 34.56 ) evaluates to "
                      + Math.Round( 34.56 )   +  "\n" ) ;

      Console.Write( "\n ((int) 34.50 ) evaluates to      "
                      + ( (int) 34.50 )
                      + "\n Math.Round( 34.50 ) evaluates to "
                      + Math.Round( 34.50 )   +  "\n" ) ;

   }
}



