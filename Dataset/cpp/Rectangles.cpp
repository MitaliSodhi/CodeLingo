
//  Rectangles.cpp   Copyright (c) Kari Laitinen

//  http://www.naturalprogramming.com

//  2006-06-07  File created.
//  2006-06-07  Last modification.

//  This program is not presented in the C++ book, but there are
//  corresponding programs presented in the Java and C# books.

#include  <iostream.h>

class Rectangle
{
protected:
   int  rectangle_width ;
   int  rectangle_height ;
   char  filling_character ;

public:

   void initialize_rectangle( int  given_rectangle_width,
                              int  given_rectangle_height,
                              char given_filling_character ) ;

   void print_rectangle() ;
} ;

void Rectangle::initialize_rectangle( int  given_rectangle_width,
                                      int  given_rectangle_height,
                                      char given_filling_character )
{
   rectangle_width    =  given_rectangle_width ;
   rectangle_height   =  given_rectangle_height ;
   filling_character  =  given_filling_character ;
}

void Rectangle::print_rectangle()
{
   for ( int number_of_rows_printed  =  0 ;
             number_of_rows_printed  <  rectangle_height ;
             number_of_rows_printed  ++ )
   {
      cout << "\n      "  ;

      for ( int number_of_characters_printed  =  0 ;
                number_of_characters_printed  <  rectangle_width ;
                number_of_characters_printed  ++ )
      {
         cout  <<  filling_character ;
      }
   }

   cout << "\n" ;
}



int main()
{
   Rectangle  first_rectangle ;

   first_rectangle.initialize_rectangle( 7, 4, 'Z' ) ;
   first_rectangle.print_rectangle() ;

   Rectangle  second_rectangle ;

   second_rectangle.initialize_rectangle( 12, 3, 'X' ) ;
   second_rectangle.print_rectangle() ;
}


