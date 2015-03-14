
//  Decorations.cs  (c) 2003 Kari Laitinen

using System ;

class Decorations
{
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
      int text_length  =  text_from_caller.Length ;

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
   }

   static void Main()
   {
      string  first_text  =  "Hello, world." ;

      print_text_in_decorated_box( first_text ) ;

      print_text_in_decorated_box(

                  "I am a computer program written in C#." ) ;
   }
}



