
//  GameSolution_5_2.cs  (c) 2004 Kari Laitinen

//  www.naturalprogramming.com

using System ;

class GameSolution_5_2
{
   static void Main()
   {
      int  integer_from_keyboard ;
      int  one_larger_integer ;

      Console.Write(
          "\n This program is a computer game. Please, type in "
        + "\n an integer in the range  1 ... 2147483646 : " ) ;

      integer_from_keyboard  =  Convert.ToInt32( Console.ReadLine() ) ;

      one_larger_integer  =  integer_from_keyboard  +  1 ;

      Console.Write( "\n You typed in " + integer_from_keyboard + "."
                  +  "\n My numbers are " + one_larger_integer   ) ;

      one_larger_integer  =  one_larger_integer  +  1 ;

      Console.Write( ", "  +  one_larger_integer ) ;

      one_larger_integer  =  one_larger_integer  +  1 ;

      Console.Write( ", and "  +  one_larger_integer  +  "."  
                  +  "\n Sorry, you lost. My numbers are larger.\n") ;
   }
}



