
//  Planets.cs (c) 2004 Kari Laitinen

//  www.naturalprogramming.com

using System ;

class Planet
{
   string  planet_name ;
   double  mean_distance_from_sun ;
   double  circulation_time_around_sun ;
   double  rotation_time_around_own_axis ;
   long    equatorial_radius_in_kilometers ;
   double  mass_compared_to_earth ;
   int     number_of_moons ;

   public Planet( string  given_planet_name,
                  double  given_mean_distance_from_sun,
                  double  given_circulation_time_around_sun,
                  double  given_rotation_time_around_own_axis,
                  long    given_equatorial_radius_in_kilometers,
                  double  given_mass_compared_to_earth,
                  int     given_number_of_moons )
   {
      planet_name  =  given_planet_name ;
      mean_distance_from_sun  =  given_mean_distance_from_sun ;
      circulation_time_around_sun  =  given_circulation_time_around_sun ;
      rotation_time_around_own_axis  =  given_rotation_time_around_own_axis ;
      equatorial_radius_in_kilometers = given_equatorial_radius_in_kilometers ;
      mass_compared_to_earth  =  given_mass_compared_to_earth ;
      number_of_moons  =  given_number_of_moons ;
   }

   public string get_planet_name()
   {
      return  planet_name ;
   }

   public void print_planet_data()
   {
      Console.Write( "\n " + planet_name
                  +  " orbits the sun in average distance of "
                  +  ( mean_distance_from_sun * 149500000 ) + " kilometers."
                  +  "\n It takes "  +  circulation_time_around_sun
                  +  " years for " +  planet_name
                  +  " to go around the sun once. \n The radius of "
                  +  planet_name + " is "
                  +  equatorial_radius_in_kilometers  + " kilometers.\n" ) ;
   }
}

class  PlanetDataFinder
{
   static void Main()
   {
      //  Much of the information given in the following table is
      //  relative to the information concerning the Earth. E.g.,
      //  Pluto is 39.507 times further from the sun than the Earth.
      //  The data concerning the number of moons may be old.

      Planet[]  planet_table  =  new  Planet[ 30 ] ;

      planet_table[ 0 ] = new Planet(
          "Mercury",  0.387,   0.241,  58.815,  2433,   0.05,  0  ) ;
      planet_table[ 1 ] = new Planet(
          "Venus",    0.723,   0.615, 224.588,  6053,   0.82,  0  ) ;
      planet_table[ 2 ] = new Planet(
          "Earth",    1.000,   1.000,   1.000,  6379,   1.00,  1  ) ;
      planet_table[ 3 ] = new Planet(
          "Mars",     1.523,   1.881,   1.029,  3386,   0.11,  2  ) ;
      planet_table[ 4 ] = new Planet(
          "Jupiter",  5.203,  11.861,   0.411, 71370, 317.93, 12  ) ;
      planet_table[ 5 ] = new Planet(
          "Saturn",   9.541,  29.457,   0.428, 60369,  95.07, 10  ) ;
      planet_table[ 6 ] = new Planet(
          "Uranus",  19.190,  84.001,   0.450, 24045,  14.52,  5  ) ;
      planet_table[ 7 ] = new Planet(
          "Neptune", 30.086, 164.784,   0.657, 22716,  17.18,  2  ) ;
      planet_table[ 8 ] = new Planet(
          "Pluto",   39.507, 248.35,    6.410,  5700,   0.18,  0  ) ;


      Console.Write( "\n This program can give you information about the"
                   + "\n planets in our solar system. Give a planet name: ");

      string  planet_name_from_user  =  Console.ReadLine() ;

      int  planet_index  =  0 ;

      bool table_search_ready  =  false ;

      while ( table_search_ready  ==  false )
      {
         if ( planet_table[ planet_index ].get_planet_name().ToLower()
                    .IndexOf( planet_name_from_user.ToLower() )  !=  -1 )
         {
            planet_table[ planet_index ].print_planet_data() ;

            table_search_ready  =  true ;
         }
         else
         {
            planet_index  ++  ;

            if ( planet_table[ planet_index ]  ==  null )
            {
               Console.Write( "\n Sorry, could not find information on \""
                           +  planet_name_from_user  +  "\".\n" ) ;

               table_search_ready  =  true ;
            }
         }
      }
   }
}



