
//  BitOperatorTests.cs  (c) 2004 Kari Laitinen

//  www.naturalprogramming.com

using System ;

class BitOperatorTests
{
   static void print_in_binary_form( int  given_integer )
   {
      uint  bit_mask   =  0x80000000 ;
      uint  one_bit_in_given_integer ;

      for ( int bit_counter  =  0  ;
                bit_counter  <  32 ;
                bit_counter  ++ )
      {
         one_bit_in_given_integer  = (uint) given_integer & bit_mask ;

         if ( one_bit_in_given_integer  ==  0 )
         {
            Console.Write( "0" ) ;
         }
         else
         {
            Console.Write( "1" ) ;
         }

         bit_mask  =  bit_mask  >>  1 ;
      }
   }

   static void Main()
   {


      Console.Write( "\n (0x61 & 0xDF) produces 0x"
                  + ( 0x61 & 0xDF).ToString( "X2" ) ) ;
      Console.Write( "\n (0xF0 & 0x0F) produces 0x"
                  +  (0xF0 & 0x0F).ToString( "X2" ) +  "\n" ) ;

      Console.Write( "\n (0x41 | 0x20) produces 0x"
                  +  (0x41 | 0x20).ToString( "X2" ) ) ;
      Console.Write( "\n (0xF0 | 0x0F) produces 0x"
                  +  (0xF0 | 0x0F).ToString( "X2" ) +  "\n" ) ;

      Console.Write( "\n (0xAF ^ 0xFF) produces 0x"
                  +  (0xAF ^ 0xFF).ToString( "X2" ) ) ;
      Console.Write( "\n (0xFF ^ 0xFF) produces 0x"
                  +  (0xFF ^ 0xFF).ToString( "X2" ) +  "\n" ) ;

      Console.Write( "\n ( ~ 0xE1 ) produces 0x"
                  +  ( ~ 0xE1 ).ToString( "X2" ) ) ;
      Console.Write( "\n ( ~ 0xF0 ) produces 0x"
                  +  ( ~ 0xF0 ).ToString( "X2" ) +  "\n" ) ;

      Console.Write( "\n ( 0x49 >> 2 ) produces 0x"
                  +  ( 0x49 >> 2 ).ToString( "X2" ) ) ;
      Console.Write( "\n ( 0x49 >> 3 ) produces 0x"
                  +  ( 0x49 >> 3 ).ToString( "X2" ) +  "\n" ) ;

      Console.Write( "\n ( 0x12 << 3 ) produces 0x"
                  +  ( 0x12 << 3 ).ToString( "X2" ) ) ;
      Console.Write( "\n ( 0x12 << 4 ) produces 0x"
             +  ( 0x12 <<   4 ).ToString( "X2" ) +  "\n" ) ;



      //  The following statements prove that operator ~
      //  produces an int value also when its operand is a byte.

      Console.Write( "\n " ) ;

      byte  first_byte   =  0xE1 ;
      byte  second_byte  =  0xF0 ;

      Console.Write( "\n ( ~ first_byte ) produces 0x"
                  +  ( ~ first_byte ).ToString( "X2" ) ) ;
      Console.Write( "\n ( ~ second_byte ) produces 0x"
                  +  ( ~ second_byte ).ToString( "X2" ) +  "\n" ) ;


      Console.Write( "\n " ) ;

      ushort  variable_of_16_bits  =  0xA26B ;

      print_in_binary_form( variable_of_16_bits ) ;

      variable_of_16_bits  = (ushort) ( variable_of_16_bits  >>  3 ) ;

      Console.Write( "\n " ) ;

      print_in_binary_form( variable_of_16_bits ) ;


      Console.Write( "\n " ) ;

      char  some_character  =  'a' ;

      Console.Write( "\n some_character is " + some_character ) ;

      some_character  =  (char) ( some_character  &  0xDF ) ;

      Console.Write( "\n some_character is " + some_character ) ;

      some_character  =  (char) ( some_character  |  0x20 ) ;

      Console.Write( "\n some_character is " + some_character ) ;
   }
}




