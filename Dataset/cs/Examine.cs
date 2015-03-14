
//  Examine.cs  (c) Kari Laitinen

//  http://www.naturalprogramming.com

//  2004-11-19  File created.
//  2004-11-19  Last modification.

//  A solution to Exercise 14-8.

using System ;
using System.IO ;    // Classes for file handling.
using System.Text ;  // Class StringBuilder etc.

class FileToNumbers
{
   static void Main( string[] command_line_parameters )
   {
      if ( command_line_parameters.Length  ==  1 )
      {
         try
         {
            FileStream file_to_read  =
                           File.OpenRead( command_line_parameters[ 0 ] ) ;

            byte[]  bytes_from_file  =  new  byte[ 16 ] ;

            int lines_printed_since_last_pause  =  0 ;

            int number_of_bytes_read  ;

            while (( number_of_bytes_read  =
                       file_to_read.Read( bytes_from_file, 0,
                                           bytes_from_file.Length ))  >  0 )
            {
               StringBuilder  line_of_bytes  =  new  StringBuilder() ;
               StringBuilder  bytes_as_characters  =  new  StringBuilder () ;

               for ( int byte_index  =  0 ;
                         byte_index  <  number_of_bytes_read ;
                         byte_index  ++ )
               {
                  line_of_bytes.Append( " "
                        +  bytes_from_file[ byte_index].ToString( "X2" )  ) ;

                  char  byte_as_character  =
                                  (char) bytes_from_file[ byte_index ] ;

                  if ( byte_as_character  >=  ' ' )
                  {
                     bytes_as_characters.Append( byte_as_character ) ;
                  }
                  else
                  {
                     bytes_as_characters.Append( ' ' ) ;
                  }
               }

               Console.Write( "\n" +  line_of_bytes.ToString().PadRight(16 * 3 )
                           +  "  "  +  bytes_as_characters.ToString() ) ;

               lines_printed_since_last_pause  ++  ;

               if ( lines_printed_since_last_pause  >  22 )
               {
                  Console.Write( "\n Press the Enter key to continue ..." ) ;
                  string any_string_from_keyboard  =  Console.ReadLine() ;
                  lines_printed_since_last_pause  =  0 ;
               }
            }

            file_to_read.Close() ;
         }
         catch ( FileNotFoundException )
         {
            Console.Write( "\n Cannot open file "
                        +  command_line_parameters[ 0 ] ) ;
         }
      }
      else
      {
         Console.Write( "\n You have to command this program as: \n"
                     +  "\n  Examine file.ext \n") ;
      }
   }
}




