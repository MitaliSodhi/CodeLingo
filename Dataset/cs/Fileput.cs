
//  Fileput.cs  (c) 2003 Kari Laitinen

using System ;
using System.IO ;  // Classes for file handling.

class Fileput
{
   static void Main()
   {
      Console.Write( "\n This program allows you to store text in a"
                   + "\n text file. First give a file name: " ) ;

      string  file_name_from_user  =  Console.ReadLine() ;

      try
      {
         StreamWriter output_file  = 
                           new  StreamWriter( file_name_from_user ) ;

         Console.Write( "\n Please, start typing in text from the keyboard."
                      + "\n Type in Ctrl-A and Enter to finish. \n\n" ) ;

         char character_from_keyboard  = (char) Console.Read() ;

         while( character_from_keyboard  !=  '\u0001'  )
         {
            output_file.Write( character_from_keyboard ) ;

            character_from_keyboard  =  (char) Console.Read() ;
         }

         output_file.Close() ;
      }
      catch ( Exception )
      {
         Console.Write( "\n Cannot write to file " + file_name_from_user ) ;
      }
   }
}




