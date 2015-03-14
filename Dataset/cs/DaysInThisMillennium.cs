
//  DaysInThisMillennium.cs  (c) 2004 Kari Laitinen

//  www.naturalprogramming.com

//  Compile: csc DaysInThisMillennium.cs Date.cs

using System ;

class DaysInThisMillennium
{
   static void Main()
   {
      int number_of_days_in_this_millennium  =  0 ;

      Date  date_to_increment  =  new Date( 1, 1, 2000 ) ;

      Date  first_day_of_next_millennium  =  new Date( 1, 1, 3000 ) ;

      while ( date_to_increment.is_earlier_than(
                                    first_day_of_next_millennium ) )
      {
          number_of_days_in_this_millennium  ++ ;
          date_to_increment.increment() ;
      }


      Console.Write( "\n Number of days in this millennium:  "
                  +  number_of_days_in_this_millennium  +  "\n\n" ) ;

   }
}



