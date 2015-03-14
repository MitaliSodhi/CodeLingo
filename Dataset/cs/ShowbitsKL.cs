
//  ShowbitsKL.cs  (c) 2003 Kari Laitinen

//  http://www.naturalprogramming.com

//  2004-11-25  File created.
//  2004-11-25  Last modification.

//  A solution to exercises 16-3 and 16-4.

using System ;

class ShowbitsKL
{
   static void print_in_binary_form( int  given_integer )
   {
      uint  bit_mask ;
      int   number_of_bits_to_print ;

      if ( given_integer  <  0x100 )
      {
         bit_mask  = 0x80 ;
         number_of_bits_to_print  =  8 ;
      }
      else if ( given_integer  <  0x10000 )
      {
         bit_mask  = 0x8000 ;
         number_of_bits_to_print  =  16 ;
      }
      else
      {
         bit_mask  = 0x80000000 ;
         number_of_bits_to_print  =  32 ;
      }

      uint  one_bit_in_given_integer ;

      int bit_counter  =  0  ;

      while ( bit_counter  <  number_of_bits_to_print )
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

         bit_counter  ++ ;

         if ( ( bit_counter  %  4 )  ==  0 )
         {
            //  Printing a space after each four bits.
            Console.Write( " " ) ;
         }
      }
   }

   static void Main( string[]  command_line_parameters )
   {
      if ( command_line_parameters.Length  ==  1 )
      {
         string  given_number_as_string  = 
                          command_line_parameters[ 0 ] ;

         int  given_number ;

         if ( given_number_as_string.Length  >  1  &&
              ( given_number_as_string[ 1 ]  ==  'x'  ||
                given_number_as_string[ 1 ]  ==  'X'   ) )
         {
            //  A hexadecimal number was given
            given_number  =  Convert.ToInt32( given_number_as_string, 16 ) ;

            Console.Write( "\n 0x"  +  given_number.ToString( "X" )
                        +  "  is  " ) ;
            print_in_binary_form( given_number ) ;
            Console.Write( "(binary)    "
                        +  given_number  +  " (decimal)   " ) ;
         }
         else
         {
            //  We'll suppose that a decimal number was given.
            given_number  =  Convert.ToInt32( given_number_as_string ) ;

            Console.Write( "\n "  +  given_number  +  "  is  " ) ;
            print_in_binary_form( given_number ) ;
            Console.Write( "(binary)    "
                        +  given_number.ToString( "X" )
                        +  " (hexadecimal)   " ) ;
         }

         //  We'll print the number as a character if it is less
         //  than 256.

         if ( given_number  <  0x100 )
         {
            Console.Write( "\'"  +  (char) given_number
                        +  "\' as  character  \n\n" ) ;
         }
         else
         {
            Console.Write( "\n\n" ) ;
         }
      }
      else
      {
         Console.Write( "\n\n Give a number on the command line.\n\n" ) ;
      }
   }
}


