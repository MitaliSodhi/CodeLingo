
//  Binary.cs  (c) 2003 Kari Laitinen

using System ;

class Binary
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
      int  test_number  =  0x9A9A ;

      Console.Write( "\n Original test number:    " ) ;
      print_in_binary_form( test_number ) ;

      Console.Write( "\n Twice left-shifted form: " ) ;
      test_number  =  test_number  <<  2  ;  
      print_in_binary_form( test_number ) ;

      Console.Write( "\n Back to original form:   " ) ;
      test_number  =  test_number  >>  2  ;
      print_in_binary_form( test_number ) ;

      Console.Write( "\n Last four bits zeroed:   " ) ;
      test_number  =  test_number  &  0xFFF0 ;
      print_in_binary_form( test_number ) ;

      Console.Write( "\n Last four bits to one:   " ) ;
      test_number  =  test_number  |  0x000F ;
      print_in_binary_form( test_number ) ;

      Console.Write( "\n A complemented form:     " ) ;
      test_number  =  ~test_number ;
      print_in_binary_form( test_number ) ;

      Console.Write( "\n Exclusive OR with 0xF0F0:" ) ;
      test_number  =  test_number ^ 0xF0F0 ;
      print_in_binary_form( test_number ) ;
   }
}


