
//  EncryptAlternativeVersion.cs  (c) 2003 Kari Laitinen

using System ;
using System.IO ;    // Classes for file handling.
using System.Text ;  // Class StringBuilder etc.

class EncryptAlternativeVersion
{
   static void Main( string[] command_line_parameters )
   {
      if ( command_line_parameters.Length  ==  2 )
      {
         try
         {
            FileStream original_file_stream  =
                           File.OpenRead( command_line_parameters[ 0 ] ) ;

            BinaryReader original_file  =
                           new  BinaryReader( original_file_stream ) ;

            StreamWriter encrypted_file  =
                           new  StreamWriter( command_line_parameters[ 1 ] ) ;

            int number_of_blocks_encrypted  =  0 ;

            int number_of_bytes_read  =  999 ;

            while ( number_of_bytes_read  >  0 )
            {
               try
               {
                  byte[]  bytes_from_file  =  original_file.ReadBytes( 30 ) ;

                  number_of_bytes_read  =  bytes_from_file.Length ;

                  StringBuilder encrypted_bytes  =  new  StringBuilder() ;

                  for ( int byte_index  =  0 ;
                            byte_index  <  number_of_bytes_read ;
                            byte_index  ++ )
                  {
                     encrypted_bytes.Append(
                       (char) ( ( bytes_from_file[ byte_index ] & 0xF )
                                 + 0x20 + byte_index ) ) ;

                     encrypted_bytes.Append(
                       (char) ( ( bytes_from_file[ byte_index ] >> 4 )
                                 + 0x20 + byte_index ) ) ;
                  }

                  encrypted_file.Write( encrypted_bytes.ToString() + "\n" ) ;

                  number_of_blocks_encrypted  ++  ;
               }
               catch ( EndOfStreamException )
               {
                  number_of_bytes_read  =  -1 ;
               }
            }

            original_file.Close() ;
            encrypted_file.Close() ;

            Console.Write( "\n "  +  number_of_blocks_encrypted
                        +  " blocks were encrypted. \n" ) ;
         }
         catch ( FileNotFoundException )
         {
            Console.Write( "\n Cannot open file "
                        +  command_line_parameters[ 0 ] ) ;
         }
         catch ( Exception )
         {
            Console.Write( "\n File error. Probably cannot write to "
                        +  command_line_parameters[ 1 ] ) ;
         }
      }
      else
      {
         Console.Write( "\n You have to command this program as: \n"
                     +  "\n  Encrypt originalfile.ext ecryptedfile.ext\n") ;
      }
   }
}




