
//  NewYearDaySundays.cs  (c) 2003 Kari Laitinen

//  http://www.naturalprogramming.com

//  2004-11-11  File created.
//  2004-11-11  Last modification.

//  Compilation: csc NewYearDaySundays.cs Date.cs

//  Solution to exercise 11-3.

using System ;

class NewYearDaySundays
{
   static void Main()
   {

      int  future_year  =  2005 ;

      int  number_of_dates_printed  =  0  ;

      while ( number_of_dates_printed  <  5 )
      {
         Date  future_new_year_day  =  new  Date( 1, 1, future_year ) ;

         if ( future_new_year_day.index_for_day_of_week()  ==  6 )
         {
            Console.Write( "\n   The day "  +  future_new_year_day 
               +   " is "  +  future_new_year_day.get_day_of_week()   ) ;

            number_of_dates_printed  ++ ;
         }

         future_year  ++ ;
      }
   }
}


