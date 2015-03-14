
//  SolutionToExercise_6_4.cs  (c) 2004 Kari Laitinen

//  http://www.naturalprogramming.com

//  2004-10-28  File created.
//  2004-10-28  Last modification.

/*  This is a multiline comment.

   You see the correct answers below to the left of the == operator

   ( some_variable  !=  8 ) == ( ! ( some_variable  == 8 ) )
   ( some_variable  >  10 ) == ( ( some_variable - 10 )  >  0 )
   ( some_variable  <= 88 ) == ( some_variable  <  88  ||  some_variable  ==  88 )
   ( some_variable  <  other_variable ) == ( ( some_variable - other_variable )  <  0 )
   ( some_variable  <  99 ) == ( ! ( ! ( some_variable  <  99 ) )


This is the last line of the multiline comment */

using System ;

class SolutionToExercise_6_4
{
   static void Main()
   {
      Console.Write( "\n Testing the solutions in a loop ... \n " ) ;
                  
      int other_variable  =  77 ;
      
      int number_of_correct_test_cases  =  0 ;
      int number_of_errors  =  0 ;
      
      for ( int some_variable  =  - 2500 ;
                some_variable  <    2500 ;
                some_variable  ++ )
      {
         if ((( some_variable  !=  8 ) == ( ! ( some_variable  == 8 ) )) &&
             (( some_variable  >  10 ) == ( ( some_variable - 10 )  >  0 )) &&
             (( some_variable  <= 88 ) == ( some_variable  <  88  ||  some_variable  ==  88 )) &&
             (( some_variable  <  other_variable ) == ( ( some_variable - other_variable )  <  0 ) ) &&
             (( some_variable  <  99 ) == ( ! ( ! ( some_variable  <  99 ) ) ) ) )
          {
             number_of_correct_test_cases  ++ ;
          }    
          else
          {
             number_of_errors  ++ ;
          }
      }

      Console.Write( "\n\n  "  +  number_of_correct_test_cases  +  " correct runs. "
                     +  "\n  "  +  number_of_errors  +  " errors.\n" ) ;
   }
}



