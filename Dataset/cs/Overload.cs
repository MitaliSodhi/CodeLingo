
//  Overload.cs  (c) 2003 Kari Laitinen

using System ;

class Overload
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

   static void print_array( char[] character_array,
                            int    number_of_characters_to_print )
   {
      Console.Write( "\n\n Characters in array:" ) ;

      for ( int character_index  =  0 ;
                character_index  <  number_of_characters_to_print ;
                character_index  ++ )
      {
         Console.Write( "   " + character_array[ character_index ] ) ;
      }
   }

   static void print_array( char[] character_array )
   {
      Console.Write( "\n\n Characters in array:" ) ;

      for ( int character_index  =  0 ;
                character_index  <  character_array.Length ;
                character_index  ++ )
      {
         Console.Write( "   " + character_array[ character_index ] ) ;
      }
   }

   static void Main()
   {
      int[]  first_array  =  { 55, 77, 888, 4444, 33, 22, 11 } ;

      char[] second_array =  { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H' } ;

      print_array( first_array, 6 ) ;
      print_array( second_array ) ;
      print_array( second_array, 5 ) ;
   }
}




