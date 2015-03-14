
//  birthdays.cpp  (c) 1998-2002 Kari Laitinen

#include  <iostream.h>
#include  "class_date.h"

int main()
{
   char  date_of_birth_as_string[ 20 ] ;

   cout << "\n Type in your date of birth either as DD.MM.YYYY "
           "\n or as MM/DD/YYYY. Use two digits for days and months "
           "\n and four digits for the year:  " ;

   cin  >>  date_of_birth_as_string ;

   Date  date_of_birth( date_of_birth_as_string ) ;

   cout << "\n   You were born on a " ;
   date_of_birth.print_day_of_week( cout ) ;
   cout << "\n   Here are your days to celebrate. You are\n" ;

   int  years_to_celebrate  =  10 ;

   while ( years_to_celebrate  <  80 )
   {
      Date date_to_celebrate( date_of_birth.day(),
                              date_of_birth.month(),
                              date_of_birth.year() + years_to_celebrate,
                              date_of_birth.get_date_print_format()) ;

      cout  << "\n   "    <<  years_to_celebrate
            << " years old on "  <<  date_to_celebrate  << " (" ;

      date_to_celebrate.print_day_of_week( cout ) ;
      cout  << ")" ;

      years_to_celebrate  =  years_to_celebrate  +  10 ;
   }
}


