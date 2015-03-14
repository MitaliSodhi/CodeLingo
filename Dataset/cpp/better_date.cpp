
//  better_date.cpp (c) 2000-2002 Kari Laitinen

#include  <iostream.h>

#include  "class_date.h"

class  Better_date  :  public  Date
{
public:
   Better_date( char date_as_string[] )
        :  Date( date_as_string )  {}

   void print_with_month_name() ;
   void print_in_american_format() ;
} ;

void Better_date::print_with_month_name()
{
   char*  names_of_months[]  =  

      { "January", "February", "March", "April",
        "May", "June", "July", "August",
        "September", "October", "November", "December" } ;

   cout <<  names_of_months[ this_month - 1 ]  << " "
        <<  this_day  <<  ", "  <<  this_year ;
}

void Better_date::print_in_american_format()
{
   int  saved_date_print_format  =  date_print_format ;

   date_print_format  =  'A' ;

   cout << *this ;

   date_print_format  =  saved_date_print_format ;
}

int main()
{
   Better_date  birthday_of_einstein( "14.03.1879" ) ;

   cout << "\n Albert Einstein was born on "
        << birthday_of_einstein  ;

   birthday_of_einstein.increment() ;

   cout << "\n Albert was one day old on " ;
   birthday_of_einstein.print_with_month_name() ;

   birthday_of_einstein.increment() ;

   cout << "\n Albert was two days old on " ;
   birthday_of_einstein.print_in_american_format() ;
}


