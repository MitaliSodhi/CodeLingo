
//  WeddingdatesDateTime.cs  (c) 2004 Kari Laitinen

//  http://www.naturalprogramming.com

//  2004-02-12  File created.
//  2004-11-24  Last modification.

//  A solution to Exercise 15-8.

using System ;

class WeddingdatesDateTime
{
   static void Main()
   {
      DateTime  date_to_increment  =  DateTime.Today ;

      int   number_of_dates_printed  =  0 ;

      Console.Write(
          "\n These are easy-to-remember dates for weddings and"
        + "\n other important events because the days and months"
        + "\n consist of the digits used in the year: \n" ) ;

      while ( number_of_dates_printed  <  60 )
      {
         string  day_as_string    =  date_to_increment.Day.ToString( "D2" ) ;
         string  month_as_string  =  date_to_increment.Month.ToString( "D2" ) ;
         string  year_as_string   =  date_to_increment.Year.ToString() ;

         if ( year_as_string.IndexOf( day_as_string[ 0 ] )  != -1  &&
              year_as_string.IndexOf( day_as_string[ 1 ] )  != -1  &&
              year_as_string.IndexOf( month_as_string[ 0 ] )  != -1  &&
              year_as_string.IndexOf( month_as_string[ 1 ] )  != -1  )
         {
            // Now we have found a date that meets our requirements.

            if ( number_of_dates_printed  %  5  ==  0 )
            {
               Console.Write( "\n" ) ;
            }

            Console.Write(

                date_to_increment.ToShortDateString().PadLeft( 12 ) ) ;

            number_of_dates_printed  ++  ;
         }

         date_to_increment  =  date_to_increment.AddDays( 1 ) ;
      }
   }
}







