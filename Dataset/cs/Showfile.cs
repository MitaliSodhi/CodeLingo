
//  Showfile.cs  (c) 2003 Kari Laitinen

using System ;
using System.IO ;

class Showfile
{
   static void Main()
   {
      Console.Write( "\n This program prints the contents of a text"
                  +  "\n file to the screen. Please, give the name"
                  +  "\n of a text file: " ) ;

      string  file_name_from_user  =  Console.ReadLine() ;

      try
      {
         StreamReader file_to_print  =
                         new  StreamReader( file_name_from_user ) ;

         Console.Write( "\n The contents of file is: \n\n" ) ;

         int  character_counter  =  0  ;

         int character_code_from_file  =  file_to_print.Read() ;

         while ( character_code_from_file  !=  -1 )
         {
            Console.Write( (char) character_code_from_file ) ;
            character_counter  ++  ;

            character_code_from_file  =  file_to_print.Read() ;
         }

         file_to_print.Close() ;

         Console.Write( "\n "  +  character_counter
                     +  " characters were displayed on the screen.\n" ) ;
      }
      catch ( FileNotFoundException )
      {
         Console.Write( "\n Cannot open file " + file_name_from_user ) ;
      }
   }
}



