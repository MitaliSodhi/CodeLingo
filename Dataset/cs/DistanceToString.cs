
//  DistanceToString.cs  (c) 2003 Kari Laitinen

using System ;

//  This program is the same as Distance.cs except that
//  string methods ToString(), PadLeft() etc. are used to
//  format the screen output.

class DistanceToString
{
   static void Main()
   {
      double  distance_in_meters,  distance_in_kilometers,
              distance_in_miles,   distance_in_yards,
              distance_in_feet,    distance_in_inches ;
      double  distance_in_light_years ;

      Console.Write( 
            "\n This program converts meters to other units of" 
         +  "\n distance. Please, enter a distance in meters:  " ) ;

      distance_in_meters  =  Convert.ToDouble( Console.ReadLine() ) ;

      distance_in_kilometers  =  distance_in_meters / 1000.0 ;
      distance_in_miles       =  6.21371e-4 *  distance_in_meters ;
      distance_in_yards       =  1.093613   *  distance_in_meters ;
      distance_in_feet        =  3.280840   *  distance_in_meters ;
      distance_in_inches      =  12         *  distance_in_feet ;
      distance_in_light_years  =  distance_in_meters /
                               ( 2.99793e8 * 365 * 24 * 3600 ) ;

      Console.Write( "\n " + distance_in_meters + " meters is: \n\n" ) ;

      Console.Write( distance_in_kilometers.ToString( "f3" ).PadLeft( 15 )
                  +  "  kilometers\n" ) ;
      Console.Write( distance_in_miles.ToString( "f3" ).PadLeft( 15 )
                  +  "  miles\n" ) ;
      Console.Write( distance_in_yards.ToString( "f3" ).PadLeft( 15 )
                  +  "  yards\n" ) ;
      Console.Write( distance_in_feet.ToString( "f3" ).PadLeft( 15 )
                  +  "  feet\n"
                  +  distance_in_inches.ToString( "f3" ).PadLeft( 15 )
                  +  "  inches\n" ) ;
      Console.Write( distance_in_light_years.ToString( "e5" ).PadLeft( 15 )
                  +  "  light years \n" ) ;
   }
}



