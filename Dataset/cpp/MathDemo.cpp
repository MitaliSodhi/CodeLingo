
//  MathDemo.demo  (c) 2006 Kari Laitinen

//  http://www.naturalprogramming.com

//  2006-06-05  File created.
//  2006-06-05  Last modification.

//  This program demonstrates the use of mathematical functions.
//  It is not presented in "A Natural Introduction to Computer
//  Programming with C++".

#include <iostream.h>
#include <iomanip.h>

#include  <time.h>
#include <stdlib.h>  //  Functions for generating random numbers

// #include <math.h>  //  This line seems to be unnecessary.

const double  EARTH_RADIUS_IN_KILOMETERS  =  6379  ;

double  degrees_to_radians( int  given_degrees,
                             int  given_minutes )
{
   return

   ( (double) (( given_degrees  *  60 ) + given_minutes ) /
                       (double) ( 360 * 60 ) )

       * 2.0 * M_PI ;
}


int main()
{
   double  an_angle_in_radians  =  degrees_to_radians( 45, 00 ) ;

   double  sine_of_an_angle  =  sin( an_angle_in_radians ) ;

   cout  <<  "\n The sine of an angle of 45 degrees is "
         <<  sine_of_an_angle  <<  "\n" ;

   double  diameter_of_the_earth  =
                  2  *  M_PI  *  EARTH_RADIUS_IN_KILOMETERS ;

   //  Because our planet Earth is not exactly a ball, the
   //  diameters and areas calculated below are approximate.

   cout  <<  fixed  <<  setprecision( 0 ) ;

   cout  <<  "\n Earth diameter in kilometers:   "  <<  setw( 15 )
         <<  diameter_of_the_earth  ;

   cout  <<  "\n Earth diameter in miles:        "  <<  setw( 15 )
         <<  diameter_of_the_earth / 1.6093  ;

   double  surface_area_of_the_earth  =
                  4  *  M_PI  *  pow( EARTH_RADIUS_IN_KILOMETERS, 2 ) ;

   cout  <<  "\n Earth area in square kilometers:"  <<  setw( 15 )
         <<  surface_area_of_the_earth ;
   cout  <<  "\n Earth area in square miles:     "  <<  setw( 15 )
         <<  surface_area_of_the_earth / pow( 1.6093, 2 )  <<  "\n" ;


   //  The following lines do not produce ideal random numbers.
   //  There should be a better way to 're-start' the random number generator.

   long  seconds_since_1970  ; 

   time( &seconds_since_1970 ) ;

   srand( (int) seconds_since_1970 ) ;  //  're-start' random number generator

   int  a_random_integer  =  rand()  %   50 ;

   cout  <<  "\n And here is a random integer in the range "
         <<  "from 0 to 49:  "  <<  a_random_integer  <<  "\n\n"  ;

}



