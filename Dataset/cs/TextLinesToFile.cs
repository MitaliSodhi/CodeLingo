
//  TextLinesToFile.cs  (c) 2004 Kari Laitinen

//  www.naturalprogramming.com

using System ;
using System.IO ;  // Classes for file handling.

class TextLinesToFile
{
   static void Main()
   {

      StreamWriter  file_to_write  =  null ;

      try
      {
         file_to_write  =
                          new  StreamWriter( "TextLinesToFile_output.txt" ) ;


         for ( int line_number  =  1 ;
                   line_number  <  4 ;
                   line_number  ++ )
         {
            file_to_write.WriteLine( "This is line "  +  line_number ) ;
         }
      }
      catch ( Exception  caught_exception )
      {
         Console.Write( "\n File error. Cannot write to file. " ) ;
         Console.Write( "\n Exception info: "  +  caught_exception ) ;
      }
      finally
      {
         if ( file_to_write  !=  null )
         {
            file_to_write.Close() ;
         }
      }
   }
}




