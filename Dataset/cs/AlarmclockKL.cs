
//  Alarmclock.cs (c) 2004 Kari Laitinen

//  http://www.naturalprogramming.com

//  2004-02-20  File created.
//  2004-11-25  Last modification.

//  This is a solution to Exercise 16-8.

using System ;
using System.Threading ;

class AlarmclockKL
{
   static bool alarming_mode_activated ;

   static int  alarm_hour ;
   static int  alarm_minute ;

   static void measure_time_and_alarm()
   {
      bool  it_is_time_to_give_alarm  =  false ;

      while ( alarming_mode_activated   ==  true  &&
              it_is_time_to_give_alarm  ==  false )
      {
         DateTime  current_time  =  DateTime.Now ;

         if ( current_time.Hour    ==  alarm_hour  &&
              current_time.Minute  ==  alarm_minute )
         {
            it_is_time_to_give_alarm  =  true ;
         }

         Console.Write( "\r  Current time:  "
                     +  current_time.Hour.ToString( "D" )  +  ":"
                     +  current_time.Minute.ToString( "D2" ) 
                     +  "     Alarm time:  "
                     +  alarm_hour.ToString( "D" )  +  ":"
                     +  alarm_minute.ToString(  "D2" )  ) ;

         Thread.Sleep( 5000 ) ; // Check time once in every 5 seconds.
      }

      while ( alarming_mode_activated  ==  true )
      {
         Console.Write( "\a" ) ;  // Output the Alert sound 0x07

         Thread.Sleep( 1000 ) ;   // Alert is given once a second.
      }
   }


   static void Main()
   {
      Thread thread_to_measure_time_and_alarm  = 
               new Thread( new ThreadStart( measure_time_and_alarm ) ) ;

      Console.Write( "\n Give alarm hour between 0 ... 23   : " ) ;

      alarm_hour  =  Convert.ToInt32( Console.ReadLine() ) ;

      Console.Write( "\n Give alarm minute between 0 ... 59 : " ) ;

      alarm_minute  =  Convert.ToInt32( Console.ReadLine() ) ;

      Console.Write( "\n Press the Enter key to stop the alarm sound "
                  +  "\n or deactivate the alarm clock.\n\n" ) ;

      alarming_mode_activated  =  true ;

      thread_to_measure_time_and_alarm.Start() ;

      string  any_string_from_keyboard  =  Console.ReadLine() ;

      alarming_mode_activated  =  false ;
   }
}




