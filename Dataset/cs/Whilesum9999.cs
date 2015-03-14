
//  Whilesum9999.cs  (c) Kari Laitinen

using System ;

class Whilesum9999
{
   static void Main()
   {
      int sum_of_integers = 0 ;
      bool user_wants_to_stop_entering_numbers = false ;

      while ( user_wants_to_stop_entering_numbers == false )
      {
         Console.Write( "\n Give a number: " ) ;

         int integer_from_keyboard  =
                       Convert.ToInt32( Console.ReadLine() ) ;

         if ( integer_from_keyboard  ==  9999 )
         {
            user_wants_to_stop_entering_numbers = true ;
         }
         else
         {
            sum_of_integers  =
                     sum_of_integers + integer_from_keyboard ;
         }
      }

      Console.Write( "\n The sum is: " + sum_of_integers  + "\n" ) ;
   }
}