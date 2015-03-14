
//  encrypt.cpp  (c) 2000-2002 Kari Laitinen

#include  <iostream.h>
#include  <fstream.h>  // C++ classes for file handling.

int main( int   number_of_command_line_arguments,
          char* command_line_arguments[] )
{
   if ( number_of_command_line_arguments  !=  3 )
   {
      cout << "\n You have to command this program as: \n"
              "\n  encrypt originalfile.ext ecryptedfile.ext\n" ;
   }
   else
   {
      ifstream  original_file( command_line_arguments[ 1 ],
                               ios::binary ) ;

      if ( original_file.fail() )
      {
         cout << "\n Cannot open " << command_line_arguments[ 1 ] ;
      }
      else
      {
         ofstream  encrypted_file( command_line_arguments[ 2 ] ) ;

         if ( encrypted_file.fail() )
         {
            cout << "\n Cannot open " << command_line_arguments[ 2 ] ;
         }
         else
         {
            int  number_of_blocks_encrypted  =  0 ;

            while ( ! original_file.eof() )
            {
               unsigned char  bytes_from_file[ 30 ] ;
               unsigned char  encrypted_bytes[ 61 ] ;

               original_file.read( bytes_from_file,  30 ) ;

               int number_of_bytes_read  =  original_file.gcount() ;

               for ( int byte_index  =  0 ;
                         byte_index  <  number_of_bytes_read ;
                         byte_index  ++ )
               {
                  encrypted_bytes[ byte_index * 2 ] =
                          ( bytes_from_file[ byte_index ] & 0xF )
                           + 0x20 + byte_index ;

                  encrypted_bytes[ byte_index * 2 + 1 ] =
                          ( bytes_from_file[ byte_index ] >> 4 )
                           + 0x20 + byte_index ;
               }

               encrypted_bytes[ number_of_bytes_read * 2 ]  =  0 ;

               encrypted_file  <<  encrypted_bytes  <<  "\n" ;

               number_of_blocks_encrypted  ++  ;
            }

            cout << "\n "  <<  number_of_blocks_encrypted
                 << " blocks were encrypted. \n" ;
         }
      }
   }
}





