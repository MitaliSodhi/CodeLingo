
//  MirrorKL.cs  (c) Kari Laitinen

//  http://www.naturalprogramming.com

//  2004-11-19  File created.
//  2004-11-19  Last modification.

//  A solution to Exercise 14-3.

using System ;
using System.IO ;

class MirrorKL
{

   static void Main()
   {
      Console.Write( "\n This program \"mirrors\" the contents of a text"
                   + "\n file on the screen. Give a file name: " ) ;

      string  file_name_from_user  =  Console.ReadLine() ;

      try
      {
         StreamReader file_to_print  =  new  StreamReader(
                                               file_name_from_user ) ;
         int  line_counter  =  0 ;
         bool end_of_file_encountered  =  false ;

         while ( end_of_file_encountered  ==  false )
         {
            string  text_line_from_file   =  file_to_print.ReadLine() ;

            if ( text_line_from_file  ==  null )
            {
               end_of_file_encountered  =  true ;
            }
            else
            {
               int  character_index  =  text_line_from_file.Length ;

               while ( character_index  >  0 )
               {
                  character_index  --  ;
                  Console.Write( text_line_from_file[ character_index ] ) ;
               }

               Console.Write( "\n" ) ;

               line_counter  ++  ;
            }
         }

         file_to_print.Close() ;
         Console.Write( "\n  " +  line_counter  + " lines printed." ) ;
      }
      catch ( FileNotFoundException )
      {
         Console.Write( "\n Cannot open file " + file_name_from_user ) ;
      }
   }
}




