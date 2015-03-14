
//  Windows.cs  (c) 2003 Kari Laitinen

//  24.05.2003  File created.
//  11.12.2003  Last modification.

//  NOTE: As this is an educational program, the classes defined
//  here are not safe for all kinds of uses. If you try to define
//  very large or very small windows, or put long texts inside
//  the windows, the classes may not work properly.

using System ;

class  Window
{
   protected const int MAXIMUM_WINDOW_WIDTH   =  78 ;
   protected const int MAXIMUM_WINDOW_HEIGHT  =  22 ;

   protected char[,]  window_contents ;

   protected int   window_width   =  MAXIMUM_WINDOW_WIDTH ;
   protected int   window_height  =  MAXIMUM_WINDOW_HEIGHT ;
   protected char  background_character  =  ' ' ;

   public  Window()
   {
      //  Data members are initialized with the above values
      //  before this default constructor is executed.

      window_contents  =  new  char [ window_width,
                                      window_height ] ;

      fill_with_character( background_character ) ;
   }

   public  Window( int  desired_window_width,
                   int  desired_window_height,
                   char given_background_character )
   {
      window_width          =  desired_window_width ;
      window_height         =  desired_window_height ;
      background_character  =  given_background_character ;

      window_contents  =  new  char [ window_width,
                                      window_height ] ;

      fill_with_character( background_character ) ;
   }

   public void fill_with_character( char filling_character )
   {
      for ( int row_index  =  0  ;
                row_index  <  window_height ;
                row_index  ++  )
      {
         for ( int column_index  =  0 ;
                   column_index  <  window_width ;
                   column_index  ++ )
         {
            window_contents[ column_index, row_index ]  =
                                               filling_character ;
         }
      }
   }

   public void print()
   {
      Console.Write( "\n" ) ;

      for ( int row_index  =  0  ;
                row_index  <  window_height ;
                row_index  ++  )
      {
         for ( int column_index  =  0 ;
                   column_index  <  window_width ;
                   column_index  ++ )
         {
            Console.Write( 
                    window_contents[ column_index, row_index ] ) ;
         }

         Console.Write( "\n" ) ;
      }
   }

   public void move( int     destination_x_index,
                     int     destination_y_index,
                     Window  another_window )
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
                  window_contents [ destination_x_index,
                                    destination_y_index ]  =

                     another_window.window_contents[ source_x_index,
                                                     source_y_index ] ;
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
}


class  FrameWindow  :  Window
{
   public FrameWindow()
   
      :  this( 40, 10 )  // Calling the other constructor below.
   {
   }

   public FrameWindow( int  desired_window_width,
                       int  desired_window_height )

      :  base( desired_window_width, desired_window_height, '|' )
   {
      Window horizontal_frames  =  new Window( window_width - 2,
                                               window_height,  '-' ) ;

      Window spaces_inside_window  =  new Window( window_width - 2,
                                                  window_height - 2, ' ');

      move( 1, 0, horizontal_frames ) ;
      move( 1, 1, spaces_inside_window ) ;
   }
} 

class  TextWindow  :  FrameWindow
{
   protected string text_inside_window ;

   protected void embed_text_in_window()
   {
      int  text_length  =  text_inside_window.Length ;
      int  text_row     =  window_height / 2 ;

      int  text_start_column = (window_width - text_length) / 2 ;

      for ( int character_index  =  0 ;
                character_index  <  text_length ;
                character_index  ++ )
      {
         window_contents [ text_start_column + character_index,
                           text_row ]  =  

                 text_inside_window[ character_index ] ;
      }
   }

   public TextWindow( int     desired_window_width,
                      int     desired_window_height,
                      string  given_line_of_text ) 

      :  base( desired_window_width, desired_window_height )
   {
      text_inside_window  =  given_line_of_text ;
      embed_text_in_window() ;
   }

   public void change_text( string  new_line_of_text )
   {
      text_inside_window  =  new_line_of_text ;
      embed_text_in_window() ;
   }
}


class DecoratedTextWindow  :  TextWindow
{
   public DecoratedTextWindow( int    desired_window_width,
                               int    desired_window_height,
                               string given_line_of_text ) 

      :  base( desired_window_width,
               desired_window_height,
               given_line_of_text )
   {
      Window decoration_frame  =  new  Window( desired_window_width,
                                               desired_window_height,
                                               '*' ) ;
      TextWindow  window_inside_window  = 
                      new  TextWindow( desired_window_width - 2,
                                       desired_window_height - 2,
                                       given_line_of_text ) ;

      decoration_frame.move( 1, 1, window_inside_window ) ;

      move( 0, 0, decoration_frame ) ;
   }
}


class Windows
{
   static void Main()
   {
      Window  background_window  =  new  Window( 76, 22, '/' ) ;

      FrameWindow  empty_window     =  new  FrameWindow( 24, 7 ) ;
      TextWindow   greeting_window  =
                       new  TextWindow( 30, 8, "Hello, world." ) ;
      DecoratedTextWindow  smiling_window  =
                       new  DecoratedTextWindow( 28, 11, "Smile!" ) ;

      background_window.move(  6,  2, empty_window ) ;
      background_window.move(  4, 12, greeting_window ) ;

      greeting_window.change_text( "HELLO, UNIVERSE!" ) ;
      background_window.move( 43, 11, greeting_window ) ;

      background_window.move( 40,  3, smiling_window ) ;

      background_window.print() ;
   }
}




