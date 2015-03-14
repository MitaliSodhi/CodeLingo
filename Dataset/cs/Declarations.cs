
//  Declarations.cs  (c) 2004 Kari Laitinen

//  www.naturalprogramming.com

using System ;

class Declarations
{
   static void some_method( Date given_date )
   {
   }

   static void Main()
   {
      Date  some_date  =  null ;
  string[]  any_array_of_strings ; 
      some_method( some_date ) ;
  Date first_day_of_this_millennium = new Date( 1, 1, 2000 ) ;
  Date last_day_of_this_millennium = new Date("12/31/2999") ;

  object  anything ;  // A reference to point to any object
/*****
  Date[]  days_of_this_millennium  =  new  Date[ 365243 ] ;
  days_of_this_millennium[ 0 ]  =  new Date( 1, 1, 2000 ) ;
  days_of_this_millennium[ 1 ]  =  new Date( 2, 1, 2000 ) ;
  days_of_this_millennium[ 3 ]  =  new Date( 3, 1, 2000 ) ;

  string  some_string  ;  // declares a string reference
  string  another_string  =  ""  ;  // an empty string
  string  third_string    =  "text inside string object" ;
  string  zzzzzzz_string  =  new  string( 'z', 7 ) ;

  string[]  array_of_strings   =  new  string[ 9 ] ;
  array_of_strings[ 0 ]  =  "some text line" ;
  array_of_strings[ 1 ]  =  "another text line" ;

  // The following is an initialized array of strings
  string[]  largest_moons_of_jupiter  =
             { "Io", "Ganymede", "Europa", "Callisto" } ;

  char[] array_of_characters ;
  array_of_characters  =  new  char[ 50 ] ;
  int[]  array_of_integers  =  new  int[ 60 ] ;
  int[]  integers_to_power_of_two =
         { 0, 1, 4, 9, 16, 25, 36, 49, 64, 81, 100, 121 } ;
  int[]  two_to_power_of_integer =
         { 1, 2, 4, 8, 16, 0x20, 0x40, 0x80, 0x100 } ;
  int[,]  some_rectangular_array  =  new int[ 5, 9 ] ;

  char[]  hexadecimal_digits  =
         { '0', '1', '2', '3', '4', '5', '6', '7',
           '8', '9', 'A', 'B', 'C', 'D', 'E', 'F' } ;

  double[] pi_times_integer  =
           { 0, 3.1416, 6.2832, 9.4248, 12.5664 } ;

  float[]  centimeters_to_inches  =
           { 0, 0.3937F, 0.7874F, 1.1811F, 1.5748F, 1.9685F } ;

  const  int  LENGTH_OF_NORMAL_YEAR  =  365 ;
  const  int  LENGTH_OF_LEAP_YEAR    =  366 ;

  const  double  EXACT_LENGTH_OF_YEAR_IN_SECONDS  =  31558149.5 ;

  const  float  EXACT_LENGTH_OF_YEAR_IN_DAYS  =  365.256F ;
*********/

/****
  char  character_from_keyboard ;
  char  user_selection  =  '?' ;
  byte  mask_for_most_significant_bit  =  0x80 ;
  short  given_small_integer ;
  int    integer_from_keyboard ;
  int    character_index  =  0 ;
  uint   bit_mask   =  0x80000000 ;
  long   speed_of_light   =  299793000L ;
  ulong  multiplication_result ;

  float   kilometers_to_miles  = 1.6093F ;
  double  value_of_pi  =  3.14159 ;
  
  bool    text_has_been_modified  =  false ;

****/

   }
}



