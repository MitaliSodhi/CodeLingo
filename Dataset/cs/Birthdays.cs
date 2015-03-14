
//  Birthdays.cs  (c) 2003 Kari Laitinen

//  www.naturalprogramming.com

//  Compilation: csc Birthdays.cs Date.cs

//  Warning:  This program does not work if the given 
//            birthday is a leap day (29th of February).

using System ;

class Birthdays
{
   static void Main()
   {
      Console.Write( "\n Type in your date of birth as DD.MM.YYYY"
                  +  "\n or MM/DD/YYYY. Use four digits for the year"
                  +  "\n and two digits for the month and day:  " ) ;

      string  date_of_birth_as_string   =  Console.ReadLine() ;

      Date date_of_birth  =  new  Date( date_of_birth_as_string ) ;

      Console.Write(
         "\n   You were born on a "  +  date_of_birth.get_day_of_week()
       + "\n   Here are your days to celebrate. You are\n" ) ;

      int  years_to_celebrate  =  10 ;

      while ( years_to_celebrate  <  80 )
      {
         Date  date_to_celebrate  =  new  Date(

                      date_of_birth.day(),
                      date_of_birth.month(),
                      date_of_birth.year()  +  years_to_celebrate,
                      date_of_birth.get_date_print_format() ) ;

         Console.Write( "\n   "  +  years_to_celebrate 
            +  " years old on "  +  date_to_celebrate
            +   " ("  +  date_to_celebrate.get_day_of_week()  +  ")" ) ;

         years_to_celebrate  =  years_to_celebrate  +  10 ;
      }
   }
}


