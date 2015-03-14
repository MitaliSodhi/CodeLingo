
//  NowKL.cs  (c) 2004 Kari Laitinen

//  http://www.naturalprogramming.com

//  2004-11-14  File created.
//  2004-11-14  Last modification.

//  Compile: NowKL.cs CurrentDate.cs Date.cs

//  A solution to Exercise 12-2.

using System ;

class NowKL
{
   static void Main()
   {
      Date  date_of_birth  =  new  Date( "30.12.1988" ) ;

      Date  date_to_increment  =  new  Date( date_of_birth.ToString() ) ;

      //  Now date_of_birth and date_to_increment refer to identical,
      //  but different, objects.

      CurrentDate  date_today  =  new  CurrentDate() ;

      int   day_counter  =  0 ;

      while  (  date_to_increment.is_earlier_than( date_today )  )
      {
         date_to_increment.increment() ;
         day_counter  ++ ;
      }

      Console.Write(  "\n\n  Today "  +  date_to_increment 
                   +  " you are "  +  day_counter  +  " days old. " ) ;

      int  years_of_age, months_of_age, days_of_age ;

      date_today.get_distance_to( date_of_birth,
                                  out years_of_age,
                                  out months_of_age,
                                  out days_of_age ) ;

      Console.Write(  "\n  That is " + years_of_age  + " years, "
                   +  months_of_age  +  " months, and "
                   +  days_of_age    +  " days. \n " ) ;

      //  At this phase of the execution of this program
      //  date_to_increment  references a Date object that
      //  contains the date of today. We'll continue incrementing
      //  it until the next birthday.

      int  number_of_days_to_next_birthday  =  0 ;

      while ( date_to_increment.day()    !=  date_of_birth.day()  ||
              date_to_increment.month()  !=  date_of_birth.month() )
      {
         date_to_increment.increment() ;
         number_of_days_to_next_birthday  ++  ;
      }

      Console.Write( "\n  There are "  +  number_of_days_to_next_birthday
                  +  " days until your next birthday. \n" ) ;
   }  
}

