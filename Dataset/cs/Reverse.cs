
//  Reverse.cs  (c) 2003 Kari Laitinen

using System ;

class Reverse
{
   static void Main()
   {
      int[] array_of_integers      =  new  int[ 100 ] ;
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

         array_of_integers[ integer_index ]  =  integer_from_keyboard ;
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





