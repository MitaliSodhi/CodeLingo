
//  FilecopyCommand.cs  (c) Kari Laitinen

//  http://www.naturalprogramming.com

//  2004-11-19  File created.
//  2004-11-19  Last modification.

//  A solution to Exercise 14-2.

using System ;
using System.IO ;  // Classes for file handling.

class FilecopyCommand
{
   static void copy_file( string  name_of_file_to_be_copied,
                          string  name_of_new_duplicate_file )
   {
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

   static void Main( string[] command_line_parameters )
   {
      if ( command_line_parameters.Length  ==  2 )
      {
         copy_file ( command_line_parameters[ 0 ],
                     command_line_parameters[ 1 ] ) ;
      }
      else
      {
         Console.Write( "\n This program copies text from one file"
                      + "\n to another file. Please, give the name of"
                      + "\n the file to be copied: " ) ;

         string  name_of_file_to_be_copied  =  Console.ReadLine() ;

         Console.Write( "\n Give the name of the duplicate file: " ) ;

         string  name_of_new_duplicate_file  =  Console.ReadLine() ;

         copy_file( name_of_file_to_be_copied,
                    name_of_new_duplicate_file ) ;
      }
   }


}




