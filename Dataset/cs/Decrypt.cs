
//  Decrypt.cs  (c) 2003 Kari Laitinen

using System ;
using System.IO ;    // Classes for file handling.

class Decrypt
{
   static void Main( string[] command_line_parameters )
   {
      if ( command_line_parameters.Length  ==  2 )
      {
         try
         {
            StreamReader encrypted_file  =
                           new  StreamReader( command_line_parameters[ 0 ] ) ;

            Stream decrypted_file  =
                           File.Open( command_line_parameters[ 1 ],
                                      FileMode.Create, FileAccess.Write ) ;

            int number_of_blocks_decrypted  =  0 ;

            byte[]  decrypted_bytes  =  new  byte[ 30 ] ;

            string  encrypted_bytes_from_file  =  encrypted_file.ReadLine() ;

            while ( encrypted_bytes_from_file  !=  null )
            {
               int  number_of_decrypted_bytes  =
                              encrypted_bytes_from_file.Length / 2 ;

               for ( int byte_index  =  0 ;
                         byte_index  <  number_of_decrypted_bytes ;
                         byte_index  ++ )
               {
                  decrypted_bytes[ byte_index ]  =  (byte)
                         
                     ( ( encrypted_bytes_from_file[ byte_index * 2 ] 
                              - 0x20 - byte_index  )   + 

                       ( ( encrypted_bytes_from_file[ byte_index * 2 + 1 ] 
                               - 0x20 - byte_index  )  <<  4  ) ) ;

               }

               decrypted_file.Write( decrypted_bytes, 0, 
                                     number_of_decrypted_bytes ) ;

               number_of_blocks_decrypted  ++  ;

               encrypted_bytes_from_file  =  encrypted_file.ReadLine() ;
            }

            encrypted_file.Close() ;
            decrypted_file.Close() ;

            Console.Write( "\n "  +  number_of_blocks_decrypted
                        +  " blocks were decrypted. \n" ) ;
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
                     +  "\n  Decrypt ecryptedfile.ext decryptedfile.ext\n") ;
      }
   }
}




