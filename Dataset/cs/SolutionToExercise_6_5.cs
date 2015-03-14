
//  SolutionToExercise_6_5.cs  (c) 2004 Kari Laitinen

//  http://www.naturalprogramming.com

//  2004-10-28  File created.
//  2004-10-28  Last modification.

/*  This is a multiline comment.

    Execute this program to see the answer.

This is the last line of the multiline comment */

using System ;

class SolutionToExercise_6_5
{
   static void Main()
   {
      int  growing_number    =  1 ;
      int  shrinking_number  =  20 ;
      Console.Write( "\n\n " ) ;

      while ( growing_number  <  shrinking_number )
      {
         Console.Write(  " "  +  growing_number
                     +  " "  +  shrinking_number ) ;

         growing_number  =  growing_number  +  2 ;
         shrinking_number  =  shrinking_number  -  3 ;
      } 
      
      Console.Write( "\n\n " ) ;
                  
      growing_number    =  1 ;
      shrinking_number  =  20 ;


      while ( growing_number  <  shrinking_number )
      {
         shrinking_number  =  shrinking_number  -  3 ;
         growing_number  =  growing_number  +  2 ;
         
         Console.Write(  " "  +  growing_number
                     +  " "  +  shrinking_number ) ;
      } 
      

      Console.Write( "\n\n " ) ;
   }
}



