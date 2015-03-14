
//  Playtime.cs (c) 2004 Kari Laitinen

//  www.naturalprogramming.com

//  WARNING!  It may be better not to run this program
//  for a long time on your computer because the infinite
//  loop of the program consumes quite a lot of processing
//  power, and that may result in that the electronics 
//  of your computer gets too hot. In my computer the cooling
//  fan of the processor starts operating immediately when
//  I start executing this program.

using System ;
using System.Threading ;

class Playtime
{
   static bool must_display_ticks_and_time ;

   static void display_ticks_and_time()
   {
      long  previous_time_ticks,  current_time_ticks ;
      long  loop_counter  =  0 ;

      Console.Write(
        "\n loop_counter   current_time_ticks      ToString() \n" ) ;

      previous_time_ticks  =  DateTime.Now.Ticks ;

      while ( must_display_ticks_and_time  ==  true )
      {
         loop_counter  ++  ;

         current_time_ticks  =  DateTime.Now.Ticks ;

         if ( ( current_time_ticks  -  previous_time_ticks )  >  50000000  &&
              ( ( current_time_ticks  /  10000000 ) %  5 )  ==  0 ) 
         {
            Console.Write( "\n   "  + loop_counter 
                        +  "     "  + current_time_ticks  +  "      "
                        +  DateTime.Now.ToString() )  ;

            previous_time_ticks  =  current_time_ticks ;
            loop_counter   =  0 ;
         }
      }
   }

   static void Main()
   {
      Thread thread_to_display_ticks_and_time  = 
               new Thread( new ThreadStart( display_ticks_and_time ) ) ;

      Console.Write( "\n Press the Enter key to stop the program.\n" ) ;

      must_display_ticks_and_time  =  true ;

      thread_to_display_ticks_and_time.Start() ;

      string  any_string_from_keyboard  =  Console.ReadLine() ;

      must_display_ticks_and_time  =  false ;
   }
}




