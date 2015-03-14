
//  ArrayDemoSolution_7_5.cs  (c)  Kari Laitinen

//  http://www.naturalprogramming.com

//  2004-10-30  File created.
//  2004-10-30  Last modification.

using  System ;

class ArrayDemoSolution_7_5
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

      int  sum_of_integers  =  0 ;

      for ( integer_index  =  0 ;
            integer_index  <  50 ;
            integer_index  ++ )
      {
         sum_of_integers  =  sum_of_integers  +
                             array_of_integers[ integer_index ] ;
      }


      Console.Write( "\n\n The sum of integers in \"array_of_integers\""
                  +  " is: "  +  sum_of_integers  +  "\n"  ) ;

   }
}


