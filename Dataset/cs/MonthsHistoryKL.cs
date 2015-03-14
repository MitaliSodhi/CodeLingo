
//  MonthsHistoryKL.cs  (c) 2004 Kari Laitinen

//  http://www.naturalprogramming.com

//  2004-06-10  File created.
//  2004-10-31  Last modification.

using System ;

class MonthsHistoryKL
{
   static void Main()
   {
      string[]  names_of_months  =

         { "January", "February", "March", "April", "May", "June",
           "July", "August", "September", "October", "November",
           "December"  }  ;

      string[]  history_of_months =
      {  "month of Roman god Janus",      // January
         "last month in Roman calendar",  // February
         "month of Roman war god Mars",   // March
         "month of Roman goddess Venus",  // April
         "month of goddess Maia",         // May
         "month of Roman goddess Juno",   // June
         "month of Julius Caesar",        // July
         "month of Emperor Augustus",     // August
         "7th Roman month",               // September
         "8th Roman month",               // October
         "9th Roman month",               // November
         "10th Roman month"  } ;          // December

      Console.Write( "\n Give the number of a month (1 ... 12) : " ) ;

      int month_number  =  Convert.ToInt32( Console.ReadLine() ) ;

      if ( month_number > 0  &&  month_number < 13 )
      {
         Console.Write(  "\n " + names_of_months[ month_number - 1 ]
                     +  " is the " + history_of_months[ month_number - 1 ]
                     +  "\n\n"  ) ;
      }
      else
      {
         Console.Write(  "\n Not a valid number of a month. \n\n" ) ;
      }
   }
}






