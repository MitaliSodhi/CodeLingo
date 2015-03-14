
//  BoxMoreElegant.cs  (c) 2004 Kari Laitinen

//  http://www.naturalprogramming.com

//  2004-11-05  File created.
//  2004-11-05  Last modification.

//  A more elegant solution to Exercise 9-4.

//  This solution can be considered more elegant than BoxKL.cs
//  because in this program a method named print_box() is
//  used to print the box. The printed box is, though, equally
//  unelegant as the box produced by BoxKL.cs.

using System ;

class BoxMoreElegant
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

   static void print_box( int desired_box_width,
                          int desired_box_height  )
   {
      Console.Write( "\n Here is your box: \n" ) ;

      for ( int line_index  =  0 ;
                line_index  <  desired_box_height ;
                line_index  ++  )
      {
         Console.Write( "\n     " ) ;
         multiprint_character( 'X', desired_box_width ) ;
      }

   }

   static void Main()
   {
      Console.Write( "\n Give box width:   " ) ;
      int box_width  =  Convert.ToInt32( Console.ReadLine() ) ;

      Console.Write( "\n Give box height:  " ) ;
      int box_height  =  Convert.ToInt32( Console.ReadLine() ) ;

      print_box( box_width, box_height ) ;

   }
}



