
//  Search.cs  (c) 2003 Kari Laitinen

//  www.naturalprogramming.com

using System ;
using System.IO ;

class Search
{
   static void search_string_in_file( string  file_name_from_caller,
                                      string  string_to_be_searched )
   {
      try
      {
         StreamReader file_to_read  =  new  StreamReader(
                                                 file_name_from_caller ) ;
         Console.Write( "\n Searching ... \""
                     +  string_to_be_searched  + "\"\n" ) ;

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

               if ( text_line_from_file.IndexOf(
                                           string_to_be_searched )  !=  -1 )
               {
                  Console.Write( "\n String \"" +  string_to_be_searched
                               + "\" was found on line "  +  line_counter ) ;
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
      if ( command_line_parameters.Length  ==  2 )
      {
         search_string_in_file ( command_line_parameters[ 0 ],
                                 command_line_parameters[ 1 ] ) ;
      }
      else
      {
         Console.Write( "\n This program can search a string in a "
                      + "\n text file. Give first the file name :  " ) ;

         string  file_name_given_by_user  =  Console.ReadLine() ;

         Console.Write( "\n Type in the string to be searched: " ) ;

         string  string_to_be_searched    =  Console.ReadLine() ;

         search_string_in_file( file_name_given_by_user,
                                string_to_be_searched ) ;
      }
   }
}


