
//  Friday13.cs  (c) 2003 Kari Laitinen

//  Compilation: csc Friday13.cs Date.cs

using System ;

class Friday13
{
   static void Main()
   {
      Console.Write(
          "\n This program can print you a list of 10 dates" 
        + "\n that are Fridays and 13th days of a month."
        + "\n Please, type in a date from which you want"
        + "\n the calculation to begin. Type in the date either"
        + "\n in form DD.MM.YYYY or in form MM/DD/YYYY and use"
        + "\n two digits for days and months and four digits"
        + "\n for the year:  " ) ;

      string  given_date_as_string  =  Console.ReadLine() ;

      Date  date_to_increment  =  new  Date( given_date_as_string ) ;

      int   number_of_friday13_dates_to_print  =  10 ;

      Console.Write( "\n It is a common belief that you may have"
                   + "\n bad luck on the following dates:\n" ) ;

      while ( number_of_friday13_dates_to_print  >  0 )
      {
         while ( date_to_increment.index_for_day_of_week()  !=  4  ||
                 date_to_increment.day()  !=  13   )
         {
            date_to_increment.increment() ;
         }

         Console.Write( "\n    "  +  date_to_increment  +  ", "
                     +  date_to_increment.get_day_of_week()  ) ;

         date_to_increment.increment() ;
         number_of_friday13_dates_to_print  --  ;
      }
   }
}



