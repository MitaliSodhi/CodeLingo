
//  friday13.cpp  (c) 1997-2002 Kari Laitinen

//  20.10.1997  file created
//  10.12.2002  Last modification

#include  <iostream.h>
#include  "class_date.h"

int main()
{
   char  given_date_as_string[ 20 ] ;

   cout <<"\n This program can print you a list of 10 dates" 
          "\n that are Fridays and 13th days of a month."
          "\n Please, type in a date from which you want"
          "\n the calculation to begin. Type in the date either"
          "\n in form DD.MM.YYYY or in form MM/DD/YYYY and use"
          "\n two digits for days and months and four digits"
          "\n for the year:  " ;

   cin  >>  given_date_as_string ;

   Date  date_to_increment( given_date_as_string ) ;

   int   number_of_friday13_dates_to_print  =  10 ;

   cout << "\n It is a common belief that you may have"
           "\n bad luck on the following dates:\n" ;

   while ( number_of_friday13_dates_to_print  >  0 )
   {
      while ( date_to_increment.index_for_day_of_week()  !=  4  ||
              date_to_increment.day()  !=  13   )
      {
         date_to_increment.increment() ;
      }

      cout << "\n    "  <<  date_to_increment  <<  ", " ;
      date_to_increment.print_day_of_week( cout ) ;
      date_to_increment.increment() ;
      number_of_friday13_dates_to_print  --  ;
   }
}



