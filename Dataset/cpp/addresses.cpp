
//  addresses.cpp (c) 1998-2002 Kari Laitinen

#include  <iostream.h>

int main()
{
   int   int_variable ;
   char  char_variable ;

   int   array_of_integers[ 4 ] ;
   char  some_string[ 16 ] ;

   long   long_variable ;
   double double_variable ;

   cout << "\n THE SIZES OF SOME DATA TYPES:\n"
        << "\n  char :   "  << sizeof( char )  << " bytes"
        << "\n  int :    "  << sizeof( int  )  << " bytes"
        << "\n  long :   "  << sizeof( long )  << " bytes"
        << "\n  double : "  << sizeof( double) << " bytes" ;


   cout << "\n\n  DATA ITEM                MEMORY ADDRESS\n" << hex

    << "\n  \"int_variable\"           " << (long) &int_variable
    << "\n  \"char_variable\"          " << (long) &char_variable
    << "\n  \"array_of_integers[ 0 ]\" " << (long) &array_of_integers[ 0 ]
    << "\n  \"array_of_integers[ 1 ]\" " << (long) &array_of_integers[ 1 ]
    << "\n  \"array_of_integers[ 2 ]\" " << (long) &array_of_integers[ 2 ]
    << "\n  \"array_of_integers[ 3 ]\" " << (long) &array_of_integers[ 3 ]
    << "\n  \"some_string[ 0 ]\"       " << (long) &some_string[ 0 ]
    << "\n  \"some_string[ 1 ]\"       " << (long) &some_string[ 1 ]
    << "\n  \"some_string[ 2 ]\"       " << (long) &some_string[ 2 ]
    << "\n  \"some_string[ 15 ]\"      " << (long) &some_string[ 15 ]
    << "\n  \"long_variable\"          " << (long) &long_variable
    << "\n  \"double_variable\"        " << (long) &double_variable<<"\n";
}


