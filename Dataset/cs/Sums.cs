
//  Sums.cs  (c) 2002 Kari Laitinen

//  Note that is different program than Sum.cs
//  which is discussed at the beginning of the book.
//  So if you by accident found this program while
//  trying to find Sum.cs, keep searching. This is
//  not the correct program in the beginning of
//  your studies.

using  System ;

class Sums
{
   static void print_sum( int first_integer_from_caller,
                          int second_integer_from_caller )
   {
      int calculated_sum ;

      calculated_sum  =  first_integer_from_caller  +
                         second_integer_from_caller ;

      Console.Write( "\n The sum of " +  first_integer_from_caller
                   + " and "  +  second_integer_from_caller
                   + " is "   +  calculated_sum  + ".\n" ) ;
   }

   static void Main()
   {
      print_sum( 555, 222 ) ;

      Console.Write( "\n As you can see, this program can print"
                  +  "\n the sum of two integers. Please, type in"
                  +  "\n the first integer: " ) ;

      int first_integer  =  Convert.ToInt32( Console.ReadLine() ) ;

      Console.Write( "\n And now the second integer: " ) ;

      int second_integer  =  Convert.ToInt32( Console.ReadLine() ) ;

      print_sum( first_integer, second_integer ) ;
   }
}



