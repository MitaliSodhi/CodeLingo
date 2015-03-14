
//  times.cpp (c) 2000-2002 Kari Laitinen

#include  <iostream.h>
#include  <iomanip.h>
#include  <time.h>

class  Current_time
{
protected:
   int  current_hours ;
   int  current_minutes ;
   int  current_seconds ;

public:
   Current_time() ;

   virtual void print() = 0 ;
} ;


Current_time::Current_time()
{
   // Function time gives us seconds that have elapsed
   // since 1.1.1970 00:00:00. Function localtime converts
   // these seconds to more meaningful time units.

   time_t  seconds_since_1970  ; 

   time( &seconds_since_1970 ) ;

   current_hours    = localtime( &seconds_since_1970 ) -> tm_hour  ;
   current_minutes  = localtime( &seconds_since_1970 ) -> tm_min  ;
   current_seconds  = localtime( &seconds_since_1970 ) -> tm_sec  ;
}

//  It is not entirely true that the 12-hour a.m./p.m. time
//  would be used everywhere in America, and the 24-hour time
//  would be used everywhere in Europe. The names American_time
//  and European_time just happen to be nice names to
//  distinguish these two different ways to display time.


class  American_time  :  public  Current_time
{
public:

   void  print() ;
} ;

void  American_time::print()
{
   int  american_hours[]  =

     { 12, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11,
       12, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11  } ;

   cout << setfill( '0' )    << american_hours[ current_hours ]
        << ":"  << setw( 2 ) << current_minutes
        << ":"  << setw( 2 ) << current_seconds  ;

   if ( current_hours  <  12 )
   {
      cout << " a.m." ;
   }
   else
   {
      cout << " p.m." ;
   }
}


class  European_time  :  public  Current_time
{
public:

   void  print() ;
} ;

void  European_time::print()
{
   cout << setfill( '0' )    << current_hours
        << ":"  << setw( 2 ) << current_minutes
        << ":"  << setw( 2 ) << current_seconds  ;
}



int main()
{
   Current_time*   time_to_show ;

   cout << "\n Type 12 to see time in 12-hour a.m./p.m format."
           "\n Any other number gives the 24-hour format. " ;

   int  user_response ;
   cin  >>  user_response ;

   if ( user_response  ==  12 )
   {
      time_to_show  =  new  American_time ;
   }
   else
   {
      time_to_show  =  new  European_time ;
   }

   cout << "\n  The time is now " ;

   time_to_show  ->  print() ;

   cout << "\n" ;

   delete  time_to_show ;
}


