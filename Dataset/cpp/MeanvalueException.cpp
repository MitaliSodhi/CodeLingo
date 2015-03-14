
//  MeanvalueException.cpp (c) 1997-2006 Kari Laitinen

//  http://www.naturalprogramming.com

//  2006-06-08  File created.
//  2006-06-08  Last modification.

//  This is the C++ version of corresponding Java/C#/Python
//  programs (e.g. MeanvalueException.java). This program is not presented
//  in the C++ book. I decided to provide this program because it
//  is available with other languages.

#include  <iostream.h>

//  The following function is used to read an int value from
//  the keyboard. If a non-int value is given, an exception is thrown.

//  We must use this function in this program because, to my knowledge,
//  C++ does not provide a standard input function that would throw
//  exceptions.

int get_integer_from_keyboard()
{
   char string_from_keyboard[ 20 ] ;

   cin.getline( string_from_keyboard, sizeof( string_from_keyboard ) ) ;

   //  We'll check the given string and throw an exception if it
   //  contains a character that is not a numerical digit.

   for ( unsigned int character_index  =  0 ;
                      character_index  <  strlen( string_from_keyboard ) ;
                      character_index  ++ )
   {
      if ( ! ( string_from_keyboard[ character_index ]  >=  '0'  &&
               string_from_keyboard[ character_index ]  <=  '9' ) )
      {
         throw  exception() ;
      }
   }

   //  Function atoi() converts the given string to an int value.

   return  atoi( string_from_keyboard ) ;
}

int main()
{
   int   integer_from_keyboard  ;
   int   number_of_integers_given  =  0 ;
   float mean_value                =  0 ;
   int   sum_of_integers           =  0 ;

   cout << "\n This program calculates the mean value of"
        << "\n the integers that you enter from the keyboard."
        << "\n Please, start entering numbers. The program"
        << "\n stops when you enter a letter. \n\n" ;

   bool  keyboard_input_is_numerical  =  true ;

   while ( keyboard_input_is_numerical  ==  true )
   {
      try
      {
         cout  <<  "   Enter an integer: " ;
         integer_from_keyboard   =  get_integer_from_keyboard() ;

         number_of_integers_given  ++  ;
         sum_of_integers  =  sum_of_integers + integer_from_keyboard ;
      }
      catch ( exception  not_numerical_input_exception )
      {
         keyboard_input_is_numerical  =  false ;
      }
   }

   if ( number_of_integers_given  >  0 )
   {
      mean_value  =  (float) sum_of_integers /
                     (float) number_of_integers_given ;
   }

   cout << "\n The mean value is: "  <<  mean_value  << "\n" ;
}




