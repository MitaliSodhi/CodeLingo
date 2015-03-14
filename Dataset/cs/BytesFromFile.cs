
//  BytesFromFile.cs  (c) 2003 Kari Laitinen

//  www.naturalprogramming.com

using System ;
using System.IO ;    // Classes for file handling.
using System.Text ;  // Class StringBuilder etc.

class  BytesFromFile
{
   static void Main( string[] command_line_parameters )
   {
      if ( command_line_parameters.Length  ==  1 )
      {
         try
         {
            FileStream file_to_read  =
                           File.OpenRead( command_line_parameters[ 0 ] ) ;

            byte[]  bytes_from_file  =  new  byte[ 50 ] ;

            int  file_size_in_bytes  =  0 ;

            bool  bytes_still_available_in_file  =  true ;

            while ( bytes_still_available_in_file  ==  true )
            {
               int  number_of_bytes_read  = 
                          file_to_read.Read( bytes_from_file, 0,
                                             bytes_from_file.Length ) ;

               if ( number_of_bytes_read  >  0 )
               {
                  file_size_in_bytes  =  file_size_in_bytes  +
                                         number_of_bytes_read ;

                  //  This loop does not do anything to the read data.
               }
               else
               {
                  bytes_still_available_in_file  =  false ;
               }
            }

            Console.Write( "\n "  +  file_size_in_bytes  
                        +  " is the file size.  " ) ;

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
                     +  "\n  BytesFromFile file.ext \n") ;
      }
   }
}




