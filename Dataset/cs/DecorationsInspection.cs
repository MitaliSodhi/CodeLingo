
//  DecorationsInspection.cs  (c) 2004 Kari Laitinen

//  Compile: csc DecorationsInspection.cs /unsafe

//  07.06.2004  File created.
//  08.06.2004  Last modification.

//  With this program I tried to explore the real
//  memory locations used by Decorations.cs.
//  The exploration was not very successful, because
//  the C# compiler seems to optimize memory usage.
//  I believe, however, that the figure in Chapter 9
//  gives a correct picture of the usage of memory.

using System ;

unsafe class Decorations
{
   static int  string_content ;

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

   static string get_string()
   {
      string  string_to_return  =  "000" + string_content.ToString() ;

      string_content  ++  ;

      return  string_to_return ;
   }

   static void print_nothing( string  given_string )
   {
      given_string  =  "xxxx" ;
   }

   static void multiprint_character( char character_from_caller,
                                     int  number_of_times_to_repeat )
   {
      int  repetition_counter  =  0 ;

      while ( repetition_counter  <  number_of_times_to_repeat )
      {
         Console.Write( character_from_caller ) ;
         repetition_counter  ++ ;
      }
   }

   static void print_text_in_decorated_box( string text_from_caller )
   {
      string  saved_text  =   get_string() ;

      print_nothing( saved_text ) ;

      int text_length  =  text_from_caller.Length ;

      print_memory( &text_length - 4, 12 ) ;
      Console.Write( "\n Press the Enter key ... " ) ;
      string any_string_from_keyboard  =  Console.ReadLine() ;


      Console.Write( "\n " ) ;
      multiprint_character( '=',  text_length  +  8  ) ;
      Console.Write( "\n " ) ;
      multiprint_character( '*',  text_length  +  8  ) ;
      Console.Write( "\n **" ) ;
      multiprint_character( ' ',  text_length  +  4  ) ;

      Console.Write( "**\n **  "  + text_from_caller + "  **\n **" ) ;

      multiprint_character( ' ',  text_length  +  4  ) ;
      Console.Write( "**\n " ) ;
      multiprint_character( '*',  text_length  +  8  ) ;
      Console.Write( "\n " ) ;
      multiprint_character( '=',  text_length  +  8  ) ;
      Console.Write( "\n " ) ;

      print_nothing( saved_text ) ;
   }

   static void Main()
   {
      string  first_text  =  get_string() ;

      print_text_in_decorated_box( first_text ) ;

      string  second_text  =  get_string() ;


/// "I am a computer program written in C#." ;


      print_text_in_decorated_box( second_text ) ;

      Console.Write( "\n " + first_text + " " + second_text ) ;

   }
}



