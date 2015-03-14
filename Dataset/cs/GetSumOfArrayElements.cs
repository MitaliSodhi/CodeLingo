
//  GetSumOfArrayElements.cs  (c) 2004 Kari Laitinen

//  http://www.naturalprogramming.com

//  2004-11-06  File created.
//  2004-11-06  Last modification.

//  A solution to Exercise 9-8.

using System ;

class GetSumOfArrayElements
{
   static int get_sum_of_elements( int[] given_array,
                                   int   number_of_integers_to_process )
   {
      int  calculated_sum  =  0 ;
      
      for ( int integer_index  =  0 ;
                integer_index  <  number_of_integers_to_process ;
                integer_index  ++ )
      {
         calculated_sum  =  calculated_sum  +
                            given_array[ integer_index ] ;
      }
      
      return calculated_sum ;
   }
   

   static void Main()
   {
      int[] example_array = { 22, 33, 44, 55 } ;

      int sum_of_elements  =
               get_sum_of_elements( example_array, 3 ) ;

      Console.Write( "\n Sum of three elements: "
                  +  sum_of_elements ) ;
      Console.Write( "\n Sum of four elements:  "
                  +  get_sum_of_elements( example_array, 4 ) ) ;
   }
}



