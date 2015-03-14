
//  ParamsKeywordTest.cs  (c) 2004 Kari Laitinen

//  www.naturalprogramming.com

//  2004  File created.
//  2005-07-15  Last modification.

/*  With the params keyword it is possible to declare a method that
    accepts a varying number of parameters of the same type. Only the
    last formal parameter of a method can be declared with the params
    keyword.
    
    The corresponding Java program is named ParametersVaryingInNumber.java
*/

using System ;

class ParamsKeywordTest
{
   static void print_integers( params int[] given_integers )
   {
      Console.Write( "\n   Given integers: " ) ;

      foreach ( int integer_in_array in given_integers )
      {
         Console.Write( "  "  +  integer_in_array ) ;
      }
   }

   static void print_string_and_integers( string  given_string,
                                          params int[] given_integers )
   {
      Console.Write( "\n   "  +  given_string  +  "   " ) ;

      foreach ( int integer_in_array in given_integers )
      {
         Console.Write( "  "  +  integer_in_array ) ;
      }
   }

   static void Main()
   {
      print_integers() ;

      print_integers( 1111 ) ;

      print_integers( 3, 88, 77, 2, 5 ) ;

      int[] array_of_integers  =  { 44, 999, 66, 11 } ;

      print_integers( array_of_integers ) ;
  

      print_string_and_integers( "xxx" ) ;

      print_string_and_integers( "yyy", 1111 ) ;

      print_string_and_integers( "zzz", 3, 88, 77, 2, 5 ) ;

      print_string_and_integers( "www", array_of_integers ) ;
  


   }
}



