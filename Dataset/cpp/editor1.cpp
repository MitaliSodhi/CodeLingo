/*-------------------------------------------------------------------

    editor1.cpp  (c) 1996 - 2001 Kari Laitinen

    This program is the source code of a text editor called "zedit".

    The buyers of Kari Laitinen's book on C++ computer programming
    may freely use and further develop this editor program. They
    may not, however, sell this editor or use it in commercial
    purposes.

    Mr. Kari Laitinen has used this editor program to write
    and modify most of the source programs that belong to his
    book on C++ computer programming. However, Mr. Kari Laitinen
    does not assume any responsibility or liability regarding this
    editor program or its use. The users of this editor program may
    use this at their own risk.

---------------------------------------------------------------------

  PROGRAM MODIFICATION HISTORY

---------------------------------------------------------------------

    06.10.1996  ( file created )
    22.10.1996  ( editor1.cpp )
    22.09.1998  One month of serious development work completed.
                A kind of beta testing begins now.
    29.10.1998  A reasonably working version of the program.
    30.01.1999  keyboard_decoding_table was modified to work
                with correctly-behaving getch in Borland's
                C++ 5.3 (Part of C++ Builder 3)
    17.02.2000  Short file names not allowed while storing texts.
                Member cursor_movement_style is added into
                class Edition. This style is constant for the time
                being, and cursor moves beyond line ends in some cases
    02.02.2001  Tabulator-free, version-showing version 1.3
    07.02.2001  v1.3.1 Some improvements in screen updating.

    Version number must be written in ZEDIT_EDITOR_VERSION_TEXT

----------------------------------------------------------------------

  COMPILATION INSTRUCTIONS

----------------------------------------------------------------------

  - This progam can be compiled with the following compilers:

    --  bcc32.exe compiler in Borland C++ 5.2 (The resulting
        editor may work correctly only with U.S.-style keyboards.)

    --  bcc32.exe 5.3 compiler in Borland C++ Builder 3.
        The 5.3 - version has been working well about 2 years.

    --  bcc32.exe 5.5.1 of Borland's Free Command Line Tools
        Testing of 5.5.1 -version zedit begun on 2.1.2001


----------------------------------------------------------------------

  KNOWN PROBLEMS IN THE SOFTWARE

----------------------------------------------------------------------

  -  This editor is to be executed in an MS-DOS Window in Windows.
     This program does not check in any ways if somebody is trying
     to close the MS-DOS window by clicking its corner with the 
     mouse. If the MS-DOS window is closed while this editor
     is running in that particular window, it is possible that
     the text being edited is lost.

  -  There have been some problems with editing files written
     with other editors. It is possible that if the files contain
     very long text lines, this program stops reading the file
     when it encounters a too long line.

----------------------------------------------------------------------

  SOFTWARE DEVELOPMENT NOTES

----------------------------------------------------------------------

  - It is better to have this file named "editor1.cpp" instead
    of "zedit.cpp". I have worked so that "editor1.exe" is always
    renamed to "zedit.exe" after it has been found
    working well enough. This way it is possible to use an earlier
    version of zedit to develop a new version of the editor program.

  - This editor uses function getch, defined in conio.h, to read
    single characters from the keyboard. This function is
    appropriate for an editor program which just reads characters
    without expecting the Enter key to be pressed. There has been
    problems in reading the keyboard. The following is a summary
    of the problems:

    -- In bcc32 5.2, the function reads the keyboard approximately
       as it were an American keyboard. This problem occurs only
       with 32-bit compiler bcc32. The 16-bit compiler bcc would
       work correctly, but this program cannot be compiled with it.

    -- The bcc32 5.3 compiler that belongs to C++ Builder 3 seems 
       to have a rather decent getch function. There are only the
       keys containing tilde and carat signs and some accent marks
       that the function reads so that it produces some extra
       characters. It seems also that when the numerical keyboard
       is locked, the getch function produces a wrong code for
       the Delete key. These are, however, minor problems. 


  - C++ compiler generates operator= functions, the assignment
    functions, if the user does not specify these member funtions.
    The automatic operator= functions do not work with
    classes that use memory on the free store. Therefore,
    classes Text_line and Array_of_text_lines have
    specially-written assignment functions.
    When Edition objects are copied, these assignment functions
    are called since Text_line objects and Array_of_text_lines
    objects are members of Edition objects.

  - Class Text_line had to be equipped with a copy constructor
    before it started work properly.

  - Class Screen is used to maintain the text that is currently
    on the screen. The class contains several functions to update
    text on screen. Updating the screen is slightly problematic
    because the screen begins to blink if the entire screen
    is updated too often (e.g. after every keystroke). The several
    member functions in class Screen help in this problem. If the
    screen could be updated without any blinking problems, the
    easiest way would be to have one function (e.g. in class
    Array_of_text_lines) to update the screen after each
    text-modifying keystroke.

  - An object of class Edition corresponds to a file being edited.
    The name of the class is Edition (and not, for example, File)
    because Edition objects can exist before they are actually
    connected to any named files.

*/

/*-----------------------------------------------------------------

   I N C L U D E D   F I L E S

-----------------------------------------------------------------*/

#include  <iostream.h>
#include  <iomanip.h>
#include  <fstream.h>
#include  <conio.h>
#include  <string.h>
#include  <stdlib.h>

#include  "useful_functions.h"

/*-----------------------------------------------------------------

   C O N S T A N T S

-----------------------------------------------------------------*/

#define  ZEDIT_EDITOR_VERSION_TEXT            "Zedit editor 1.3.1"

#define  SCREEN_HEIGHT_IN_LINES                  25
#define  SCREEN_WIDTH_IN_COLUMNS                 80

#define  TEXT_LINE_INCREMENT                     10
#define  TEXT_SPACE_INCREMENT                  1000

#define  NUMBER_OF_EDITIONS_ALLOWED               4
#define  NUMBER_OF_TAGS_ALLOWED                   5
#define  NUMBER_OF_SPACES_IN_A_TAB                3

#define  FILE_NAME_SIZE                          40

#define  MINIMUM_FILE_NAME_LENGTH                 5
#define  MAXIMUM_TEXT_LINE_LENGTH               300

//  The following constants define cursor movement styles.
//  DIRECT_VERTICAL_CURSOR is able to go beyond the end
//  of a text line.

#define  DIRECT_VERTICAL_CURSOR                   1
#define  LEFTIST_VERTICAL_CURSOR                  2

//  The following are keyboard commands to the editor.
//  It is possible to change the commands to suit to your
//  own preferences, but bear in mind that you should not
//  use commands from Ctrl-G (0x07) to Ctrl-M (0x0D), because
//  those are used for backspace, tab, carriage return, etc.

#define  HELP_MENU_COMMAND                     0x05  // Ctrl-E

#define  DELETE_TO_END_OF_LINE_COMMAND         0x01  // Ctrl-A
#define  DELETE_LINE_COMMAND                   0x1A  // Ctrl-Z

#define  TEXT_BUFFERING_COMMAND                0x02  // Ctrl-B
#define  TEXT_DELETION_COMMAND                 0x04  // Ctrl-D
#define  PASTE_COMMAND                         0x10  // Ctrl-P

#define  OTHER_TEXT_BUFFERING_COMMAND          1013  // F6
#define  OTHER_TEXT_DELETION_COMMAND           1014  // F7
#define  OTHER_PASTE_COMMAND                   1015  // F8

#define  FILE_EXIT_MENU_COMMAND                0x18  // Ctrl-X

#define  FIND_COMMAND                          0x06  // Ctrl-F
#define  FIND_AND_REPLACE_COMMAND              0x12  // Ctrl-R
#define  FIND_AND_MAYBE_REPLACE_COMMAND        0x11  // Ctrl-Q
#define  FIND_REPLACE_NEXT_COMMAND             0x0E  // Ctrl-N

#define  FIND_NAME_COMMAND                     0x16  // Ctrl-V
#define  OTHER_FIND_NAME_COMMAND               1016  // F9

#define  OTHER_FIND_COMMAND                    1019  // F12
#define  OTHER_FIND_AND_REPLACE_COMMAND        1018  // F11
#define  OTHER_FIND_AND_MAYBE_REPLACE_COMMAND  1017  // F10
#define  REPLACE_FINDING_COMMAND               0x18B // Alt-F11
#define  MAYBE_REPLACE_FINDING_COMMAND         0x171 // Alt-F10

#define  SET_TAG_COMMAND                       0x14  // Ctrl-T
#define  WANDER_TO_LINE_COMMAND                0x17  // Ctrl-W

#define  FILE_OPEN_KEY                         1008  // F1
#define  FILE_SAVE_KEY                         1009  // F2
#define  FILE_SAVE_AS_KEY                      1010  // F3
#define  FILE_MOVE_KEY                         1011  // F4
#define  FILE_CLOSE_KEY                        1012  // F5

/*  Buffering of text means actually marking a text area to
    by cut or pasted. The following character shows the limits
    of the buffered area in the text. */

#define  BUFFER_MARKING_CHARACTER              '@'



class  Text_line
{
protected:

    char*   characters_on_free_store ;

    int     number_of_characters_on_this_line ;
    int     number_of_bytes_reserved_on_free_store ;

public:

    Text_line() ;
    Text_line( Text_line&  another_text_line ) ;
    ~Text_line() ;

    void  insert_character(  int   column_index,
                             char  new_text_character ) ;
    void  append_character(  char  character_to_the_end_of_line ) ;

    void  remove_character(  int   column_index ) ;
    bool  remove_character(  int   column_index,
                             char& removed_character ) ;
    void  remove_all_characters() ;

    bool  read_character(    int     column_index,
                             char&   character_in_given_position ) ;

    void  exchange_character( int    column_index,
                              char   new_character,
                              char&  old_character ) ;

    int   get_line_length() ;

    void  split_line( int         column_index,
                      Text_line&  first_part_of_line,
                      Text_line&  second_part_of_line ) ;

    void  append_line( Text_line  line_to_append ) ;

    bool  contains_string( int   column_index_where_to_start_search,
                           char  string_to_search[],
                           int&  index_of_found_string ) ;

    Text_line&  operator= ( Text_line&  text_line_on_right_side ) ;
    bool  operator!=      ( Text_line&  another_text_line  ) ;
    bool  operator==      ( Text_line&  another_text_line  ) ;

    void  print( ostream& output_stream_for_printing ) ;
    bool  scan(  istream& input_stream_for_scanning ) ;

} ;


Text_line::Text_line()
{
    characters_on_free_store  =  0 ;

    number_of_characters_on_this_line       =  0 ;
    number_of_bytes_reserved_on_free_store  =  0 ;
}

Text_line::Text_line( Text_line&  another_text_line )
{
   number_of_characters_on_this_line  =
           another_text_line.number_of_characters_on_this_line ;

   number_of_bytes_reserved_on_free_store  =
                        number_of_characters_on_this_line ;

   if ( number_of_characters_on_this_line  !=  0 )
   {
      characters_on_free_store  =
          new  char[ number_of_bytes_reserved_on_free_store ] ;

      move_bytes( number_of_characters_on_this_line,
                  another_text_line.characters_on_free_store,
                  characters_on_free_store ) ;
   }
   else
   {
      characters_on_free_store  =  0 ;
   }
}

Text_line::~Text_line()
{
    delete  []  characters_on_free_store ;
}

void
Text_line::insert_character( int   column_index,
                             char  new_character )
{
    //  The character will be appended to the end of line if
    //  the column index is larger than the line itself.

    if ( column_index  >  number_of_characters_on_this_line  )
    {
       column_index  =  number_of_characters_on_this_line ;
    }

    if ( number_of_bytes_reserved_on_free_store  <=
                        number_of_characters_on_this_line  )
    {
       char*  new_space_on_free_store  =

               new char[ number_of_bytes_reserved_on_free_store +
                         TEXT_LINE_INCREMENT  ] ;

       move_bytes(  number_of_characters_on_this_line,
                    characters_on_free_store,
                    new_space_on_free_store  ) ;

       delete  []  characters_on_free_store ;

       characters_on_free_store  =  new_space_on_free_store ;

       number_of_bytes_reserved_on_free_store  =
                    number_of_bytes_reserved_on_free_store  +
                    TEXT_LINE_INCREMENT  ;
    }

    move_bytes( number_of_characters_on_this_line - column_index,
                &characters_on_free_store[ column_index ],
                &characters_on_free_store[ column_index  + 1 ] ) ;

    characters_on_free_store[ column_index ]  =  new_character ;
    number_of_characters_on_this_line  ++  ;
}

void
Text_line::append_character( char character_to_the_end_of_line )
{
   insert_character( number_of_characters_on_this_line,
                     character_to_the_end_of_line ) ;
}


void
Text_line::remove_character( int    column_index )
{
   char  removed_character  ;

   remove_character( column_index, removed_character ) ;
}

bool
Text_line::remove_character( int    column_index,
                             char&  removed_character  )
{
   bool  character_removal_was_successful  =  true ;

   if ( number_of_characters_on_this_line  ==  0 )
   {
      character_removal_was_successful  =  false ;
   }
   else if ( column_index  <  number_of_characters_on_this_line )
   {
      removed_character  =  characters_on_free_store[ column_index ] ;

      move_bytes( number_of_characters_on_this_line - column_index - 1,
                  &characters_on_free_store[ column_index  +  1 ],
                  &characters_on_free_store[ column_index  ]  )  ;

      number_of_characters_on_this_line  --  ;
   }
   else
   {
      character_removal_was_successful  =  false ;
   }

   return  character_removal_was_successful ;
}

bool
Text_line::read_character( int   column_index,
                           char& character_in_given_position )
{
   bool  column_index_is_valid  ;

   if ( column_index  <  number_of_characters_on_this_line )
   {
      column_index_is_valid  =  true ;

      character_in_given_position  =
                  characters_on_free_store[ column_index ] ;
   }
   else
   {
      column_index_is_valid  =  false ;
   }

   return  column_index_is_valid ;
}

void
Text_line::exchange_character( int    column_index,
                               char   new_character,
                               char&  old_character )
{
   if ( column_index  <  number_of_characters_on_this_line )
   {
      old_character  =  characters_on_free_store[ column_index ] ;
      characters_on_free_store[ column_index ]  =  new_character ;
   }
   else
   {
      cout  <<  "\n\nIndexing error in exchange_character ..\n" ;
   }
}

int
Text_line::get_line_length()
{
   return  number_of_characters_on_this_line ;
}

void
Text_line::remove_all_characters()
{
   number_of_characters_on_this_line  =  0 ;
}

void
Text_line::split_line( int         splitting_index,
                       Text_line&  first_part_of_line,
                       Text_line&  second_part_of_line )
{
   int  character_index  =  0  ;

   first_part_of_line.remove_all_characters() ;
   second_part_of_line.remove_all_characters() ;

   while  ( character_index  <  number_of_characters_on_this_line &&
            character_index  <  splitting_index )
   {
      first_part_of_line.insert_character( character_index,
                             characters_on_free_store[ character_index ] ) ;

      character_index  ++ ;
   }
   
   while  ( character_index  <  number_of_characters_on_this_line )
   {
      second_part_of_line.insert_character(
                             character_index  -  splitting_index,
                             characters_on_free_store[ character_index ] ) ;
      character_index  ++ ;
   }
}

void
Text_line::append_line( Text_line line_to_append )
{
   //  Note that the argument is a copy of a text line.
   //  The while loop removes characters from the beginning
   //  of the line as long as there are characters to remove.

   char character_to_append ;

   while ( line_to_append.
                 remove_character( 0, character_to_append ) ) 
   {
      append_character( character_to_append ) ;
   }
}

