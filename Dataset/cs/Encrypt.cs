
//  Encrypt.cs  (c) 2003 Kari Laitinen

using System ;
using System.IO ;    // Classes for file handling.
using System.Text ;  // Class StringBuilder etc.

class Encrypt
{
   static void Main( string[] command_line_parameters )
   {
      if ( command_line_parameters.Length  ==  2 )
      {
         try
         {
            Stream original_file  =
                           File.OpenRead( command_line_parameters[ 0 ] ) ;

            StreamWriter encrypted_file  =
                           new  StreamWriter( command_line_parameters[ 1 ] ) ;

            int number_of_blocks_encrypted  =  0 ;


            byte[]  bytes_from_file  =  new  byte[ 30 ] ;

            int number_of_bytes_read  ;

            while (( number_of_bytes_read  =
                       original_file.Read( bytes_from_file, 0,
                                           bytes_from_file.Length ))  >  0 )
            {
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

               encrypted_file.Write( encrypted_bytes.ToString()  +  "\n" ) ;

               number_of_blocks_encrypted  ++  ;
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




