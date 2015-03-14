
//  StringMethods.cs  (c) 2003 Kari Laitinen

//  This program is the C# version of string_functions.cpp.
//  Because no string methods were needed in this program,
//  this is not discussed in the C# book.

using System ;

class StringMethods
{
   static void Main()
   {
      string  name_of_user ;
      string  first_part_of_sentence  = "\n This program shows you, ";
      string  third_part_of_sentence  = ", the string methods." ;

      string  sentence_to_screen ;

      Console.Write( "\n Please, type in your name: " ) ;
      name_of_user  =  Console.ReadLine() ;

      sentence_to_screen  =  first_part_of_sentence  +
                             name_of_user  +
                             third_part_of_sentence  ;

      Console.Write( sentence_to_screen ) ;

      Console.Write( "\n\n By the way, your name has "
                  +  name_of_user.Length  +  " characters. \n" ) ;
   }
}