bool
Text_line::contains_string( int   column_where_to_start_search,
                            char  string_to_search[],
                            int&  index_of_found_string )
{
   //  To use function strstr, we must first temporarily make this
   //  line a string by appending a NULL to the end.

   bool  string_was_found  =  false  ;

   append_character( '\0' ) ;


   char*  pointer_to_found_string  =

            strstr( &characters_on_free_store [ column_where_to_start_search ],
                     string_to_search ) ;

   if ( pointer_to_found_string  !=  0  )
   {
      string_was_found  =  true  ;

      index_of_found_string  =  pointer_to_found_string  -
                                         characters_on_free_store ;
   }

   remove_character( number_of_characters_on_this_line - 1 ) ;

   return  string_was_found ;
}



Text_line&
Text_line::operator= ( Text_line& text_line_to_be_copied )
{
   if (  this  !=  &text_line_to_be_copied  )
   {
      //  The addresses of the Text_line objects are different.
      //  The text line is not being copied over itself.

      number_of_characters_on_this_line  =
          text_line_to_be_copied.number_of_characters_on_this_line ;

      if ( number_of_characters_on_this_line
                     >  number_of_bytes_reserved_on_free_store )
      {

         delete  []  characters_on_free_store ;

         number_of_bytes_reserved_on_free_store  =
                              number_of_characters_on_this_line ;

         characters_on_free_store  =
             new  char[ number_of_bytes_reserved_on_free_store ] ;
      }

      move_bytes( number_of_characters_on_this_line,
                  text_line_to_be_copied.characters_on_free_store,
                  characters_on_free_store ) ;
   }

   return  *this ;
}

bool
Text_line::operator== ( Text_line&  another_text_line )
{
   bool  return_code ;

   if ( number_of_characters_on_this_line  ==
             another_text_line.number_of_characters_on_this_line )
   {
      int  character_index  =  0 ;
      return_code           =  true ;

      while ( return_code     ==  true  &&
              character_index  <  number_of_characters_on_this_line )
      {
         if ( characters_on_free_store[ character_index ] !=
                  another_text_line.characters_on_free_store[
                                               character_index ] )
         {
            return_code  =  false ;
         }

         character_index  ++  ;
      }
   }
   else
   {
      return_code  =  false ;
   }

   return  return_code ;
}

bool
Text_line::operator!=  ( Text_line&  another_text_line )
{
   return  ( ! operator==( another_text_line ) ) ;
}



void
Text_line::print( ostream&  output_stream )
{
   for (  int character_index  =  0 ;
              character_index  <  number_of_characters_on_this_line ;
              character_index  ++  )
   {
      output_stream  <<  characters_on_free_store[ character_index ] ;
   }

   output_stream  <<  '\n' ;
}

bool
Text_line::scan(  istream&  input_stream )
{
   bool  stream_reading_was_successful  =  false ;

   if ( input_stream )
   {
      char  line_from_input_stream[ MAXIMUM_TEXT_LINE_LENGTH ] ;

      if ( input_stream.getline( line_from_input_stream,
                                 sizeof(  line_from_input_stream ) ) )
      {
         int  number_of_characters_read  =  strlen( line_from_input_stream ) ;

         //  The following statement makes the line empty and
         //  keeps the memory space available.

         number_of_characters_on_this_line  =  0 ;


         int character_index  =  0 ;
         int insertion_index  =  0 ;

         while ( character_index  <  number_of_characters_read )
         {
            if ( line_from_input_stream[ character_index ]  ==  '\t' )
            {
               /*  Tabulator characters are replaced with a certain
                   number of spaces.  */

               for ( int space_counter  =  0 ;
                         space_counter  <  NUMBER_OF_SPACES_IN_A_TAB ;
                         space_counter  ++  )
               {
                  insert_character( insertion_index,  ' '  ) ;
                  insertion_index  ++  ;
               }
            }
            else
            {
               insert_character( insertion_index,
                                 line_from_input_stream[ character_index ]);
               insertion_index  ++  ;
            }

            character_index  ++  ;
         }

         stream_reading_was_successful  =  true ;
      }
   }

   return  stream_reading_was_successful ;
}



class  Position
{
public:

   int  x_coordinate  ;
   int  y_coordinate  ;

   Position( int  given_x_coordinate  =  0,
             int  given_y_coordinate  =  0 ) ;

   void  exchange( Position& another_position ) ;

   bool operator< ( Position& another_position ) ;
   bool operator> ( Position& another_position ) ;
   bool operator== ( Position& another_position ) ;
} ;
   

Position::Position( int  given_x_coordinate,
                    int  given_y_coordinate )
{
   x_coordinate  =  given_x_coordinate ;
   y_coordinate  =  given_y_coordinate ;
}

void
Position::exchange( Position& another_position ) 
{
   int  saved_x_coordinate  =  x_coordinate ;
   int  saved_y_coordinate  =  y_coordinate ;

   x_coordinate  =  another_position.x_coordinate ;
   y_coordinate  =  another_position.y_coordinate ;

   another_position.x_coordinate  =  saved_x_coordinate ;
   another_position.y_coordinate  =  saved_y_coordinate ;
}


bool  Position::operator< ( Position&  another_position )
{
   bool  this_position_is_smaller ;

   if ( y_coordinate  <  another_position.y_coordinate )
   {
      this_position_is_smaller  =  true ;
   }
   else if ( y_coordinate  ==  another_position.y_coordinate )
   {
      if ( x_coordinate  <  another_position.x_coordinate )
      {
         this_position_is_smaller  =  true  ;
      }
      else
      {
         this_position_is_smaller  =  false  ;
      }
   }
   else
   {
      this_position_is_smaller  =  false ;
   }

   return  this_position_is_smaller ;
}

bool  Position::operator> ( Position&  another_position )
{
   bool  this_position_is_greater ;

   if ( y_coordinate  >  another_position.y_coordinate )
   {
      this_position_is_greater  =  true ;
   }
   else if ( y_coordinate  ==  another_position.y_coordinate )
   {
      if ( x_coordinate  >  another_position.x_coordinate )
      {
         this_position_is_greater  =  true  ;
      }
      else
      {
         this_position_is_greater  =  false  ;
      }
   }
   else
   {
      this_position_is_greater  =  false ;
   }

   return  this_position_is_greater ;
}

bool  Position::operator== ( Position&  another_position )
{
   return  ( x_coordinate  ==  another_position.x_coordinate  &&
             y_coordinate  ==  another_position.y_coordinate  ) ;
}


class  Array_of_text_lines
{
protected:

   Text_line*  text_lines_on_free_store ;

   int  number_of_lines_in_this_text ;
   int  size_of_reserved_text_space ;

public:

   Array_of_text_lines() ;
   Array_of_text_lines( int requested_text_space_size ) ;
   Array_of_text_lines( Array_of_text_lines&
                        another_array_of_text_lines ) ;

   ~Array_of_text_lines() ;

   Array_of_text_lines&  operator= ( Array_of_text_lines&
                                     text_lines_to_copy ) ;

   int  get_number_of_lines() ;

   void  enlarge_text_space( int requested_space_enlargement ) ;

   void  insert_line( int         line_index,
                      Text_line&  new_text_line ) ;
   void  update_line( int         line_index,
                      Text_line&  new_line_of_text ) ;
   void  read_line(   int         line_index,
                      Text_line&  line_to_caller ) ;

   void  remove_line( int         line_index ) ;

   bool  remove_line( int         line_index,
                      Text_line&  removed_line ) ;

   void  insert_character( int   column_index,
                           int   line_index,
                           char  new_character ) ;

   void  exchange_character( int    column_index,
                             int    line_index,
                             char   new_character,
                             char&  old_character ) ; 

   bool  read_character(   int   column_index,
                           int   line_index,
                           char& character_from_text  ) ;

   void  convert_line_to_string( int   line_index,
                                 int   maximum_string_size,
                                 char  line_as_string[] ) ;

   int   get_line_length( int  line_index ) ;

   void  store_text_to_file(  char  file_name[],
                              char  message_to_caller[] ) ;
   bool  load_text_from_file( char  file_name[],
                              char  message_to_caller[] ) ;

   void  copy_text_lines(
                  Array_of_text_lines&  text_lines_to_copy,
                  int                   index_of_first_line_to_copy,
                  int                   index_of_last_line_to_copy ) ;
} ;


Array_of_text_lines::Array_of_text_lines()
{
   text_lines_on_free_store     =  0 ;

   number_of_lines_in_this_text  =  0 ;
   size_of_reserved_text_space   =  0 ;
}

Array_of_text_lines::Array_of_text_lines(
                                  int requested_text_space_size )
{
   text_lines_on_free_store  =  new Text_line[
                                      requested_text_space_size ] ;

   number_of_lines_in_this_text  =  0  ;
   size_of_reserved_text_space   =  requested_text_space_size ;
}

Array_of_text_lines::Array_of_text_lines(
                  Array_of_text_lines&  another_array_of_text_lines )
{

   cout << "\n\n .........SOFTWARE ERROR  ................\n"
        << "\n\n ..Array_of_text_lines has no copy constructor\n" ;

}


Array_of_text_lines::~Array_of_text_lines()
{
   delete  []  text_lines_on_free_store ;
}

Array_of_text_lines&
Array_of_text_lines::operator= ( Array_of_text_lines&
                                      text_lines_to_copy )
{
   if (  this  !=  &text_lines_to_copy  )
   {
      delete []  text_lines_on_free_store ;

      number_of_lines_in_this_text  =
                  text_lines_to_copy.number_of_lines_in_this_text ;
      size_of_reserved_text_space   =
                  text_lines_to_copy.size_of_reserved_text_space ;

      text_lines_on_free_store  =
                  new  Text_line[ size_of_reserved_text_space ] ;

      move_objects( number_of_lines_in_this_text,
                    text_lines_to_copy.text_lines_on_free_store,
                    text_lines_on_free_store ) ;
   }

   return  *this  ;
}


int Array_of_text_lines::get_number_of_lines()
{
   return  number_of_lines_in_this_text ;
}


void Array_of_text_lines::enlarge_text_space(
                                  int requested_new_space_size )
{
   Text_line*  larger_space_on_free_store  =

                new  Text_line[ number_of_lines_in_this_text  +
                                requested_new_space_size  ] ;

   //  It would be a catastrophe if larger_space_on_free_store
   //  were zero here. That would mean that we were not able to
   //  allocate more space.

   move_objects( number_of_lines_in_this_text,
                 text_lines_on_free_store,
                 larger_space_on_free_store  ) ;

   delete  []  text_lines_on_free_store  ;

   text_lines_on_free_store  =  larger_space_on_free_store ;
   size_of_reserved_text_space  =  number_of_lines_in_this_text +
                                   requested_new_space_size ;
}

void
Array_of_text_lines::insert_line( int         index_of_new_line,
                                  Text_line&  new_text_line )
{
   if ( size_of_reserved_text_space <= number_of_lines_in_this_text )
   {
      //  The following statements results in that the default
      //  constructor of Text_line will be called for every
      //  allocated Text_line object in the array.

      Text_line*  larger_space_on_free_store  =

                new  Text_line[ number_of_lines_in_this_text  +
                                TEXT_SPACE_INCREMENT  ] ;

      //  It would be a catastrophe if larger_space_on_free_store
      //  were zero here. That would mean that we were not able to
      //  allocate more space.

      move_objects( number_of_lines_in_this_text,
                    text_lines_on_free_store,
                    larger_space_on_free_store  ) ;

      delete  []  text_lines_on_free_store  ;

      text_lines_on_free_store  =  larger_space_on_free_store ;
      size_of_reserved_text_space  =  number_of_lines_in_this_text +
                                      TEXT_SPACE_INCREMENT ;
   }

   move_objects( number_of_lines_in_this_text - index_of_new_line ,
               &text_lines_on_free_store[ index_of_new_line ],
               &text_lines_on_free_store[ index_of_new_line + 1 ] ) ;

   //  The following operation is possible since operator = is
   //  overloaded for Text_line objects.

   text_lines_on_free_store[ index_of_new_line ]  =  new_text_line ;

   number_of_lines_in_this_text  ++  ;
}


void
Array_of_text_lines::update_line( int         line_index,
                                  Text_line&  modified_text_line )
{
   if (  line_index  <  number_of_lines_in_this_text  )
   {
      text_lines_on_free_store[ line_index ] = modified_text_line ;
   }
   else
   {
      cout  << "\n\nINDEXING ERROR in update_line ... \n\n" ;
   }
}

void
Array_of_text_lines::read_line( int         line_index,
                                Text_line&  line_to_caller )
{
   if (  line_index  <  number_of_lines_in_this_text  )
   {
      line_to_caller  =  text_lines_on_free_store[ line_index ] ;
   }
   else
   {
      cout  << "\n\nINDEXING ERROR in read_line ... \n\n" ;
   }
}


bool Array_of_text_lines::remove_line( int         line_index,
                                       Text_line&  removed_line )
{
   bool  line_removal_was_successful  =  true ;

   if (  line_index  <  number_of_lines_in_this_text  )
   {
      removed_line  =  text_lines_on_free_store[ line_index ] ;

      move_objects( number_of_lines_in_this_text - line_index - 1,
                    &text_lines_on_free_store[ line_index  +  1 ],
                    &text_lines_on_free_store[ line_index ] ) ;

      number_of_lines_in_this_text  --  ;
   }
   else
   {
      line_removal_was_successful  =  false ;
   }

   return  line_removal_was_successful ;
}

void Array_of_text_lines::remove_line( int  line_index )
{
   if (  line_index  <  number_of_lines_in_this_text  )
   {
      move_objects( number_of_lines_in_this_text - line_index - 1,
                    &text_lines_on_free_store[ line_index  +  1 ],
                    &text_lines_on_free_store[ line_index ] ) ;

      number_of_lines_in_this_text  --  ;
   }
}

void
Array_of_text_lines::insert_character( int   column_index,
                                       int   line_index,
                                       char  new_character )
{
   if ( line_index  <  number_of_lines_in_this_text )
   {
      text_lines_on_free_store[ line_index ].
                              insert_character( column_index,
                                                new_character ) ;
   }
   else
   {
      cout  <<  "\n\nIndexing error in insert_character..\n" ;
   }
}


void
Array_of_text_lines::exchange_character( int    column_index,
                                         int    line_index,
                                         char   new_character,
                                         char&  old_character )
{
   if ( line_index  <  number_of_lines_in_this_text )
   {
      text_lines_on_free_store[ line_index ].
                            exchange_character( column_index,
                                                new_character,
                                                old_character ) ;
   }
   else
   {
      cout  <<  "\n\nIndexing error, exchange_character..\n" ;
   }
}


int
Array_of_text_lines::get_line_length( int  line_index )
{
   int  line_length ;

   if ( line_index  <  number_of_lines_in_this_text )
   {
      line_length  =
           text_lines_on_free_store[ line_index ].get_line_length() ;
   }
   else
   {
      line_length  =  0 ;
      cout  <<  "\n\nIndexing error, get_line_length..\n" ;
   }

   return  line_length ;
}

bool Array_of_text_lines::read_character( int   column_index,
                                          int   line_index,
                                          char& character_from_text  )
{
   bool  indexes_are_valid   =  false  ;

   if ( line_index  <  number_of_lines_in_this_text )
   {
      if ( text_lines_on_free_store[ line_index ]
                     .read_character( column_index,
                                      character_from_text ) )
      {
         //  Member function  Text_line::read_character returns
         //  true if the index is valid.

         indexes_are_valid  =  true  ;
      }
   }
   
   return  indexes_are_valid  ;
}

