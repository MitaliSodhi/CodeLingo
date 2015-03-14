
//  StringReverse.cs (c) 2003 Kari Laitinen

using System ;

class StringReverse
{
   public static void Main()
   {
      Console.Write("\n This program is able to reverse a string."
                 +  "\n Please, type in a string.\n\n   " ) ;

      string  string_from_keyboard  =  Console.ReadLine() ;

      Console.Write("\n String length is " + string_from_keyboard.Length
                 +  ".\n\n String in reverse character order: \n\n   " ) ;

      int character_index  =  string_from_keyboard.Length ;

      while (  character_index  >  0  )
      {
         character_index  --  ;
         Console.Write( string_from_keyboard[ character_index ] ) ;
      }
   }
}





