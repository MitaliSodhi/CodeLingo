
//  StringInShrinkingPieces.cs  (c) 2004 Kari Laitinen

//  http://www.naturalprogramming.com

//  2004-10-31  File created.
//  2004-10-31  Last modification.

//  A solutions to Exercise 8-8.

using System ;

class StringInShrinkingPieces
{
   static void Main()
   {
      Console.Write( "\n Please, type in a string. \n\n    " ) ;

      string  given_string  =  Console.ReadLine() ;

      Console.Write( "\n The given string in shrinking pieces: \n" ) ;


      for ( int character_index  =  0 ;
                character_index  <  given_string.Length ;
                character_index  ++ )
      {
         string  substring_of_given_string  =
                          given_string.Substring( character_index ) ;

         Console.Write(  "\n    "  +  substring_of_given_string ) ;
      }
   }
}



