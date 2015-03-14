
//  LargestWithRef.cs  (c) 2003 Kari Laitinen

using  System ;

class LargestWithRef
{
   static void search_largest_integer( int[] array_of_integers,

                                       ref int largest_integer )
   {
      largest_integer     =  array_of_integers[ 0 ] ;
      int  integer_index  =  1 ;

      while (  integer_index  <  array_of_integers.Length  )
      {
         if ( array_of_integers[ integer_index ] > largest_integer )
         {
            largest_integer  =  array_of_integers[ integer_index ] ;
         }

         integer_index   ++  ;
      }
   }

   static void Main()
   {
      int[]  first_array   =  { 44, 2, 66, 33, 9 } ;
      int[]  second_array  =  { 888, 777, 66, 999, 998, 997 } ;

      int  found_largest_integer  =  0 ;

      search_largest_integer( first_array,
                              ref found_largest_integer ) ;

      Console.Write( "\n The largest integer in first_array is "
                     +  found_largest_integer  +  ".\n" ) ;

      search_largest_integer( second_array,
                              ref found_largest_integer ) ;

      Console.Write( "\n The largest integer in second_array is "
                     +  found_largest_integer  +  ".\n" ) ;
   }
}


