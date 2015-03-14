
//  ExceptionalNumbers.cpp  (c) Kari Laitinen

//  http://www.naturalprogramming.com

//  2006-06-08  File created.
//  2006-06-08  Last modification.

//  This is the C++ version of corresponding Java/C#/Python
//  programs. This program is not presented in the C++ book.

//  Because C++ does not include automatic garbage collection,
//  creating the exception objects with the new operator can 
//  be problematic.

//  C++ has a standard superclass for exceptions and the name
//  of the class is 'exception'. It is not, however, mandatory
//  to use this class as a base class for user-defined exception
//  classes.

#include <iostream.h>

class  NumberTooSmallException  :  public exception
{
} ;

class  NumberTooLargeException  :  public exception
{
} ;


//  The following function is used to read an int value from
//  the keyboard. If a non-int value is given, an exception is thrown.

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

int get_number_from_keyboard()
{
   int number_from_keyboard   =  get_integer_from_keyboard() ;

   if ( number_from_keyboard  <=  99 )
   {
      throw NumberTooSmallException() ;
   }
   else if ( number_from_keyboard  >=  999 )
   {
      throw NumberTooLargeException() ;
   }

   return number_from_keyboard ;
}

int get_number()
{
   int number_from_above_function  =  1234 ;

   try
   {
      number_from_above_function  =  get_number_from_keyboard() ;
   }
   catch ( NumberTooSmallException  number_too_small_exception )
   {
      cout << "\n NumberTooSmallException caught. " ;
   }

   return  number_from_above_function ;
}

int main()
{
   cout << " Please, type in a number: " ;

   try
   {
      int  number_read_via_several_functions  =  get_number() ;

      cout << "\n The number from keyboard is : "
           <<  number_read_via_several_functions  ;
   }
   catch ( NumberTooLargeException number_too_large_exception )
   {
      cout << "\n NumberTooLargeException caught. " ;
   }
   catch ( exception caught_exception )
   {
      cout << "\n Some exception was caught. Some info:  " ;
      cout << caught_exception.what() ;
   }
}




