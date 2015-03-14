
//  SplittingSentence.cs  (c) 2004 Kari Laitinen

//  http://www.naturalprogramming.com

//  2004-10-31  File created.
//  2004-10-31  Last modification.

//  A solutions to Exercise 8-9.

using System ;

class SplittingSentence
{
   static void Main()
   {
      Console.Write( "\n Please, type in a sentence. \n\n    " ) ;

      string  given_sentence  =  Console.ReadLine() ;

      Console.Write( "\n Splitted sentence with reversed words: \n    " ) ;

      char[]  separator_characters  =  { ' ' } ; 

      string[]  words_of_the_sentence  =
                            given_sentence.Split( separator_characters ) ;

      for ( int word_index  =  0 ;
                word_index  <  words_of_the_sentence.Length ;
                word_index  ++ )
      {
         Console.Write( "\n    " ) ;

         string  word_to_print  =  words_of_the_sentence[ word_index ] ;

         int character_index  =  word_to_print.Length ;

         while( character_index  >  0 )
         {
            character_index  -- ;
            Console.Write( word_to_print[ character_index ] ) ;
         }
      }
   }
}



