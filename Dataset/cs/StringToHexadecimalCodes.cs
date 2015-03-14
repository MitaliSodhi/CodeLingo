
//  StringToHexadecimalCodes.cs  (c) 2004 Kari Laitinen

//  http://www.naturalprogramming.com

//  2004-10-30  File created.
//  2004-10-30  Last modification.

//  A solutions to Exercise 8-3.

using System ;

class StringToHexadecimalCodes
{
   static void Main()
   {
      Console.Write( "\n Please, type in a string. \n\n    " ) ;

      string  given_string  =  Console.ReadLine() ;

      Console.Write( "\n The given string as hexadecimal codes: \n\n  " ) ;


      for ( int character_index  =  0 ;
                character_index  <  given_string.Length ;
                character_index  ++ )
      {
         Console.Write( " "  +
           Convert.ToInt32( given_string[ character_index ] ).ToString("X"));
      }
   }
}



