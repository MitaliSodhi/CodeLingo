
//  Age10000days.cs  (c) 2003 Kari Laitinen

//  http://www.naturalprogramming.com

//  2004-11-11  File created.
//  2004-11-11  Last modification.

//  Compilation: csc Age10000days.cs Date.cs

//  A solution to exercise 11-2.

using System ;

class Age10000days
{
   static void Main()
   {
      Console.Write( "\n Type in your date of birth as DD.MM.YYYY"
                  +  "\n or MM/DD/YYYY. Use four digits for the year"
                  +  "\n and two digits for the month and day:  " ) ;

      string  date_of_birth_as_string   =  Console.ReadLine() ;

      Date date_to_increment  =  new  Date( date_of_birth_as_string ) ;

      Console.Write(
         "\n   You were born on a "  +  date_to_increment.get_day_of_week()
       + "\n   Here are your days to celebrate. You are\n" ) ;


      int  day_counter  =  0 ;

      while ( day_counter  <  50001 )
      {
         date_to_increment.increment() ;
         day_counter  ++  ;

         if ( ( day_counter  %  10000 )  ==  0 )
         {
            Console.Write( "\n   "  +  day_counter 
               +  " days old on "  +  date_to_increment
               +   " ("  +  date_to_increment.get_day_of_week()  +  ")" ) ;
         }

      }
   }
}


