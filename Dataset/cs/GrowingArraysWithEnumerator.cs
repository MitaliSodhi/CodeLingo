
//  GrowingArraysWithEnumerator.cs (c) 2004 Kari Laitinen

//  www.naturalprogramming.com

//  This program works like GrowingArrays.cs.
//  An enumerator is used here to iterate through the an array.

using System ;
using System.Collections ;

class GrowingArrays
{
   static void Main()
   {
      ArrayList  array_of_integers  =  new  ArrayList() ;

      for ( int integer_to_array  =  202 ;
                integer_to_array  <  303 ;
                integer_to_array  =  integer_to_array  +  11 )
      {
         array_of_integers.Add( integer_to_array ) ;
      }

      Console.Write( "\n  Contents of array_of_integers: \n\n  " ) ;

      for ( int integer_index  =  0 ;
                integer_index  <  array_of_integers.Count ;
                integer_index  ++  )
      {
         Console.Write( "   "  +  array_of_integers[ integer_index ] ) ;
      }

      ArrayList  array_of_text_lines  =  new  ArrayList() ;

      string  first_line   =  "   The following are Morse codes:" ;

      array_of_text_lines.Add( first_line ) ;

      array_of_text_lines.Add(
               "   A .-    B -...  C -.-.  D -..   E .     F ..-." ) ;
      array_of_text_lines.Add(
               "   G --.   H ....  I ..    J .---  K -.-   L .-.." ) ;
      array_of_text_lines.Add(
               "   M --    N -.    O ---   P .--.  Q --.-  R .-. "
          +  "\n   S ...   T -     U ..-   V ...-  W .--   X -..-" ) ;
      array_of_text_lines.Add(
               "   Y -.--  Z --..  1 .---- 2 ..--- 3 ...-- 4 ....-"
          +  "\n   5 ..... 6 -.... 7 --... 8 ---.. 9 ----. 0 -----" ) ;

      Console.Write( "\n\n  Contents of array_of_text_lines: \n" ) ;

      IEnumerator  text_line_to_print  =
                           array_of_text_lines.GetEnumerator() ;

      while ( text_line_to_print.MoveNext() )
      {
         Console.Write( "\n" +  text_line_to_print.Current ) ;
      }

      Console.Write( "\n" ) ;
   }
}





