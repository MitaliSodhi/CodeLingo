
//  Stopwatch.cs (c) 2004 Kari Laitinen

//  http://www.naturalprogramming.com

//  2004-02-19  File created.
//  2004-11-25  Last modification.

//  Solution to exercise 16-7


using System ;
using System.Threading ;

class StopwatchKL
{
   static bool must_measure_time ;

   static void measure_time()
   {
      long  start_time_ticks,  current_time_ticks ;
      long  elapsed_milliseconds ;

      Console.Write( "\n" ) ;

      start_time_ticks  =  DateTime.Now.Ticks ;

      while ( must_measure_time  ==  true )
      {
         current_time_ticks  =  DateTime.Now.Ticks ;

         elapsed_milliseconds  =  ( current_time_ticks  -  start_time_ticks )
                                  / 10000 ;

         Console.Write( "\r  "
              +  elapsed_milliseconds / 60000   //  minutes
              +  ":"
              +  (( elapsed_milliseconds % 60000 ) / 1000 ).ToString( "D2" )
              +  ":"
              +  (( elapsed_milliseconds % 1000 ) / 10 ).ToString( "D2" ) ) ;

         Thread.Sleep( 10 ) ;  //  Sleeping 0.01 seconds
      }
   }

   static void Main()
   {
      Thread thread_to_measure_time  = 
               new Thread( new ThreadStart( measure_time ) ) ;

      Console.Write( "\n Press the Enter key to start the stopwatch. " ) ;

      string  any_string_from_keyboard  =  Console.ReadLine() ;

      Console.Write( "\n Press the Enter key to stop the stopwatch.\n" ) ;

      must_measure_time  =  true ;

      thread_to_measure_time.Start() ;

      any_string_from_keyboard  =  Console.ReadLine() ;

      must_measure_time  =  false ;
   }
}




