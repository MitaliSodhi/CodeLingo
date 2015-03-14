
//  Weddingdates.cs  (c) 2003 Kari Laitinen

//  www.naturalprogramming.com

//  23.10.2002  C# file created.
//  30.11.2003  Last modification.

//  Compilation: csc Weddingdates.cs CurrentDate.cs Date.cs

using System ;

class Weddingdates
{
   static void Main()
   {
      CurrentDate  date_to_increment  =  new  CurrentDate() ;

      int   number_of_dates_printed  =  0 ;

      Console.Write( "\n These are easy-to-remember dates for weddings and"
                  +  "\n other important events because the days and months"
                  +  "\n consist of the digits used in the year: \n" ) ;

      while ( number_of_dates_printed  <  60 )
      {
         string day_as_string   = date_to_increment.day().ToString( "D2" ) ;
         string month_as_string = date_to_increment.month().ToString( "D2") ;
         string year_as_string  = date_to_increment.year().ToString() ;

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

            Console.Write( "  "  +  date_to_increment ) ;

            number_of_dates_printed  ++  ;
         }

         date_to_increment.increment() ;
      }
   }
}







