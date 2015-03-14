
//  MeanvalueMethod.cs  (c) 2003 Kari Laitinen

using System ;

class MeanvalueMethod
{
   static void read_array_of_numbers( double[] array_of_numbers,
                                      out int  number_of_numbers_in_array )
   {
      int  number_index  =  0  ;

      Console.Write( "   Enter a number: " ) ;

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

      number_of_numbers_in_array  =  number_index ;
   }


   static void calculate_mean_value( double[] array_of_numbers,
                                     int      number_of_numbers_in_array,

                                     out double calculated_mean_value )
   {
      double  sum_of_numbers   =  0  ;

      for ( int number_index  =  0 ;
                number_index  <  number_of_numbers_in_array ;
                number_index  ++ )
      {
         sum_of_numbers  =  sum_of_numbers  +
                             array_of_numbers[ number_index ] ;
      }

      if ( number_of_numbers_in_array  >  0 )
      {
         calculated_mean_value  = (double) sum_of_numbers /
                                  (double) number_of_numbers_in_array ;
      }
      else
      {
         calculated_mean_value  =  0 ;
      }
   }

   static void Main()
   {
      double[]  array_of_numbers  =  new  double[ 100 ] ;
      int     number_of_numbers_read ;
      double  mean_value ;

      Console.Write( "\n This program calculates the mean value of"
                   + "\n the numbers you enter from the keyboard."
                   + "\n The program stops when you enter a letter.\n\n");

      read_array_of_numbers( array_of_numbers,
                             out number_of_numbers_read ) ;

      calculate_mean_value( array_of_numbers,
                            number_of_numbers_read,

                            out mean_value ) ;

      Console.Write( "\n The mean value is: "  +  mean_value  + "\n" ) ;
   }
}



