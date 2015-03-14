
//  StructTests.cs  (c) 2004 Kari Laitinen

//  www.naturalprogramming.com

using System ;

struct  SomeStruct
{
   public int  some_member  ;
   public int  another_member ;


   /***  The following parameterless constructor is not allowed.

   public SomeStruct()
   {
      some_member  =  88 ;
      another_member  =  99 ;
   }  ****/

   public SomeStruct( int  some_value )
   {
      some_member  =  88 ;
      another_member  =  99 ;
   }


}

class StructTests
{
   static void Main()
   {
      SomeStruct  some_object  =  new  SomeStruct() ;

      SomeStruct  another_object  =  new  SomeStruct(  999 ) ;

      Console.Write( "\n some_object.ToString() produces:  "
                  +  some_object ) ;

      Console.Write( "\n another_object.ToString() produces:  "
                  +  another_object ) ;

   }
}



