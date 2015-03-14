
//  Sentence.cs  (c) 1997-2004 Kari Laitinen

//  http://www.naturalprogramming.com

//  2006-06-13  File created.
//  2006-06-13  Last modification.

/*  The corresponding Java and C++ programs demonstrate 'bad' ways
    of writing switch-case constructs. C# is a better language
    in the sense that it does not accept switch-case constructs 
    that do not contain break statements. For this reason,
    this is quite an unnecessary program as a C# program.
    However, I whote this program so that it behaves almost like the
    corresponding program in the Java book.

    This program is not presented in the C# book.

    This program would be a too difficult program for Chapter 6
    because classes string and ArrayList are in use. 
*/

using System ;
using System.Collections ;

class Sentence
{
   public static void Main()
   {
      char  character_from_keyboard ;

      Console.Write(
              "\n Type in L, M, or S, depending on whether you want" 
           +  "\n a long, medium, or short sentence displayed:  "  ) ;

      character_from_keyboard  =  Convert.ToChar(
                                      Console.ReadLine().ToUpper() ) ;

      string[] sentence_components  = 
         {  "\n This is a ",
            "switch statement in a \n ",
            "program in a ",
            "book that teaches C# programming.",
            "\n I hope that this is an interesting book.\n"  } ;

      ArrayList  list_of_sentence_components  =
                              new  ArrayList( sentence_components ) ;

      switch ( character_from_keyboard )
      {
      case 'S' :
         list_of_sentence_components.RemoveAt( 1 ) ; //  remove second string
         list_of_sentence_components.RemoveAt( 1 ) ; //  remove second string
         break ;

      case 'M' :
         list_of_sentence_components.RemoveAt( 1 ) ;
         break ;

      case 'L' :
      default  :
         break ;
      }

      foreach ( string component_in_sentence  in  list_of_sentence_components )
      {
         Console.Write( component_in_sentence ) ;
      }
   }
}




