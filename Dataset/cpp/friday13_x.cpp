
//  friday13_x.cpp  (c) 1997-2002 Kari Laitinen

//  13.11.2001  file created
//  01.08.2002  Last modification

//  This program is just used to test the improved Date
//  class in class_date_x.h

#include  <iostream.h>
#include  "class_date_x.h"

int main()
{

   cout <<"\n This program can print you a list of 10 dates" 
          "\n that are Fridays and 13th days of a month."
          "\n Please, type in a date from which you want"
          "\n the calculation to begin. Type in the date either"
          "\n in form DD.MM.YYYY or in form MM/DD/YYYY and use"
          "\n two digits for days and months and four digits"
          "\n for the year:  " ;

   Date  date_to_increment ;

   //  Because operator >> is overloaded in the improved
   //  version of class Date, it is possible to input a
   //  Date object with operator >>.

   cin  >>  date_to_increment  ;

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



