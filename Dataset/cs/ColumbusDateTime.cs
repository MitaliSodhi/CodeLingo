
//  ColumbusDateTime.cs  (c) 2003 Kari Laitinen

//  www.naturalprogramming.com

using System ;

class ColumbusDateTime
{
   static void Main()
   {
      DateTime date_of_discovery_of_america = new DateTime( 1492, 10, 12 ) ;

      DateTime date_of_first_moon_landing  =  new DateTime( 1969,  7, 20 ) ;

      Console.Write(
          "\n   Christopher Columbus discovered America on "
        +  date_of_discovery_of_america.ToShortDateString()
        + "\n   That was a " + date_of_discovery_of_america.DayOfWeek ) ;


      Console.Write(
          "\n\n   Apollo 11 landed on the moon on "
        +  date_of_first_moon_landing.ToShortDateString()
        + "\n   That was a " + date_of_first_moon_landing.DayOfWeek ) ;

      TimeSpan  distance_between_voyages  =

         date_of_first_moon_landing  -  date_of_discovery_of_america  ;

      Console.Write( "\n\n   America was discovered "
                  +  distance_between_voyages.Days  +  " days"
                  +  "\n   before the first moon landing.\n" ) ;
   }
}


