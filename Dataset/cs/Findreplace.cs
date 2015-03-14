
//  Findreplace.cs  (c) 2003 Kari Laitinen

//  www.naturalprogramming.com

using System ;
using System.IO ;           // Classes for file handling.
using System.Collections ;  // ArrayList class etc.

class Findreplace
{
   static void
   store_text_lines_to_file( ArrayList  given_array_of_text_lines,
                             string     given_file_name )
   {
      try
      {
         StreamWriter output_file  = 
                          new  StreamWriter( given_file_name ) ;

         for ( int line_index  =  0 ;
                   line_index  <  given_array_of_text_lines.Count ;
                   line_index  ++ )
         {
            output_file.WriteLine(
                          given_array_of_text_lines[ line_index ] ) ;
         }

         output_file.Close() ;
      }
      catch ( Exception )
      {
         Console.Write( "\n\n Cannot write to file \""
                     +  given_file_name  +  "\"\n" ) ;
      }
   }


   static void replace_string_in_file( string  original_file_name,
                                       string  string_to_replace,
                                       string  replacement_string )
   {
      try
      {
         StreamReader original_file  =  new StreamReader(
                                                original_file_name ) ;
         ArrayList  original_text_lines  =  new  ArrayList() ;
         ArrayList  modified_text_lines  =  new  ArrayList() ;

         int  line_counter  =  0 ;
         bool end_of_file_encountered  =  false ;

         while ( end_of_file_encountered  ==  false )
         {
            string  text_line_from_file   =  original_file.ReadLine() ;

            if ( text_line_from_file  ==  null )
            {
               end_of_file_encountered  =  true ;
            }
            else
            {
               line_counter  ++ ;
               original_text_lines.Add( text_line_from_file ) ;

               if ( text_line_from_file.IndexOf( string_to_replace )  !=  -1 )
               {
                  text_line_from_file  =
                          text_line_from_file.Replace( string_to_replace,
                                                       replacement_string ) ;

                  Console.Write( "\n \""  +  string_to_replace
                       +  "\" was replaced with \""  +  replacement_string
                       +  "\" on line "  +  line_counter  ) ;
               }

               modified_text_lines.Add( text_line_from_file ) ;
            }
         }

         original_file.Close() ;

         string  backup_file_name  =  original_file_name  +  ".bak" ;

         store_text_lines_to_file( original_text_lines,
                                   backup_file_name   ) ; 
         store_text_lines_to_file( modified_text_lines,
                                   original_file_name ) ;
      }
      catch ( FileNotFoundException )
      {
         Console.Write( "\n Cannot open file " + original_file_name ) ;
      }
   }


   static void Main( string[] command_line_parameters )
   {
      string  file_name_given_by_user ;
      string  string_to_replace ;
      string  replacement_string ;

      if ( command_line_parameters.Length  ==  3 )
      {
         file_name_given_by_user  =  command_line_parameters[ 0 ] ;
         string_to_replace        =  command_line_parameters[ 1 ] ;
         replacement_string       =  command_line_parameters[ 2 ] ;
      }
      else
      {
         Console.Write( "\n This program can replace a string in a "
                     +  "\n text file. Give first the file name :  " ) ;

         file_name_given_by_user  =  Console.ReadLine() ;

         Console.Write( "\n Type in the string to be replaced: " ) ;
         string_to_replace    =  Console.ReadLine() ;

         Console.Write( "\n Type in the replacement string:    " ) ;
         replacement_string   =  Console.ReadLine() ;
      }

      if ( string_to_replace  ==  ""  ||
           string_to_replace  ==  replacement_string )
      {
         Console.Write( "\n Cannot replace \""  +  string_to_replace
              +  "\" with \""  +  replacement_string  +  "\"\n\n" ) ;
      }
      else
      {
         replace_string_in_file( file_name_given_by_user,
                                 string_to_replace,
                                 replacement_string ) ;
      }
   }
}