void
Array_of_text_lines::convert_line_to_string( int   line_index,
                                             int   maximum_string_size,
                                             char  line_as_string[] )
{
   int  string_index  =  0  ;

   while ( string_index  <  maximum_string_size - 1   &&
           string_index  <  text_lines_on_free_store[ line_index ].
                                                       get_line_length() )
   {
      text_lines_on_free_store[ line_index ].read_character(

                                   string_index,
                                   line_as_string[ string_index ] ) ;

      string_index  ++  ;
   }

   line_as_string[ string_index ]  =  0 ;  //  NULL terminates strings.
}


void
Array_of_text_lines::store_text_to_file( char  file_name[],
                                         char  message_to_caller[] )
{
   ofstream  file_stream( file_name ) ;

   if ( ! file_stream )
   {
      strcpy( message_to_caller, "***File opening error**** " ) ;
      strcat( message_to_caller,  file_name ) ;
   }
   else
   {
      for ( int line_index  =  0 ;
                line_index  <  number_of_lines_in_this_text ;
                line_index  ++ )
      {
         text_lines_on_free_store[ line_index ].print(
                                                 file_stream ) ;
      }

      if ( ! file_stream  )
      {
         strcpy( message_to_caller, "File writing error.  " ) ;
         strcat( message_to_caller, file_name ) ;
      }
      else
      {
         strcpy( message_to_caller, "Text has been stored to file \"" ) ;
         strcat( message_to_caller, file_name ) ;
         strcat( message_to_caller, "\"." ) ;
      }
   }
}

bool
Array_of_text_lines::load_text_from_file( char  file_name[],
                                          char  message_to_caller[] )
{
   // This function returns true if file loading is successful.

   bool file_loading_is_successful  =  true  ;

   ifstream  file_to_load( file_name ) ;

   if ( ! file_to_load )
   {
      strcpy( message_to_caller,  "File does not exist." ) ;
      file_loading_is_successful  =  false ;
   }
   else
   {
      Text_line  line_from_file ;

      //  We do not have to release the text space in free store.
      //  insert_line enlarges it if necessary.
      //  We can "delete" the old text simply by zeroing
      //  variable number_of_lines_in_this_text. This variable
      //  will be automatically incremented by insert_line.

      number_of_lines_in_this_text  =  0 ;

      while ( line_from_file.scan( file_to_load ) )
      {
         insert_line( number_of_lines_in_this_text,
                      line_from_file  ) ;
      }
   }

   return  file_loading_is_successful ;
}


void
Array_of_text_lines::copy_text_lines(
                     Array_of_text_lines&  text_lines_to_copy,
                     int                   index_of_first_line_to_copy,
                     int                   index_of_last_line_to_copy )
{
   //  This function does not make the reserved text space smaller.
   //  It just makes the text space empty in the beginning.

   number_of_lines_in_this_text  =  0 ;
   int  line_index  =  0  ;

   while ( line_index + index_of_first_line_to_copy
                           <=  index_of_last_line_to_copy  )
   {
      insert_line( line_index,
                   text_lines_to_copy.text_lines_on_free_store[
                       line_index + index_of_first_line_to_copy ] ) ;
      line_index  ++  ;
   }
}



class  Screen
{
protected:

   char  text_on_screen [ SCREEN_HEIGHT_IN_LINES - 2 ]
                        [ SCREEN_WIDTH_IN_COLUMNS + 1 ] ;

   char  previous_text_on_screen [ SCREEN_HEIGHT_IN_LINES - 2 ]
                                 [ SCREEN_WIDTH_IN_COLUMNS + 1 ] ;

   int   number_of_screen_lines ;
   int   number_of_previous_screen_lines ;

   void  copy_new_text_lines( Array_of_text_lines&  lines_to_copy,
                          int             number_of_lines_in_entire_text,
                          int             screen_top_y_coordinate ) ;
public:
   Screen()
   {
      number_of_screen_lines  =  0 ;
      number_of_previous_screen_lines  =  0 ;
   }

   void  update_all_screen_lines(
                          Array_of_text_lines&  all_text_lines,
                          int         number_of_lines_in_entire_text,
                          int         screen_top_y_coordinate ) ;

   void  update_modified_screen_lines(
                          Array_of_text_lines&  all_text_lines,
                          int         number_of_lines_in_entire_text,
                          int         screen_top_y_coordinate ) ;

   void  update_line_end( char       character_to_line_end,
                          Position&  cursor_position,
                          int        screen_top_y_coordinate ) ;
} ;


void
Screen::copy_new_text_lines( Array_of_text_lines& lines_to_copy,
                             int               number_of_lines_in_entire_text,
                             int               screen_top_y_coordinate )
{
   int  screen_line_index  =  0  ;

   while ( screen_line_index  <  number_of_screen_lines )
   {
      strcpy( previous_text_on_screen[ screen_line_index ],
              text_on_screen[ screen_line_index ] ) ;
      screen_line_index  ++ ;
   }

   number_of_previous_screen_lines  =  number_of_screen_lines ;

   int  number_of_lines_to_copy  =  SCREEN_HEIGHT_IN_LINES  -  2 ;

   if ( screen_top_y_coordinate  +  SCREEN_HEIGHT_IN_LINES  -  2
                     >=  number_of_lines_in_entire_text )
   {
      number_of_lines_to_copy  =  number_of_lines_in_entire_text -
                                     screen_top_y_coordinate ;
   }

   screen_line_index  =  0  ;

   while ( screen_line_index  <  number_of_lines_to_copy )
   {
      lines_to_copy.convert_line_to_string(

                        screen_top_y_coordinate  +  screen_line_index,
                        SCREEN_WIDTH_IN_COLUMNS + 1,
                        text_on_screen[ screen_line_index ] ) ;

      screen_line_index  ++  ;
   }

   number_of_screen_lines  =  screen_line_index ;
}


void
Screen::update_all_screen_lines( Array_of_text_lines&  all_text_lines,
                                 int         number_of_lines_in_entire_text,
                                 int         screen_top_y_coordinate )
{
   copy_new_text_lines( all_text_lines,
                        number_of_lines_in_entire_text,
                        screen_top_y_coordinate ) ;

   int  screen_line_index  =  0  ;

   while ( screen_line_index  <  number_of_screen_lines )
   {
      gotoxy( 1, screen_line_index  +  1 ) ;

      //  Text is printed as strings.

      cout  <<  text_on_screen[ screen_line_index ] ;
      clreol() ;

      screen_line_index  ++  ;
   }

   while ( screen_line_index  <  SCREEN_HEIGHT_IN_LINES  -  2 )
   {
      gotoxy( 1, screen_line_index  +  1  ) ;
      clreol() ;
      screen_line_index  ++  ;
   }
}


void
Screen::update_modified_screen_lines( Array_of_text_lines&  all_text_lines,
                                 int         number_of_lines_in_entire_text,
                                 int         screen_top_y_coordinate )
{
   copy_new_text_lines( all_text_lines,
                        number_of_lines_in_entire_text,
                        screen_top_y_coordinate ) ;

   int  screen_line_index  =  0  ;

   while ( screen_line_index  <  number_of_screen_lines  &&
           screen_line_index  <  number_of_previous_screen_lines )
   {
      if ( strcmp( text_on_screen[ screen_line_index ],
                   previous_text_on_screen[ screen_line_index ] ) !=  0 )
      {
         //  This line has been modified. Let's update the line.

         gotoxy( 1, screen_line_index  +  1 ) ;

         cout  <<  text_on_screen[ screen_line_index ] ;
         clreol() ;
      }

      screen_line_index  ++  ;
   }

   //  The following loop updates those screen lines which
   //  were not part of the previous screen.

   while ( screen_line_index  <  number_of_screen_lines  )
   {
      gotoxy( 1, screen_line_index  +  1 ) ;

      cout  <<  text_on_screen[ screen_line_index ] ;
      clreol() ;

      screen_line_index  ++  ;
   }

   while ( screen_line_index  <  SCREEN_HEIGHT_IN_LINES  -  2 )
   {
      gotoxy( 1, screen_line_index  +  1  ) ;
      clreol() ;
      screen_line_index  ++  ;
   }
}


void
Screen::update_line_end( char       character_to_line_end,
                         Position&  cursor_position,
                         int        screen_top_y_coordinate )
{
   // Here we suppose that screen_top_y_coordinate has been
   // set by the calling program, and that the cursor is in the
   // position where the new character should be written.
   // cursor_position, however, must contain the coordinates
   // where the cursor should be after character insertion.

   // Note that we do not update the screen at all if the cursor
   // is somewhere beyond the screen area. This happens with
   // very long text lines.

   if ( cursor_position.x_coordinate  <  SCREEN_WIDTH_IN_COLUMNS + 1 )
   {
      int  screen_line_index  =  cursor_position.y_coordinate  -
                                             screen_top_y_coordinate ;

      strcpy( previous_text_on_screen[ screen_line_index ],
              text_on_screen[ screen_line_index ] ) ;

      text_on_screen[ screen_line_index ]
                    [ cursor_position.x_coordinate - 1 ]
                                           =  character_to_line_end ;
      text_on_screen[ screen_line_index ]
                    [ cursor_position.x_coordinate ]  =  0 ;

      cout  <<  character_to_line_end ;
   }
}




class  Edition
{
protected:

    Array_of_text_lines   text_lines_being_edited ;
    Text_line             line_being_edited ;

    Screen                screen_of_this_edition ;

    char  file_being_edited[ FILE_NAME_SIZE ] ;

    char  string_being_searched[ 80 ] ;
    char  replacement_string[ 80 ] ;

    int   cursor_movement_style ;

    char  previous_find_replace_command  ;

    int   screen_top_y_coordinate ;

    Position  cursor_position ;

    Position  buffer_start_position  ;
    Position  buffer_end_position ;

    char  saved_buffer_start_character ;
    char  saved_buffer_end_character ;

    Position  tags_in_this_edition[ NUMBER_OF_TAGS_ALLOWED ] ;
    int       number_of_tags_in_use  ;

    bool  file_name_not_yet_given ;
    bool  text_has_been_modified ;
    bool  text_is_being_buffered ;

    void  display_help_information() ;

    void  write_text_on_bottom_line( char text_to_write[] ) ;
    void  read_on_bottom_line( int   cursor_x_coordinate,
                               char  text_to_caller[] ) ;

    void  handle_cursor_movements( short cursor_key_code ) ;

    void  update_bottom_line_information() ;
    void  update_modified_text_on_screen() ;
    void  update_all_text_on_screen() ;
    void  update_line_end_on_screen( char  character_to_line_end ) ;

    bool  search_string_in_text() ;
    void  replace_string_in_text() ;
    void  search_and_replace_string_in_text() ;
    void  search_and_maybe_replace_string_in_text() ;
    void  parse_current_line_for_name() ;

    void  generate_backup_file() ;

public:
    Edition*   previous_edition ;
    Edition*   next_edition ;

    Edition() ;
    Edition(  char  file_to_be_edited[] ) ;
///    ~Edition() ;

    void  handle_character( short character_from_keyboard,
                            Array_of_text_lines&  text_to_paste ) ;
    void  activate_edition() ;

    void  save_text_to_file() ;
    void  save_text_to_new_file() ;
    bool  close_this_edition() ;

    void  inform_user( char  text_to_bottom_line[] ) ;
    void  ask_text_on_bottom_line(  char  text_to_screen[],
                                    char  text_to_caller[],
                                    int   maximum_text_length ) ;
} ;

void
Edition::display_help_information()
{
   /*  The help pages below are large string constants.
       Two string constants are considered a single string constant
       when they are separated with spaces or newlines. Thus, in C++
       "aaa" "bbb""cccc"  means the same as "aaabbbcccc".  */

   char*  array_of_help_pages[]  =
   {

   "\n  "
   "\n  W A R N I N G : "
   "\n  "
   "\n    This editor is not an error-free software product."
   "\n  You may use this editor at your own risk. Mr. Kari Laitinen"
   "\n  will not take any responsibility or liability concerning"
   "\n  the use of this editor."
   "\n  "
   "\n    This editor runs in an MS-DOS window. The editor does not"
   "\n  check whether the MS-DOS window is closed with the mouse."
   "\n  You may loose your text if the MS-DOS window is closed"
   "\n  while the editor program is running."
   "\n  "
   "\n  "
   "\n  ",

   "\n  TO EXIT THE EDITOR PROGRAM:"
   "\n  "
   "\n     - Press F5 or Ctrl-X and C (Close) until all files are closed."
   "\n     - Ctrl-X displays you the file menu where you can select a file"
   "\n       operation. Keys F1, F2, F3, F4, and F5 are shortcuts to the"
   "\n       file operations."
   "\n     - If you have typed in text, the program asks you to store it."
   "\n     - If several files are being edited simultaneously, the program"
   "\n       moves to another file when one file is closed."
   "\n  "
   "\n  SUMMARY OF FILE OPERATIONS:"
   "\n  "
   "\n     - F1 takes a new file into use (File Open operation)."
   "\n     - F2 saves the file currently being edited (File Save operation)."
   "\n     - F3 saves the current file with a new name (File save As )."
   "\n     - F4 moves to the next file among the files being edited."
   "\n     - F5 closes the current file and moves to the next file. If no"
   "\n       files are open, the program terminates."
   "\n  ",

   "\n  "
   "\n  TO FIND A STRING IN TEXT:"
   "\n  "
   "\n     - Press Ctrl-F or F12."
   "\n     - The program asks you the string to search."
   "\n     - You can repeat the search activity by typing Ctrl-N (\"Next\")"
   "\n     - The program can search only from the cursor position towards"
   "\n       the end of the text."
   "\n     - If you posision cursor over some name or word in a program"
   "\n       and press Ctrl-V or F9, the program searces that name or word."
   "\n  "
   "\n  TO FIND AND REAPLACE A STRING:"
   "\n  "
   "\n     - Press Ctrl-R or F11 to search and replace a string."
   "\n     - If you press Ctrl-Q or F10, the program asks whether the found"
   "\n       string should be replaced."
   "\n     - Ctrl-N (\"Next\") repeats last search and replace activity."
   "\n     - Alt-F10 and Alt-F11 perform find-and-replace operations"
   "\n       with the string used in previous find operation."
   "\n  ",

   "\n  "
   "\n  TO MAKE COPY, CUT, AND PASTE OPERATIONS:"
   "\n  "
   "\n     - To copy text lines, you must first copy them into a buffer."
   "\n     - You can mark the buffer start and buffer end with Ctrl-B or F6."
   "\n     - The program starts buffering text from the current cursor"
   "\n       position, when you press Ctrl-B or F6. After you have moved the"
   "\n       cursor, and press Ctrl-B or F6 again in a different cursor"
   "\n       position, the text lines between the two cursor positions are"
   "\n       copied into a buffer."
   "\n     - If you terminate the copying process by pressing Ctrl-D or F7,"
   "\n       you can make a Cut operation, i.e., you can delete lines and"
   "\n       copy them into a buffer."
   "\n     - When text lines have been copied into a buffer, you can paste"
   "\n       the copied text lines into the current cursor position by "
   "\n       pressing Ctrl-P or F8."
   "\n     - The editor program holds a single text buffer which can be used"
   "\n       to move text between the files being edited.",

   "\n  "
   "\n  SUMMARY OF KEYS F6, F7, F8, F9, F10, F11, AND F12"
   "\n  "
   "\n     - F6 is used to start and terminate text buffering operations."
   "\n     - F7 works in the same way as F6 but it deletes the text lines"
   "\n       that are copied into the buffer."
   "\n     - F8 copies the text buffer into current cursor position."
   "\n     - F9 searches a name or word found in the cursor position."
   "\n     - F10 performs a conditional Find-and-Replace operation."
   "\n     - F11 performs an unconditional Find-and-Replace operation."
   "\n     - F12 performs a Find operation."
   "\n  "
   "\n     - Alt-F10 performs a conditional Find-and-Replace operation"
   "\n       by using the string found in the previous Find operation"
   "\n     - Alt-F11 performs an unconditional Find-and-Replace operation"
   "\n       by using the string found in the previous Find operation",

   "\n  "
   "\n  SOME SPECIAL KEYS:"
   "\n  "
   "\n     - Ctrl-A deletes text between cursor position and line end."
   "\n     - Ctrl-Z deletes the line where the cursor is."
   "\n     - Ctrl-N (\"Next\") finds (and replaces) next string."
   "\n     - Ctrl-E Help. Displays these pages."
   "\n     - Ctrl-W lets you jump (wander!) to a certain line in the text."
   "\n     - Ctrl-T lets you set a tag (bookmark) in current cursor"
   "\n              position. (More information below)."
   "\n     - Ctrl-X opens you the file menu.",

   "\n  "
   "\n  SETTING TAGS (BOOKMARKS) IN THE TEXT:"
   "\n  "
   "\n     - By pressing Ctrl-T you can set a tag (bookmark) in the"
   "\n       text being currently edited."
   "\n     - Tags are useful when you edit a large file, and want"
   "\n       to go somewhere else in the file and later return back"
   "\n       to the original position in the file."
   "\n     - The tags affect the behavior of the Home and End keys."
   "\n     - Normally, when no tags have been defined, the Home key"
   "\n       brings the cursor to the beginning of the first line in"
   "\n       the text, and the End key brings the cursor to the end"
   "\n       of the last line."
   "\n     - But when tags are defined somewhere between the first"
   "\n       and last lines, the Home and End keys make stops in"
   "\n       the tags."
   "\n     - Because the editor program remembers the tags as cursor"
   "\n       coordinates, the tags become slightly inaccurate when the"
   "\n       text is modified."
   "\n  ",

   "\n  YOU CAN INVOKE this editor from the command line in three"
   "\n  different ways:"
   "\n"
   "\n    1)   zedit"
   "\n"
   "\n    2)   zedit  filename1.ext"
   "\n"
   "\n    3)   zedit  filename1.ext  filename2.ext"
   "\n"
   "\n  In the first case, the editor does not open a file, but it"
   "\n  lets you to type in text on the screen. It asks a file name"
   "\n  when you try save or close the edition. In the two other"
   "\n  cases, the editor tries to open the files that are given on"
   "\n  command line."
   "\n  "
   "\n  ",

   "\n  TABULATOR CHARACTERS "
   "\n  "
   "\n    This editor does not support the use of tabulator"
   "\n  characters. Instead, the editor inserts 3 spaces into"
   "\n  text if the tabulator key is used, or it finds"
   "\n  a tabulator character from a file."
   "\n  "
   "\n    When tabulators are not used, it is possible to print"
   "\n  a source program with many different printing programs, and"
   "\n  the program text always looks the same. Tabulators can"
   "\n  be harmful because different printing programs interpret"
   "\n  tabulator characters in different ways."

   "\n  "

   } ;


   int  page_counter  =  0  ;

   int  number_of_pages_to_display  =  sizeof( array_of_help_pages ) /
                                       sizeof( char* ) ;

   while ( page_counter  <  number_of_pages_to_display )
   {
      cout  <<  array_of_help_pages[ page_counter ] ;
      page_counter  ++  ;

      char  useless_string[ 5 ] ;

      cout  <<  "\nPress <Enter> to continue ......"  ;
      cin.getline( useless_string, sizeof( useless_string ) ) ;
   }
}


