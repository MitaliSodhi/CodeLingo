
//  BirthdaysOnSunday.cs  (c) 2003 Kari Laitinen

//  http://www.naturalprogramming.com

//  2004-11-11  File created.
//  2004-11-12  Last modification.

//  Compilation: csc BirthdaysOnSunday.cs Date.cs

//  Solution to exercise 11-4.

using System ;

class BirthdaysOnSunday
{
   static void Main()
   {
      Console.Write( "\n Type in your date of birth as DD.MM.YYYY"
                  +  "\n or MM/DD/YYYY. Use four digits for the year"
                  +  "\n and two digits for the month and day:  " ) ;

      string  date_of_birth_as_string   =  Console.ReadLine() ;

      Date date_of_birth  =  new  Date( date_of_birth_as_string ) ;

      int  future_year  =  2005 ;

      int  number_of_dates_printed  =  0  ;

      while ( number_of_dates_printed  <  5 )
      {
         Date  future_birthday  =  new  Date( date_of_birth.day(),
                                              date_of_birth.month(),
                                              future_year ) ;

         if ( future_birthday.index_for_day_of_week()  ==  6 )
         {
            Console.Write( "\n   The birthday "  +  future_birthday 
               +   " is "  +  future_birthday.get_day_of_week()   ) ;

            number_of_dates_printed  ++ ;
         }

         future_year  ++ ;
      }
   }
}



