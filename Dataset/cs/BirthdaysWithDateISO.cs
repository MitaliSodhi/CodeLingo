
//  BirthdaysWithDateISO.cs  (c) 2003 Kari Laitinen

//  http://www.naturalprogramming.com

//  2004-11-12  File created.
//  2004-11-12  Last modification.

//  Compilation: csc BirthdaysWithDateISO.cs DateISO.cs

using System ;

class BirthdaysWithDateISO
{
   static void Main()
   {
      Console.Write( "\n Type in your date of birth as DD.MM.YYYY"
                  +  "\n or MM/DD/YYYY or YYYY-MM-DD :   " ) ;

      string  date_of_birth_as_string   =  Console.ReadLine() ;

      DateISO date_of_birth  =  new  DateISO( date_of_birth_as_string ) ;

      Console.Write(
         "\n   You were born on a "  +  date_of_birth.get_day_of_week()
       + "\n   Here are your days to celebrate. You are\n" ) ;

      int  years_to_celebrate  =  10 ;

      while ( years_to_celebrate  <  80 )
      {
         DateISO  date_to_celebrate  =  new  DateISO(

                      date_of_birth.day(),
                      date_of_birth.month(),
                      date_of_birth.year()  +  years_to_celebrate,
                      date_of_birth.get_date_print_format() ) ;

         Console.Write( "\n   "  +  years_to_celebrate 
            +  " years old on "  +  date_to_celebrate
            +   " ("  +  date_to_celebrate.get_day_of_week()  +  ")" ) ;

         years_to_celebrate  =  years_to_celebrate  +  10 ;
      }

      date_of_birth.set_date_print_format( 'I' )  ;

      if ( date_of_birth.is_in_year_of( new DateISO( 1, 1, 2002 ) ) )
      {
         Console.Write( "\n\n " + date_of_birth
                     +  " belongs to year 2002 " ) ;
      }
      else
      {
         Console.Write( "\n\n " + date_of_birth
                     +  " does not belong to year 2002 " ) ;
      }

      if ( date_of_birth.is_in_month_of( new DateISO( 1, 2, 2004 ) ) )
      {
         Console.Write( "\n\n " + date_of_birth
                     +  " belongs to February 2004 " ) ;
      }
      else
      {
         Console.Write( "\n\n " + date_of_birth
                     +  " does not belong to February 2004 " ) ;
      }
   }
}


