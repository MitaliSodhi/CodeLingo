
//  ArrayMethods.cs  (c) 2004 Kari Laitinen

//  www.naturalprogramming.com

//  This program demonstrates the methods of the standard
//  class Array.

using System ;

class ArrayMethods
{
   static void print_array( Array given_array )
   {
      Console.Write( "\n\n " ) ;

      for ( int element_index  =  0 ;
                element_index  <  given_array.Length ;
                element_index  ++ )
      {
         Console.Write(
           given_array.GetValue( element_index ).ToString().PadLeft( 5 ) ) ;
      }
   }

   static void Main()
   {
      int[]  array_of_integers  =  { 44, 2, 53, 1, 32, 17, 53, 6 } ;

      Console.Write( "\n Value 32 has index:       "
                  +  Array.IndexOf( array_of_integers, 32 )  ) ;
      Console.Write( "\n Value 99 has index:       "
                  +  Array.IndexOf( array_of_integers, 99 )  ) ;

      Console.Write( "\n Last value 53 has index:  "
                  +  Array.LastIndexOf( array_of_integers, 53 )  ) ;

      print_array( array_of_integers ) ;

      int[]  original_array  =  (int[]) array_of_integers.Clone() ;
      print_array( original_array ) ;

      Array.Reverse( array_of_integers ) ;
      print_array( array_of_integers ) ;

      Array.Sort( array_of_integers ) ;
      print_array( array_of_integers ) ;

      Array.Clear( array_of_integers, 4, 3 ) ;
      print_array( array_of_integers ) ;

      Array.Copy( original_array, 0, array_of_integers, 4, 3 ) ;
      print_array( array_of_integers ) ;

      char[]  array_of_characters  =  { 'z', 'X', '3', 'a', 'k', '=', '+' } ;

      print_array( array_of_characters ) ;

      Array.Sort( array_of_characters ) ;
      print_array( array_of_characters ) ;
   }
}



