
//  RectanglesWithStructUnsafe.cs  (c) 2004 Kari Laitinen

//  Compile: csc RectanglesWithStructUnsafe.cs /unsafe

//  www.naturalprogramming.com

//  This program is a modified version of program
//  RectanglesWithStruct.cs which in turn is a modified
//  version of program Rectangles.cs. This program uses
//  the method print_memory() from program StackInspection.cs
//  to print the stack and show how the struct-based
//  Rectangle objects look like in the stack memory.

//  By studying the output of the program, you can see that
//  4 bytes are allocated for the char member filling_character 
//  although 2 bytes would be adequate for it.

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


unsafe class RectanglesWithStructUnsafe
{
   static void print_memory( int*  memory_pointer,
                             int   number_of_positions_to_print )
   {
      for ( int position_counter  =  0 ;
                position_counter  <  number_of_positions_to_print ;
                position_counter  ++  )
      {
         Console.Write( "\n Address "
              +  ( (int) memory_pointer ).ToString("X")
              +  " contains "
              +  ( *memory_pointer ).ToString("X").PadLeft( 8 ) ) ;

         memory_pointer  ++ ;
      }
   }

   static void Main()
   {
      Rectangle  first_rectangle  =  new Rectangle() ;

      first_rectangle.initialize_rectangle( 7, 4, 'Z' ) ;
      first_rectangle.print_rectangle() ;

      Rectangle  second_rectangle  =  new Rectangle() ;

      second_rectangle.initialize_rectangle( 12, 3, 'X' ) ;
      second_rectangle.print_rectangle() ;

      int  integer_on_top_of_the_stack  =  0x11223344 ;

      print_memory( &integer_on_top_of_the_stack, 12 ) ;
   }
}



