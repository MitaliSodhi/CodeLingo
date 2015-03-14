
//  Clock.cs  (c) 2004 Kari Laitinen

//  06.12.2002  File created.
//  19.02.2004  Last modification.

//  A graphical "clock" will be printed by this program.

using System ;
using System.Threading ;

class Clock
{
   static void show_seconds()
   {
      while ( true )
      {
         DateTime  current_time  =  DateTime.Now ;

         int seconds_of_current_time  =  current_time.Second ;

         if ( ( seconds_of_current_time  %  20 )  ==  0 )
         {
            Console.Write( "\n" ) ;
         }

         Console.Write( " " + seconds_of_current_time.ToString( "D2" ) ) ;

         Thread.Sleep( 1000 ) ;  //  Delay of one second 
      }
   }

   static void show_full_time_info()
   {
      int  seconds_to_first_time_printing  =  60 - DateTime.Now.Second ;

      Thread.Sleep( seconds_to_first_time_printing * 1000 ) ;

      while ( true )
      {
         Console.Write( "\n\n "
                     +  DateTime.Now.ToLongTimeString()  +  "\n\n" ) ;

         Thread.Sleep( 60000 ) ;  //  Delay of 60 seconds
      }
   }



   static void Main()
   {
      Thread thread_to_show_seconds  = 
                new Thread( new ThreadStart( show_seconds ) ) ;

      Thread thread_to_show_full_time_info  =
                new Thread( new ThreadStart( show_full_time_info ) ) ;

      Console.Write( "\n Press the Enter key to stop the clock.\n\n" ) ;

      thread_to_show_seconds.Start() ;
      thread_to_show_full_time_info.Start() ;

      string  any_string_from_keyboard  =  Console.ReadLine() ;

      thread_to_show_seconds.Abort() ;
      thread_to_show_full_time_info.Abort() ;
   }
}


