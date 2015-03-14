
//  windows.cpp  (c) 1999-2002 Kari Laitinen

//  13.07.1999  File created.
//  10.12.2002  Last modification.

//  NOTE: As this is an educational program, the classes defined
//  here are not safe for all kinds of uses. If you try to define
//  very large or very small windows, or put long texts inside
//  the windows, the classes may not work properly.

#include  <iostream.h>
#include  <string.h>

#define  MAXIMUM_WINDOW_WIDTH        78
#define  MAXIMUM_WINDOW_HEIGHT       22


class  Window
{
protected:
   char  window_contents [ MAXIMUM_WINDOW_WIDTH ]
                         [ MAXIMUM_WINDOW_HEIGHT ] ;
   int   window_width ;
   int   window_height ;
   char  background_character ;

public:
   Window( int  desired_window_width   =  MAXIMUM_WINDOW_WIDTH,
           int  desired_window_height  =  MAXIMUM_WINDOW_HEIGHT,
           char given_background_character  =  ' '  ) ;

   void  fill_with_character( char  filling_character ) ;

   void  print() ;

   void  move( int       destination_x_index,
               int       destination_y_index,
               Window&   another_window ) ;
} ;


Window::Window( int  desired_window_width,
                int  desired_window_height,
                char given_background_character )
{
   window_width          =  desired_window_width ;
   window_height         =  desired_window_height ;
   background_character  =  given_background_character ;

   fill_with_character( background_character ) ;
}

void Window::fill_with_character( char filling_character )
{
   for ( int row_index  =  0  ;
             row_index  <  window_height ;
             row_index  ++  )
   {
      for ( int column_index  =  0 ;
                column_index  <  window_width ;
                column_index  ++ )
      {
         window_contents[ column_index ] [ row_index ]  =
                                            filling_character ;
      }
   }
}

void  Window::print()
{
   cout  <<  "\n" ;

   for ( int row_index  =  0  ;
             row_index  <  window_height ;
             row_index  ++  )
   {
      for ( int column_index  =  0 ;
                column_index  <  window_width ;
                column_index  ++ )
      {
         cout  <<  window_contents[ column_index ] [ row_index ] ;
      }
      cout  <<  "\n" ;
   }
}

void  Window::move( int      destination_x_index,
                    int      destination_y_index,
                    Window&  another_window )
{
   int  source_y_index  =  0 ;

   while ( source_y_index  <  another_window.window_height )
   {
      if ( destination_y_index  >=  0   &&
           destination_y_index  <   window_height )
      {
         int  source_x_index  =  0 ;
         int  saved_destination_x_index  =  destination_x_index ;

         while ( source_x_index < another_window.window_width )
         {
            if ( destination_x_index  >=  0  &&
                 destination_x_index  <   window_width )
            {
               window_contents [ destination_x_index ]
                               [ destination_y_index ]  =

                  another_window.window_contents[ source_x_index ]
                                                    [ source_y_index ] ;
            }
            source_x_index        ++ ;
            destination_x_index   ++ ;
         }
         destination_x_index  =  saved_destination_x_index ;
      }
      source_y_index        ++ ;
      destination_y_index   ++ ;
   }
}

class  Frame_window  :  public  Window
{
public:
   Frame_window( int   desired_window_width    =  40,
                 int   desired_window_height   =  10  )

       :  Window( desired_window_width,
                  desired_window_height, '|' )
   {
      Window  horizontal_frames( desired_window_width - 2,
                                 desired_window_height,  '-' ) ;

      Window  spaces_inside_window( desired_window_width - 2,
                                    desired_window_height - 2, ' ' ) ;

      move( 1, 0, horizontal_frames ) ;
      move( 1, 1, spaces_inside_window ) ;
   }
} ;



class  Text_window  :  public  Frame_window
{
protected:
   char  text_inside_window[ MAXIMUM_WINDOW_WIDTH ] ;

   void  embed_text_in_window() ;

public:
   Text_window( int   desired_window_width,
                int   desired_window_height,
                char  given_line_of_text[] ) 

      :  Frame_window( desired_window_width,
                       desired_window_height )
   {
      strcpy( text_inside_window, given_line_of_text  ) ;
      embed_text_in_window() ;
   }

   void  change_text(  char  new_line_of_text[]  )
   {
      strcpy( text_inside_window, new_line_of_text ) ;
      embed_text_in_window() ;
   }

} ;

void  Text_window::embed_text_in_window()
{
   int  text_length  =  strlen( text_inside_window ) ;
   int  text_row     =  window_height / 2 ;

   int  text_start_column = (window_width - text_length) / 2 ;

   for ( int character_index  =  0 ;
             character_index  <  text_length ;
             character_index  ++ )
   {
      window_contents [ text_start_column + character_index ]
                      [ text_row ]  =  

              text_inside_window[ character_index ] ;
   }
}


class Decorated_text_window  :  public  Text_window
{
public:
   Decorated_text_window( int   desired_window_width,
                          int   desired_window_height,
                          char  given_line_of_text[] ) 

      :  Text_window( desired_window_width,
                      desired_window_height,
                      given_line_of_text )
   {
      Window   decoration_frame( desired_window_width,
                                 desired_window_height,
                                 '*' ) ;

      Text_window  window_inside_window( desired_window_width - 2,
                                         desired_window_height - 2,
                                         given_line_of_text ) ;

      decoration_frame.move( 1, 1, window_inside_window ) ;

      move( 0, 0, decoration_frame ) ;
   }
} ;


int main()
{
   Window          background_window( 76, 22, '/' ) ;
   Frame_window    empty_window( 24, 7 ) ;
   Text_window     greeting_window( 30, 8, "Hello, world." ) ;
   Decorated_text_window  smiling_window( 28, 11, "Smile!" ) ;

   background_window.move(  6,  2, empty_window ) ;
   background_window.move(  4, 12, greeting_window ) ;

   greeting_window.change_text( "HELLO, UNIVERSE!" ) ;
   background_window.move( 43, 11, greeting_window ) ;

   background_window.move( 40,  3, smiling_window ) ;

   background_window.print() ;
}



