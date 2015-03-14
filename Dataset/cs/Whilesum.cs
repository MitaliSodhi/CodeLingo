
//  Whilesum.cs  (c) 2003 Kari Laitinen

using System ;

class Whilesum
{
   static void Main()
   {
      int  integer_from_keyboard   =  -1 ;
      int  sum_of_integers         =   0 ;

      Console.Write( "\n This program calculates the sum of the integers"
                   + "\n you type in from the keyboard. By entering a"
                   + "\n zero you can terminate the program. \n\n" ) ;

      while ( integer_from_keyboard  !=  0 )
      {
         Console.Write( "  Current sum: "
                     +  sum_of_integers.ToString().PadLeft( 8 )
                     +  "    Enter an integer: " ) ;

         integer_from_keyboard  = Convert.ToInt32( Console.ReadLine() );

         sum_of_integers  =  sum_of_integers + integer_from_keyboard ;
      }
   }
}


