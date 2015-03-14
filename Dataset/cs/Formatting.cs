
//  Formatting.cs  (c) 2003 Kari Laitinen

using System ;

class Formatting
{
   static void Main()
   {
      int  some_integer  =  123456 ;

      Console.Write( "\n{0, 9:D}   right justified",  some_integer ) ;
      Console.Write( "\n{0,-9:D}   left justified",   some_integer ) ;
      Console.Write( "\n{0, 9:X}   right hexadecimal", some_integer ) ;
      Console.Write( "\n{0,-9:X}   left hexadecimal", some_integer ) ;
      Console.Write( "\n{0, 0:D}  no printing field",  some_integer ) ;
      Console.Write( "\n{0, 0:X}  hexadecimal", some_integer ) ;
      Console.Write( "\n{0, 0:x}  hexadecimal lowercase", some_integer ) ;
      Console.Write( "\n{0, 0:D12}  leading zeroes", some_integer ) ;
      Console.Write( "\n{0, 0:X12}  hexadecimal",  some_integer ) ;
      Console.Write( "\n{0, 0:N}  digit grouping", some_integer ) ;
      Console.Write( "\n{0, 0:C}  currency value", some_integer ) ;
      Console.Write( "\n" ) ;
      Console.Write( "\n"  +  some_integer.ToString().PadLeft( 9 ) ) ;
      Console.Write( "\n"  +  some_integer.ToString().PadRight( 9 ) ) ;
      Console.Write( "\n"  +  some_integer.ToString( "X" ).PadLeft( 9 ) ) ;
      Console.Write( "\n"  +  some_integer.ToString( "X" ).PadRight( 9 ) ) ;
      Console.Write( "\n"  +  some_integer.ToString() ) ;
      Console.Write( "\n"  +  some_integer.ToString( "X" ) ) ;
      Console.Write( "\n"  +  some_integer.ToString( "x" ) ) ;
      Console.Write( "\n"  +  some_integer.ToString( "D12" ) ) ;
      Console.Write( "\n"  +  some_integer.ToString( "X12" ) ) ;
      Console.Write( "\n"  +  some_integer.ToString( "N" ) ) ;

   }
}



