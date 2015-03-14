
//  ParameterTests.cs  (c) 2005 Kari Laitinen

//  http://www.naturalprogramming.com

//  2005-03-27  File created.

using System ;

class ParameterTests
{
   static void method_using_a_string( ref string given_string )
   {
      given_string  =  "value set inside called method" ;
   }

   static void Main()
   {
      string  test_string  =  "ORIGINAL STRING VALUE" ;

      Console.Write( "\n "  +  test_string ) ;

      method_using_a_string( ref test_string ) ;

      Console.Write( "\n "  +  test_string ) ;


   }
}



