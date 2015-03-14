
/*  lifetime.cpp  (c) 2001-2002 Kari Laitinen

    12.07.2001  File created.
    01.08.2002  Last modification.

    Notes:

    This program does not check whether the first date is
    earlier than the second date. That should be checked
    to make the program less error prone.
*/

#include  <iostream.h>
#include  <iomanip.h>
#include  "class_date.h"

int main( int   number_of_command_line_arguments, 
          char* command_line_arguments[] )
{
   if ( number_of_command_line_arguments  ==  3 )
   {
      Date  date_of_birth( command_line_arguments[ 1 ] ) ;
      Date  date_of_death( command_line_arguments[ 2 ] ) ;

      Date  date_to_increment( date_of_birth ) ;

      int   number_of_days_lived  =  0 ;

      while ( date_to_increment.day()   !=  date_of_death.day() ||
              date_to_increment.month() !=  date_of_death.month() ||
              date_to_increment.year()  !=  date_of_death.year() )
      {
         number_of_days_lived  ++  ;

         date_to_increment.increment() ;
      }

      int  full_years, leftover_months, leftover_days ;

      date_of_birth.get_distance_to( date_of_death,
                                     full_years,
                                     leftover_months,
                                     leftover_days ) ; 

      cout << "\n The person lived " << number_of_days_lived << " days." 
           << "\n That is " << full_years << " years, "
           << leftover_months << " months, and "
           << leftover_days << " days.\n" ;
   }
   else
   {
      cout <<  "\n\n  Wrong number of command line arguments. \n " ;
   }
}


