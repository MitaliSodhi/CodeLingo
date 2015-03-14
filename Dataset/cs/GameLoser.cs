
//  GameLoser.cs  (c) 2004 Kari Laitinen

//  This file is a solution to exercise 5-1.

//  www.naturalprogramming.com

using System ;

class GameLoser
{
   static void Main()
   {
      int  integer_from_keyboard ;
      int  one_smaller_integer ;

      Console.Write(
          "\n This program is a computer game. Please, type in "
        + "\n an integer in the range  1 ... 2147483646 : " ) ;

      integer_from_keyboard  =  Convert.ToInt32( Console.ReadLine() ) ;

      one_smaller_integer  =  integer_from_keyboard  -  1 ;

      Console.Write( "\n You typed in " + integer_from_keyboard + "."
                  +  "\n My number is " + one_smaller_integer    + "."
                  +  "\n I lost the game. You won. The game is over.\n") ;
   }
}



