
//  GameWithParseMethod.cs  (c) 2004 Kari Laitinen

//  This program is the same as program Game.cs, except that
//  method Int32.Parse() is used in place of Convert.ToInt32().

using System ;

class GameWithParseMethod
{
   static void Main()
   {
      int  integer_from_keyboard ;
      int  one_larger_integer ;

      Console.Write(
          "\n This program is a computer game. Please, type in "
        + "\n an integer in the range  1 ... 2147483646 : " ) ;

      integer_from_keyboard  =  Int32.Parse( Console.ReadLine() ) ;

      one_larger_integer  =  integer_from_keyboard  +  1 ;

      Console.Write( "\n You typed in " + integer_from_keyboard + "."
                  +  "\n My number is " + one_larger_integer    + "."
                  +  "\n Sorry, you lost. I won. The game is over.\n") ;
   }
}



