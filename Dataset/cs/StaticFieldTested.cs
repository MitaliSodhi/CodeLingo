
//  StaticFieldTested.cs  (c) 2004 Kari Laitinen

//  www.naturalprogramming.com

//  15.06.2004  File created.

using System ;

class TestClass
{
   static int  number_of_objects_created  =  0 ;

   public TestClass()
   {
      number_of_objects_created  ++ ;
   }

   public void print()
   {
      Console.Write( "\n  "  +  number_of_objects_created 
                  +  " objects created" )  ;
   }
}

class StaticFieldTested
{
   static void Main()
   {
      TestClass  first_object   =  new  TestClass() ;

      first_object.print() ;

      TestClass  second_object  =  new  TestClass() ;

      first_object.print() ;

      TestClass  third_object   =  new  TestClass() ;

      first_object.print() ;

      TestClass  fourth_object  =  new  TestClass() ;

      third_object.print() ;
   }
}


