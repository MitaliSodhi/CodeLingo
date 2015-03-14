
//  Sums3.cs  (c) 2002 Kari Laitinen

//  Solution to to Exercise 9-2.

//  http://www.naturalprogramming.com

//  2004-11-05  File created.
//  2004-11-05  Last modification.

using  System ;

class Sums3
{
   static void print_sum( int first_integer_from_caller,
                          int second_integer_from_caller,
                          int third_integer_from_caller )
   {
      int calculated_sum ;

      calculated_sum  =  first_integer_from_caller  +
                         second_integer_from_caller +
                         third_integer_from_caller ;

      Console.Write( "\n The sum of " +  first_integer_from_caller
                   + ", "      +  second_integer_from_caller
                   + ", and "  +  third_integer_from_caller
                   + " is "    +  calculated_sum  + ".\n" ) ;
   }

   static void Main()
   {
      print_sum( 555, 222, 111 ) ;

      Console.Write( "\n As you can see, this program can print"
                  +  "\n the sum of three integers. Please, type in"
                  +  "\n the first integer: " ) ;

      int first_integer  =  Convert.ToInt32( Console.ReadLine() ) ;

      Console.Write( "\n And now the second integer: " ) ;

      int second_integer  =  Convert.ToInt32( Console.ReadLine() ) ;

      Console.Write( "\n And still one more integer: " ) ;

      int third_integer  =  Convert.ToInt32( Console.ReadLine() ) ;

      print_sum( first_integer, second_integer, third_integer ) ;
   }
}



