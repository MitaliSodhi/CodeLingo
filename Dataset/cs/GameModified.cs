
//  GameModified.cs  (c) 2002 Kari Laitinen

using System ;

class GameModified
{
   static void Main()
   {
      short  integer_from_keyboard ;
      short  one_larger_integer ;

      string  line_of_text ;

      Console.Write(
          "\n This program is a computer game. Please, type in "
        + "\n an integer in the range  1 ... 2147483646 : " ) ;

      line_of_text  =  Console.ReadLine() ;

      integer_from_keyboard  =  Convert.ToInt16( line_of_text ) ;

      one_larger_integer  = (short) ( integer_from_keyboard  +  1 ) ;

      Console.Write( "\n You typed in " + integer_from_keyboard + "."
                  +  "\n My number is " + one_larger_integer    + "."
                  +  "\n Sorry, you lost. I won. The game is over.\n") ;
   }
}



