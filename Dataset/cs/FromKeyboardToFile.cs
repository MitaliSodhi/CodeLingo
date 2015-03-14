
//  FromKeyboardToFile.cs  (c) 2004 Kari Laitinen

//  www.naturalprogramming.com

using System ;
using System.IO ;  // Classes for file handling.

class FromKeyboardToFile
{
   static void Main()
   {
      Console.Write( "\n This program copies text from keyboard"
                   + "\n to a file. Please, give the name of"
                   + "\n the output file: " ) ;


      string  output_file_name  =  Console.ReadLine() ;

      bool  append_to_file  =  false ;

      if ( File.Exists( output_file_name ) )
      {
         Console.Write( "\n File "  +  output_file_name
                     +  " exists. Overwrite or Append (O/A) ? " ) ;

         string user_selection  =  Console.ReadLine() ;

         if ( user_selection[ 0 ]  ==  'O' ||  user_selection[ 0 ]  == 'o' )
         {
            append_to_file  =  false ;
         }
         else
         {
            append_to_file  =  true ;
         }
      }

      //  Note that this program is somewhat dangerous in that it is
      //  not possible to quit the program if the file already exists.

      try
      {
         StreamWriter output_file  =
                          new  StreamWriter( output_file_name,
                                             append_to_file ) ;

         Console.Write( "\n Type in text from the keyboard."
                     +  "\n To end text input type a dot . as the"
                     +  "\n first character of a line. \n\n" ) ;

         int  text_line_counter  =  0 ;
         bool user_wants_to_stop_entering_text  =  false ;

         while ( user_wants_to_stop_entering_text  ==  false )
         {
            string  text_line_from_user  =  Console.ReadLine() ;

            //  Console.ReadLine() returns an empty string,
            //  not a null, when the user just hits the Enter key.

            if ( text_line_from_user   ==  null )
            {
               Console.Write( " null?, this should never happen  " ) ;
            }
            else if ( text_line_from_user.Length  >  0 &&
                      text_line_from_user[ 0 ]  ==  '.' )
            {
               user_wants_to_stop_entering_text  =  true ;
            }
            else
            {
               output_file.WriteLine( text_line_from_user ) ;
               text_line_counter  ++  ;
            }
         }

         Console.Write( "\n"  +  text_line_counter
                      + " lines were written to file. \n" ) ;

         output_file.Close() ;
      }
      catch ( Exception  caught_exception )
      {
         Console.Write( "\n File error. Probably cannot write to "
                     +  output_file_name ) ;
         Console.Write( "\n Exception info: "  +  caught_exception ) ;
      }
   }
}




