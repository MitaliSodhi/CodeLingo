
//  Forcodes80toFF.cs  (c) 2002-2004 Kari Laitinen

//  This program prints character codes in the range
//  from 0x80 to 0xFF

using System ;

class Forcodes80toFF
{
   static void Main()
   {
      int  number_of_codes_on_this_line  =  0 ;

      Console.Write( "\n The visible characters with codes from 0x80"
                  +  "\n to 0xFF (hexadecimal) are the following:\n\n ");

      for ( int numerical_code  =  0x80 ;
                numerical_code  <  0x100 ;
                numerical_code  ++ )
      {
         char  character_to_print  =  (char) numerical_code  ;

         Console.Write( character_to_print + " " ) ;
         Console.Write( numerical_code.ToString( "x" ) + " ") ;

         number_of_codes_on_this_line  ++  ;

         if ( number_of_codes_on_this_line  ==  8 )
         {
            Console.Write( "\n " ) ;
            number_of_codes_on_this_line   =  0 ;
         }
      }
   }
}


/***  

      Another possibility to convert an int value to a
      hexadecimal string would be to write:

         string  numerical_code_as_hexadecimal_string  =
                        Convert.ToString( numerical_code, 16 ) ;

*****/






