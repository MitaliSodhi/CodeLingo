
//  Widename.cs  (c) 2003 Kari Laitinen

using System ;

class Widename
{
   static void Main()
   {
      string  name_from_keyboard ;
      int     character_index  =  0 ;

      Console.Write( "\n Please, type in your name: " ) ;
      name_from_keyboard  =  Console.ReadLine() ;

      Console.Write( "\n Here is your name in a wider form: \n\n  " ) ;

      while ( character_index  <  name_from_keyboard.Length )
      {
         Console.Write(  " "  +  name_from_keyboard[ character_index ] ) ;
         character_index  ++  ;
      }
   }
}


