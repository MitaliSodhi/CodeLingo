
//  showtime.cpp (c) 1998-2002 Kari Laitinen

#include  <iostream.h>
#include  <iomanip.h>
#include  <time.h>

void  get_current_time( int&  hours,
                        int&  minutes,
                        int&  seconds  )
{
   time_t  current_time  ;

   time( &current_time ) ;

   hours    =  localtime( &current_time ) -> tm_hour  ;
   minutes  =  localtime( &current_time ) -> tm_min  ;
   seconds  =  localtime( &current_time ) -> tm_sec  ;
}

void  get_current_date( int&  day_of_month,
                        int&  month_index,
                        int&  current_year,
                        int&  day_of_week_index ) 
{
   time_t  current_time  ;

   time( &current_time ) ;

   day_of_month      =  localtime( &current_time ) -> tm_mday  ;
   month_index       =  localtime( &current_time ) -> tm_mon  ;
   current_year      =  localtime( &current_time ) -> tm_year + 1900 ;
   day_of_week_index =  localtime( &current_time ) -> tm_wday ;
}



int main()
{
   char*  names_of_days_of_week[]  =

      { "Sunday",  "Monday", "Tuesday", "Wednesday", "Thursday",
        "Friday",  "Saturday" } ;

   char*  names_of_months[]  =

      { "January", "February", "March", "April", "May", "June",
        "July", "August", "September", "October", "November",
        "December"  }  ;

   int  current_hours,   current_minutes, current_seconds,
        current_day,     current_month,   current_year,
        day_of_week ;

   get_current_time( current_hours,
                     current_minutes,
                     current_seconds   ) ;

   get_current_date( current_day,
                     current_month,
                     current_year,
                     day_of_week  ) ;

   cout << setfill( '0' ) << "\n Current time is:  "<< setw( 2 )
        << current_hours  << ":"  << setw( 2 ) << current_minutes
        << ":"  << setw( 2 ) <<  current_seconds ;

   cout << "\n\n Current date is:  " 
        << names_of_days_of_week[ day_of_week ]  <<  ", day "
        << current_day  <<  " of "
        << names_of_months[ current_month ] <<  " in year "
        << current_year <<  ".\n" ;
}


