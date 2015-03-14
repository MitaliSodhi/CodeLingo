
//  ReverseWithArrayList.cs  (c) 2004 Kari Laitinen

//  http://www.naturalprogramming.com

//  2004-11-24  File created.
//  2004-11-24  Last modification.

//  A solution to exercise 15-4.

using System ;
using System.Collections ;  //  Namespace of class ArrayList

class ReverseWithArrayList
{
   static void Main()
   {
      ArrayList array_of_integers      =  new  ArrayList() ;
      int   integer_index          =  0 ;
      int   integer_from_keyboard  =  0 ;

      Console.Write("\n This program reads integers from the keyboard and,"
                 +  "\n after receiving a zero, it prints the numbers"
                 +  "\n in reverse order. Please, start entering numbers."
                 +  "\n The program will stop when you enter a zero.\n\n") ;
      do
      {
         Console.Write( " "  +  integer_index  +  "  Enter an integer: ") ;
         integer_from_keyboard  =  Convert.ToInt32( Console.ReadLine() ) ;

         array_of_integers.Add( integer_from_keyboard ) ;
         integer_index  ++ ;
      }
       while  ( integer_from_keyboard  !=  0 ) ;


      Console.Write( "\n Reverse order:  " ) ;

      while  ( integer_index  >  0 )
      {
         integer_index  -- ;
         Console.Write( array_of_integers[ integer_index ]  +  "   " ) ;
      } 
   }
}





