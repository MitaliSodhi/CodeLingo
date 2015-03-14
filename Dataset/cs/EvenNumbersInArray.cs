
//  EvenNumbersInArray.cs  (c) Kari Laitinen

//  http://www.naturalprogramming.com

//  2004-10-30  File created.
//  2004-10-30  Last modification.

using  System ;

class EvenNumbersInArray
{
   static void Main()
   {

      int[] array_of_integers      =  new  int[ 100 ] ;
      int   integer_index          =    0 ;
      int   integer_from_keyboard  =  999 ;

      while ( integer_from_keyboard   !=  0 )
      {
         Console.Write( "\nEnter an integer: " ) ;
         integer_from_keyboard =
                  Convert.ToInt32( Console.ReadLine() ) ;
         array_of_integers[ integer_index ] =
                                  integer_from_keyboard ;
         integer_index ++ ;
      }

      int  number_of_integers_given  =  integer_index ;

      Console.Write( "\n The following are even numbers in the array:\n\n" ) ;

      for ( integer_index  =  0 ;
            integer_index  <  number_of_integers_given ;
            integer_index  ++ )
      {
         if ( ( array_of_integers[ integer_index ]  %  2 )  ==  0  )
         {
            Console.Write( "  "  +  array_of_integers[ integer_index ] ) ;
         }
      }
   }
}



