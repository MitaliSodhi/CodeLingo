
//  NumbersToFile.cs  (c) 2003 Kari Laitinen

//  www.naturalprogramming.com

using System ;
using System.IO ; // Classes for file handling.

class NumbersToFile
{
   static void Main()
   {
      try
      {
         FileStream file_stream  =  File.Open( "NumbersToFile_output.data",
                                               FileMode.Create,
                                               FileAccess.Write ) ;

         BinaryWriter file_to_write  =  new  BinaryWriter( file_stream ) ;

         int integer_to_file  =  0x22 ;

         while ( integer_to_file  <  0x77 )
         {
            file_to_write.Write( integer_to_file ) ;

            integer_to_file  =  integer_to_file  +  0x11 ;
         }

         file_to_write.Write( (short) 0x1234 ) ;
         file_to_write.Write( 1.2345 ) ;
         file_to_write.Write( true ) ;
         file_to_write.Write( false ) ;
         file_to_write.Write( "aaAAbbBB" ) ;

         byte[] bytes_to_file  =  { 0x4B, 0x61, 0x72, 0x69 } ;

         file_to_write.Write( bytes_to_file, 0, 4 ) ;

         file_to_write.Close() ;
      }
      catch ( Exception )
      {
          Console.Write( "\n File error. Cannot write to file." ) ;
      }
   }
}




