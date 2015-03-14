
//  memory.cpp (c) 1998-2002 Kari Laitinen

#include  <iostream.h>
#include  <iomanip.h>
#include  <string.h>

void  print_memory_contents( void*  memory_address,
                             int    number_of_bytes_to_print )
{
   unsigned char* a_byte_in_memory = (unsigned char*) memory_address ;

   int    number_of_bytes_on_this_line  =  0 ;
   char   bytes_as_characters[ 20 ] ;

   cout  << uppercase << hex << setfill( '0' )    << "\n" 
         << setw( 8 ) << (long) a_byte_in_memory  <<  " " ;

   while  (  number_of_bytes_to_print  >  0  )
   {
      if  (  number_of_bytes_on_this_line  ==  16  )
      {
         // We'll start a new line on the screen.

         bytes_as_characters[ number_of_bytes_on_this_line ]  =  0 ;

         cout <<  "  "  <<  bytes_as_characters  <<  "\n" 
              << setw( 8 ) << (long) a_byte_in_memory << " " ;

         number_of_bytes_on_this_line   =  0 ;
      }

      cout  <<  " "  <<  setw( 2 ) <<  ( int ) *a_byte_in_memory ;

      //  We'll make sure that bytes_as_characters contains
      //  just printable characters.

      if ( *a_byte_in_memory  > 0x1F && *a_byte_in_memory < 0x7F )
      {
         bytes_as_characters[ number_of_bytes_on_this_line ]  =
                                              *a_byte_in_memory ;
      }
      else
      {
         bytes_as_characters[ number_of_bytes_on_this_line ] = ' ' ;
      }

      number_of_bytes_on_this_line  ++  ;
      number_of_bytes_to_print      --  ;
      a_byte_in_memory  ++  ;
   }

   //  The last line of memory contents may contain less than
   //  16 bytes. Now we finish that line.

   if ( number_of_bytes_on_this_line  >  0 )
   {
      while (  number_of_bytes_on_this_line  <  16  )
      {
         cout  <<  "   "  ;
         bytes_as_characters[ number_of_bytes_on_this_line ]  =  ' ' ;
         number_of_bytes_on_this_line  ++  ;
      }

      bytes_as_characters[ number_of_bytes_on_this_line ]  =  0 ;
      cout  <<  "  "  <<  bytes_as_characters  ;
   }

   cout << "\n" ;
}



int main()
{
    int    array_of_integers[]  = 
              { 1, 2, 3, 4, 5, 6, 7, 8, 65, 66, 67, 68  } ;

    int    some_integer       =  0xEE ;
    int    another_integer    =  0xCC ;
 
    char   some_string[]  =  "abcdefghijklmnopqrstuw  12345678" ;

    print_memory_contents( array_of_integers, 48 ) ;

    print_memory_contents( some_string, 32 ) ;

    print_memory_contents( &another_integer, 16 ) ;

    strcpy( some_string, "XXXXXYYYYYYzzzzzz" ) ;
    some_integer     =  0x66  ;
    another_integer  =  0x77  ;

    print_memory_contents( some_string, 32 ) ;

    print_memory_contents( &another_integer, 10 ) ;
    print_memory_contents( &some_integer, 4 ) ;

    print_memory_contents( print_memory_contents, 32 ) ;
}


