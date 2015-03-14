
//  Boxing.cs  (c) 2003 Kari Laitinen

//  www.naturalprogramming.com

using System ;

class Boxing
{
   static int increment_integer( object integer_as_object )
   {
      int  integer_to_increment  =  (int) integer_as_object ;

      integer_to_increment  ++  ;

      return  integer_to_increment ;
   }

   static void Main()
   {
      int  some_integer  =  222 ;

      int  incremented_integer  =  increment_integer( some_integer ) ;

      Console.Write( "\n  Incremented value :  "  +  incremented_integer ) ;
   }
}



