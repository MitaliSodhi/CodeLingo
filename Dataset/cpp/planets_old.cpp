
//  planets_old.cpp (c) 1998-2002 Kari Laitinen

/*  This program is the same as "planets.cpp" except that
    an old version of output manipulator "fixed" is in
    use here.  */

#include  <iostream.h>
#include  <iomanip.h>
#include  <string.h>

struct  Planet
{
   char    planet_name[ 20 ] ;
   double  mean_distance_from_sun ;
   double  circulation_time_around_sun ;
   double  rotation_time_around_own_axis ;
   long    equatorial_radius_in_kilometers ;
   double  mass_compared_to_earth ;
   int     number_of_moons ;
} ;

//  Much of the information given in the following table is
//  relative to the information concerning the Earth. E.g.,
//  Pluto is 39.507 times further from the sun than the Earth.
//  The data concerning the number of moons may be old.

Planet  planet_table[]  =
{
   { "Mercury",  0.387,   0.241,  58.815,  2433,   0.05,  0  },
   { "Venus",    0.723,   0.615, 224.588,  6053,   0.82,  0  },
   { "Earth",    1.000,   1.000,   1.000,  6379,   1.00,  1  },
   { "Mars",     1.523,   1.881,   1.029,  3386,   0.11,  2  },
   { "Jupiter",  5.203,  11.861,   0.411, 71370, 317.93, 16  },
   { "Saturn",   9.541,  29.457,   0.428, 60369,  95.07, 18  },
   { "Uranus",  19.190,  84.001,   0.450, 24045,  14.52,  5  },
   { "Neptune", 30.086, 164.784,   0.657, 22716,  17.18,  2  },
   { "Pluto",   39.507, 248.35,    6.410,  5700,   0.18,  0  }
} ;


int main()
{
   Planet*  planet_in_table  ;
   char     planet_name_from_user[ 20 ] ;

   cout << "\n This program can give you information about the"
        << "\n planets in our solar system. Give a planet name: ";

   cin  >>  planet_name_from_user ;

   planet_in_table  =  planet_table ;

   while ( ( planet_in_table  <
                     planet_table + sizeof( planet_table ) ) &&
           ! ( strstr( planet_in_table -> planet_name,
                       planet_name_from_user ) ) )
   {
      planet_in_table  ++  ;
   }

   if ( strstr( planet_in_table -> planet_name,
                planet_name_from_user ) )
   {
      cout << "\n " << planet_in_table -> planet_name
           << " orbits the sun at an average distance of "
           << setiosflags( ios::fixed ) << setprecision( 0 )
           << ( planet_in_table -> mean_distance_from_sun )
              * 149500000  << " kilometers. "
           << "\n It takes "  <<  setprecision( 3 ) 
           << planet_in_table -> circulation_time_around_sun
           << " years for " << planet_in_table -> planet_name
           << " to go around the sun once. \n The radius of "
           << planet_in_table -> planet_name << " is "
           << planet_in_table -> equatorial_radius_in_kilometers
           << " kilometers.\n" ;
   }
   else
   {
      cout << "\n Sorry, could not find information on "
           << planet_name_from_user  <<  ".\n" ;
   }
}