void
Edition::write_text_on_bottom_line( char  text_to_write[] )
{
   gotoxy( 1, SCREEN_HEIGHT_IN_LINES ) ;
   clreol() ;
   cout  <<  text_to_write ;

   gotoxy( cursor_position.x_coordinate + 1, 
           cursor_position.y_coordinate + 1 - screen_top_y_coordinate ) ;
}

void
Edition::read_on_bottom_line( int   cursor_x_coordinate,
                             char  text_to_caller[] )
{
   gotoxy( cursor_x_coordinate, SCREEN_HEIGHT_IN_LINES ) ;
   cin.getline( text_to_caller, 40 ) ;

   gotoxy( cursor_position.x_coordinate + 1, 
           cursor_position.y_coordinate + 1 ) ;
}



void
Edition::handle_cursor_movements( short cursor_key_code )
{
   if ( cursor_key_code  ==  1004 ) //  arrow up
   {
      if ( cursor_position.y_coordinate  >  0  )
      {
         cursor_position.y_coordinate  -- ;

         text_lines_being_edited.read_line(  cursor_position.y_coordinate,
                                             line_being_edited ) ;

         if ( cursor_movement_style  !=  DIRECT_VERTICAL_CURSOR )
         {
            int length_of_upper_line =  line_being_edited.
                                               get_line_length() ;

            if ( length_of_upper_line  <  cursor_position.x_coordinate )
            {
               cursor_position.x_coordinate  =  length_of_upper_line ;
            }
         }
      }
   }
   else if ( cursor_key_code  ==  1006 )  //  arrow left
   {
      if ( line_being_edited.get_line_length()  <
                                        cursor_position.x_coordinate )
      {
         //  If the cursor is somewhere to the right of the line end
         //  we'll just position it to the line end.

         cursor_position.x_coordinate  =  
                             line_being_edited.get_line_length() ;
      }
      else
      {
         if ( cursor_position.x_coordinate  >  0  )
         {
            cursor_position.x_coordinate  -- ;
         }
         else if ( cursor_position.y_coordinate  >  0 )
         {
            cursor_position.y_coordinate  -- ;

            text_lines_being_edited.read_line( cursor_position.y_coordinate,
                                               line_being_edited ) ;

            cursor_position.x_coordinate  = 
                                line_being_edited.get_line_length() ;
         }
      }
   }
   else if ( cursor_key_code  ==  1007 )  //  arrow_right
   {
      if ( cursor_position.x_coordinate  <
                             line_being_edited.get_line_length() )
      {
         cursor_position.x_coordinate  ++  ;
      }
      else if ( cursor_position.y_coordinate <
                   ( text_lines_being_edited.get_number_of_lines() - 1 ) )
      {
         cursor_position.y_coordinate  ++   ;
         cursor_position.x_coordinate  =  0 ;      
         text_lines_being_edited.read_line( cursor_position.y_coordinate,
                                            line_being_edited ) ;
      }
   }
   else if ( cursor_key_code  ==  1005 )  //  arrow down
   {
      if ( cursor_position.y_coordinate <
                   ( text_lines_being_edited.get_number_of_lines() - 1 ) )
      {
         cursor_position.y_coordinate  ++ ;

         text_lines_being_edited.read_line( cursor_position.y_coordinate,
                                            line_being_edited ) ;

         if ( cursor_movement_style  !=  DIRECT_VERTICAL_CURSOR )
         {
            int length_of_lower_line =  line_being_edited.
                                               get_line_length() ;

            if ( length_of_lower_line  <  cursor_position.x_coordinate )
            {
               cursor_position.x_coordinate  =  length_of_lower_line ;
            }
         }
      }
   }
   else if ( cursor_key_code  ==  1002 )  // Page up
   {
      //  In this case, screen_top_y_coordinate has a value
      //  that tells how many lines there are above the screen.

      if ( screen_top_y_coordinate  >  SCREEN_HEIGHT_IN_LINES - 4 )
      {
         screen_top_y_coordinate  =  screen_top_y_coordinate  -
                                      ( SCREEN_HEIGHT_IN_LINES  -  4 ) ;

         cursor_position.y_coordinate    =  cursor_position.y_coordinate  -
                                      ( SCREEN_HEIGHT_IN_LINES  -  4 ) ;
      }
      else if ( screen_top_y_coordinate  >  0 )
      {
         screen_top_y_coordinate  =  0 ;
         cursor_position.y_coordinate    =  0 ;
      }

      text_lines_being_edited.read_line( cursor_position.y_coordinate,
                                         line_being_edited ) ;

      if ( cursor_movement_style  !=  DIRECT_VERTICAL_CURSOR )
      {
         int length_of_new_line =  line_being_edited.get_line_length() ;

         if ( length_of_new_line  <  cursor_position.x_coordinate )
         {
            cursor_position.x_coordinate  =  length_of_new_line ;
         }
      }
   }
   else if ( cursor_key_code  ==  1003 )  // Page down
   {
      int  number_of_lines_below_screen  =

              text_lines_being_edited.get_number_of_lines()  -
              screen_top_y_coordinate  -
              ( SCREEN_HEIGHT_IN_LINES  -  2 ) ;

      if ( number_of_lines_below_screen  >  SCREEN_HEIGHT_IN_LINES - 4 )
      {
         screen_top_y_coordinate  =  screen_top_y_coordinate  +
                                      SCREEN_HEIGHT_IN_LINES  -  4  ;

         cursor_position.y_coordinate    =  cursor_position.y_coordinate  +
                                      SCREEN_HEIGHT_IN_LINES  -  4  ;
      }
      else if ( number_of_lines_below_screen  >  0  )
      {
         screen_top_y_coordinate  =

              text_lines_being_edited.get_number_of_lines()  -
              ( SCREEN_HEIGHT_IN_LINES  -  4 ) ;

         cursor_position.y_coordinate    =  screen_top_y_coordinate  +
                                     (( SCREEN_HEIGHT_IN_LINES - 4 ) / 2 ) ;
      }

      text_lines_being_edited.read_line( cursor_position.y_coordinate,
                                         line_being_edited ) ;

      if ( cursor_movement_style  !=  DIRECT_VERTICAL_CURSOR )
      {
         int length_of_new_line =  line_being_edited.get_line_length() ;

         if ( length_of_new_line  <  cursor_position.x_coordinate )
         {
            cursor_position.x_coordinate  =  length_of_new_line ;
         }
      }
   }
   else if ( cursor_key_code  ==  1000 )  // Home
   {
      //  Tags become inaccurate when lines are added or deleted.
      //  If too many lines are deleted, it is possible that the
      //  last tag is somewhere outside the text. In that case,
      //  tags are not taken into account in Home and End operations.

      if ( number_of_tags_in_use  >  0  &&
           tags_in_this_edition[ 0 ]  <  cursor_position  &&
           tags_in_this_edition[ number_of_tags_in_use - 1 ].y_coordinate
                <  text_lines_being_edited.get_number_of_lines()  )
      {
         // At least the first tag is somewhere above the current
         // cursor position. We must go to a tag.

         int  tag_index  =  number_of_tags_in_use - 1 ;
         int  tag_has_been_found  =  false  ;

         while ( tag_has_been_found  ==  false  &&
                 tag_index  >=  0 )
         {
            if ( tags_in_this_edition[ tag_index ]  <  cursor_position )
            {
               tag_has_been_found  =  true ;
               cursor_position     =  tags_in_this_edition[ tag_index ] ;

               if ( cursor_position.y_coordinate  >
                                      SCREEN_HEIGHT_IN_LINES - 2 )
               {
                  screen_top_y_coordinate  =  cursor_position.y_coordinate  -
                                              ( SCREEN_HEIGHT_IN_LINES - 8 ) ;
               }
               else
               {
                  screen_top_y_coordinate  =  0  ;
               }
            }
            else
            {
               tag_index  --  ;
            }
         }
      }
      else
      {
         // We'll go to the beginning of the text.
         cursor_position.x_coordinate    =  0 ;
         cursor_position.y_coordinate    =  0 ;
         screen_top_y_coordinate  =  0 ;
      }

      text_lines_being_edited.read_line( cursor_position.y_coordinate,
                                         line_being_edited ) ;
   }
   else if ( cursor_key_code  ==  1001  &&  // End
             text_lines_being_edited.get_number_of_lines()  >
                                         SCREEN_HEIGHT_IN_LINES  -  2 )
   {
      if ( number_of_tags_in_use  >  0  &&
           tags_in_this_edition[ number_of_tags_in_use - 1 ]  >
                                                 cursor_position  &&
           tags_in_this_edition[ number_of_tags_in_use - 1 ].y_coordinate
                <  text_lines_being_edited.get_number_of_lines()  )
      {
         // At least the last tag is somewhere below the current
         // cursor position. We must go to a tag.

         int  tag_index  =  0 ;
         int  tag_has_been_found  =  false  ;

         while ( tag_has_been_found  ==  false  &&
                 tag_index  <  number_of_tags_in_use )
         {
            if ( tags_in_this_edition[ tag_index ] > cursor_position )
            {
               tag_has_been_found  =  true ;
               cursor_position     =  tags_in_this_edition[ tag_index ] ;

               text_lines_being_edited.read_line( cursor_position.y_coordinate,
                                                  line_being_edited ) ;
            }
            else
            {
               tag_index  ++  ;
            }
         }
      }
      else
      {
         // We just go to the end of this edition.

         cursor_position.y_coordinate    =
                     text_lines_being_edited.get_number_of_lines() - 1 ;

         text_lines_being_edited.read_line( cursor_position.y_coordinate,
                                            line_being_edited ) ;

         cursor_position.x_coordinate  =  line_being_edited.get_line_length() ;
      }

      if ( cursor_position.y_coordinate  >  SCREEN_HEIGHT_IN_LINES - 2 )
      {
         screen_top_y_coordinate  =  cursor_position.y_coordinate  -
                                     ( SCREEN_HEIGHT_IN_LINES - 4 ) ;
      }
      else
      {
         screen_top_y_coordinate  =  0  ;
      }
   }


   if ( cursor_position.y_coordinate  <  screen_top_y_coordinate )
   {
      screen_top_y_coordinate  -- ;
   }
   else if ( cursor_position.y_coordinate  >=
            ( screen_top_y_coordinate + SCREEN_HEIGHT_IN_LINES - 2 ) )
   {
      screen_top_y_coordinate  ++ ;
   }

}


void
Edition::update_bottom_line_information()
{
   gotoxy( 1, SCREEN_HEIGHT_IN_LINES  -  1 ) ;
   clreol() ;
   gotoxy( 1, SCREEN_HEIGHT_IN_LINES  ) ;
   clreol() ;

   int  file_name_length  =  strlen( file_being_edited ) ;

   if ( file_name_length  >  0 )
   {
      gotoxy( SCREEN_WIDTH_IN_COLUMNS - 14 - file_name_length,
              SCREEN_HEIGHT_IN_LINES ) ;

      cout  <<  setw( file_name_length + 2 )  <<  file_being_edited 
            <<  setw( 8 )   <<  cursor_position.y_coordinate + 1
            <<  setw( 4 )   <<  cursor_position.x_coordinate  + 1  ;
   }
   else
   {
      //  length of <no file name> is 14

      gotoxy( SCREEN_WIDTH_IN_COLUMNS - 28,
              SCREEN_HEIGHT_IN_LINES ) ;

      cout  <<  setw( 16 )  <<  "<no file name>"
            <<  setw( 8 )   <<  cursor_position.y_coordinate + 1
            <<  setw( 4 )   <<  cursor_position.x_coordinate  + 1  ;
   }
}

