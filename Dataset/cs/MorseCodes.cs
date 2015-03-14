
//  MorseCodes.cs (c) 2004 Kari Laitinen

//  www.naturalprogramming.com

using System ;
using System.Collections ;

class MorseCodes
{
   static void Main()
   {
      string[]  array_of_morse_codes  =

       { "A", ".-",   "B", "-...", "C", "-.-.", "D", "-..", "E", ".",
         "F", "..-.", "G", " --.", "H", "....", "I", "..",  "J", ".---",
         "K", "-.-",  "L", ".-..", "M", "--",   "N", "-.",  "O", "---",
         "P", ".--.", "Q", "--.-", "R", ".-.",  "S", "...", "T", "-",   
         "U", "..-",  "V", "...-", "W", ".--",  "X", "-..-","Y", " -.--", 
         "Z", "--..", "1", ".----","2", "..---","3", "...--","4","....-",
         "5", ".....","6", "-....","7", "--...","8", "---..","9","----.",
         "0", "-----"," ", "     "  } ;

      ArrayList  arraylist_of_morse_codes  =
                           new  ArrayList( array_of_morse_codes ) ;

      Console.Write( "\n  Type in your name: " ) ;

      string  given_name  =  Console.ReadLine().ToUpper() ;

      Console.Write( "\n  Your name in Morse codes is: \n\n" ) ;

      for ( int character_index  =  0 ;
                character_index  <  given_name.Length ;
                character_index  ++ )
      {
         int index_of_character_in_arraylist  =
                arraylist_of_morse_codes.IndexOf( 
                               given_name[ character_index ].ToString() ) ;

         if ( index_of_character_in_arraylist  !=  -1 )
         {
            Console.Write( "   "  +  
                      arraylist_of_morse_codes[
                                  index_of_character_in_arraylist + 1 ] ) ;
         }
      }
   }
}




/************

   static void Main()
   {
      ArrayList  array_of_text_lines  =  new  ArrayList() ;

      string  first_line  =  
               "   A .-    B -...  C -.-.  D -..   E .     F ..-. "  ;

      array_of_text_lines.Add( first_line ) ;

      array_of_text_lines.Add(
               "   G --.   H ....  I ..    J .---  K -.-   L .-.. " ) ;
      array_of_text_lines.Add(
               "   M --    N -.    O ---   P .--.  Q --.-  R .-.  "
          +  "\n   S ...   T -     U ..-   V ...-  W .--   X -..- " ) ;
      array_of_text_lines.Add(
               "   Y -.--  Z --..  1 .---- 2 ..--- 3 ...-- 4 ....-"
          +  "\n   5 ..... 6 -.... 7 --... 8 ---.. 9 ----. 0 -----" ) ;

      Console.Write( "\n  Contents of array_of_text_lines: \n" ) ;

      for ( int text_line_index  =  0 ;
                text_line_index  <  array_of_text_lines.Count ;
                text_line_index  ++ )
      {
         Console.Write( "\n" +  array_of_text_lines[ text_line_index ] ) ;
      }
   }

****************/







