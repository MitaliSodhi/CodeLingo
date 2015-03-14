
//  HexadecimalString.cs  (c) 2003 Kari Laitinen

using System ;

class HexadecimalString
{
   static void Main()
   {
      Console.Write( "\n Please, type in a string:\n\n  " ) ;

      string  string_from_keyboard  =  Console.ReadLine() ;

      Console.Write( "\n Your string in hexadecimal character codes:\n\n  " ) ;

      for ( int character_index  =  0 ;
                character_index  <  string_from_keyboard.Length ;
                character_index  ++ )
      {
         char character_in_string  =  string_from_keyboard[ character_index ] ;

         Console.Write( 
            Convert.ToInt32( character_in_string ).ToString( "X" ) + " " ) ;
      }
   }
}



