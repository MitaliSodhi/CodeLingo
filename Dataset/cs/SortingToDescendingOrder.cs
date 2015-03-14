
//  SortingToDescendingOrder.cs  (c) 2004 Kari Laitinen

//  http://www.naturalprogramming.com

//  2004-11-06  File created.
//  2004-11-06  Last modification.

//  A solution to Exercise 9-7.

using  System ;

class SortingToDescendingOrder
{
   public static void 
   read_array_of_numbers( double[] array_of_numbers,
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

   public static void
   print_array_of_numbers( double[]  array_of_numbers,
                           int       number_of_numbers_in_array )
   {
      for ( int number_index  =  0  ;
                number_index  <  number_of_numbers_in_array ;
                number_index  ++ )
      {
         if ( ( number_index  %  5 )  ==  0  )
         {
            Console.Write( "\n" ) ;
         }

         Console.Write(

             array_of_numbers[ number_index ].ToString().PadLeft( 10 ) ) ;
      }
   }

   //  The internal structure of find_largest_number_in_array() is
   //  the same as the the structure of method find_smallest_number_-
   //  in_array(). The difference between these two methods is that
   //  operator > is used in the method below in place of operator <.

   static void
   find_largest_number_in_array( double[] array_of_numbers,
                                 int      number_of_numbers_in_array,

                                 out double  largest_number,
                                 out int     index_of_largest_number )
   {
      largest_number           =  array_of_numbers[ 0 ] ;
      index_of_largest_number  =  0 ;

      for ( int number_index  =  1  ;
                number_index  <  number_of_numbers_in_array  ;
                number_index  ++ )
      {
         if ( array_of_numbers[ number_index ]  >  largest_number )
         {
            largest_number   =  array_of_numbers[ number_index ] ;
            index_of_largest_number  =  number_index ;
         }
      }
   }

   //  sort_to_descending_order() is like sort_to_ascending_order()
   //  except that the method below always finds the largest number
   //  in the subarray being processed.

   public static void  
   sort_to_descending_order( double[]  array_of_numbers,
                             int       number_of_numbers_in_array )
   {
      double  largest_number  ;
      int     index_of_largest_number ;

      for ( int number_index  =  0 ;
                number_index  <  number_of_numbers_in_array - 1 ;
                number_index  ++ )
      {
         int  number_of_unsorted_numbers  =
                       number_of_numbers_in_array - number_index ;

         double[] array_of_unsorted_numbers  =
                       new  double[ number_of_unsorted_numbers ] ;

         Array.Copy( array_of_numbers,
                     number_index,
                     array_of_unsorted_numbers,
                     0,
                     number_of_unsorted_numbers ) ;

         find_largest_number_in_array(
                         array_of_unsorted_numbers,
                         number_of_unsorted_numbers,

                         out largest_number,
                         out index_of_largest_number ) ;

         index_of_largest_number  +=  number_index ;

         //  Now we simply put the number in current array
         //  position to where the largest number is, and
         //  then put the largest number in current position.

         array_of_numbers[ index_of_largest_number ]  =
                                  array_of_numbers[ number_index ] ;

         array_of_numbers[ number_index ]  =  largest_number ;
      }
   }

   static void Main()
   {
      double[]  array_of_numbers  =  new double[ 100 ] ;
      int       number_of_numbers_read ;

      Console.Write(
           "\n This program sorts the numbers that you enter"
        +  "\n from the keyboard. The program stops asking for new"
        +  "\n numbers when you enter a letter. \n\n" ) ;

      read_array_of_numbers( array_of_numbers,
                             out number_of_numbers_read ) ;

      sort_to_descending_order( array_of_numbers,
                                number_of_numbers_read ) ;

      print_array_of_numbers( array_of_numbers,
                              number_of_numbers_read ) ;
   }
}






