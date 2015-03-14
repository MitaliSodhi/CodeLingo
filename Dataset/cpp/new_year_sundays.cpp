
//  new_year_sundays.cpp  (c) 1997-2002 Kari Laitinen

#include  <iostream.h>
#include  "class_date.h"

int main()
{
   char  given_date_as_string[ 20 ] ;

   cout <<"\n This program can print you a list of 5 dates" 
          "\n that are Sundays and New Year's Days."
          "\n Please, type in a date from which you want"
          "\n the calculation to begin. Type in the date either"
          "\n in form DD.MM.YYYY or in form MM/DD/YYYY and use"
          "\n two digits for days and months and four digits"
          "\n for the year:  " ;

   cin  >>  given_date_as_string ;

   Date  given_date( given_date_as_string ) ;

   int  year_to_increment  =  given_date.year() + 1 ;

   int   number_of_dates_to_print  =  5 ;

   cout << "\n The following are New Year's Sundays \n" ;

   while ( number_of_dates_to_print  >  0 )
   {
      Date new_year_day( 1, 1, year_to_increment ) ;

      if ( new_year_day.index_for_day_of_week()  ==  6 )
      {
         cout << "\n    "  <<  new_year_day  <<  ", " ;
         new_year_day.print_day_of_week( cout ) ;
         number_of_dates_to_print  --  ;
      }

      year_to_increment  ++  ;
   }
}



