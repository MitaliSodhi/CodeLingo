
//  NumbersToFile.cpp  (c) Kari Laitinen

//  http://www.naturalprogramming.com

//  2006-06-09  File created.
//  2006-06-09  Last modification.

//  This is the C++ version of corresponding Java/C#/Python
//  programs. This program is not presented in the C++ book.

#include  <iostream.h>
#include  <fstream.h>  // C++ classes for file handling.

int main()
{
   ofstream  file_to_write( "NumbersToFile_output.data",
                             ios::binary ) ;

   if ( file_to_write.fail() )
   {
      cout << "\n Cannot open NumbersToFile_output.data" ;
   }
   else
   {
      int integer_to_file  =  0x22 ;

      while ( integer_to_file  <  0x77 )
      {
         file_to_write.write( (char*) &integer_to_file, sizeof( int ) ) ;

         integer_to_file  =  integer_to_file  +  0x11 ;
      }

      short  short_integer_to_file  =  0x1234 ;
      double double_value_to_file   =  1.2345 ;
      bool   boolean_true_to_file   =  true ;
      bool   boolean_false_to_file  =  false ;

      file_to_write.write( (char*) &short_integer_to_file, sizeof( short ) ) ;
      file_to_write.write( (char*) &double_value_to_file,  sizeof( double ) ) ;
      file_to_write.write( (char*) &boolean_true_to_file,  sizeof( bool ) ) ;
      file_to_write.write( (char*) &boolean_false_to_file, sizeof( bool ) ) ;

      char   c_style_string_to_file[]  =  "aaAAbbBB" ;

      int  string_length_to_file  =  strlen( c_style_string_to_file ) ;

      file_to_write.write( (char*) &string_length_to_file, sizeof( int ) ) ;
      file_to_write.write( c_style_string_to_file, string_length_to_file ) ;

      char bytes_to_file[]  =  { 0x4B, 0x61, 0x72, 0x69 } ;

      file_to_write.write( bytes_to_file, 4 ) ;
   }
}




