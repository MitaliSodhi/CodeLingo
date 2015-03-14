
//  RectanglesWithStruct.cs  (c) 2004 Kari Laitinen

//  www.naturalprogramming.com

//  This program is like program Rectangles.cs except that
//  the keyword struct is used in place of the keyword
//  class when type Rectangle is defined.

using System ;

struct Rectangle
{
   int  rectangle_width ;
   int  rectangle_height ;
   char  filling_character ;

   public void initialize_rectangle( int  given_rectangle_width,
                                     int  given_rectangle_height,
                                     char given_filling_character )
   {
      rectangle_width    =  given_rectangle_width ;
      rectangle_height   =  given_rectangle_height ;
      filling_character  =  given_filling_character ;
   }

   public void print_rectangle()
   {
      for ( int number_of_rows_printed  =  0 ;
                number_of_rows_printed  <  rectangle_height ;
                number_of_rows_printed  ++ )
      {
         Console.Write( "\n      " ) ;

         for ( int number_of_characters_printed  =  0 ;
                   number_of_characters_printed  <  rectangle_width ;
                   number_of_characters_printed  ++ )
         {
            Console.Write( filling_character ) ;
         }
      }

      Console.Write( "\n" ) ;
   }
}


class RectanglesWithStruct
{
   static void Main()
   {
      Rectangle  first_rectangle  =  new Rectangle() ;

      first_rectangle.initialize_rectangle( 7, 4, 'Z' ) ;
      first_rectangle.print_rectangle() ;

      Rectangle  second_rectangle  =  new Rectangle() ;

      second_rectangle.initialize_rectangle( 12, 3, 'X' ) ;
      second_rectangle.print_rectangle() ;
   }
}



