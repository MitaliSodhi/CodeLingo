
//  BirthdaysDateTime.cs  (c) 2002 Kari Laitinen

//  www.naturalprogramming.com

//  23.10.2002  C# file created.
//  14.12.2002  Last modification.

using System ;

class BirthdaysDateTime
{
   static void Main()
   {
      Console.Write( "\n Type in your date of birth as YYYY-MM-DD"
                  +  "\n Please, use four digits for the year and"
                  +  "\n two digits for the month and day:  " ) ;

      string  date_of_birth_as_string   =  Console.ReadLine() ;

      DateTime date_of_birth  = 
                      DateTime.Parse( date_of_birth_as_string ) ;

      Console.Write(
            "\n   You were born on a "  +  date_of_birth.DayOfWeek
          + "\n   Here are your days to celebrate. You are\n" ) ;

      int  years_to_celebrate  =  10 ;

      while ( years_to_celebrate  <  80 )
      {
         DateTime  date_to_celebrate  =  new  DateTime(

                      date_of_birth.Year  +  years_to_celebrate,
                      date_of_birth.Month,
                      date_of_birth.Day ) ;

         Console.Write(
              "\n   "  +  years_to_celebrate  +  " years old on "
            +  date_to_celebrate.ToShortDateString()
            +   " ("  +  date_to_celebrate.DayOfWeek  +  ")" ) ;

         years_to_celebrate  =  years_to_celebrate  +  10 ;
      }
   }
}


