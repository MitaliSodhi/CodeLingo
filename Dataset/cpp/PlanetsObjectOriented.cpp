
//  PlanetsObjectOriented.cpp (c) 1998-2006 Kari Laitinen

//  http://www.naturalprogramming.com

//  2006-06-11  File created.
//  2006-06-11  Last modification.

//  This is an object-oriented version of program Planets.cpp.
//  This is not presented in the C++ book. This version corresponds
//  to the programs Planets.java, Planets.cs and Planets.py that
//  are available at http://www.naturalprogramming.com

#include  <iostream.h>
#include  <iomanip.h>
#include  <string.h>

class  Planet
{
protected:
   char    planet_name[ 20 ] ;
   double  mean_distance_from_sun ;
   double  circulation_time_around_sun ;
   double  rotation_time_around_own_axis ;
   long    equatorial_radius_in_kilometers ;
   double  mass_compared_to_earth ;
   int     number_of_moons ;

public:

   Planet()   //  default constructor
   {
      strcpy( planet_name, "default planet" ) ;
   }

   Planet( char    given_planet_name[],
           double  given_mean_distance_from_sun,
           double  given_circulation_time_around_sun,
           double  given_rotation_time_around_own_axis,
           long    given_equatorial_radius_in_kilometers,
           double  given_mass_compared_to_earth,
           int     given_number_of_moons ) ;

   char* get_planet_name()
   {
      return  planet_name ;
   }

   void print_planet_data() ;
} ;

Planet::Planet( char    given_planet_name[],
                double  given_mean_distance_from_sun,
                double  given_circulation_time_around_sun,
                double  given_rotation_time_around_own_axis,
                long    given_equatorial_radius_in_kilometers,
                double  given_mass_compared_to_earth,
                int     given_number_of_moons )
{
   strcpy( planet_name, given_planet_name ) ;
   mean_distance_from_sun  =  given_mean_distance_from_sun ;
   circulation_time_around_sun  =  given_circulation_time_around_sun ;
   rotation_time_around_own_axis  =  given_rotation_time_around_own_axis ;
   equatorial_radius_in_kilometers = given_equatorial_radius_in_kilometers ;
   mass_compared_to_earth  =  given_mass_compared_to_earth ;
   number_of_moons  =  given_number_of_moons ;
}

void Planet::print_planet_data()
{
   cout << "\n " << planet_name
        << " orbits the sun at an average distance of "
        << fixed << setprecision( 0 )
        << mean_distance_from_sun * 149500000  << " kilometers. "
        << "\n It takes "  <<  setprecision( 3 ) 
        << circulation_time_around_sun << " years for " << planet_name
        << " to go around the sun once. \n The radius of "
        << planet_name << " is " << equatorial_radius_in_kilometers
        << " kilometers.\n" ;
}

int main()
{
   //  Much of the information given in the following table is
   //  relative to the information concerning the Earth. E.g.,
   //  Pluto is 39.507 times further from the sun than the Earth.
   //  The data concerning the number of moons may be old.

   Planet  planet_table[ 30 ] ;

   planet_table[ 0 ] = Planet(
          "Mercury",  0.387,   0.241,  58.815,  2433,   0.05,  0  ) ;
   planet_table[ 1 ] = Planet(
          "Venus",    0.723,   0.615, 224.588,  6053,   0.82,  0  ) ;
   planet_table[ 2 ] = Planet(
          "Earth",    1.000,   1.000,   1.000,  6379,   1.00,  1  ) ;
   planet_table[ 3 ] = Planet(
          "Mars",     1.523,   1.881,   1.029,  3386,   0.11,  2  ) ;
   planet_table[ 4 ] = Planet(
          "Jupiter",  5.203,  11.861,   0.411, 71370, 317.93, 12  ) ;
   planet_table[ 5 ] = Planet(
          "Saturn",   9.541,  29.457,   0.428, 60369,  95.07, 10  ) ;
   planet_table[ 6 ] = Planet(
          "Uranus",  19.190,  84.001,   0.450, 24045,  14.52,  5  ) ;
   planet_table[ 7 ] = Planet(
          "Neptune", 30.086, 164.784,   0.657, 22716,  17.18,  2  ) ;
   planet_table[ 8 ] = Planet(
          "Pluto",   39.507, 248.35,    6.410,  5700,   0.18,  0  ) ;

   Planet*  planet_in_table  ;
   char     planet_name_from_user[ 20 ] ;

   cout << "\n This program can give you information about the"
        << "\n planets in our solar system. Give a planet name: ";

   cin  >>  planet_name_from_user ;

   planet_in_table  =  planet_table ;

   //  The planet table is initialized automatically so that
   //  the default constructor of class Planet is called for
   //  each Planet object in the table. Therefore, the unused
   //  slots in the planet table contain the planet name "default
   //  planet".

   while ( ! ( strstr( planet_in_table -> get_planet_name(),
                       "default planet" )  )                   &&
           ! ( strstr( planet_in_table -> get_planet_name(),
                       planet_name_from_user ) ) )
   {
      planet_in_table  ++  ;  //  Make the pointer point to the next planet.
   }

   if ( strstr( planet_in_table -> get_planet_name(),
                planet_name_from_user ) )
   {
      planet_in_table -> print_planet_data() ;
   }
   else
   {
      cout << "\n Sorry, could not find information on "
           << planet_name_from_user  <<  ".\n" ;
   }
}



