
//  columbus.cpp  (c) 1998-2002 Kari Laitinen

#include  <iostream.h>
#include  "class_date.h"

int main()
{
   Date  date_of_discovery_of_america( "10/12/1492" ) ;

   Date  date_of_first_moon_landing( "20.07.1969" ) ;

   cout << "\n   Christopher Columbus discovered America on "
        <<  date_of_discovery_of_america  << "\n   That was a " ;

   date_of_discovery_of_america.print_day_of_week( cout ) ;

   cout << "\n\n   Apollo 11 landed on the moon on "
        <<  date_of_first_moon_landing  << "\n   That was a " ;

   date_of_first_moon_landing.print_day_of_week( cout ) ;

   int  years_between, months_between, days_between ;

   date_of_discovery_of_america.get_distance_to( 
                                   date_of_first_moon_landing,
                                   years_between, 
                                   months_between,
                                   days_between  ) ;

   cout << "\n\n   America was discovered "
        << years_between   <<  " years, "
        << months_between  <<  " months, and "
        << days_between    <<  " days"
        << "\n   before the first moon landing.\n" ;
}


