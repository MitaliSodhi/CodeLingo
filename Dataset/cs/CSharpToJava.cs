
//  CSharpToJava.cs  (c) 2005 Kari Laitinen

//  http://www.naturalprogramming.com

//  2005-03-02  File created.
//  2006-02-23  Last modification.

//  This program helps to convert C# programs to Java 1.5 programs.

//  Probably this can only convert the programs of Kari Laitinen's books.

//  In order to 

using System ;
using System.IO ;           // Classes for file handling.
using System.Collections ;  // ArrayList class etc.

class CSharpToJava
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


   static void replace_names_in_file( string  original_file_name )
   {

      ArrayList names_to_replace  =  new  ArrayList() ;
      ArrayList replacement_names  =  new  ArrayList() ;


      names_to_replace.Add( "Console.Write" ) ;
      replacement_names.Add( "System.out.print" ) ;

      names_to_replace.Add( "using System.IO" ) ;
      replacement_names.Add( "import java.io.*" ) ;

      names_to_replace.Add( "using System" ) ;
      replacement_names.Add( "import java.util.*" ) ;

      names_to_replace.Add( "static void Main()" ) ;
      replacement_names.Add(
                   "public static void main( String[] not_in_use )" ) ;

      names_to_replace.Add(
              "static void Main( string[] command_line_parameters )" ) ;
      replacement_names.Add(
         "public static void main( String[] command_line_parameters )" ) ;

      names_to_replace.Add( "Convert.ToInt32( Console.ReadLine()" ) ;
      replacement_names.Add( "keyboard.nextInt(" ) ;

      names_to_replace.Add( "Convert.ToDouble( Console.ReadLine()" ) ;
      replacement_names.Add( "keyboard.nextDouble(" ) ;

      names_to_replace.Add( "Convert.ToChar( Console.ReadLine()" ) ;
      replacement_names.Add( "keyboard.nextLine().charAt( 0" ) ;

      names_to_replace.Add( "Console.ReadLine()" ) ;
      replacement_names.Add( "keyboard.nextLine()" ) ;

      names_to_replace.Add( " string " ) ;
      replacement_names.Add( " String " ) ;

      names_to_replace.Add( " string[" ) ;
      replacement_names.Add( " String[" ) ;

      names_to_replace.Add( " virtual " ) ;
      replacement_names.Add( " " ) ;

      names_to_replace.Add( " override " ) ;
      replacement_names.Add( " " ) ;

      names_to_replace.Add( " bool " ) ;
      replacement_names.Add( " boolean " ) ;

      names_to_replace.Add( ".cs" ) ;
      replacement_names.Add( ".java" ) ;

      names_to_replace.Add( "string.Length" ) ;
      replacement_names.Add( "string.length()" ) ;

      names_to_replace.Add( ".Length" ) ;
      replacement_names.Add( ".length" ) ;

      names_to_replace.Add( "string[ character_index ]" ) ;
      replacement_names.Add( "string.charAt( character_index )" ) ;

      names_to_replace.Add( "IndexOf(" ) ;
      replacement_names.Add( "indexOf(" ) ;

      names_to_replace.Add( "ToUpper(" ) ;
      replacement_names.Add( "toUpperCase(" ) ;

      names_to_replace.Add( "ToCharArray(" ) ;
      replacement_names.Add( "toCharArray(" ) ;

      names_to_replace.Add( "Close(" ) ;
      replacement_names.Add( "close(" ) ;

      names_to_replace.Add( "ToLower(" ) ;
      replacement_names.Add( "toLowerCase(" ) ;

      names_to_replace.Add( "Convert.ToInt32(" ) ;
      replacement_names.Add( "Integer.parseInt(" ) ;

      names_to_replace.Add( "Equals(" ) ;
      replacement_names.Add( "equals(" ) ;

      names_to_replace.Add( "Add(" ) ;
      replacement_names.Add( "add(" ) ;

      names_to_replace.Add( "ToString(" ) ;
      replacement_names.Add( "toString(" ) ;


/****
      names_to_replace.Add( "" ) ;
      replacement_names.Add( "" ) ;

*****/

/****  The following loop was used to test this program:

      for ( int name_index  =  0 ;
                name_index  <  names_to_replace.Count ;
                name_index  ++  )
      {
         Console.Write( "\n "  +  names_to_replace[ name_index ]
                     +  "   "  +  replacement_names[ name_index ]  ) ;
      }

****/

      try
      {
         StreamReader original_file  =  new StreamReader(
                                                original_file_name ) ;
         ArrayList  original_text_lines  =  new  ArrayList() ;
         ArrayList  modified_text_lines  =  new  ArrayList() ;

         DateTime  current_date  =  DateTime.Now ;

         modified_text_lines.Add( "" ) ;

         modified_text_lines.Add(
                    "//  " + original_file_name +
                    "  Copyright (c) "  +  current_date.Year +
                    " Kari Laitinen" ) ;

         modified_text_lines.Add( "" ) ;

         modified_text_lines.Add(
                    "//  http://www.naturalprogramming.com" ) ;

         modified_text_lines.Add( "" ) ;

         modified_text_lines.Add(
                    "//  " + current_date.Year  +
                    "-"  +  current_date.Month.ToString( "D2" )  +
                    "-"  +  current_date.Day.ToString( "D2" )  +
                    "   File created." ) ;

         modified_text_lines.Add(
                    "//  " + current_date.Year  +
                    "-"  +  current_date.Month.ToString( "D2" )  +
                    "-"  +  current_date.Day.ToString( "D2" )  +
                    "   Last modification." ) ;


         bool opening_brace_of_main_method_found  =  false ;
         bool start_of_main_method_found  =  false ;


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

               for ( int name_index  =  0 ;
                         name_index  <  names_to_replace.Count ;
                         name_index  ++ )
               {
                  if ( text_line_from_file.IndexOf(
                         (string)  names_to_replace[ name_index ] )  !=  -1 )
                  {
                     text_line_from_file  =
                          text_line_from_file.Replace(
                              (string) names_to_replace[ name_index ],
                              (string) replacement_names[ name_index ] ) ;

                     Console.Write( "\n \""  +  names_to_replace[ name_index ]
                          +  "\" was replaced with \"" 
                          +  replacement_names[ name_index ]
                          +  "\" on line "  +  line_counter  ) ;

                  }
               }

               //  The following three if constructs are used to find
               //  out when to add the line "Scanner keyboard ... "
               //  to the beginning of the main() method

               if ( opening_brace_of_main_method_found  ==  true )
               {
                  modified_text_lines.Add(
                  "      Scanner keyboard = new Scanner( System.in ) ;" ) ;

                  modified_text_lines.Add( "" ) ;

                  opening_brace_of_main_method_found  =  false ;
                  start_of_main_method_found  =  false ;
               }

               if ( start_of_main_method_found  ==  true )
               {
                  if ( text_line_from_file.IndexOf( "{" ) != -1 )
                  {
                     opening_brace_of_main_method_found  =  true ;
                  }
               }

               if ( text_line_from_file.IndexOf( "void main(" ) !=  -1 )
               {
                  start_of_main_method_found  =  true ;
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

      if ( command_line_parameters.Length  ==  1 )
      {
         file_name_given_by_user  =  command_line_parameters[ 0 ] ;
      }
      else
      {
         Console.Write( "\n This program can replace names in a "
                     +  "\n program file. Give first the file name :  " ) ;

         file_name_given_by_user  =  Console.ReadLine() ;
      }

      replace_names_in_file( file_name_given_by_user ) ;
   }
}



