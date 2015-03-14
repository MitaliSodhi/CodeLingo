
//  Showtime.cs (c) 2003 Kari Laitinen

//  www.naturalprogramming.com

using System ;

class Showtime
{
   static void Main()
   {
      string[]  names_of_months  =

      { "January", "February", "March", "April", "May", "June",
        "July", "August", "September", "October", "November",
        "December"  }  ;

      DateTime  date_and_time_now  =  DateTime.Now ;

      Console.Write( "\n Current time is:  "
       +  date_and_time_now.Hour + ":"
       +  date_and_time_now.Minute.ToString().PadLeft( 2,'0') + ":"
       +  date_and_time_now.Second.ToString().PadLeft( 2,'0') ) ;

      Console.Write( "\n\n Current date is:  " 
        +  date_and_time_now.DayOfWeek 
        +  ", day " + date_and_time_now.Day  +  " of "
        +  names_of_months[ date_and_time_now.Month - 1 ] + " in year "
        +  date_and_time_now.Year +  ".\n" ) ;

      Console.Write( "\n Index for day of week is: "
                  +  (int) date_and_time_now.DayOfWeek  +  "\n" ) ;

      Console.Write( "\n ToShortTimeString() returns: "
                  +  date_and_time_now.ToShortTimeString() ) ;
      Console.Write( "\n ToLongTimeString()  returns: "
                  +  date_and_time_now.ToLongTimeString() ) ;
      Console.Write( "\n ToShortDateString() returns: "
                  +  date_and_time_now.ToShortDateString() ) ;
      Console.Write( "\n ToLongDateString()  returns: "
                  +  date_and_time_now.ToLongDateString() ) ;
      Console.Write( "\n ToString()          returns: "
                  +  date_and_time_now.ToString() ) ;
      Console.Write( "\n ToUniversalTime()   returns: "
                  +  date_and_time_now.ToUniversalTime() ) ;
   }
}


