//  distance.cpp  (c) 1997-2002 Kari Laitinen

#include  <iostream.h>
#include  <iomanip.h>

int main()
{
   double  distance_in_meters,  distance_in_kilometers,
           distance_in_miles,   distance_in_yards,
           distance_in_feet,    distance_in_inches ;
   double  distance_in_light_years ;

   cout <<  "\n This program converts meters to other units of" 
        <<  "\n distance. Please, enter a distance in meters:  "  ;

   cin  >>  distance_in_meters ;

   distance_in_kilometers  =  distance_in_meters / 1000.0 ;
   distance_in_miles       =  6.21371e-4 *  distance_in_meters ;
   distance_in_yards       =  1.093613   *  distance_in_meters ;
   distance_in_feet        =  3.280840   *  distance_in_meters ;
   distance_in_inches      =  12         *  distance_in_feet ;
   distance_in_light_years  =  distance_in_meters /
                               ( 2.99793e8 * 365 * 24 * 3600 ) ;

   cout <<  "\n "  <<  distance_in_meters  <<  " meters is: \n\n"
        <<  setprecision( 3 )  <<  fixed 
        <<  setw( 15 )
        <<  distance_in_kilometers   <<  "  kilometers \n"
        <<  setw( 15 )
        <<  distance_in_miles        <<  "  miles  \n" 
        <<  setw( 15 )
        <<  distance_in_yards        <<  "  yards  \n"
        <<  setw( 15 )
        <<  distance_in_feet         <<  "  feet   \n"
        <<  setw( 15 )
        <<  distance_in_inches       <<  "  inches \n"
        <<  scientific
        <<  setw( 15 )
        <<  distance_in_light_years  <<  "  light years\n" ;
}



