
//  alarmclock.cpp (c) 2001-2002 Kari Laitinen

#include  <iostream.h>
#include  <iomanip.h>
#include  <stdlib.h>
#include  <time.h>
#include  <conio.h>

void  get_current_time( int&  hours,
                        int&  minutes,
                        int&  seconds   )
{
   time_t  current_time  ;

   time( &current_time ) ;

   hours    =  localtime( &current_time ) -> tm_hour  ;
   minutes  =  localtime( &current_time ) -> tm_min  ;
   seconds  =  localtime( &current_time ) -> tm_sec  ;
}

int main( int    number_of_command_line_arguments,
          char*  command_line_arguments[] )
{
   int  alarm_hour, alarm_minute ;

   if ( number_of_command_line_arguments  ==  3 )
   {
      alarm_hour    =  atoi( command_line_arguments[ 1 ] ) ;
      alarm_minute  =  atoi( command_line_arguments[ 2 ] ) ;

   }
   else
   {
      cout << "\n Give alarm hour   : " ;
      cin  >>  alarm_hour ;
      cout << "\n Give alarm minute : " ;
      cin  >>  alarm_minute ;
   }

   cout << "\n\n" ;

   int  current_hour, current_minute,  current_second ;

   do
   {
      get_current_time( current_hour,
                        current_minute,
                        current_second ) ;
   }
    while ( ( current_hour    !=  alarm_hour  ||
              current_minute  !=  alarm_minute   ) &&
            ! kbhit() ) ;


   time_t  current_time, previous_time ;

   time( &previous_time ) ;

   while ( ! kbhit() )
   {
      time( &current_time ) ;

      if ( current_time  >  previous_time )  
      {
         if ( ( current_time  % 2 )  == 0 )
         {
            cout << "\r ALARM ! \x07" ;
         }
         else
         {
            cout << "\r         \x07" ;
         }

         previous_time  =  current_time ;
      }
   }

   getch() ;
}



