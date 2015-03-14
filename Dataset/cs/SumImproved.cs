
// SumImproved.cs (c) 2004 Kari Laitinen

//  This is a simple calculator program that can
//  calculate the sum of the two integers that are
//  typed in from the keyboard.

using System ;

class SumImproved
{
   static void Main()
   {
      Console.Write( "\n Please, type in an integer:      " ) ;
      int first_integer_from_keyboard  =
                       Convert.ToInt32( Console.ReadLine() ) ;

      Console.Write( "\n Please, type in another integer: " ) ;
      int second_integer_from_keyboard  =
                       Convert.ToInt32( Console.ReadLine() ) ;

      int sum_of_two_integers  =  first_integer_from_keyboard  +
                                  second_integer_from_keyboard  ;

      Console.Write( "\n The sum of " +  first_integer_from_keyboard
                     + " and "  +  second_integer_from_keyboard
                     + " is "   +  sum_of_two_integers  +  ".\n" ) ;
   }
}



