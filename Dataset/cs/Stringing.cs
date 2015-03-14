
//  Stringing.cs (c) 2002-2004 Kari Laitinen

//  26.11.2002  C# file created.
//  18.05.2004  Last modification

using System ;

class Stringing
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


      foreach ( char character_in_text in text_to_print )
      {
         Console.Write( " "  +  character_in_text ) ;
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




