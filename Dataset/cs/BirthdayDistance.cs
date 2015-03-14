
//  BirthdayDistance.cs  (c) 2003 Kari Laitinen

//  http://www.naturalprogramming.com

//  2004-11-11  File created.
//  2004-11-11  Last modification.

//  Compilation: csc BirthdayDistance.cs Date.cs

//  A solution to exercise 11-1.

using System ;

class BirthdayDistance
{
   static void Main()
   {
      Date my_birthday  =  new  Date( "19.03.1981" ) ;

      Console.Write(
          "\n   Please, type in a date in the form DD.MM.YYYY and "
        + "\n   please use two digits for the day and month, and"
        + "\n   four digits for the year:  " ) ;

      string  given_date_as_string  =  Console.ReadLine() ;

      Date  given_date  =  new  Date( given_date_as_string ) ;

      int  years_of_distance, months_of_distance, days_of_distance ;

      my_birthday.get_distance_to(  given_date,
                                    out years_of_distance, 
                                    out months_of_distance,
                                    out days_of_distance  ) ;

      Console.Write( "\n\n   The distance from date "  +  my_birthday
                  + " to date "  +  given_date  +  " is \n   "
                  +  years_of_distance   +  " years, "
                  +  months_of_distance  +  " months, and "
                  +  days_of_distance    +  " days"
                  +  ".\n\n" ) ;
   }
}


