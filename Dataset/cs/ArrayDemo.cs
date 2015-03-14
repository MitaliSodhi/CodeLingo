
//  ArrayDemo.cs  (c) 2002-2003 Kari Laitinen

//  The corresponding C++ program has name array.cpp.
//  In C#, it might be problematic to use the class
//  name Array because the language has a standard
//  class named Array.

using  System ;

class ArrayDemo
{
   static void Main()
   {
      int[]  array_of_integers  =  new  int[ 50 ] ;

      int  integer_index ;

      array_of_integers[ 0 ]  =  333 ;
      array_of_integers[ 1 ]  =   33 ;
      array_of_integers[ 2 ]  =    3 ;
      array_of_integers[ 3 ]  =  array_of_integers[ 2 ]  +  2 ;

      for ( integer_index  =  4 ;
            integer_index  <  50 ;
            integer_index  ++ )
      {
         array_of_integers[ integer_index ]  =
                array_of_integers[ integer_index - 1 ]  +  2 ;
      }

      Console.Write( "\n The contents of \"array_of_integers\" is:\n" ) ;

      for ( integer_index  =  0 ;
            integer_index  <  50 ;
            integer_index  ++ )
      {
         if ( ( integer_index  %  10 )  ==  0 )
         {
            Console.Write( "\n" ) ;
         }

         Console.Write(
           array_of_integers[ integer_index ].ToString().PadLeft( 5 ) ) ;
      }
   }
}


