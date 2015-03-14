
//  Distance.cs  (c) 2002 Kari Laitinen

using System ;

class Distance
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

      Console.Write( "{0, 15:f3}  kilometers\n",distance_in_kilometers) ;
      Console.Write( "{0, 15:f3}  miles \n",    distance_in_miles ) ;
      Console.Write( "{0, 15:f3}  yards \n",    distance_in_yards ) ;

      Console.Write( "{0, 15:f3}  feet  \n{1, 15:f3}  inches \n",
                     distance_in_feet, distance_in_inches ) ;

      Console.Write( "{0, 15:e5}  light years \n",
                                       distance_in_light_years) ;
   }
}



