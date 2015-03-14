
//  DelegateTests.cs  (c) 2004 Kari Laitinen

//  www.naturalprogramming.com

using System ;

//  First we define a delegate type that can represent
//  methods that take an array of type int as a parameter
//  and have void as their return type.

delegate void PrintingMethod( int[] array_of_integers ) ;

class DelegateTests
{
   static void print_array_in_normal_order( int[] array_of_integers )
   {
      Console.Write( "\n Integers in normal order:  " ) ;

      for ( int integer_index  =  0 ;
                integer_index  <  array_of_integers.Length ;
                integer_index  ++ )
      {
         Console.Write( "   " + array_of_integers[ integer_index ] ) ;
      }
   }

   static void print_array_in_reverse_order( int[] array_of_integers )
   {
      Console.Write( "\n Integers in reverse order: " ) ;

      int integer_index  =  array_of_integers.Length ;

      while ( integer_index  >  0 )
      {
         integer_index  -- ;
         Console.Write( "   " + array_of_integers[ integer_index ] ) ;
      }
   }

   static void test()
   {
      Console.Write( " xxx " ) ;
   }

   static void print_array( PrintingMethod  given_printing_method,
                            int[]           given_array )
   {
      given_printing_method( given_array ) ;
   }

   static void Main()
   {
      int[]  test_array  =  { 33, 44, 55, 66, 77, 88 } ;

      print_array_in_normal_order( test_array ) ;

      print_array_in_reverse_order( test_array ) ;

      PrintingMethod  printing_delegate  =
                         new  PrintingMethod( print_array_in_normal_order ) ;

      print_array( printing_delegate,
                   test_array ) ;

      printing_delegate( test_array ) ;

      print_array( new  PrintingMethod( print_array_in_reverse_order ),
                   test_array ) ;


   }
}



