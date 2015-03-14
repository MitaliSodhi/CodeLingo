
//  FileprintCountingCharacters.cs  (c) 2003 Kari Laitinen

//  http://www.naturalprogramming.com

//  2004-11-18  File created.
//  2004-11-18  Last modification.

//  A solution to Exercise 14-1.

using System ;
using System.IO ;

class FileprintCountingCharacters
{
   static void Main()
   {
      Console.Write( "\n This program prints the contents of a text"
                   + "\n file to the screen. Give a file name: " ) ;

      string  file_name_from_user  =  Console.ReadLine() ;

      try
      {
         StreamReader file_to_print  =  new  StreamReader(
                                               file_name_from_user ) ;
         int  line_counter  =  0 ;
         int  character_counter  =  0 ;
         bool end_of_file_encountered  =  false ;

         while ( end_of_file_encountered  ==  false )
         {
            string  text_line_from_file   =  file_to_print.ReadLine() ;

            if ( text_line_from_file  ==  null )
            {
               end_of_file_encountered  =  true ;
            }
            else
            {
               Console.Write( text_line_from_file  +  "\n" ) ;
               line_counter  ++  ;

               //  The line termination characters are not counted
               //  because they are not present in text_line_from_file

               character_counter  =  character_counter  +
                                     text_line_from_file.Length ;
            }
         }

         file_to_print.Close() ;
         Console.Write( "\n  " +  line_counter  + " lines printed." ) ;
         Console.Write( "\n  " +  character_counter  
                     +  " characters were printed.\n" ) ;
      }
      catch ( FileNotFoundException )
      {
         Console.Write( "\n Cannot open file " + file_name_from_user ) ;
      }
   }
}




