
//  stopwatch.cpp (c) 2002 Kari Laitinen

#include  <iostream.h>
#include  <iomanip.h>
#include  <time.h>
#include  <conio.h>

int main()
{
   time_t  start_time,  stop_time ;
   long    elapsed_seconds   =  0 ;

   cout << "\n Start the stopwatch by pressing a key ...\n\n"
        << setfill( '0' ) ;

   while ( ! kbhit() )
   {
      ;
   }

   time( &start_time ) ;

   getch() ;  // Character is read here without storing it.

   while ( ! kbhit() )
   {
      time( &stop_time ) ;

      if ( ( stop_time - start_time )  > elapsed_seconds )
      {
         elapsed_seconds  =  stop_time - start_time ;

         cout << "\r "  <<  setw( 2 )  <<  elapsed_seconds / 60 
              << ":"    <<  setw( 2 )  <<  elapsed_seconds % 60 ;
      }
   }

   getch() ;

   cout << "\n\n" ;
}



