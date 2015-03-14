
//  now.cpp  (c) 2000 Kari Laitinen

#include  <iostream.h>
#include  <iomanip.h>

#include  "class_date.h"
#include  "class_current_date.h"

int main()
{
   Date  date_of_birth( "08.12.1959" ) ;

   Date  date_to_increment( date_of_birth ) ;

   Current_date  date_now ;

   int   day_counter  =  0 ;

   while  (  date_to_increment  <  date_now  )
   {
      date_to_increment.increment() ;
      day_counter  ++ ;

      if ( ( day_counter % 2000 )  ==  0 )
      {
         cout << "\n  You are "  <<  day_counter  <<  " days old on "  
              << date_to_increment ;
      }
   }

   cout  <<  "\n\n  Today "  <<  date_to_increment 
         <<  " you are "  <<  day_counter  <<  " days old. " ;

   int  years_of_age, months_of_age, days_of_age ;

   date_to_increment.get_distance_to( date_of_birth,
                                      years_of_age,
                                      months_of_age,
                                      days_of_age ) ;

   cout  <<  "\n  That is " << years_of_age  << " years, "
         <<  months_of_age  <<  " months, and "
         <<  days_of_age    <<  " days. \n " ;
}