void 
Edition::update_modified_text_on_screen()
{
   screen_of_this_edition.update_modified_screen_lines(

                        text_lines_being_edited,
                        text_lines_being_edited.get_number_of_lines(),
                        screen_top_y_coordinate ) ;

   update_bottom_line_information() ;

   gotoxy( cursor_position.x_coordinate + 1,
           cursor_position.y_coordinate + 1
            - screen_top_y_coordinate ) ;


   if ( text_is_being_buffered )
   {
      if ( saved_buffer_end_character  !=  0 )
      {
         //  This is not the first time that cursor moves after
         //  buffering has started.

         //  We must remove the previous buffer end marking
         //  from the screen if it still is visible on the
         //  screen.

         if ( buffer_end_position.y_coordinate  >=
                         screen_top_y_coordinate  &&
              buffer_end_position.y_coordinate  <
                         screen_top_y_coordinate +
                         SCREEN_HEIGHT_IN_LINES -  2  )
         {
            // It should be visible on the screen.

            gotoxy( buffer_end_position.x_coordinate  +  1,
                    buffer_end_position.y_coordinate  +  1
                        -  screen_top_y_coordinate ) ;

            // Now the cursor should be where the previous
            // buffer end marking is on the screen.

            int length_of_previous_buffer_end_line  =
                    text_lines_being_edited.get_line_length(
                                       buffer_end_position.y_coordinate  ) ;

            if ( buffer_end_position.x_coordinate  <
                           length_of_previous_buffer_end_line )
            {
               cout  <<  saved_buffer_end_character  ;
            }
            else
            {
               //  It was in the end of a line. Let's overspace it.

               cout  <<  ' ' ;
            }

            //  Now we must move the cursor to its right current
            //  place on the screen.

            gotoxy( cursor_position.x_coordinate + 1,
                    cursor_position.y_coordinate + 1
                       - screen_top_y_coordinate ) ;
         }
      }


      //  We must write the BUFFER_MARKING_CHARACTER where
      //  the cursor is.

      cout  <<  BUFFER_MARKING_CHARACTER  ;

      buffer_end_position   =   cursor_position ;

      if ( !  text_lines_being_edited.read_character(
                                      buffer_end_position.x_coordinate,
                                      buffer_end_position.y_coordinate,
                                      saved_buffer_end_character ) )
      {
         //  read_character  returns false when some index
         //  is not OK. In this case we suppose that the cursor
         //  is in the end of a line.

         saved_buffer_end_character  =  '\n'  ;
      }


      //  One more time we must move the cursor to its right current
      //  place on the screen.

      gotoxy( cursor_position.x_coordinate + 1,
              cursor_position.y_coordinate + 1
                 - screen_top_y_coordinate ) ;
   }
}

void 
Edition::update_all_text_on_screen()
{
   screen_of_this_edition.update_all_screen_lines(

                        text_lines_being_edited,
                        text_lines_being_edited.get_number_of_lines(),
                        screen_top_y_coordinate ) ;


   update_bottom_line_information() ;

   gotoxy( cursor_position.x_coordinate + 1,
           cursor_position.y_coordinate + 1
            - screen_top_y_coordinate ) ;
}


void
Edition::update_line_end_on_screen( char  character_to_line_end )
{
   gotoxy( SCREEN_WIDTH_IN_COLUMNS - 4,  SCREEN_HEIGHT_IN_LINES ) ;

   cout  <<  setw( 4 )  <<  cursor_position.x_coordinate + 1 ;

   gotoxy( cursor_position.x_coordinate,
           cursor_position.y_coordinate + 1
            - screen_top_y_coordinate ) ;

   screen_of_this_edition.update_line_end( character_to_line_end,
                                           cursor_position,
                                           screen_top_y_coordinate ) ;
}


bool Edition::search_string_in_text()
{
   bool  string_has_been_found  =  false  ;

   if ( strlen( string_being_searched )  >  0 )
   {
      int  index_of_found_string  ;

      Position  saved_cursor_position  =  cursor_position ;

      while ( string_has_been_found  ==  false   &&
              cursor_position.y_coordinate  <
                     text_lines_being_edited.get_number_of_lines() )
      {
         text_lines_being_edited.read_line( cursor_position.y_coordinate,
                                            line_being_edited  ) ;

         /*  In the beginning of the search cursor can be somewhere
             over the end of line.  */

         if ( line_being_edited.get_line_length()  <
                                   cursor_position.x_coordinate )
         {
            cursor_position.x_coordinate  =
                               line_being_edited.get_line_length() ;
         }

         if ( line_being_edited.contains_string( cursor_position.x_coordinate,
                                                 string_being_searched,
                                                 index_of_found_string  ) )
         {
            string_has_been_found        =  true  ;
            cursor_position.x_coordinate  =  
                  index_of_found_string  +  strlen( string_being_searched ) ;

            if ( cursor_position.y_coordinate  >=
                          screen_top_y_coordinate  + 
                                           SCREEN_HEIGHT_IN_LINES  -  2  )
            {
               //  The found string is below the text shown on the screen.

               screen_top_y_coordinate  =  cursor_position.y_coordinate - 4 ;
            }

            update_modified_text_on_screen() ;
         }
         else
         {
            cursor_position.y_coordinate  ++   ;
            cursor_position.x_coordinate  =  0 ;
         }
      }

      if ( string_has_been_found  ==  false  )
      {
         cursor_position  =  saved_cursor_position ;

         text_lines_being_edited.read_line( cursor_position.y_coordinate,
                                            line_being_edited ) ;

         char  bottom_line_text[ 80 ] ;

         strcpy(  bottom_line_text, "String \"" ) ;
         strncat( bottom_line_text, string_being_searched, 50 ) ;
         strcat(  bottom_line_text, "\" was not found." ) ;


         write_text_on_bottom_line( bottom_line_text ) ;
      }
   }

   return  string_has_been_found  ;
}

void
Edition::replace_string_in_text()
{
   //  Cursor is supposed to be in the end of the string to replace

   int  number_of_characters_to_remove  =
                           strlen( string_being_searched ) ;

   while ( number_of_characters_to_remove  >  0 )
   {
      cursor_position.x_coordinate  --  ;

      line_being_edited.remove_character( cursor_position.x_coordinate ) ;

      number_of_characters_to_remove  --  ;
   }

   unsigned int  character_index  =  0 ;

   while ( character_index  <  strlen( replacement_string ) )
   {
      line_being_edited.insert_character(
                           cursor_position.x_coordinate,
                           replacement_string[ character_index ] ) ;

      cursor_position.x_coordinate  ++  ;
      character_index   ++  ;
   }

   text_lines_being_edited.update_line( cursor_position.y_coordinate,
                                        line_being_edited  ) ;

   text_has_been_modified   =  true ;

   update_modified_text_on_screen() ;
}

void
Edition::search_and_replace_string_in_text()
{
   if ( search_string_in_text()  )
   {
      // The string was found. Cursor is in the end of string.

      replace_string_in_text() ;
   }
}


void
Edition::search_and_maybe_replace_string_in_text()
{
   if ( search_string_in_text()  )
   {
      // The string was found. Cursor is in the end of string.

      char  yes_no_answer  ;

      write_text_on_bottom_line( "Replace this? (Y/N) " ) ;

      yes_no_answer  =  getch() ;

      if ( yes_no_answer  ==  'Y' ||   yes_no_answer  ==  'y'  )
      {
         replace_string_in_text() ;
      }
      else
      {
         update_modified_text_on_screen() ;
      }
   }
}

void
Edition::parse_current_line_for_name()
{
   char  current_line_as_string[ 100 ] ;

   text_lines_being_edited.convert_line_to_string(

                                cursor_position.y_coordinate,
                                sizeof( current_line_as_string ),
                                current_line_as_string  ) ;

   int  line_index  =  cursor_position.x_coordinate ;

   //  The cursor should be on some character of the name.
   //  We will first back line_index so that it points
   //  to the first character of the name. The names in C++,
   //  as well as in C, Java, and other languages, begin with
   //  a letter or an underscore character. Other characters may
   //  be letters, numbers, or underscores.

   while ( line_index  >  0  &&
           ( character_is_letter_or_digit( 
                           current_line_as_string[ line_index ] ) ||
           current_line_as_string[ line_index ]  ==  '_' ) )
   {
      line_index  --  ;
   }

   if ( ! character_is_letter_or_digit(
                           current_line_as_string[ line_index ] ) ||
           current_line_as_string[ line_index ]  !=  '_' )
   {
      line_index  ++  ;
   }

   //  Now we will copy the name to string_being_searched.

   int  string_index  =  0 ;

   while ( ( character_is_letter_or_digit(
                           current_line_as_string[ line_index ] ) ||
             current_line_as_string[ line_index ]  ==  '_'   )     &&
             string_index  <  sizeof( string_being_searched ) )
   {
      string_being_searched[ string_index ]  =
                               current_line_as_string[ line_index ] ;

      line_index    ++  ;
      string_index  ++  ;
   }

   string_being_searched[ string_index ]  =  0  ;  // terminate string

}


void
Edition::generate_backup_file()
{
   char  backup_file_name[ FILE_NAME_SIZE  +  4  ] ;

   strcpy( backup_file_name,  file_being_edited ) ;

   if ( string_terminates_string( ".cpp", file_being_edited ) ||
        string_terminates_string( ".CPP", file_being_edited ) ||
        string_terminates_string( ".TXT", file_being_edited ) ||
        string_terminates_string( ".txt", file_being_edited ) )
   {
      strcpy( backup_file_name  +  strlen( file_being_edited ) - 4,
              ".bak" ) ;
   }
   else if ( string_terminates_string( ".c", file_being_edited )  ||
             string_terminates_string( ".C", file_being_edited )  )
   {
      strcpy( backup_file_name  +  strlen( file_being_edited ) - 2,
              ".bak" ) ;
   }
   else if ( string_terminates_string( ".java", file_being_edited ) )
   {
      strcpy( backup_file_name  +  strlen( file_being_edited ) - 5,
              ".bak" ) ;
   }
   else
   {
      strcat( backup_file_name, ".bak" ) ;
   }

   ifstream  file_to_be_copied( file_being_edited ) ;


   if ( file_to_be_copied )
   {
      // File opening was successful. That means that the file
      // is not a new file, and needs to be backupped.

      ofstream  backup_file( backup_file_name ) ;

      char   text_line_from_file[ MAXIMUM_TEXT_LINE_LENGTH ] ;

      while ( file_to_be_copied )
      {
         file_to_be_copied.getline( text_line_from_file,
                                    sizeof( text_line_from_file ) ) ;

         backup_file  <<  text_line_from_file  <<  '\n' ;
      }

      if ( ! backup_file )
      {
         char  useless_text[ 10 ] ;

         ask_text_on_bottom_line(

                      "Error in creating backup file!!! Hit <Enter>", 
                      useless_text, sizeof( useless_text ) ) ;
      }
   }
}


Edition::Edition()
{
   strcpy( file_being_edited,  "" ) ;

   screen_top_y_coordinate      =  0 ;

   number_of_tags_in_use        =  0 ;

   cursor_movement_style        =  DIRECT_VERTICAL_CURSOR ;

   text_lines_being_edited.insert_line( cursor_position.y_coordinate,
                                        line_being_edited  ) ;

   file_name_not_yet_given  =  true ;
   text_has_been_modified   =  false ;
   text_is_being_buffered   =  false ;

   previous_find_replace_command  =  0 ;

   clrscr() ;

   update_all_text_on_screen() ;

   gotoxy( 1, SCREEN_HEIGHT_IN_LINES ) ;
   cout  <<  ZEDIT_EDITOR_VERSION_TEXT
         <<  "  Press Ctrl-E for Help." ;
   gotoxy( 1, 1 ) ;
}

Edition::Edition(  char  file_to_be_edited[]  )
{
   char  file_action_message[ 80 ] ;
   strcpy( file_action_message, "" ) ;

   screen_top_y_coordinate      =  0 ;

   number_of_tags_in_use        =  0 ;

   cursor_movement_style        =  DIRECT_VERTICAL_CURSOR ;

   text_lines_being_edited.insert_line( cursor_position.y_coordinate,
                                        line_being_edited  ) ;

   strcpy( file_being_edited, file_to_be_edited ) ;

   file_name_not_yet_given  =  false ;
   text_has_been_modified   =  false ;
   text_is_being_buffered   =  false ;

   previous_find_replace_command  =  0 ;

   clrscr() ;

   if ( text_lines_being_edited.
                         load_text_from_file( file_to_be_edited,
                                              file_action_message ) )
   {
      // File loading was successful.

      text_lines_being_edited.read_line( cursor_position.y_coordinate,
                                         line_being_edited  ) ;
   }
   else
   {
      write_text_on_bottom_line( file_action_message ) ;
   }

   update_all_text_on_screen() ;

   gotoxy( 1, SCREEN_HEIGHT_IN_LINES ) ;
   cout  <<  ZEDIT_EDITOR_VERSION_TEXT
         <<  "  Press Ctrl-E for Help." ;
   gotoxy( 1, 1 ) ;
}

/******
Edition::~Edition()
{
   ;
}

*******/

