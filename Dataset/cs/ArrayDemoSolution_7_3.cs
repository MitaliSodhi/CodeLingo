
//  ArrayDemoSolution_7_3.cs  (c)  Kari Laitinen

//  http://www.naturalprogramming.com

//  2004-10-30  File created.
//  2004-10-30  Last modification.

using  System ;

class ArrayDemoSolution_7_3
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

      //  integer_index is never equally divisible when the loop
      //  below is executed. Only the integers in odd index positions
      //  are printed.

      for ( integer_index  =  1 ;
            integer_index  <  29 ;
            integer_index  =  integer_index  +  2 )
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



