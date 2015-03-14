
//  PlaytimeModified.cs (c) 2004 Kari Laitinen

//  http://www.naturalprogramming.com

//  2004-02-20  File created.
//  2004-11-25  Last modification.

//  This is a solution to the exercise 16-6.

using System ;
using System.Threading ;

class PlaytimeModified
{
   static bool must_display_ticks_and_time ;

   static void display_ticks_and_time()
   {
      long  previous_time_ticks,  current_time_ticks ;
      long  loop_counter  =  0 ;

      Console.Write(
        "\n    nanoseconds   current_time_ticks      ToString() \n" ) ;

      previous_time_ticks  =  DateTime.Now.Ticks ;

      while ( must_display_ticks_and_time  ==  true )
      {
         loop_counter  ++  ;

         current_time_ticks  =  DateTime.Now.Ticks ;

         if ( ( current_time_ticks  -  previous_time_ticks )  >  50000000  &&
              ( ( current_time_ticks  /  10000000 ) %  5 )  ==  0 ) 
         {
            double  time_to_execute_the_loop_once  =

            ( ( (double) ( current_time_ticks  -
                                   previous_time_ticks ) ) * 100.0 )

                    / (double) loop_counter ;

            //  "F4" says that the number is shown with 4 decimals.

            Console.Write( "\n "
                        + time_to_execute_the_loop_once.ToString( "F4" )
                                                       .PadLeft( 12 ) 
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