void
Edition::handle_character( short  character_from_keyboard,
                           Array_of_text_lines& text_to_paste )
{
   if ( character_from_keyboard  ==  0x7F  &&  //  delete
        text_is_being_buffered   ==  false )
   {
      if ( cursor_position.x_coordinate <
                    ( line_being_edited.get_line_length() ) )
      {
         // We will just delete one character on line_being_edited.

         line_being_edited.remove_character( cursor_position.x_coordinate ) ;
      }
      else if ( cursor_position.y_coordinate <
                ( text_lines_being_edited.get_number_of_lines() - 1 ) )
      {
         // If cursor is somewhere beyond the end of line, it will
         // be forced to return to the end of line.

         cursor_position.x_coordinate  =
                  line_being_edited.get_line_length() ;

         // The cursor is in the end of line, and there are lines
         // following this line in the text.

         Text_line  deleted_line ;

         text_lines_being_edited.remove_line( cursor_position.y_coordinate + 1,
                                              deleted_line ) ;

         line_being_edited.append_line( deleted_line ) ;
      }

      text_lines_being_edited.update_line( cursor_position.y_coordinate,
                                           line_being_edited  ) ;
      update_modified_text_on_screen() ;

      text_has_been_modified   =  true  ;
   }
   else if ( character_from_keyboard  >=  ' '  &&
             character_from_keyboard  <=  0xFF  ) 
   {

      //  Character is a visible character. DEL (0x7F) which is among
      //  the visible characters was processed earlier.

      //  The following if-statement is needed when
      //    cursor_movement_style  ==  DIRECT_VERTICAL_CURSOR 

      if ( line_being_edited.get_line_length()  <
                                   cursor_position.x_coordinate  )
      {
         cursor_position.x_coordinate  =
                       line_being_edited.get_line_length() ;
      }

      text_lines_being_edited.insert_character( cursor_position.x_coordinate,
                                                cursor_position.y_coordinate,
                                                character_from_keyboard ) ;

      line_being_edited.insert_character( cursor_position.x_coordinate,
                                          character_from_keyboard ) ;

      cursor_position.x_coordinate  ++  ;

      if ( cursor_position.x_coordinate  ==  
                               line_being_edited.get_line_length() )
      {
         //  Characters are being inserted to the end of line.
         //  Screen can be updated in simple manner.

         update_line_end_on_screen( character_from_keyboard ) ;
      }
      else
      {
         update_modified_text_on_screen() ;
      }

      text_has_been_modified  =  true ;
   }
   else if ( character_from_keyboard  >=  1000  &&
             character_from_keyboard  <=  1007  )
   {
      // Cursor is being moved. Cursor movements do not modify 
      // the text being edited.

      handle_cursor_movements( character_from_keyboard ) ;
      update_modified_text_on_screen() ;
   }
   else if ( character_from_keyboard  ==  TEXT_BUFFERING_COMMAND  ||
             character_from_keyboard  ==  TEXT_DELETION_COMMAND   ||
             character_from_keyboard  ==  OTHER_TEXT_BUFFERING_COMMAND ||
             character_from_keyboard  ==  OTHER_TEXT_DELETION_COMMAND )
   {
      if ( text_is_being_buffered )
      {
         //  This is the second buffering or deletion command
         //  which will terminate the text buffering or deletion
         //  operation.

         text_is_being_buffered  =  false ;

         //  In the case of DIRECT_VERTICAL_CURSOR the cursor might
         //  be beyond line end.

         if ( line_being_edited.get_line_length()  <
                                   cursor_position.x_coordinate  )
         {
            cursor_position.x_coordinate  =
                       line_being_edited.get_line_length() ;
         }


         //  First we will remove all buffering markings in the
         //  text and on the screen.

         char  buffer_marking_character ;

         text_lines_being_edited.exchange_character(
                                        buffer_start_position.x_coordinate,
                                        buffer_start_position.y_coordinate,
                                        saved_buffer_start_character,
                                        buffer_marking_character ) ;

         if ( saved_buffer_end_character  !=  0  )
         {
            if ( buffer_end_position.x_coordinate  <
                           line_being_edited.get_line_length() )
            {
               cout  <<  saved_buffer_end_character  ;
            }
            else
            {
               //  It was in the end of a line. Let's overspace it.

               cout  <<  ' ' ;
            }

            //  Now we must move the cursor to its right current
            //  place on the screen.

            gotoxy( cursor_position.x_coordinate + 1,
                    cursor_position.y_coordinate + 1
                       - screen_top_y_coordinate ) ;
         }

         //  Coordinates which define the buffer within the
         //  entire text must be adjusted because it is possible
         //  that the user defined the buffer end first.

         if ( buffer_end_position.y_coordinate  ==
                                buffer_start_position.y_coordinate )
         {
            if ( buffer_end_position.x_coordinate  <
                                   buffer_start_position.x_coordinate )
            {
               int  saved_x_coordinate    = 
                                buffer_start_position.x_coordinate ;
               buffer_start_position.x_coordinate  =
                                buffer_end_position.x_coordinate ;
               buffer_end_position.x_coordinate    =  saved_x_coordinate ;
            }
         }
         else if ( buffer_end_position.y_coordinate  < 
                                   buffer_start_position.y_coordinate )
         {
            buffer_start_position.exchange( buffer_end_position ) ;
         }

         text_to_paste.copy_text_lines( text_lines_being_edited,
                                        buffer_start_position.y_coordinate,
                                        buffer_end_position.y_coordinate - 1 );

         if ( character_from_keyboard  ==  TEXT_DELETION_COMMAND  ||
              character_from_keyboard  ==  OTHER_TEXT_DELETION_COMMAND )
         {
            int  number_of_lines_to_delete  =
                               buffer_end_position.y_coordinate  -
                               buffer_start_position.y_coordinate ;

            cursor_position  =  buffer_start_position  ;

            while ( number_of_lines_to_delete  >  0 )
            {
               text_lines_being_edited.remove_line(
                                          cursor_position.y_coordinate ) ;
               number_of_lines_to_delete  --  ;
            }

            text_lines_being_edited.read_line( cursor_position.y_coordinate,
                                               line_being_edited  ) ;

            if ( cursor_position.y_coordinate  <  screen_top_y_coordinate  ||
                 cursor_position.y_coordinate  >
                     screen_top_y_coordinate  +  SCREEN_HEIGHT_IN_LINES  - 2 )
            {
               //  cursor_is_not_on_screen

               if ( cursor_position.y_coordinate  >  4  )
               {
                  screen_top_y_coordinate  =
                                    cursor_position.y_coordinate - 4 ;
               }
               else
               {
                  screen_top_y_coordinate  =  0 ;
               }
            }

            text_has_been_modified  =  true ;
         }

         update_modified_text_on_screen() ;
      }
      else
      {
         //  We will start buffering text now.

         if ( cursor_position.x_coordinate  >=
                       line_being_edited.get_line_length() )
         {
            inform_user( "Buffering cannot start in line end." ) ;
         }
         else
         {
            text_is_being_buffered  =  true ;

            buffer_start_position   =  cursor_position ;

            text_lines_being_edited.exchange_character(
                                           cursor_position.x_coordinate,
                                           cursor_position.y_coordinate,
                                           BUFFER_MARKING_CHARACTER,
                                           saved_buffer_start_character ) ;

            saved_buffer_end_character  =  0 ;
            update_modified_text_on_screen() ;
         }
      }

   }
   else if ( character_from_keyboard  ==  PASTE_COMMAND  ||
             character_from_keyboard  ==  OTHER_PASTE_COMMAND )
   {
      for ( int pasting_index  =  0  ;
                pasting_index  <  text_to_paste.get_number_of_lines() ;
                pasting_index  ++  )
      {
         Text_line  line_to_paste ;

         text_to_paste.read_line( pasting_index,
                                  line_to_paste ) ;

         text_lines_being_edited.insert_line( cursor_position.y_coordinate +
                                                          pasting_index,
                                              line_to_paste  ) ;
      }

      text_lines_being_edited.read_line( cursor_position.y_coordinate,
                                         line_being_edited ) ;

      update_modified_text_on_screen() ;
      text_has_been_modified  =  true ;
   }
   else if ( character_from_keyboard  ==  FIND_COMMAND  ||
             character_from_keyboard  ==  OTHER_FIND_COMMAND )
   {
      //  string_being_searched is a member of this class

      ask_text_on_bottom_line( "Give string to search: ",
                               string_being_searched,
                               sizeof( string_being_searched ) ) ;

      search_string_in_text() ;

      previous_find_replace_command  =  FIND_COMMAND  ;
   }
   else if ( character_from_keyboard  ==  FIND_AND_REPLACE_COMMAND ||
             character_from_keyboard  ==  OTHER_FIND_AND_REPLACE_COMMAND )
   {
      ask_text_on_bottom_line( "Give string to replace:  ",
                               string_being_searched,
                               sizeof( string_being_searched ) ) ;

      ask_text_on_bottom_line( "Give replacement string: ",
                               replacement_string,
                               sizeof( replacement_string ) ) ;

      search_and_replace_string_in_text() ;

      previous_find_replace_command  =  FIND_AND_REPLACE_COMMAND  ;
   }
   else if ( character_from_keyboard  ==  FIND_AND_MAYBE_REPLACE_COMMAND ||
             character_from_keyboard  ==
                                    OTHER_FIND_AND_MAYBE_REPLACE_COMMAND )
   {
      ask_text_on_bottom_line( "Give string to replace:  ",
                               string_being_searched,
                               sizeof( string_being_searched ) ) ;

      ask_text_on_bottom_line( "Give replacement string: ",
                               replacement_string,
                               sizeof( replacement_string ) ) ;

      search_and_maybe_replace_string_in_text() ;

      previous_find_replace_command  =  FIND_AND_MAYBE_REPLACE_COMMAND  ;
   }
   else if ( character_from_keyboard  ==  REPLACE_FINDING_COMMAND )
   {
      char text_to_bottom_line[ 80 ] ;

      strcpy( text_to_bottom_line, "Give string to replace \"" ) ;
      strcat( text_to_bottom_line, string_being_searched ) ;
      strcat( text_to_bottom_line, "\" : " ) ;

      ask_text_on_bottom_line( text_to_bottom_line,
                               replacement_string,
                               sizeof( replacement_string ) ) ;

      search_and_replace_string_in_text() ;

      previous_find_replace_command  =  FIND_AND_REPLACE_COMMAND  ;
   }
   else if ( character_from_keyboard  ==  MAYBE_REPLACE_FINDING_COMMAND )
   {
      char text_to_bottom_line[ 80 ] ;

      strcpy( text_to_bottom_line, "Give string to replace \"" ) ;
      strcat( text_to_bottom_line, string_being_searched ) ;
      strcat( text_to_bottom_line, "\" : " ) ;

      ask_text_on_bottom_line( text_to_bottom_line,
                               replacement_string,
                               sizeof( replacement_string ) ) ;

      search_and_maybe_replace_string_in_text() ;

      previous_find_replace_command  =  FIND_AND_MAYBE_REPLACE_COMMAND  ;
   }
   else if ( character_from_keyboard  ==  FIND_NAME_COMMAND  ||
             character_from_keyboard  ==  OTHER_FIND_NAME_COMMAND )
   {
      parse_current_line_for_name() ;

      //  The name found on current line should be now stored in
      //  string_being_searched.

      search_string_in_text() ;

      previous_find_replace_command  =  FIND_COMMAND ;
   }
   else if ( character_from_keyboard  ==  FIND_REPLACE_NEXT_COMMAND )
   {
      if ( previous_find_replace_command  ==  FIND_COMMAND )
      {
         search_string_in_text() ;
      }
      else if ( previous_find_replace_command  == FIND_AND_REPLACE_COMMAND )
      {
         search_and_replace_string_in_text() ;
      }
      else if ( previous_find_replace_command  ==
                                            FIND_AND_MAYBE_REPLACE_COMMAND )
      {
         search_and_maybe_replace_string_in_text() ;
      }
   }
   else if (  character_from_keyboard  ==  '\n' ||
              character_from_keyboard  ==  '\r'  )  // newline
   {
      Text_line  first_part_of_splitted_line ;
      Text_line  second_part_of_splitted_line ;

      //  split_line does a correct splitting although the
      //  cursor were beyond the end of line.

      line_being_edited.split_line( cursor_position.x_coordinate,
                                    first_part_of_splitted_line,
                                    second_part_of_splitted_line ) ;
      text_lines_being_edited.update_line( cursor_position.y_coordinate,
                                           first_part_of_splitted_line ) ;

      //  In most cases, the second_part_of_splitted_line is 
      //  a line of zero length.

      line_being_edited  =  second_part_of_splitted_line ;

      cursor_position.y_coordinate  ++   ;
      cursor_position.x_coordinate  = 0  ;

      text_lines_being_edited.insert_line( cursor_position.y_coordinate,
                                           line_being_edited  ) ;

      if ( ( cursor_position.y_coordinate -
             screen_top_y_coordinate )  >=  SCREEN_HEIGHT_IN_LINES - 2 )
      {
         screen_top_y_coordinate  ++  ;
      }

      text_lines_being_edited.update_line( cursor_position.y_coordinate,
                                           line_being_edited  ) ;

      update_modified_text_on_screen() ;

      text_has_been_modified   =  true  ;
   }
   else if (  character_from_keyboard  ==  '\b'  ) // backspace
   {
      //  Cursor may be beyond line end.

      if ( line_being_edited.get_line_length()  <
                                   cursor_position.x_coordinate  )
      {
         cursor_position.x_coordinate  =
                       line_being_edited.get_line_length() ;
      }

      if ( cursor_position.x_coordinate  >  0  )
      {
         //  We will just shorten the line by one character

         cursor_position.x_coordinate  --  ;

         line_being_edited.remove_character( cursor_position.x_coordinate ) ;
      }
      else if ( cursor_position.x_coordinate  ==  0  &&
                cursor_position.y_coordinate  >   0  )
      {
         Text_line  deleted_line  =  line_being_edited ;

         text_lines_being_edited.remove_line( cursor_position.y_coordinate ) ;

         cursor_position.y_coordinate  --  ;

         text_lines_being_edited.read_line( cursor_position.y_coordinate,
                                            line_being_edited ) ;

         cursor_position.x_coordinate  =  line_being_edited.get_line_length() ;

         line_being_edited.append_line( deleted_line ) ;

         if ( cursor_position.y_coordinate  <  screen_top_y_coordinate )
         {
            screen_top_y_coordinate  -- ;
         }
      }

      text_lines_being_edited.update_line( cursor_position.y_coordinate,
                                           line_being_edited  ) ;

      update_modified_text_on_screen() ;

      text_has_been_modified   =  true  ;
   }
   else if (  character_from_keyboard  ==  DELETE_LINE_COMMAND  )
   {
      if ( cursor_position.y_coordinate  <
                      text_lines_being_edited.get_number_of_lines() - 1 )
      {
         text_lines_being_edited.remove_line( cursor_position.y_coordinate ) ;

         text_lines_being_edited.read_line( cursor_position.y_coordinate,
                                            line_being_edited ) ;

         if ( cursor_movement_style  !=  DIRECT_VERTICAL_CURSOR )
         {
            if ( line_being_edited.get_line_length()  <
                                      cursor_position.x_coordinate  )
            {
               cursor_position.x_coordinate  =
                          line_being_edited.get_line_length() ;
            }
         }
      }
      else
      {
         text_lines_being_edited.remove_line( cursor_position.y_coordinate ) ;

         Text_line  empty_line  ;

         text_lines_being_edited.insert_line( cursor_position.y_coordinate,
                                              empty_line  ) ;

         line_being_edited            =  empty_line ;
         cursor_position.x_coordinate  =  0 ;
      }

      update_modified_text_on_screen() ;

      text_has_been_modified  =  true  ;
   }
   else if ( character_from_keyboard  ==  DELETE_TO_END_OF_LINE_COMMAND )
   {
      while ( cursor_position.x_coordinate  <
                                line_being_edited.get_line_length() )
      {
         line_being_edited.remove_character( cursor_position.x_coordinate ) ;
      }

      text_lines_being_edited.update_line( cursor_position.y_coordinate,
                                           line_being_edited ) ;

      update_modified_text_on_screen() ;

      text_has_been_modified  =  true ;
   }
   else if ( character_from_keyboard  ==  '\t' )  //  tabulator
   {
      //  Cursor may be beyond line end.

      if ( line_being_edited.get_line_length()  <
                                 cursor_position.x_coordinate  )
      {
         cursor_position.x_coordinate  =
                       line_being_edited.get_line_length() ;
      }

      line_being_edited.insert_character( cursor_position.x_coordinate,
                                          ' ' ) ;
      cursor_position.x_coordinate  ++ ;

      while ( ( cursor_position.x_coordinate  %
                                  NUMBER_OF_SPACES_IN_A_TAB )  !=  0 )
      {
         line_being_edited.insert_character( cursor_position.x_coordinate,
                                             ' ' ) ;
         cursor_position.x_coordinate  ++ ;
      }


      text_lines_being_edited.update_line( cursor_position.y_coordinate,
                                           line_being_edited ) ;

      update_modified_text_on_screen() ;

      text_has_been_modified  =  true ;
   }
   else if ( character_from_keyboard  ==  SET_TAG_COMMAND )
   {
      //  Cursor may be beyond line end.

      if ( line_being_edited.get_line_length()  <
                                 cursor_position.x_coordinate  )
      {
         cursor_position.x_coordinate  =
                       line_being_edited.get_line_length() ;
      }

      if ( number_of_tags_in_use  <  NUMBER_OF_TAGS_ALLOWED )
      {
         tags_in_this_edition[ number_of_tags_in_use ]  =  cursor_position ;
         number_of_tags_in_use  ++  ;
         sort_to_ascending_order( tags_in_this_edition,
                                  number_of_tags_in_use  ) ;
      }
      else
      {
         inform_user( "No more tags allowed." ) ;
      }
   }
   else if ( character_from_keyboard  ==  WANDER_TO_LINE_COMMAND )
   {
      char  line_number_as_string[ 10 ] ;

      ask_text_on_bottom_line( "Line number: ",
                               line_number_as_string,
                               sizeof( line_number_as_string ) ) ;

      int  line_number  =  atoi( line_number_as_string ) ;

      if ( line_number <= text_lines_being_edited.get_number_of_lines() )
      {
         cursor_position  =  Position( 0, line_number - 1 ) ;

         if ( cursor_position.y_coordinate  >  SCREEN_HEIGHT_IN_LINES  -  4  )
         {
            screen_top_y_coordinate  =  cursor_position.y_coordinate  -  
                                           ( SCREEN_HEIGHT_IN_LINES  -  4 ) ;
         }
         else
         {
            screen_top_y_coordinate  =  0 ;
         }

         update_modified_text_on_screen() ;
      }
      else
      {
         write_text_on_bottom_line( "Too big line number." ) ;
      }
   }
   else if ( character_from_keyboard  ==  HELP_MENU_COMMAND  )
   {
      clrscr() ;

      gotoxy( 1, 1 ) ;

      display_help_information() ;

      clrscr() ;
      update_all_text_on_screen() ;
   }
}

