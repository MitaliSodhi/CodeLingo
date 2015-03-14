
//  EditorSimple.cs  (c) Kari Laitinen

//  http://www.naturalprogramming.com

//  2004-11-19  File created.
//  2004-11-19  Last modification.

//  A solution to Exercise 14-4.

//  This program would be easier to make by using an ArrayList array.
//  Those arrays are a subject in Chapter 15.

using System ;
using System.IO ;           // Classes for file handling.

class EditorSimple
{
   static void
   store_text_lines_to_file( string[]  given_array_of_text_lines,
                             int       number_of_lines_to_store,
                             string    given_file_name )
   {
      try
      {
         StreamWriter output_file  = 
                          new  StreamWriter( given_file_name ) ;

         for ( int line_index  =  0 ;
                   line_index  <  number_of_lines_to_store ;
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


   static void Main( string[] command_line_parameters )
   {
      string  file_name_given_by_user  =  null ;

      if ( command_line_parameters.Length  ==  1 )
      {
         file_name_given_by_user  =  command_line_parameters[ 0 ] ;
      }

      Console.Write( "\n This program is a simple text editor. "
                  +  "\n Please, start writing text. You can stop by"
                  +  "\n writing a dot . into the first column.\n\n" ) ;

      int  number_of_text_lines_given  =  0 ;

      string[]  given_text_lines  =  new  string[ 200 ] ;

      bool  user_wants_to_stop_writing_text  =  false ;

      while ( user_wants_to_stop_writing_text  ==  false )
      {
         string  text_line_from_user  =  Console.ReadLine() ;

         //  We must check the line length in order to allow
         //  lines of zero length to be put into the file.

         if ( text_line_from_user.Length  >    0  &&
              text_line_from_user[ 0 ]    ==  '.' )
         {
            user_wants_to_stop_writing_text  =  true ;
         }
         else
         {
            given_text_lines[ number_of_text_lines_given ]  =
                                              text_line_from_user ;

            number_of_text_lines_given  ++  ;

            if ( number_of_text_lines_given  >=
                                            given_text_lines.Length )
            {
               Console.Write( "\n\n Sorry, you cannot give more lines! " ) ;
               user_wants_to_stop_writing_text  =  true  ;
            }
         }
      }

      if ( file_name_given_by_user  ==  null )
      {
         Console.Write( "\n Please, given the name of the file where"
                     +  "\n you want this text to be stored: " ) ;

         file_name_given_by_user  =  Console.ReadLine() ;
      }

      Console.Write( "\n Storing text to file "  +  file_name_given_by_user ) ;

      store_text_lines_to_file( given_text_lines,
                                number_of_text_lines_given,
                                file_name_given_by_user ) ;
   }
}



