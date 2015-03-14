
//  ScopeExploration.cs  (c) 2004 Kari Laitinen

//  www.naturalprogramming.com

using System ;

class ScopeExploration
{
   static int[]  some_array     =  { 1111, 2222 } ;
   static int    some_variable  =  3333 ;

   static void some_method()
   {
      int  some_variable  =  4444 ;

      Console.Write( "\n some_variable (local) contains "
                  +  some_variable ) ;

      some_array[ 0 ]  =  8888 ;
   }

   static void another_method()
   {
      some_variable    =  7777 ;

      some_array[ 1 ]  =  9999 ;
   }

   static void print_classwide_data()
   {
      Console.Write( "\n some_variable contains " +  some_variable ) ;

      Console.Write( "\n some_array    contains "
                  +  some_array[ 0 ]  +  " and "  +  some_array[ 1 ] ) ;
   }

   static void Main()
   {
      print_classwide_data() ;
      some_method() ;
      print_classwide_data() ;
      another_method() ;
      print_classwide_data() ;
   }
}



