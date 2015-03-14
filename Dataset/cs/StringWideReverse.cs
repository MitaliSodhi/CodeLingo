
//  StringWideReverse.cs (c) Kari Laitinen

//  http://www.naturalprogramming.com

//  2004-10-30  File created.
//  2004-10-30  Last modification.

//  A solution to Exercise 8-1.

using System ;

class StringWideReverse
{
   public static void Main()
   {
      Console.Write("\n This program is able to widen and reverse a string."
                 +  "\n Please, type in a string.\n\n   " ) ;

      string  string_from_keyboard  =  Console.ReadLine() ;

      Console.Write("\n String length is " + string_from_keyboard.Length
                 +  ".\n\n String in wide reverse character order: \n\n   " ) ;

      int character_index  =  string_from_keyboard.Length ;

      while (  character_index  >  0  )
      {
         character_index  --  ;
         Console.Write( " "  +  string_from_keyboard[ character_index ] ) ;
      }
   }
}





