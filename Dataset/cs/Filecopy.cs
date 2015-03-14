
//  Filecopy.cs  (c) 2003 Kari Laitinen

//  www.naturalprogramming.com

using System ;
using System.IO ;  // Classes for file handling.

class Filecopy
{
   static void Main()
   {
      Console.Write( "\n This program copies text from one file"
                   + "\n to another file. Please, give the name of"
                   + "\n the file to be copied: " ) ;

      string  name_of_file_to_be_copied  =  Console.ReadLine() ;

      Console.Write( "\n Give the name of the duplicate file: " ) ;

      string  name_of_new_duplicate_file  =  Console.ReadLine() ;

      try
      {
         StreamReader file_to_be_copied  =
                          new  StreamReader( name_of_file_to_be_copied ) ;

         StreamWriter new_duplicate_file  =
                          new  StreamWriter( name_of_new_duplicate_file ) ;

         Console.Write( "\n Copying in progress ... \n" ) ;

         int  text_line_counter  =  0 ;
         bool end_of_file_encountered  =  false ;

         while ( end_of_file_encountered  ==  false )
         {
            string  text_line_from_file  =  file_to_be_copied.ReadLine() ;

            if ( text_line_from_file  ==  null )
            {
               end_of_file_encountered  =  true ;
            }
            else
            {
               new_duplicate_file.WriteLine( text_line_from_file ) ;
               text_line_counter  ++  ;
            }
         }

         Console.Write( "\n Copying ready. "  +  text_line_counter
                      + " lines were copied. \n" ) ;

         file_to_be_copied.Close() ;
         new_duplicate_file.Close() ;
      }
      catch ( FileNotFoundException )
      {
         Console.Write( "\n Cannot open "  +  name_of_file_to_be_copied ) ;
      }
      catch ( Exception )
      {
         Console.Write( "\n File error. Probably cannot write to "
                     +  name_of_new_duplicate_file ) ;
      }
   }
}




