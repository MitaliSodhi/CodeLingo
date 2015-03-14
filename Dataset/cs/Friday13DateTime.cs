
//  Friday13DateTime.cs  (c) 1997-2004 Kari Laitinen

//  www.naturalprogramming.com

using System ;

class Friday13DateTime
{
   static void Main()
   {
      DateTime  date_to_increment  =  DateTime.Now ;

      int   number_of_friday13_dates_to_print  =  10 ;

      Console.Write( "\n The following are the next such dates"
                   + "\n that are Fridays and the 13th days"
                   + "\n of a month: \n" ) ;

      while ( number_of_friday13_dates_to_print  >  0 )
      {
         while ( ( (int) date_to_increment.DayOfWeek )  !=  5  ||
                         date_to_increment.Day  !=  13   )
         {
            date_to_increment  =  date_to_increment.AddDays( 1 ) ;
         }

         Console.Write( "\n   " + 
                        date_to_increment.ToShortDateString() +
                        ", "  +  date_to_increment.DayOfWeek ) ;
         date_to_increment  =  date_to_increment.AddDays( 27 ) ;
         number_of_friday13_dates_to_print  --  ;
      }
   }
}




