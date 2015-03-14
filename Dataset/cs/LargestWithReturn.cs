
//  LargestWithReturn.cs  (c) 2003 Kari Laitinen

using  System ;

class LargestWithReturn
{
   static int search_largest_integer( int[] array_of_integers,
                                      int   number_of_integers_in_array )
   {
      int  largest_integer     =  array_of_integers[ 0 ] ;
      int  integer_index  =  1 ;

      while (  integer_index  <  number_of_integers_in_array  )
      {
         if ( array_of_integers[ integer_index ] > largest_integer )
         {
            largest_integer  =  array_of_integers[ integer_index ] ;
         }

         integer_index   ++  ;
      }

      return  largest_integer ;
   }

   static void Main()
   {
      int[]  first_array   =  { 44, 2, 66, 33, 9 } ;
      int[]  second_array  =  { 888, 777, 66, 999, 998, 997 } ;

      int  found_largest_integer  ;

      found_largest_integer =  search_largest_integer( first_array, 5 ) ;

      Console.Write( "\n The largest integer in first_array is "
                     +  found_largest_integer  +  ".\n" ) ;

      Console.Write( "\n The largest integer in second_array is "
            +  search_largest_integer( second_array, 6 )  +  ".\n" ) ;
   }
}


