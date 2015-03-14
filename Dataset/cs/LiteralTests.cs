
//  LiteralTests.cs  (c) 2004 Kari Laitinen

//  www.naturalprogramming.com

using System ;

class LiteralTests
{
   static void Main()
   {
      //  The following assignment is not possible.
      //  char  first_character  =  0x41 ;  // explicit cast required

      char some_character  =  'X' ;
      Console.Write( "\n  "  +  some_character ) ;

      char another_character  =  '\u0041' ;
      Console.Write( "  "  +  another_character ) ;

      char third_character  =  '\x33' ;
      Console.Write( "  "  +  third_character ) ;

      Console.Write( "  "  +  '\\'  +  "  "  +  '\''  +  "  "  +  '\0' 
                  +  "  "  +  '\0'  +  "  "  +  '\"'  +  "  "  +  '\t' 
                  +  "  "  +  'z' ) ;

      Console.Write( "\nxxxx"  +  '\t'  +  "xxxx" +  '\t'  +  "xxxx"  ) ;

      byte  some_byte  =  123 ;
      byte  another_byte  = (byte) 'A' ; 
      ushort  some_ushort  =  65535 ;
      int  some_integer  =  'A' ;  //  this is allowed

      Console.Write( "\n  "  +  some_byte  +  " "  +  another_byte 
                  +  "    "  +  some_ushort  +  "  "  +  some_integer ) ;

      some_integer  =  123 ;
      short some_short_integer  =  123 ;
      long  some_long_integer   =  123 ;
      ulong some_ulong_integer  =  123 ;

      float  some_float  =  34.45e-3F ;
      double some_double =  34.45e-3 ;

      Console.Write( "\n float    "  +  some_float
                  +  " double " +  some_double ) ;

      some_float  =  2.998e8F ;
      some_double =  2.998e8 ;

      Console.Write( "\n float    "  +  some_float
                  +  " double " +  some_double ) ;

      decimal some_decimal  =  2.998e8M ;
      Console.Write( "\n decimal  "  +  some_decimal ) ;

      Console.Write( "\n"  +  "\\ABCDE\\"
                  +  "\n"  +  @"\ABCDE\" ) ;
   }
}



