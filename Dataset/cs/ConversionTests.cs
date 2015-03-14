
//  ConversionTests.cs  (c) 2004 Kari Laitinen

//  www.naturalprogramming.com

using System ;

class ConversionTests
{
   static void Main()
   {
  string  value_of_pi_as_string  =  "3.14159" ;

  double  value_of_pi =  Convert.ToDouble( value_of_pi_as_string ) ;

  Console.Write( value_of_pi ) ;


  Console.Write( "\n " + Convert.ToInt32( "123" )
              +  "   " + Convert.ToInt32( "1111011", 2 ) 
              +  "   " + Convert.ToInt32( "7B", 16 ) ) ;


  string  one_day_in_dublin  =  "1904-06-16" ;

  Console.Write( "\n "
      +  Convert.ToDateTime( one_day_in_dublin ).
                                  ToLongDateString() ) ;

  int  some_character  =  'X' ;

  Console.Write( (int) some_character ) ;

   }
}



