
//  CalendarSimple.cs  (c) 2004 Kari Laitinen

//  http://www.naturalprogramming.com

//  2004-11-12  File created.
//  2004-11-12  Last modification.

//  compile: csc CalendarSimple.cs Date.cs

//  A solution to Exercise 10-5.
//  A better calendar program is Calendars.cs in Chapter 12.

using System ;

class  CalendarSimple
{
   static void Main()
   {
      Console.Write( "\n Give the number a month 1 ... 12: " ) ;

      int given_month  =  Convert.ToInt32( Console.ReadLine() ) ;

      Console.Write( "\n Give a year with four digits: " ) ;

      int given_year  =  Convert.ToInt32( Console.ReadLine() ) ;

      string[]  names_of_months  =  

         { "January", "February", "March", "April",
           "May", "June", "July", "August",
           "September", "October", "November", "December" } ;

      string  week_description  =

          " Week   Mon  Tue  Wed  Thu  Fri  Sat  Sun" ;

      Date a_day_in_given_month  =  new  Date( 1, given_month, given_year ) ;

      int day_of_week_index   =  0 ;

      int day_of_week_of_first_day  =
                          a_day_in_given_month.index_for_day_of_week() ;

      Console.Write(
            "\n\n   "  +  names_of_months[ given_month - 1 ]
         +  "  "  +  given_year  +  "\n\n"  +  week_description   +  "\n\n" 
         +  a_day_in_given_month.get_week_number().ToString().PadLeft( 4 ) 
         +  "  " ) ;

      // The first week of a month is often an incomplete week, 
      // i.e., the first part of week belongs to the previous
      // month. In place of the days that belong to the previous
      // month we print just spaces.

      while ( day_of_week_index != day_of_week_of_first_day )
      {
         Console.Write( "     " )  ;
         day_of_week_index  ++ ;
      }

      while ( given_month  ==  a_day_in_given_month.month() )
      {
         if ( day_of_week_index  >=  7 )
         {
            Console.Write( "\n"  + 
              a_day_in_given_month.get_week_number().ToString().PadLeft( 4 )
              +  "  ") ;

            day_of_week_index  =  0 ;
         }

         Console.Write( a_day_in_given_month.day().ToString().PadLeft( 5 ) ) ;

         a_day_in_given_month.increment() ;

         day_of_week_index  ++  ;
      }

      Console.Write( "\n" ) ;
   }
}



