
//  clock.cpp  (c)  1998-2002 Kari Laitinen

//  A graphical "clock" will be printed by this program.

#include  <iostream.h>
#include  <iomanip.h>
#include  <conio.h>  //  Functions clrsrc, kbhit, gotoxy, etc.
#include  <time.h>

#define   DELAYING                         1
#define   DELAY_ENDED_IN_NORMAL_WAY        2
#define   SOME_KEY_WAS_PRESSED             3

bool
delay_while_keys_not_pressed( int  number_of_seconds_to_wait )
{
   //  This function returns true when no keys were pressed
   //  during the specified delay time.

   time_t  starting_time, current_time ;
   char    character_from_keyboard ;

   time( &starting_time ) ;

   int   delay_status  =  DELAYING ;

   while (  delay_status  ==  DELAYING  )
   {
      time( &current_time ) ;

      if ( ( current_time - starting_time )
                            >= number_of_seconds_to_wait )
      {
         delay_status  =  DELAY_ENDED_IN_NORMAL_WAY ;
      }

      if  ( kbhit() )
      {
         delay_status  =  SOME_KEY_WAS_PRESSED ;
         character_from_keyboard  =  getch() ;
      }
   }

   return ( delay_status  ==  DELAY_ENDED_IN_NORMAL_WAY ) ;
}


void display_simple_clock()
{
   struct  Coordinates 
   {
      int   x_coordinate ;
      int   y_coordinate ;
   } ;

   Coordinates  clock_coordinates []   =
   {
      40,  4,  43,  4,  46,  4,  49,  4,  52,  4,
      55,  4,  58,  4,  61,  4,  63,  5,  63,  6,
      63,  7,  63,  8,  63,  9,  63, 10,  63, 11,
      63, 12,  63, 13,  63, 14,  63, 15,  63, 16,
      63, 17,  63, 18,  63, 19,  63, 20,  61, 21,
      58, 21,  55, 21,  52, 21,  49, 21,  46, 21,
      43, 21,  40, 21,  37, 21,  34, 21,  31, 21,
      28, 21,  25, 21,  22, 21,  20, 20,  20, 19,
      20, 18,  20, 17,  20, 16,  20, 15,  20, 14,
      20, 13,  20, 12,  20, 11,  20, 10,  20,  9,
      20,  8,  20,  7,  20,  6,  20,  5,  22,  4,
      25,  4,  28,  4,  31,  4,  34,  4,  37,  4,
      40,  4,  43,  4 } ;

   time_t  current_time ;

   time( &current_time ) ;

   int seconds_of_current_time  =
                     localtime( &current_time ) -> tm_sec ;

   if ( seconds_of_current_time  ==  1 )
   {
      clrscr() ;
   }
   gotoxy( 38, 12 ) ;
   
   cout << setfill( '0' )
     << setw( 2 ) << localtime( &current_time ) -> tm_hour << ":"
     << setw( 2 ) << localtime( &current_time ) -> tm_min  << ":"
     << setw( 2 ) << seconds_of_current_time  ;

   gotoxy(

      clock_coordinates[ seconds_of_current_time ].x_coordinate,
      clock_coordinates[ seconds_of_current_time ].y_coordinate ) ;

   cout << setw( 2 )  <<  seconds_of_current_time  ;
}

int main()
{
   cout << "\n After 7 seconds this program starts displaying"
        << "\n a simple clock. You may need to wait a minute"
        << "\n to see the clock to become clear. "
        << "\n Press any key to start the clock immediately."
        << "\n Press any key to stop the clock. \n\n" ;

   delay_while_keys_not_pressed( 7 ) ;

   while ( delay_while_keys_not_pressed( 1 ) )
   {
      display_simple_clock() ;
   }
}


