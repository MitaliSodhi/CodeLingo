
//  SolutionToExercise_6_3.cs  (c) 2004 Kari Laitinen

//  http://www.naturalprogramming.com

//  2004-10-28  File created.
//  2004-10-28  Last modification.

/*  This is a multiline comment.

   Execute this program to see the following solution:

D:\cssolutions>SolutionToExercise_6_3

 ( first_variable  <  second_variable )  is True
 ( third_variable  <  first_variable )  is False
 ( ! ( first_variable  <  second_variable ) )  is False
 ( third_variable  >  first_variable )  is True
 ( ( first_variable + second_variable )  <  third_variable )  is True
 ( ( first_variable + second_variable )  <= third_variable )  is True
 ( ( third_variable - second_variable )  >  first_variable )  is True
 ( first_variable  ==  0 )  is False
 ( ! ( first_variable == 0 ) )  is True
 ( first_variable  >  0  ||  second_variable  <  0 )  is True
 ( first_variable  == 8  ||  second_variable  == 5 )  is False
 ( first_variable  <  second_variable  &&  third_variable >=  14 )  is True
 ( first_variable  == 5  &&  second_variable  >  8 )  is False

This is the last line of the multiline comment */

using System ;

class SolutionToExercise_6_3
{
   static void Main()
   {
      int  first_variable   =   5 ;
      int  second_variable  =   8 ;
      int  third_variable   =  14 ;
   
      Console.Write( "\n ( first_variable  <  second_variable )  is "
                   + ( first_variable  <  second_variable )  ) ;
      
      Console.Write( "\n ( third_variable  <  first_variable )  is "
                   + ( third_variable  <  first_variable )  ) ;
      Console.Write( "\n ( ! ( first_variable  <  second_variable ) )  is "
                   + ( ! ( first_variable  <  second_variable ) )  ) ;
      Console.Write( "\n ( third_variable  >  first_variable )  is "
                   + ( third_variable  >  first_variable )  ) ;
      Console.Write(
         "\n ( ( first_variable + second_variable )  <  third_variable )  is "
        + ( ( first_variable + second_variable )  <  third_variable )  ) ;
      Console.Write(
         "\n ( ( first_variable + second_variable )  <= third_variable )  is "
        + ( ( first_variable + second_variable )  <= third_variable )  ) ;
      Console.Write(
         "\n ( ( third_variable - second_variable )  >  first_variable )  is "
        + ( ( third_variable - second_variable )  >  first_variable )  ) ;
      Console.Write( "\n ( first_variable  ==  0 )  is "
                   + ( first_variable  ==  0 )  ) ;
      Console.Write( "\n ( ! ( first_variable == 0 ) )  is "
                   + ( ! ( first_variable == 0 ) )  ) ;
      Console.Write(
        "\n ( first_variable  >  0  ||  second_variable  <  0 )  is "
       + ( first_variable  >  0  ||  second_variable  <  0 )  ) ;
      Console.Write(
       "\n ( first_variable  == 8  ||  second_variable  == 5 )  is "
       + ( first_variable  == 8  ||  second_variable  == 5 )  ) ;
      Console.Write(
       "\n ( first_variable  <  second_variable  &&  third_variable >=  14 )  is "
       + ( first_variable  <  second_variable  &&  third_variable >=  14 )  ) ;
      Console.Write( "\n ( first_variable  == 5  &&  second_variable  >  8 )  is "
                   + ( first_variable  == 5  &&  second_variable  >  8 )  ) ;

   }
}



