
//  FileCompare.cs  (c) 2003 Kari Laitinen

//  http://www.naturalprogramming.com

//  2004-11-19  File created.
//  2004-11-19  Last modification.

//  A solution to Exercise 14-6.

using System ;
using System.IO ;  // Classes for file handling.

class FileCompare
{
   static void Main( string[]  command_line_parameters  )
   {
      string  name_of_first_file ;
      string  name_of_second_file ;

      if ( command_line_parameters.Length  ==  2 )
      {
         name_of_first_file  =  command_line_parameters[ 0 ] ;
         name_of_second_file =  command_line_parameters[ 1 ] ;
      }
      else
      {
         Console.Write( "\n This program compares a file"
                      + "\n to another file. Please, give the name of"
                      + "\n the first file: " ) ;

         name_of_first_file  =  Console.ReadLine() ;

         Console.Write( "\n Give the name of the second file: " ) ;

         name_of_second_file  =  Console.ReadLine() ;
      }

      try
      {
         FileStream first_file  =
                          File.OpenRead( name_of_first_file ) ;

         FileStream second_file  =
                          File.OpenRead( name_of_second_file ) ;

         Console.Write( "\n Comparison in progress ... \n" ) ;

         int  number_of_bytes_compared  =  0 ;

         //  If this program were used for serious file comparison
         //  operations, it might be better to use a larger array
         //  (input buffer) into which bytes are read.

         byte[]  bytes_from_first_file  =  new  byte[ 128 ] ;
         byte[]  bytes_from_second_file  =  new  byte[ 128 ] ;

         bool  files_are_equal      =  true  ;
         bool  comparison_is_ready  =  false ;

         while ( files_are_equal  ==  true  &&
                 comparison_is_ready  ==  false )
         {
            int  first_number_of_bytes  =
                    first_file.Read( bytes_from_first_file, 0,
                                      bytes_from_first_file.Length ) ;
            int  second_number_of_bytes  =
                    second_file.Read( bytes_from_second_file, 0,
                                      bytes_from_second_file.Length ) ;

            if ( first_number_of_bytes  ==  0  &&
                 second_number_of_bytes  ==  0 )
            {
               comparison_is_ready  =  true ;
            }
            else if ( first_number_of_bytes  !=  second_number_of_bytes )
            {
               files_are_equal  =  false ;
            }
            else 
            {
               int byte_index  =  0 ;

               while (  byte_index  <  first_number_of_bytes  &&
                        files_are_equal  ==  true  )
               {
                  if ( bytes_from_first_file[ byte_index ]  !=
                                  bytes_from_second_file[ byte_index ] )
                  {
                     files_are_equal  =  false ;
                  }

                  number_of_bytes_compared  ++  ;
                  byte_index  ++ ;
               }
            }
         }

         if ( files_are_equal  ==  true )
         {
            Console.Write( "\n The files are equal. " ) ;
         }
         else
         {
            Console.Write( "\n The files are NOT equal. " ) ;
         }

         Console.Write( "\n  "  +  number_of_bytes_compared
                      + "  bytes were compared. \n" ) ;

         first_file.Close() ;
         second_file.Close() ;
      }
      catch ( FileNotFoundException )
      {
         Console.Write( "\n Cannot open both files. " ) ;
      }
      catch ( Exception )
      {
         Console.Write( "\n File error. " ) ;
      }
   }
}




