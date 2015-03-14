
//  ColumbusWithDateISO.cs  (c) 2003 Kari Laitinen

//  http://www.naturalprogramming.com

//  2004-11-12  File created.
//  2004-11-12  Last modification.

//  Compilation: csc ColumbusWithDateISO.cs DateISO.cs

using System ;

class ColumbusWithDateISO
{
   static void Main()
   {
      DateISO date_of_discovery_of_america = new DateISO( "1492-10-12" ) ;

      DateISO date_of_first_moon_landing  =  new DateISO( "1969-7-20" ) ;

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