void  Edition::activate_edition()
{
   clrscr() ;
   update_all_text_on_screen() ;
}

void  Edition::inform_user( char  text_to_bottom_line[] )
{
   write_text_on_bottom_line( text_to_bottom_line ) ;
}


void
Edition::save_text_to_file()
{
   char  file_action_message[ 80 ] ;

   if (  file_name_not_yet_given  ==  true )
   {
      ask_text_on_bottom_line( "Give file name: ",
                               file_being_edited,
                               sizeof( file_being_edited ) ) ;

      if ( strlen( file_being_edited ) >=  MINIMUM_FILE_NAME_LENGTH )
      {
         file_name_not_yet_given   =  false ;
      }
      else
      {
         write_text_on_bottom_line(
                 "File not saved. File name not acceptable." ) ;

         strcpy( file_being_edited, "" ) ;
      }
   }


   if ( file_name_not_yet_given  ==  false )
   {
      generate_backup_file() ;

      text_lines_being_edited.store_text_to_file(
                                     file_being_edited,
                                     file_action_message ) ;

      write_text_on_bottom_line( file_action_message ) ;

      text_has_been_modified  =  false ;
   }
}

void
Edition::save_text_to_new_file()
{
   char  new_file_name[ 80 ] ;

   ask_text_on_bottom_line( "Give new file name: ",
                             new_file_name, sizeof( new_file_name ) ) ;

   if ( strlen( new_file_name )  >=  MINIMUM_FILE_NAME_LENGTH )
   {
      strcpy( file_being_edited, new_file_name ) ;

      file_name_not_yet_given   =  false ;

      generate_backup_file() ;

      char  file_action_message[ 80 ] ;

      text_lines_being_edited.store_text_to_file(
                                     file_being_edited,
                                     file_action_message ) ;

      write_text_on_bottom_line( file_action_message ) ;

      text_has_been_modified  =  false ;
   }
   else
   {
      write_text_on_bottom_line(
             "Too short file name. Text not stored." ) ;
   }
}

bool
Edition::close_this_edition()
{
   bool  file_closing_was_successful   =  false ;

   if ( text_has_been_modified   ==  true  )
   {
      char  response_text[ 10 ] ;

      ask_text_on_bottom_line( "Do you want to save this text? (Y/N) ",
                               response_text, sizeof( response_text ) ) ;

      if ( response_text[ 0 ]  ==  'n' ||
           response_text[ 0 ]  ==  'N'   )
      {
         text_has_been_modified       =  false ;
         file_closing_was_successful  =  true ;
      }
      else
      {
         if ( file_name_not_yet_given  ==  true  )
         {
            ask_text_on_bottom_line( "Give file name: ",
                                      file_being_edited,
                                      sizeof( file_being_edited ) ) ;

            if ( strlen( file_being_edited )  >=  MINIMUM_FILE_NAME_LENGTH )
            {
               file_name_not_yet_given   =  false ;
            }
            else
            {
               strcpy( file_being_edited,  "" ) ;
            }
         }


         if ( file_name_not_yet_given  ==  false )
         {
            char  file_action_message[ 80 ] ;

            generate_backup_file() ;

            text_lines_being_edited.store_text_to_file( file_being_edited,
                                                        file_action_message ) ;
  
            write_text_on_bottom_line( file_action_message ) ;

            text_has_been_modified  =  false ;

            file_closing_was_successful  =  true ;
         }
         else
         {
             write_text_on_bottom_line(
                       "File not closed. File name not acceptable." ) ;
         }
      }
   }
   else
   {
      //  Text was not modified.

      file_closing_was_successful  =  true ;
   }

   return  file_closing_was_successful ;
}


void
Edition::ask_text_on_bottom_line(  char  text_to_screen[],
                                   char  text_to_caller[],
                                   int   maximum_text_length )
{
   gotoxy( 1, SCREEN_HEIGHT_IN_LINES ) ;
   clreol() ;
   gotoxy( 1, SCREEN_HEIGHT_IN_LINES ) ;
   cout  <<  text_to_screen ;
   cin.getline( text_to_caller, maximum_text_length ) ;

   screen_of_this_edition.update_all_screen_lines(

                        text_lines_being_edited,
                        text_lines_being_edited.get_number_of_lines(),
                        screen_top_y_coordinate ) ;

   gotoxy( cursor_position.x_coordinate + 1, 
           cursor_position.y_coordinate + 1 
               -  screen_top_y_coordinate  ) ;
}



class  Editor
{
protected:
   Edition*  active_edition ;
   int       number_of_editions_in_use ;

   Array_of_text_lines  text_lines_to_paste ;

   void  get_next_key_code( short&  key_code ) ;

public:
   Editor( char  file_name[]  =  0,
           char  another_file_name[]  =  0 ) ;

   void  run() ;
} ;


void
Editor::get_next_key_code( short&  code_to_caller ) 
{

/*-------------------

      Encoding the characters that make the words in natural
      languages is a problematic task. In the world of personal
      computers, the 8-bit ASCII coding is in use. However,
      although we can encode most visible characters with 8 bits,
      there are some special characters, or keys on the keyboard,
      which require more than 8 bits to be encoded.

      Unicode is a new system to give numerical values to
      characters. Unicodes are 16-bit codes, which means that
      we can express 256 times more characters with Unicodes
      than with the 8-bit ASCII codes.

      The following keyboard_decoding_table is used to give
      Unicode values to all characters that are read from
      the keyboard. The first 256 Unicodes are the same as the
      256 codes in the 8-bit ASCII coding system which is, 
      for example, used in the Windows operating system.

      For example, the letter keys of the keyboard of a personal
      computer produce 8-bit ASCII-codes which directly correspond
      with Unicodes. But there are special keys such as the
      cursor movement keys and the function keys F1, F2, F3, etc.
      which produce 2-byte extended key codes. The first byte of
      an extended key code is zero and the second byte says
      which key was pressed.

      Extended key codes of function keys are the following:

               Basic    Shift    Ctrl     Alt

      F1       00 3B    00 54    00 5E    00 68
      F2       00 3C    00 55    00 5F    00 69
      F3       00 3D    00 56    00 60    00 6A
      F4       00 3E    00 57    00 61    00 6B
      F5       00 3F    00 58    00 62    00 6C
      F6       00 40    00 59    00 63    00 6D
      F7       00 41    00 5A    00 64    00 6E
      F8       00 42    00 5B    00 65    00 6F
      F9       00 43    00 5C    00 66    00 70
      F10      00 44    00 5D    00 67    00 71
      F11      00 85    00 87    00 89    00 8B
      F12      00 86    00 88    00 8A    00 8C

      Other special keys have the following extended codes:

      Insert      00 52
      Delete      00 53
      Home        00 47
      End         00 4F
      Page Up     00 49
      Page Down   00 51
      Arrow Left  00 4B
      Arrow Up    00 48
      Arrow Down  00 50
      Arrow Right 00 4D


      This function converts extended key codes into 16-bit
      codes according to the following principle:


      Key       Code       Conversion

      Ctrl-F1   00  5E     15E
      Ctrl-F2   00  5F     15F
      Ctrl-F3   00  60     160

          etc.  etc.


      The following example shows how this function works:

        -  the user of the computer presses Arrow Up key
        -  this results in that the codes 00H 48H are
           received from the keyboard
        -  this function detects that the first byte is
           zero, so it reads the second byte
        -  having received 48H as the second byte of the
           extended key code, this function forms the code
           148H
        -  code 148H is used as an index in the 
           keyboard_decoding_table and value 1004 is returned
           to the caller of the function, value 1004 is the
           Unicode value of Arrow Up key

      I must admit that I do not know how official the
      Unicodes (1004 etc.) of the special keys in the table are.
      I found these values for the special keys while I was
      experimenting with a Java program that could show the
      numerical values of various keys. As the Unicode system
      is the official character coding system in Java, I
      concluded that these must be appropriate codes.
      It can be that these codes are not very official after all.


      -------------------------------------*/

   short  keyboard_decoding_table[]  =

   { 0x00, 0x01, 0x02, 0x03, 0x04, 0x05, 0x06, 0x07,
     0x08, 0x09, 0x0A, 0x0B, 0x0C, 0x0D, 0x0E, 0x0F,
     0x10, 0x11, 0x12, 0x13, 0x14, 0x15, 0x16, 0x17,
     0x18, 0x19, 0x1A, 0x1B, 0x1C, 0x1D, 0x1E, 0x1F,
     0x20, 0x21, 0x22, 0x23, 0X24, 0X25, 0x26, 0x27,
     0x28, 0x29, 0x2A, 0x2B, 0x2C, 0x2D, 0x2E, 0x2F,
     0x30, 0x31, 0x32, 0x33, 0x34, 0x35, 0x36, 0x37,
     0x38, 0x39, 0x3A, 0x3B, 0x3C, 0x3D, 0x3E, 0x3F,
     0x40, 0x41, 0x42, 0x43, 0x44, 0x45, 0x46, 0x47,
     0x48, 0x49, 0x4A, 0x4B, 0x4C, 0x4D, 0x4E, 0x4F,
     0x50, 0x51, 0x52, 0x53, 0x54, 0x55, 0x56, 0x57,
     0x58, 0x59, 0x5A, 0x5B, 0x5C, 0x5D, 0x5E, 0x5F,
     0x60, 0x61, 0x62, 0x63, 0x64, 0x65, 0x66, 0x67,
     0x68, 0x69, 0x6A, 0x6B, 0x6C, 0x6D, 0x6E, 0x6F,
     0x70, 0x71, 0x72, 0x73, 0x74, 0x75, 0x76, 0x77,
     0x78, 0x79, 0x7A, 0x7B, 0x7C, 0x7D, 0x7E, 0x7F,

     0x80, 0x81, 0x82, 0x83, 0x84, 0x85, 0x86, 0x87,
     0x88, 0x89, 0x8A, 0x8B, 0x8C, 0x8D, 0x8E, 0x8F,
     0x90, 0x91, 0x92, 0x93, 0x94, 0x95, 0x96, 0x97,
     0x98, 0x99, 0x9A, 0x9B, 0x9C, 0x9D, 0x9E, 0x9F,
     0xA0, 0xA1, 0xA2, 0xA3, 0xA4, 0xA5, 0xA6, 0xA7,
     0xA8, 0xA9, 0xAA, 0xAB, 0xAC, 0xAD, 0xAE, 0xAF,
     0xB0, 0xB1, 0xB2, 0xB3, 0xB4, 0xB5, 0xB6, 0xB7,
     0xB8, 0xB9, 0xBA, 0xBB, 0xBC, 0xBD, 0xBE, 0xBF,

     0xC0, 0xC1, 0xC2, 0xC3, 0xC4, 0xC5, 0xC6, 0xC7,
     0xC8, 0xC9, 0xCA, 0xCB, 0xCC, 0xCD, 0xCE, 0xCF,
     0xD0, 0xD1, 0xD2, 0xD3, 0xD4, 0xD5, 0xD6, 0xD7,
     0xD8, 0xD9, 0xDA, 0xDB, 0xDC, 0xDD, 0xDE, 0xDF,
     0xE0, 0xE1, 0xE2, 0xE3, 0xE4, 0xE5, 0xE6, 0xE7,
     0xE8, 0xE9, 0xEA, 0xEB, 0xEC, 0xED, 0xEE, 0xEF,
     0xF0, 0xF1, 0xF2, 0xF3, 0xF4, 0xF5, 0xF6, 0xF7,
     0xF8, 0xF9, 0xFA, 0xFB, 0xFC, 0xFD, 0xFE, 0xFF,

     0x100, 0x101, 0x102, 0x103, 0x104, 0x105, 0x106, 0x107,
     0x108, 0x109, 0x10A, 0x10B, 0x10C, 0x10D, 0x10E, 0x10F,
     0x110, 0x111, 0x112, 0x113, 0x114, 0x115, 0x116, 0x117,
     0x118, 0x119, 0x11A, 0x11B, 0x11C, 0x11D, 0x11E, 0x11F,
     0x120, 0x121, 0x122, 0x123, 0x124, 0x125, 0x126, 0x127,
     0x128, 0x129, 0x12A, 0x12B, 0x12C, 0x12D, 0x12E, 0x12F,
     0x130, 0x131, 0x132, 0x133, 0x134, 0x135, 0x136, 0x137,
     0x138, 0x139, 0x13A,  1008,  1009,  1010,  1011,  1012,

      1013,  1014,  1015,  1016,  1017, 0x145, 0x146, 1000,
      1004,  1002, 0x14A,  1006, 0x14C,  1007, 0x14E, 1001,
      1005,  1003, 0x152, 0x7F,  0x154, 0x155, 0x156, 0x157,
     0x158, 0x159, 0x15A, 0x15B, 0x15C, 0x15D, 0x15E, 0x15F,
     0x160, 0x161, 0x162, 0x163, 0x164, 0x165, 0x166, 0x167,
     0x168, 0x169, 0x16A, 0x16B, 0x16C, 0x16D, 0x16E, 0x16F,
     0x170, 0x171, 0x172, 0x173, 0x174, 0x175, 0x176, 0x177,
     0x178, 0x179, 0x17A, 0x17B, 0x17C, 0x17D, 0x17E, 0x17F,

     0x180, 0x181, 0x182, 0x183, 0x184,  1018,  1019, 0x187,
     0x188, 0x189, 0x18A, 0x18B, 0x18C, 0x18D, 0x18E, 0x18F,
     0x190, 0x191, 0x192, 0x193, 0x194, 0x195, 0x196, 0x197,
     0x198, 0x199, 0x19A, 0x19B, 0x19C, 0x19D, 0x19E, 0x19F,
     0x1A0, 0x1A1, 0x1A2, 0x1A3, 0x1A4, 0x1A5, 0x1A6, 0x1A7,
     0x1A8, 0x1A9, 0x1AA, 0x1AB, 0x1AC, 0x1AD, 0x1AE, 0x1AF,
     0x1B0, 0x1B1, 0x1B2, 0x1B3, 0x1B4, 0x1B5, 0x1B6, 0x1B7,
     0x1B8, 0x1B9, 0x1BA, 0x1BB, 0x1BC, 0x1BD, 0x1BE, 0x1BF,

     0x1C0, 0x1C1, 0x1C2, 0x1C3, 0x1C4, 0x1C5, 0x1C6, 0x1C7,
     0x1C8, 0x1C9, 0x1CA, 0x1CB, 0x1CC, 0x1CD, 0x1CE, 0x1CF,
     0x1D0, 0x1D1, 0x1D2, 0x1D3, 0x1D4, 0x1D5, 0x1D6, 0x1D7,
     0x1D8, 0x1D9, 0x1DA, 0x1DB, 0x1DC, 0x1DD, 0x1DE, 0x1DF,
     0x1E0, 0x1E1, 0x1E2, 0x1E3, 0x1E4, 0x1E5, 0x1E6, 0x1E7,
     0x1E8, 0x1E9, 0x1EA, 0x1EB, 0x1EC, 0x1ED, 0x1EE, 0x1EF,
     0x1F0, 0x1F1, 0x1F2, 0x1F3, 0x1F4, 0x1F5, 0x1F6, 0x1F7,
     0x1F8, 0x1F9, 0x1FA, 0x1FB, 0x1FC, 0x1FD, 0x1FE, 0x1FF

   } ;

   unsigned char  byte_from_keyboard,  another_byte_from_keyboard ;

   short  decoding_table_index ;

   byte_from_keyboard  =  getch() ;

   decoding_table_index  =  byte_from_keyboard ;

   if ( byte_from_keyboard  ==  0 )
   {
      // We are about to receive an extended key code.

      another_byte_from_keyboard  =  getch() ;

      decoding_table_index  =  0x100  +  another_byte_from_keyboard ;
   }

   code_to_caller  =  keyboard_decoding_table[ decoding_table_index ] ;
}



