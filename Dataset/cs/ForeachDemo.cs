
//  ForeachDemo.cs  (c) 2003 Kari Laitinen

using  System ;

class ForeachDemo
{
   static void Main()
   {
      int[]  array_of_integers  =  { 33, 444, 55, 6, 777 } ;

      string[] array_of_strings  =  { "January", "February", "March" } ;

      Console.Write(
           "\n\n array_of_integers printed with a for loop:\n\n " ) ;

      for ( int integer_index  =  0 ;
                integer_index  <  array_of_integers.Length ;
                integer_index  ++ )
      {
         Console.Write( "  "  +  array_of_integers[ integer_index ] ) ;
      }

      Console.Write(
           "\n\n array_of_integers printed with a foreach loop:\n\n " ) ;

      foreach ( int integer_in_array in array_of_integers )
      {
         Console.Write( "  "  +  integer_in_array ) ;
      }

      Console.Write(
           "\n\n array_of_strings printed with a for loop:\n\n " ) ;

      for ( int string_index  =  0 ;
                string_index  <  array_of_strings.Length ;
                string_index  ++ )
      {
         Console.Write( "  "  +  array_of_strings[ string_index ] ) ;
      }

      Console.Write(
           "\n\n array_of_strings printed with a foreach loop:\n\n " ) ;

      foreach ( string string_in_array in array_of_strings )
      {
         Console.Write( "  "  +  string_in_array ) ;
      }
   }
}


