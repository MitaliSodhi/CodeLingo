
//  MeanvalueArray.cs  (c) 2003 Kari Laitinen

using System ;

class MeanvalueArray
{
   static void Main()
   {
      Console.Write( "\n This program calculates the mean value of"
                  +  "\n the numbers you enter from the keyboard."
                  +  "\n The program stops when you enter a letter."
                  +  "\n\n   Enter a number: " ) ;

      double[]  array_of_numbers  =  new double[ 100 ] ;
      int       number_index   =  0  ;

      bool  keyboard_input_is_numerical  =  true ;

      while ( keyboard_input_is_numerical ==  true  &&
              number_index  <  array_of_numbers.Length  )
      {
         try
         {
            double  number_from_keyboard  =
                             Convert.ToDouble( Console.ReadLine() ) ;
            array_of_numbers[ number_index ]  =  number_from_keyboard ;
            number_index  ++ ;
            Console.Write(  "   Enter a number: " ) ;
         }
         catch ( FormatException  not_numerical_input_exception )
         {
            keyboard_input_is_numerical  =  false ;
         }
      }

      int  number_of_numbers_in_array  =  number_index ;
      double  sum_of_numbers  =  0 ;

      for (  number_index  =  0 ;
             number_index  <  number_of_numbers_in_array ;
             number_index  ++ )
      {
         sum_of_numbers  =  sum_of_numbers  +
                            array_of_numbers[ number_index ] ;
      }

      double  mean_value  =  0 ;

      if ( number_of_numbers_in_array  >  0 )
      {
         mean_value  =  sum_of_numbers /
                        (double) number_of_numbers_in_array ;
      }

      Console.Write( "\n The mean value is: " + mean_value + " \n" ) ;
   }
}


