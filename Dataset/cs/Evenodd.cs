
//  Evenodd.cs  (c) 2003 Kari Laitinen

using System ;

class Evenodd
{
   static void Main()
   {
      int  integer_from_keyboard ;

      Console.Write( "\n This program can find out whether an integer"
                  +  "\n is even or odd. Please, enter an integer: " ) ;

      integer_from_keyboard  =  Convert.ToInt32( Console.ReadLine() ) ;

      if ( ( integer_from_keyboard  %  2 )  ==  0 )
      {
         Console.Write( "\n " + integer_from_keyboard + " is even.\n") ;
      }
      else
      {
         Console.Write( "\n " + integer_from_keyboard + " is odd. \n") ;
      }
   }
}





