
//  playtime.cpp (c) 1998-2002 Kari Laitinen

#include  <iostream.h>
#include  <time.h>
#include  <conio.h>

int main()
{
   time_t  previous_time,  current_time ;
   long    loop_counter  =  0 ;

   cout << "\n loop_counter   current_time     asctime \n\n" ;

   time( &previous_time ) ;

   while ( ! kbhit() )
   {
      loop_counter  ++  ;

      time( &current_time ) ;

      if ( ( current_time  >  previous_time )  &&
           ( ( current_time  %  5 )  ==  0  )  )
      {
         cout << "     "  << loop_counter 
              << "     "  << current_time  <<  "        "
              << asctime( localtime( &current_time ) )  ;

         previous_time  =  current_time ;
         loop_counter   =  0 ;
      }
   }
}



