
//  Forcodes.cs  (c) 2002-2003 Kari Laitinen

using System ;

class Forcodes
{
   static void Main()
   {
      int  number_of_codes_on_this_line  =  0 ;

      Console.Write( "\n The visible characters with codes from 20"
                  +  "\n to 7F (hexadecimal) are the following:\n\n ");

      for ( int numerical_code  =  0x20 ;
                numerical_code  <  0x80 ;
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






