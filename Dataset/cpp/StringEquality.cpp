
//  StringEquality.cpp  (c) Kari Laitinen

//  http://www.naturalprogramming.com

//  2006-06-08  File created.
//  2006-06-08  Last modification.

//  This is the C++ version of corresponding Java/C#/Python
//  programs (e.g. StringEquality.java). This program is not presented
//  in the C++ book. I decided to provide this program because it
//  is available with other languages.

//  This program differs from the corresponding programs written
//  with other programming languages because the strings in C++
//  differ from the strings in Java/C#/Python.

//  This program deals first with the C-style strings
//  that are discussed in Chapter 7 of the C++ book.
//  Also the string objects, that are discussed in Chapter 15, are
//  compared in this program.

//  The following facts can be said about C-style strings:

//    Function strcmp() returns 0 when two strings contain the same
//    sequence of characters.

//    Function strcpy() makes a copy of a C-style string.


//  The following facts can be said about C++ string objects.

//    Operator == checks whether two C++ string objects contain the
//    same sequence of characters.

//    Operator = makes a copy of a string object.


#include <iostream.h>
#include <string>       //  The C++ standard string class

int main()
{
   char  first_c_style_string[]   =  "xxxxxx" ;
   char  second_c_style_string[]  =  "yyyyyy" ;

   cout << "\n  "  <<  first_c_style_string  <<  "  "
        << second_c_style_string  ;

   if ( strcmp( first_c_style_string, second_c_style_string )  ==  0 )
   {
      cout << "\n     Equal C-style strings."  ;
   }
   else
   {
      cout << "\n     Not equal C-style strings."  ;
   }

   if ( first_c_style_string  ==  second_c_style_string )
   {
      cout << "\n     The same C-style strings were compared."  ;
   }
   else
   {
      cout << "\n     Different C-style strings were compared."  ;
   }

   strcpy( second_c_style_string, first_c_style_string ) ;

   cout << "\n  "  <<  first_c_style_string  <<  "  "
        << second_c_style_string  ;

   if ( strcmp( first_c_style_string, second_c_style_string )  ==  0 )
   {
      cout << "\n     Equal C-style strings."  ;
   }
   else
   {
      cout << "\n     Not equal C-style strings."  ;
   }

   if ( first_c_style_string  ==  second_c_style_string )
   {
      cout << "\n     The same C-style strings were compared."  ;
   }
   else
   {
      cout << "\n     Different C-style strings were compared."  ;
   }

   //  The rest of this program deals with string objects.

   string  first_string   =  "aaaaaa" ;
   string  second_string  =  "bbbbbb" ;

   cout << "\n  " + first_string + "  " + second_string  ;

   if ( first_string  ==  second_string )
   {
      cout << "\n     Equal String objects."  ;
   }
   else
   {
      cout << "\n     Not equal String objects."  ;
   }


   second_string  =  first_string ;  //  This makes a copy of an object

   cout << "\n  " + first_string + "  " + second_string  ;

   if ( first_string  ==  second_string )
   {
      cout << "\n     Equal String objects."  ;
   }
   else
   {
      cout << "\n     Not equal String objects."  ;
   }
}



