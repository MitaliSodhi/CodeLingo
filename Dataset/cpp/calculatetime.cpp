
//  calculatetime.cpp (c) 1999-2002 Kari Laitinen

#include  <iostream.h>
#include  <iomanip.h>
#include  <time.h>

#include  "class_date.h"

// This program demonstrates how a Date object can be used
// to calculate the current time from the second-based
// time information received from the operating system.
// In other programs, we have used standard function "localtime"
// to do the job that is done here "manually" with a Date
// object.

int main()
{
   time_t  seconds_to_decrement  ;

   time( &seconds_to_decrement ) ;

   // seconds_to_decrement contains now the seconds that have
   // elapsed since 1.1.1970 at 00:00:00 o'clock.
   // Function "time" got this information by discussing
   // with the operating system of the computer.
   // We can calculate the current date and time from these seconds 
   // when we know that every day consists of 86400 secons,
   // every hour of 3600 seconds, and every minute of 60 seconds.

   Date  date_to_increment( 1, 1, 1970 ) ;

   while ( seconds_to_decrement  >=  86400 )
   {
      date_to_increment.increment() ;
      seconds_to_decrement  =  seconds_to_decrement  -  86400 ;
   }

   int  current_hours    =  0 ;

   while ( seconds_to_decrement  >=  3600 )
   {
      current_hours  ++  ;
      seconds_to_decrement  =  seconds_to_decrement  -  3600 ;
   }

   int  current_minutes  =  0 ;

   while ( seconds_to_decrement  >=  60 )
   {
      current_minutes  ++  ;
      seconds_to_decrement  =  seconds_to_decrement  -  60 ;
   }

   int  current_seconds  =  seconds_to_decrement ;

   cout << "\n It is now "  << date_to_increment
        << ". The time is " << current_hours  << ":"
        << current_minutes  << ":" << current_seconds << "\n\n" ;
}


