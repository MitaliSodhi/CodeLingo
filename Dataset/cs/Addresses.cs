
//  Addresses.cs (c) 2002 Kari Laitinen

using System ;

class Addresses
{
   unsafe static void Main()
   {
      int   int_variable ;
      byte  byte_variable ;

      int[]  array_of_integers  =  new  int[ 4 ] ;
      byte[] array_of_bytes     =  new byte[ 16 ] ;

      long   long_variable ;
      double double_variable ;
 
      Console.Write( "\n THE SIZES OF SOME DATA TYPES:\n" +
        "\n  byte :   " + (sizeof( byte )).ToString()  + " bytes" +
        "\n  int :    " + (sizeof( int  )).ToString()  + " bytes" +
        "\n  long :   " + (sizeof( long )).ToString()  + " bytes" +
        "\n  double : " + (sizeof( double)).ToString() + " bytes" ) ;

      int*  some_pointer  =  &array_of_integers[ 1 ] ;

      Console.Write(

      "\n\n  DATA ITEM                MEMORY ADDRESS\n" +

      "\n  \"int_variable\"           " + ((int) &int_variable).ToString("X")+
      "\n  \"byte_variable\"          " + ((int) &byte_variable).ToString("X")+

      "\n  \"array_of_integers[ 0 ]\" " +

                    ((int) &array_of_integers[ 0 ]).ToString("X") ) ;
/****
    << "\n  \"array_of_integers[ 1 ]\" " << (long) &array_of_integers[ 1 ]
    << "\n  \"array_of_integers[ 2 ]\" " << (long) &array_of_integers[ 2 ]
    << "\n  \"array_of_integers[ 3 ]\" " << (long) &array_of_integers[ 3 ]
    << "\n  \"some_string[ 0 ]\"       " << (long) &some_string[ 0 ]
    << "\n  \"some_string[ 1 ]\"       " << (long) &some_string[ 1 ]
    << "\n  \"some_string[ 2 ]\"       " << (long) &some_string[ 2 ]
    << "\n  \"some_string[ 15 ]\"      " << (long) &some_string[ 15 ]
    << "\n  \"long_variable\"          " << (long) &long_variable
    << "\n  \"double_variable\"        " << (long) &double_variable<<"\n";

*****/
   }
}


