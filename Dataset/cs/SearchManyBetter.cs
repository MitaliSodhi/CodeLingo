
//  SearchManyBetter.cs  (c) Kari Laitinen

//  http://www.naturalprogramming.com

//  2004-11-19  File created.
//  2004-11-19  Last modification.

//  The AND and OR features are not implemented in this program.

//  A better solution to exercise 14-5.

using System ;
using System.IO ;

class SearchManyBetter
{
   static void search_strings_in_file( string  file_name_from_caller,
                                       string[]  strings_to_be_searched )
   {
      try
      {
         StreamReader file_to_read  =  new  StreamReader(
                                                 file_name_from_caller ) ;

         int   line_counter  =  0 ;
         bool  end_of_file_encountered  =  false ;

         while ( end_of_file_encountered  ==  false )
         {
            string  text_line_from_file   =  file_to_read.ReadLine() ;

            if ( text_line_from_file  ==  null )
            {
               end_of_file_encountered  =  true ;
            }
            else
            {
               line_counter  ++ ;

               for ( int string_index  =  0 ;
                         string_index  <  strings_to_be_searched.Length ;
                         string_index  ++ )
               {
                  string  string_to_be_searched  =
                                 strings_to_be_searched[ string_index ] ;

                  if ( text_line_from_file.IndexOf(
                                     string_to_be_searched )  !=  -1 )
                  {
                     Console.Write( "\n String \"" +  string_to_be_searched
                                  + "\" was found on line "  +  line_counter ) ;
                  }
               }
            }
         }

         file_to_read.Close() ;
      }
      catch ( FileNotFoundException )
      {
         Console.Write( "\n Cannot open file " + file_name_from_caller ) ;
      }
   }


   static void Main( string[] command_line_parameters )
   {
      string[]  strings_to_be_searched ;

      string  file_name_given_by_user ;

      if ( command_line_parameters.Length  > 1 )
      {
         strings_to_be_searched  =  new  string[
                         command_line_parameters.Length  - 1 ] ;

         for ( int string_index  =  0 ;
                   string_index  <  strings_to_be_searched.Length ;
                   string_index  ++ )
         {
            strings_to_be_searched[ string_index ]  =
                         command_line_parameters[ string_index  +  1 ] ;
         }

         file_name_given_by_user  =  command_line_parameters[ 0 ] ;
      }
      else
      {
         Console.Write( "\n This program can search a string in a "
                      + "\n text file. Give first the file name :  " ) ;

         file_name_given_by_user  =  Console.ReadLine() ;

         Console.Write( "\n Type in the string to be searched: " ) ;

         string  string_to_be_searched    =  Console.ReadLine() ;

         strings_to_be_searched  =  new  string[ 1 ] ;
         strings_to_be_searched[ 0 ]  =  string_to_be_searched ;
      }

      search_strings_in_file( file_name_given_by_user,
                              strings_to_be_searched ) ;
   }
}


