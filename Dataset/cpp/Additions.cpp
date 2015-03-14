
//  Additions.cpp  (c) Kari Laitinen

//  http://www.naturalprogramming.com

//  2006-06-09  File created.
//  2006-06-09  Last modification.

//  This is the C++ version of corresponding Java/C#/Python
//  programs. This program is not presented in the C++ book.

//  The corresponding Java and C# programs demonstrate the
//  'dualistic' nature of the + operator. This C++ program
//  is not important because the + operator cannot be used
//  to concatenate C-style strings.

//  This C++ version of the program produces the same output
//  as the corresponding Java/C# programs.

#include <iostream.h>

int main()
{
   int  some_integer  =  1234 ;

   cout << "\n "  ;
   cout << "xxxx" << some_integer << "zzzz"  ;
   cout << "\n "  ;
   cout << "xxxx" << some_integer << some_integer << "zzzz"  ;
   cout << "\n "  ;
   cout << "xxxx" << ( some_integer + some_integer ) << "zzzz"  ;
   cout << "\n "  ;
   cout << ( some_integer + some_integer ) << "xxxx" << "zzzz"  ;
   cout << "\n "  ;
   cout << some_integer << some_integer << "xxxx" << "zzzz"  ;
   cout << "\n "  ;
   cout << "xxxx" << "zzzz" << some_integer << ( some_integer + 1 ) ;
   cout << "\n "  ;
   cout << "xxxx" << "zzzz" << some_integer << some_integer << 1  ;

}



