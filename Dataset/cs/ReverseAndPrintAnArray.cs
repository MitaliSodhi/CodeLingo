
//  ReverseAndPrintAnArray.cs  (c) 2004 Kari Laitinen

//  http://www.naturalprogramming.com

//  2004-11-05  File created.
//  2004-11-05  Last modification.

//  A solution to exercise 9-6.

using System ;

class ReverseAndPrintAnArray
{
   static void print_array( int[] array_of_integers,
                            int   number_of_integers_to_print )
   {
      Console.Write( "\n\n Integers in array:" ) ;

      for ( int integer_index  =  0 ;
                integer_index  <  number_of_integers_to_print ;
                integer_index  ++ )
      {
         Console.Write( "   " + array_of_integers[ integer_index ] ) ;
      }
   }

   static void reverse_array( int[] array_of_integers,
                              int   number_of_integers_to_reverse )
   {
      int  growing_index    =  0 ;
      int  shrinking_index  =  number_of_integers_to_reverse - 1 ;

      while ( growing_index  <  shrinking_index )
      {
         int  saved_integer  =  array_of_integers[ growing_index ] ;

         array_of_integers[ growing_index ]  =
                                 array_of_integers[ shrinking_index ] ;
         array_of_integers[ shrinking_index ]  =  saved_integer ;

         growing_index    ++  ;
         shrinking_index  --  ;
      }
   }

   static void Main()
   {
      int[] test_array  =  { 2, 33, 44, 55, 666 } ;

      reverse_array( test_array, 5 ) ;
      print_array(   test_array, 5 ) ;
      reverse_array( test_array, 3 ) ;
      print_array(   test_array, 5 ) ;

      
   }
}



