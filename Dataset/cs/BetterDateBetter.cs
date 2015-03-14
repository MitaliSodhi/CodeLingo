
//  BetterDateBetter.cs  (c) 2003 Kari Laitinen

//  http://www.naturalprogramming.com

//  2004-11-14  File created.
//  2004-11-14  Last modification.

//  Compile: csc BetterDateBetter.cs Date.cs

//  A solution to Exercise 12-1.

using System ;

class BetterDate  :  Date
{
   public BetterDate( string date_as_string )
        :  base( date_as_string )
   {
   }

   public BetterDate( int  given_day,
                      int  given_month,
                      int  given_year  )
        :  base( given_day, given_month, given_year )
   {
   }

/****  The following is another possibility to write the required
       constructor:

   public BetterDate( int  given_day,
                      int  given_month,
                      int  given_year  )
   {
      this_day           =  given_day ;
      this_month         =  given_month ;
      this_year          =  given_year ;
   }

****/

   public string to_string_with_month_name()
   {
      string[]  names_of_months  =  

         { "January", "February", "March", "April",
           "May", "June", "July", "August",
           "September", "October", "November", "December" } ;

      return (  names_of_months[ this_month - 1 ]  + " "
                +  this_day  +  ", "  +  this_year ) ;
   }

   public string to_american_format_string()
   {
      char  saved_date_print_format  =  date_print_format ;

      date_print_format  =  'A' ;

      string  string_to_return  =  this.ToString() ;

      date_print_format  =  saved_date_print_format ;

      return  string_to_return ;
   }
}

class  BetterDateTester
{
   static void Main()
   {
      BetterDate  birthday_of_einstein  =  new  BetterDate( 14, 03, 1879 );

      Console.Write( "\n Albert Einstein was born on "
                  +  birthday_of_einstein  ) ;

      birthday_of_einstein.increment() ;

      Console.Write( "\n Albert was one day old on " 
                  +  birthday_of_einstein.to_string_with_month_name() ) ;

      birthday_of_einstein.increment() ;

      Console.Write( "\n Albert was two days old on "
                  +  birthday_of_einstein.to_american_format_string() ) ;
   }
}

