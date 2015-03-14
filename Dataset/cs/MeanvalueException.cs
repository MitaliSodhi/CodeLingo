
//  MeanvalueException.cs  (c) 2003 Kari Laitinen

using System ;

class MeanvalueException
{
   static void Main()
   {
      Console.Write( "\n This program calculates the mean value of"
                  +  "\n the integers you enter from the keyboard."
                  +  "\n The program stops when you enter a letter."
                  +  "\n\n   Enter an integer: " ) ;

      int   number_of_integers_given  =  0 ;
      int   sum_of_integers           =  0 ;

      bool  keyboard_input_is_numerical  =  true ;

      while ( keyboard_input_is_numerical ==  true )
      {
         try
         {
            int integer_from_keyboard  =
                             Convert.ToInt32( Console.ReadLine() ) ;
            number_of_integers_given  ++  ;
            sum_of_integers  =  sum_of_integers + integer_from_keyboard ;
            Console.Write(  "   Enter an integer: " ) ;
         }
         catch ( FormatException  not_numerical_input_exception )
         {
            keyboard_input_is_numerical  =  false ;
         }
      }

      float mean_value  =  0 ;

      if ( number_of_integers_given  >  0 )
      {
         mean_value  =  (float) sum_of_integers /
                        (float) number_of_integers_given ;
      }

      Console.Write( "\n The mean value is: " + mean_value + " \n" ) ;
   }
}