Editor::Editor( char  file_name[], char  another_file_name[] )
{
   if ( file_name  ==  0  &&  another_file_name  ==  0 )
   {
      // No file names are given.

      active_edition  =  new  Edition ;

      active_edition -> previous_edition  =  active_edition ;
      active_edition -> next_edition      =  active_edition ;

      number_of_editions_in_use  =  1  ;
   }
   else if ( another_file_name  ==  0 )
   {
      // One file name was given.

      active_edition  =  new  Edition( file_name ) ;

      active_edition -> previous_edition  =  active_edition ;
      active_edition -> next_edition      =  active_edition ;

      active_edition -> activate_edition() ;
      number_of_editions_in_use  =  1  ;
   }
   else
   {
      // Two file names were given. We'll build two Edition
      // objects and combine them to doubly-linked list.

      active_edition  =  new  Edition( file_name ) ;

      Edition*  second_edition  =  new  Edition( another_file_name ) ;

      active_edition -> previous_edition  =  second_edition ;
      active_edition -> next_edition      =  second_edition ;

      second_edition -> previous_edition  =  active_edition ;
      second_edition -> next_edition      =  active_edition ;

      active_edition -> activate_edition() ;

      number_of_editions_in_use  =  2  ;
   }
}

void  Editor::run()
{
   while ( number_of_editions_in_use  >  0 )
   {
      short  character_from_keyboard ;

      get_next_key_code( character_from_keyboard ) ;

      if ( character_from_keyboard  ==  FILE_EXIT_MENU_COMMAND )
      {
         active_edition  ->  inform_user( 
           "Open     Save    save As     Move     Close     Exit" ) ;

         short  another_character_from_keyboard ;

         get_next_key_code( another_character_from_keyboard ) ;
      
         another_character_from_keyboard  =
                       another_character_from_keyboard  &  0xDF  ;  

         if (  another_character_from_keyboard  ==  'S'  )  //  Save
         {
            character_from_keyboard   =  FILE_SAVE_KEY ;
         }
         else if (  another_character_from_keyboard  ==  'A'  )  //  Save as
         {
            character_from_keyboard   =  FILE_SAVE_AS_KEY ;
         }
         else if (  another_character_from_keyboard  ==  'E' ||  //  Exit
                    another_character_from_keyboard  ==  'C'  )  //  Close
         {
            character_from_keyboard   =  FILE_CLOSE_KEY  ;
         }
         else if (  another_character_from_keyboard  ==  'O'  )  // Open
         {
            character_from_keyboard   =  FILE_OPEN_KEY  ;

         }
         else if (  another_character_from_keyboard  ==  'M'  )  //  Move 
         {
            character_from_keyboard   =  FILE_MOVE_KEY  ;
         }
         else
         {
            character_from_keyboard   =  0  ;
        
         }
      }

      if ( character_from_keyboard  ==  FILE_CLOSE_KEY )
      {
         //  The following call to funtion close_this_edition
         //  returns false if the edition cannot be closed 
         //  for some reason.

         if ( active_edition -> close_this_edition() )
         {
            if ( active_edition -> next_edition   ==  active_edition )
            {
               // There is only one edition in the circle of editions.

               delete  active_edition ;
               number_of_editions_in_use  =  0 ;
            }
            else
            {
               ( active_edition -> previous_edition ) -> next_edition
                            =  active_edition -> next_edition ;

               ( active_edition -> next_edition ) -> previous_edition
                            =  active_edition -> previous_edition ;

               // Now the edition being closed is taken away from
               // the chain of editions.

               Edition*  new_active_edition  =  
                               active_edition -> next_edition ;

               delete  active_edition ;
               active_edition  =  new_active_edition ;
               active_edition ->  activate_edition() ;

               number_of_editions_in_use  --  ;
            }
         }
      }
      else if ( character_from_keyboard  ==  FILE_MOVE_KEY )
      {
         active_edition  =  active_edition -> next_edition ;
         active_edition ->  activate_edition() ;
      }
      else if ( character_from_keyboard  ==  FILE_OPEN_KEY )
      {
         if ( number_of_editions_in_use < NUMBER_OF_EDITIONS_ALLOWED )
         {

            char  file_name[ FILE_NAME_SIZE ] ;

            active_edition -> ask_text_on_bottom_line( "Give file name: ",
                                           file_name, FILE_NAME_SIZE  ) ;

            Edition*  new_edition ;

            if ( strlen( file_name )  <  MINIMUM_FILE_NAME_LENGTH )
            {
               new_edition  =  new  Edition ;
            }
            else
            {
               new_edition  =  new  Edition( file_name ) ;
            }

            new_edition -> previous_edition  =  active_edition ;
            new_edition -> next_edition   =
                             active_edition -> next_edition ;

            ( active_edition -> next_edition ) -> previous_edition
                        =  new_edition ;
            active_edition -> next_edition  =  new_edition ;

            active_edition   =  new_edition ;
            active_edition  ->  activate_edition() ;

            number_of_editions_in_use  ++ ;
         }
         else
         {
            char  useless_text[ 10 ] ;

            active_edition -> ask_text_on_bottom_line(
                 "Cannot open more files. Press <Enter> to continue. ",
                  useless_text, sizeof( useless_text ) ) ;
            active_edition -> activate_edition() ;
         }
      }
      else if ( character_from_keyboard  ==  FILE_SAVE_KEY )
      {
         active_edition -> save_text_to_file() ;
      }
      else if ( character_from_keyboard  ==  FILE_SAVE_AS_KEY )
      {
         active_edition -> save_text_to_new_file() ;
      }
      else
      { 
         active_edition -> handle_character( character_from_keyboard,
                                             text_lines_to_paste ) ;
      }
   }

   gotoxy( SCREEN_WIDTH_IN_COLUMNS, SCREEN_HEIGHT_IN_LINES ) ;
   cout << "\n -------------- "  <<   ZEDIT_EDITOR_VERSION_TEXT
        << " -------- (c) Kari Laitinen -------------\n" ;
}


int main( int   number_of_command_line_arguments,
          char* command_line_arguments[] )
{
   if ( number_of_command_line_arguments  ==  1 )
   {
      Editor   this_editor ;
      this_editor.run() ;
   }
   else if ( number_of_command_line_arguments  ==  2 )
   {
      // One file name was given on command line

      Editor   this_editor( command_line_arguments[ 1 ] ) ;
      this_editor.run() ;
   }
   else if ( number_of_command_line_arguments  ==  3 )
   {
      // Two file names were given on command line.

      Editor   this_editor( command_line_arguments[ 1 ],
                            command_line_arguments[ 2 ] ) ;
      this_editor.run() ;
   }
}


/*-----------------------------------------------------------

      The following table is included in this program because of
      historical reasons. The table was used to convert a U.S.-style
      keyboard to Finnish style, and also to give
      Unicode values to cursor movement keys. The table was needed
      because the getch function in Borland C++ 5.2 seemed to read
      all keyboards like U.S. keyboards. This problem does not exist
      any more with Borland C++ 5.3 compiler.

      The table is just saved here without any particular reason.
      You never know: some day it might be needed. Inside function
      Editor::get_next_key_code there is a similar table which just
      converts extended key codes to Unicode values.

      It seems to be impossible to put character constants
      '”', '„', '™', 'Ž', '†', and '' to the table because
      the compiler interprets them as negative numbers.

      The following codes mean Scandinavian special
      characters:

      0x84  means  '„'   0x8E   means  'Ž'
      0x94  means  '”'   0x99   means  '™'
      0x86  means  '†'   0x8F   means  ''

      To further increase the confusion, note that this file
      was written with Zedit and other MS-DOS editors. This means
      that if you view this file with a Windows editor or print
      the file with a Windows printing program, the above
      characters do not print properly. The ASCII coding system
      in MS-DOS is slightly different from that in Windows.

------------------*/

/*---------------------------

   short  keyboard_decoding_table[]  =

   { 0x00, 0x01, 0x02, 0x03, 0x04, 0x05, 0x06, 0x07,
     0x08, 0x09, 0x0A, 0x0B, 0x0C, 0x0D, 0x0E, 0x0F,
     0x10, 0x11, 0x12, 0x13, 0x14, 0x15, 0x16, 0x17,
     0x18, 0x19, 0x1A, 0x1B, 0x1C, 0x1D, 0x1E, 0x1F,
     0x20, '!',  0x8E,  '#', 0X24, 0X25, '/',  0x84,
     ')',  '=',  '(',   '?', 0x2C, 0x2D, 0x2E, '\'',
     0x30, 0x31, 0x32, 0x33, 0x34, 0x35, 0x36, 0x37,
     0x38, 0x39, '^',   '~',  ';',  '+',  ':',  '*',
     '\"', 0x41, 0x42, 0x43, 0x44, 0x45, 0x46, 0x47,
     0x48, 0x49, 0x4A, 0x4B, 0x4C, 0x4D, 0x4E, 0x4F,
     0x50, 0x51, 0x52, 0x53, 0x54, 0x55, 0x56, 0x57,
     0x58, 0x59, 0x5A,  '<', 0x5C, 0x86,  '&', 0x5F,
     0x94, 0x61, 0x62, 0x63, 0x64, 0x65, 0x66, 0x67,
     0x68, 0x69, 0x6A, 0x6B, 0x6C, 0x6D, 0x6E, 0x6F,
     0x70, 0x71, 0x72, 0x73, 0x74, 0x75, 0x76, 0x77,
     0x78, 0x79, 0x7A, '>',   '|', 0x8F, 0x99, 0x7F,

     0x80, 0x81, 0x82, 0x83, 0x84, 0x85, 0x86, 0x87,
     0x88, 0x89, 0x8A, 0x8B, 0x8C, 0x8D, 0x8E, 0x8F,
     0x90, 0x91, 0x92, 0x93, 0x94, 0x95, 0x96, 0x97,
     0x98, 0x99, 0x9A, 0x9B, 0x9C, 0x9D, 0x9E, 0x9F,
     0xA0, 0xA1, 0xA2, 0xA3, 0xA4, 0xA5, 0xA6, 0xA7,
     0xA8, 0xA9, 0xAA, 0xAB, 0xAC, 0xAD, 0xAE, 0xAF,
     0xB0, 0xB1, 0xB2, 0xB3, 0xB4, 0xB5, 0xB6, 0xB7,
     0xB8, 0xB9, 0xBA, 0xBB, 0xBC, 0xBD, 0xBE, 0xBF,

     0xC0, 0xC1, 0xC2, 0xC3, 0xC4, 0xC5, 0xC6, 0xC7,
     0xC8, 0xC9, 0xCA, 0xCB, 0xCC, 0xCD, 0xCE, 0xCF,
     0xD0, 0xD1, 0xD2, 0xD3, 0xD4, 0xD5, 0xD6, 0xD7,
     0xD8, 0xD9, 0xDA, 0xDB, 0xDC, 0xDD, 0xDE, 0xDF,
     0xE0, 0xE1, 0xE2, 0xE3, 0xE4, 0xE5, 0xE6, 0xE7,
     0xE8, 0xE9, 0xEA, 0xEB, 0xEC, 0xED, 0xEE, 0xEF,
     0xF0, 0xF1, 0xF2, 0xF3, 0xF4, 0xF5, 0xF6, 0xF7,
     0xF8, 0xF9, 0xFA, 0xFB, 0xFC, 0xFD, 0xFE, 0xFF,

     0x100, 0x101, 0x102, 0x103, 0x104, 0x105, 0x106, 0x107,
     0x108, 0x109, 0x10A, 0x10B, 0x10C, 0x10D, 0x10E, 0x10F,
     0x110, 0x111, 0x112, 0x113, 0x114, 0x115, 0x116, 0x117,
     0x118, 0x119, 0x11A, 0x11B, 0x11C, 0x11D, 0x11E, 0x11F,
     0x120, 0x121, 0x122, 0x123, 0x124, 0x125, 0x126,  '~',
     0x128, 0x129, 0x12A, 0x12B, 0x12C, 0x12D, 0x12E, 0x12F,
     0x130, 0x131, 0x132, 0x133, 0x134, 0x135, 0x136, 0x137,
     0x138, 0x139, 0x13A,  1008,  1009,  1010,  1011,  1012,

      1013,  1014,  1015,  1016,  1017, 0x145, 0x146, 1000,
      1004,  1002, 0x14A,  1006, 0x14C,  1007, 0x14E, 1001,
      1005,  1003, 0x152, 0x7F,  0x154, 0x155, 0x156, 0x157,
     0x158, 0x159, 0x15A, 0x15B, 0x15C, 0x15D, 0x15E, 0x15F,
     0x160, 0x161, 0x162, 0x163, 0x164, 0x165, 0x166, 0x167,
     0x168, 0x169, 0x16A, 0x16B, 0x16C, 0x16D, 0x16E, 0x16F,
     0x170, 0x171, 0x172, 0x173, 0x174, 0x175, 0x176, 0x177,
     0x178,  '@' ,   '|',  '$' , 0x17C, 0x17D,   '{',  '[' ,

       ']',  '}' , 0x182,  '\\', 0x184,  1018,  1019, 0x187,
     0x188, 0x189, 0x18A, 0x18B, 0x18C, 0x18D, 0x18E, 0x18F,
     0x190, 0x191, 0x192, 0x193, 0x194, 0x195, 0x196, 0x197,
     0x198, 0x199, 0x19A, 0x19B, 0x19C, 0x19D, 0x19E, 0x19F,
     0x1A0, 0x1A1, 0x1A2, 0x1A3, 0x1A4, 0x1A5, 0x1A6, 0x1A7,
     0x1A8, 0x1A9, 0x1AA, 0x1AB, 0x1AC, 0x1AD, 0x1AE, 0x1AF,
     0x1B0, 0x1B1, 0x1B2, 0x1B3, 0x1B4, 0x1B5, 0x1B6, 0x1B7,
     0x1B8, 0x1B9, 0x1BA, 0x1BB, 0x1BC, 0x1BD, 0x1BE, 0x1BF,

     0x1C0, 0x1C1, 0x1C2, 0x1C3, 0x1C4, 0x1C5, 0x1C6, 0x1C7,
     0x1C8, 0x1C9, 0x1CA, 0x1CB, 0x1CC, 0x1CD, 0x1CE, 0x1CF,
     0x1D0, 0x1D1, 0x1D2, 0x1D3, 0x1D4, 0x1D5, 0x1D6, 0x1D7,
     0x1D8, 0x1D9, 0x1DA, 0x1DB, 0x1DC, 0x1DD, 0x1DE, 0x1DF,
     0x1E0, 0x1E1, 0x1E2, 0x1E3, 0x1E4, 0x1E5, 0x1E6, 0x1E7,
     0x1E8, 0x1E9, 0x1EA, 0x1EB, 0x1EC, 0x1ED, 0x1EE, 0x1EF,
     0x1F0, 0x1F1, 0x1F2, 0x1F3, 0x1F4, 0x1F5, 0x1F6, 0x1F7,
     0x1F8, 0x1F9, 0x1FA, 0x1FB, 0x1FC, 0x1FD, 0x1FE, 0x1FF

   } ;

--------------------------*/





