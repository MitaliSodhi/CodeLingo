
//  Columbus.cs  (c) 2003 Kari Laitinen

//  Compilation: csc Columbus.cs Date.cs

using System ;

class Columbus
{
   static void Main()
   {
      Date date_of_discovery_of_america = new Date( "10/12/1492" ) ;

      Date date_of_first_moon_landing  =  new Date( "20.07.1969" ) ;

      Console.Write(
          "\n   Christopher Columbus discovered America on "
        +  date_of_discovery_of_america  +  "\n   That was a "
        +  date_of_discovery_of_america.get_day_of_week() ) ;

      Console.Write(
          "\n\n   Apollo 11 landed on the moon on "
        +  date_of_first_moon_landing  +  "\n   That was a "
        +  date_of_first_moon_landing.get_day_of_week() ) ;

      int  years_between, months_between, days_between ;

      date_of_discovery_of_america.get_distance_to( 
                                    date_of_first_moon_landing,
                                    out years_between, 
                                    out months_between,
                                    out days_between  ) ;

      Console.Write( "\n\n   America was discovered "
                  +  years_between   +  " years, "
                  +  months_between  +  " months, and "
                  +  days_between    +  " days"
                  +  "\n   before the first moon landing.\n" ) ;
   }
}


