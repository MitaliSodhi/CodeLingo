
//  decrypt.cpp  (c) 2000-2002 Kari Laitinen

#include  <iostream.h>
#include  <fstream.h>  // C++ classes for file handling.
#include  <string.h>

int main( int   number_of_command_line_arguments,
          char* command_line_arguments[] )
{
   if ( number_of_command_line_arguments  !=  3 )
   {
      cout << "\n You have to command this program as:\n "
              "\n  decrypt encryptedfile.ext decryptedfile.ext\n" ;
   }
   else
   {
      ifstream  encrypted_file( command_line_arguments[ 1 ] ) ;

      if ( encrypted_file.fail() )
      {
         cout << "\n Cannot open "  <<  command_line_arguments[ 1 ] ;
      }
      else
      {
         ofstream  decrypted_file( command_line_arguments[ 2 ],
                                   ios::binary ) ;

         if ( decrypted_file.fail() )
         {
            cout << "\n Cannot open " << command_line_arguments[ 2 ] ;
         }
         else
         {
            int  number_of_blocks_decrypted  =  0 ;

            while ( ! encrypted_file.eof() )
            {
               char           encrypted_bytes_from_file[ 100 ] ;
               unsigned char  decrypted_bytes[ 61 ] ;

               encrypted_file.getline( encrypted_bytes_from_file,
                                sizeof( encrypted_bytes_from_file ) ) ;

               int number_of_decrypted_bytes  = 
                           strlen( encrypted_bytes_from_file ) / 2 ;

               for ( int byte_index  =  0 ;
                         byte_index  <  number_of_decrypted_bytes ;
                         byte_index  ++ )
               {
                  decrypted_bytes[ byte_index ] =
                         
                    ( encrypted_bytes_from_file[ byte_index * 2 ] 
                           - 0x20 - byte_index  )  +

                    ( ( encrypted_bytes_from_file[ byte_index * 2 + 1 ] 
                           - 0x20 - byte_index  )  <<  4  ) ;
               }

               decrypted_file.write( decrypted_bytes,
                                     number_of_decrypted_bytes ) ;

               number_of_blocks_decrypted  ++ ;
            }

            cout << "\n " <<  number_of_blocks_decrypted
                 << " blocks were decrypted. \n" ;
         }
      }
   }
}




