
//  Words.cs  (c) 2003 Kari Laitinen

using System ;

class Words
{
   static void Main()
   {
      Console.Write( "\n This program separates the words of a"
                   + "\n sentence and prints them in wide form."
                   + "\n Type in a sentence.\n\n   " ) ;

      char character_in_sentence  =  (char) Console.Read() ;

      Console.Write( "\n  " ) ;

      while ( character_in_sentence  !=  '\n' )
      {
         if ( character_in_sentence  ==  ' ' )
         {
             Console.Write( "\n  " ) ;
         }
         else
         {
             Console.Write( " "  +  character_in_sentence ) ;
         }

         character_in_sentence  =  (char) Console.Read() ;
      }
   }
}



