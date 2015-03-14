
//  EvenoddWithBitOperator.cs  (c) 2004 Kari Laitinen

//  http://www.naturalprogramming.com

//  2004-02-19  File created.
//  2004-11-25  Last modification.

//  A solution to Exercise 16-1.

using System ;

class EvenoddWithBitOperator
{
   static void Main()
   {
      int  integer_from_keyboard ;

      Console.Write( "\n This program can find out whether an integer"
                  +  "\n is even or odd. Please, enter an integer: " ) ;

      integer_from_keyboard  =  Convert.ToInt32( Console.ReadLine() ) ;

      if ( ( integer_from_keyboard  &  0x00000001 )  ==  0 )
      {
         Console.Write( "\n " + integer_from_keyboard + " is even.\n") ;
      }
      else
      {
         Console.Write( "\n " + integer_from_keyboard + " is odd. \n") ;
      }
   }
}





