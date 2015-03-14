
//  ObjectClassTests.cs  (c) 2004 Kari Laitinen

using System ;

class  TestClass
{
}

class ObjectClassTests
{

   static void Main()
   {
      int  some_integer  =  333444 ;

      string  some_string  =  "AAABBB" ;

      TestClass  some_object  =  new  TestClass() ;

      Console.Write( "\n some_integer.GetHashCode()   "
                  +  some_integer.GetHashCode()
                  +  "\n some_integer.GetType()       "
                  +  some_integer.GetType() +  "\n" ) ;

      Console.Write( "\n some_string.GetHashCode()   "
                  +  some_string.GetHashCode()
                  +  "\n some_string.GetType()       "
                  +  some_string.GetType()  +  "\n" ) ;

      Console.Write( "\n some_object.GetHashCode()   "
                  +  some_object.GetHashCode()
                  +  "\n some_object.GetType()       "
                  +  some_object.GetType() 
                  +  "\n some_object.ToString()      "
                  +  some_object    +  "\n" ) ;


   }
}



