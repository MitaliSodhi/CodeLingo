
//  StringingWithCharEnumerator.cs (c) 2004 Kari Laitinen

//  18.05.2004  File created.
//  18.05.2004  Last modification

//  This program works like Stringing.cs but this one uses
//  a CharEnumerator instead of a foreach loop.

using System ;

class StringingWithCharEnumerator
{
   static void Main()
   {
      string  abcdefgh_string  =  "abcdefgh" ;

      string  xxxxxxxx_string  =  new  string( 'x', 8 ) ;

      string  defgzzzz_string  =  abcdefgh_string.Substring( 3, 4 ) ;

      defgzzzz_string  =  defgzzzz_string  +  "zzzz" ;

      string  text_to_print  =  "  "  +  abcdefgh_string  +
                                "  "  +  xxxxxxxx_string  +
                                "  "  +  defgzzzz_string  +  "  " ;
      Console.Write( "\n" ) ;

      int  character_index  =  0 ;

      while ( character_index  <  text_to_print.Length )
      {
         Console.Write( text_to_print[ character_index ] ) ;
         character_index  ++ ;
      }


      Console.Write( "\n\n" ) ;

      CharEnumerator  character_in_text ;

      character_in_text  =  text_to_print.GetEnumerator() ;

      while ( character_in_text.MoveNext() )
      {
         Console.Write( " "  +  character_in_text.Current ) ;
      }


      Console.Write( "\n" ) ;

      character_index  =  text_to_print.Length ;

      while ( character_index  >  0 )
      {
         character_index  --  ;
         Console.Write( " "  +  text_to_print[ character_index ] ) ;
      }
   }
}




