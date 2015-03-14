
//  sort.cpp  (c) 1997-2002 Kari Laitinen

#include  <iostream.h>
#include  <iomanip.h>

#define   ARRAY_SIZE     100

void
read_array_of_numbers( double  array_of_numbers[],
                       int&    number_of_numbers_in_array ) ;
void
find_smallest_number_in_array( double   array_of_numbers[],
                               int      number_of_numbers_in_array,

                               double&  smallest_number,
                               int&     index_of_smallest_number ) ;

void  
sort_to_ascending_order( double  array_of_numbers[],
                         int     number_of_numbers_in_array ) ;

void
print_array_of_numbers( double  array_of_numbers[],
                        int     number_of_numbers_in_array ) ;

int main()
{
   double  array_of_numbers[ ARRAY_SIZE ] ;
   int     number_of_numbers_read ;

   cout << "\n This program sorts the numbers that you enter"
        << "\n from the keyboard. The program stops asking for new"
        << "\n numbers when you enter a letter. \n\n" ;

   read_array_of_numbers( array_of_numbers,
                          number_of_numbers_read ) ;

   sort_to_ascending_order( array_of_numbers,
                            number_of_numbers_read ) ;

   print_array_of_numbers( array_of_numbers,
                           number_of_numbers_read ) ;
}

void  read_array_of_numbers( double  array_of_numbers[],
                             int&    number_of_numbers_in_array )
{
   int      number_index  =  0  ;
   double   number_from_keyboard   ;

   cout  <<  "   Enter a number: " ;

   while ( ( cin  >>  number_from_keyboard )  &&
           ( number_index  <  ARRAY_SIZE    )  )
   {
      array_of_numbers[ number_index ]  =  number_from_keyboard ;
      number_index  ++ ;
      cout  <<  "   Enter a number: " ;
   }

   number_of_numbers_in_array  =  number_index ;
}

void
find_smallest_number_in_array( double   array_of_numbers[],
                               int      number_of_numbers_in_array,

                               double&  smallest_number,
                               int&     index_of_smallest_number )
{
   smallest_number           =  array_of_numbers[ 0 ] ;
   index_of_smallest_number  =  0 ;

   for ( int number_index  =  1  ;
             number_index  <  number_of_numbers_in_array  ;
             number_index  ++ )
   {
      if ( array_of_numbers[ number_index ]  <  smallest_number )
      {
         smallest_number   =  array_of_numbers[ number_index ] ;
         index_of_smallest_number  =  number_index ;
      }
   }
}

void  
sort_to_ascending_order( double  array_of_numbers[],
                         int     number_of_numbers_in_array )
{
   double  smallest_number  ;
   int     index_of_smallest_number ;

   for ( int number_index  =  0 ;
             number_index  <  number_of_numbers_in_array - 1 ;
             number_index  ++ )
   {
      find_smallest_number_in_array(
                     &array_of_numbers[ number_index ],
                      number_of_numbers_in_array - number_index,

                      smallest_number,
                      index_of_smallest_number ) ;

      index_of_smallest_number  +=  number_index ;

      //  Now we simply put the number in current array
      //  position to where the smallest number is, and
      //  then put the smallest number in current position.

      array_of_numbers[ index_of_smallest_number ]  =
                               array_of_numbers[ number_index ] ;

      array_of_numbers[ number_index ]  =  smallest_number ;
   }
}

void
print_array_of_numbers( double  array_of_numbers[],
                        int     number_of_numbers_in_array )
{
   for ( int number_index  =  0  ;
             number_index  <  number_of_numbers_in_array ;
             number_index  ++ )
   {
      if ( ( number_index  %  5 )  ==  0  )
      {
         cout  <<  "\n" ;
      }

      cout << setw( 10 ) << array_of_numbers[ number_index ] ;
   }
}



