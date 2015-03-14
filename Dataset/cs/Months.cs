
//  Months.cs  (c) 2004 Kari Laitinen

//  www.naturalprogramming.com

//  If you are a reader who also studies my C++ book,
//  please note that this program does not work exactly
//  the same way as months.cpp in the C++ book.
//  The C++ program uses pointers, and pointers are not
//  widely discussed in the C# book.

using System ;

class Months
{
   static void Main()
   {
      string[]  names_of_months  =

         { "January", "February", "March", "April", "May", "June",
           "July", "August", "September", "October", "November",
           "December"  }  ;

      Console.Write( "\n The first month of year is "
                  +  names_of_months[ 0 ]  +  "." ) ;

      Console.Write(  "\n\n The seventh month, " + names_of_months[ 6 ]
                  +  ", is named after Julius Caesar.\n" ) ;

      Console.Write( "\n Our calendar has " +  names_of_months.Length
                  +  " months. \n" ) ;

      for ( int month_index  =  0 ;
                month_index  <  4 ;
                month_index  ++  )
      {
         int number_of_letters_in_month_name  =
                             names_of_months[ month_index ].Length ;

         Console.Write( "\n " +  names_of_months[ month_index ]
                     +  " is made of "
                     +  number_of_letters_in_month_name
                     +  " letters: " ) ;

         for ( int letter_index  =  0 ;
                   letter_index  <  number_of_letters_in_month_name ;
                   letter_index  ++ )
         {
            Console.Write(  " "  +
                  names_of_months[ month_index ] [ letter_index ] ) ;
         }            
      }
   }
}

/* Multiline comment begins:

   The following array is to be used in an exercise related
   to Months.cs:

      string[]  history_of_months =
      {  "month of Roman god Janus",      // January
         "last month in Roman calendar",  // February
         "month of Roman war god Mars",   // March
         "month of Roman goddess Venus",  // April
         "month of goddess Maia",         // May
         "month of Roman goddess Juno",   // June
         "month of Julius Caesar",        // July
         "month of Emperor Augustus",     // August
         "7th Roman month",               // September
         "8th Roman month",               // October
         "9th Roman month",               // November
         "10th Roman month"  } ;          // December

   Mulitiline comment ends.  */






