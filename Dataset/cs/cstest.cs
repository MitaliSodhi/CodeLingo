
//  cstest.cs  (c) 2004 Kari Laitinen

//  I have used this program to test various C# features.

using System ;

using System.Globalization ;
using System.Text ;

class cstest
{
   static void Main()
   {
      short  some_variable  =  255 ;

      Console.Write( "\n The value is:  "  +  some_variable ) ;

      while ( some_variable  >  10 ) 
      {
         Console.Write( " 0" ) ;
      }

   }
}

/******

   static void Main()
   {

      string  given_string  =  "xxxxx" ;

      int  character_index  =  0 ;

      while ( character_index  <  given_string.Length )
      {
         Console.Write( "  "  +  given_string[ character_index ] ) ;

         character_index  ++ ;
      }

   }



class SomeClass
{
   int  some_member ;

   public int SomeProperty
   {
      get
      {
         return  some_member ;
      }

      set
      {
         some_member  =  value ;
      }
   }

}


class cstest
{

   static void Main()
   {

      SomeClass  some_object  =  new  SomeClass() ;

      some_object.SomeProperty  =  99 ;

      //  It is possible to increment the value of a property
      //  with the increment operator ++. The property must have
      //  both get and set accessors.

      some_object.SomeProperty  ++ ;

      Console.Write( "\n   "  +  some_object.SomeProperty ) ;


      int[]  some_array  =  { 1, 3, 99, 2, 44, 1, 7, 33, 22, 8 } ;

      int  integer_index  =  3 ;

      some_array[ integer_index + 1 ]  ++ ;

      Console.Write( "\n   "  +   some_array[ integer_index + 1 ] ) ;


   }
}

*****/

/************

enum  TimeOfYear
{
   WINTER      =   1,
   SPRING      =   4,
   SUMMER      =   7,
   AUTUMN      =  10,
   FALL        =  10
}

class cstest
{
   static int  some_variable  =  5 ;

   static void Main()
   {
      Console.Write( " \n\n    "  +  some_variable ) ;

       const int     RADIUS_OF_SUN_IN_KILOMETERS  =  695950 ;
       const double  VALUE_OF_PI   =  3.1416 ;
   }
}

**********/

/********

   static void Main()
   {
      StringBuilder  some_text  =  new  StringBuilder() ;

      Console.Write( "\n Capacity: " + some_text.Capacity ) ;

      some_text.Append( "12345678901234567890" ) ;

      Console.Write( "\n Capacity: " + some_text.Capacity ) ;
   }
   static void Main()
   {
      string  test_string  =  "xxxxyyyyxxxxzzzz" ;

      Console.Write( "\n" + test_string ) ;

      string  replacement_string  =  null ;

      Console.Write( "\n" + test_string.Replace( "a", "" ) ) ;
   }
   static void Main()
   {
      string[]  array_of_strings  =  { "AAA", "BBB", "CCC", "DDD" } ;

      string    separator_string  =  "xxxx" ;

      string  joined_strings  =  String.Join(  separator_string,
                                               array_of_strings  ) ;
      Console.Write( joined_strings ) ;
   }

   ********

   static void Main()
   {
      Console.Write( "Anna luku: " ) ;

      int given_integer  =  Convert.ToInt32( Console.ReadLine() ) ;

      string  text_to_print  =  String.Format(
                  "{0, 0:D6} is {1, 0:X6} hexadecimal", given_integer,
                                                        given_integer ) ;
      Console.Write( text_to_print ) ;

   }



********
class  Test
{
   public override string ToString()
   {
      return " xx" ;
   }
}

class cstest
{

   static void Main()
   {
      Test  xx  =  new Test() ;
      Test  yy  =  new Test() ;

//      string resulting_string  =  "" + xx + yy ;

      string resulting_string  =  String.Concat( xx, yy, xx ) ;

      string some_string  =  " xx" ;

      if ( some_string.Equals( "" + yy ) )
      {
         Console.Write( "\n  Yes" +  yy ) ;
      }
      else
      {
         Console.Write( "\n  No"  +  yy ) ;
      }

      Console.Write( "\n " + resulting_string ) ;
   }


   ******************
   static void print_array( object[] array_of_objects )
   {
      Console.Write( "\n\n Objects in array:" ) ;

      for ( int object_index  =  0 ;
                object_index  <  array_of_objects.Length ;
                object_index  ++ )
      {
         Console.Write( "   " + array_of_objects[ object_index ] ) ;
      }
   }
   static void print_array( int[] array_of_integers,
                            int   number_of_integers_to_print )
   {
      Console.Write( "\n\n Integers in array:" ) ;

      for ( int integer_index  =  0 ;
                integer_index  <  number_of_integers_to_print ;
                integer_index  ++ )
      {
         Console.Write( "   " + array_of_integers[ integer_index ] ) ;
      }
   }

   static void Main()
   {
      double[]  us_gallons_to_liters  =  new  double[ 6 ]
            { 0.0, 3.785, 7.570, 11.355, 15.140, 18.925 } ;

      double[]  _us_gallons_to_liters  =
            { 0.0, 3.785, 7.570, 11.355, 15.140, 18.925 } ;

      float[]  __us_gallons_to_liters  =
            { 0.0F, 3.785F, 7.570F, 11.355F, 15.140F, 18.925F } ;

      int[]  days_in_months  =  new  int[ 13 ]
            { 0, 31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31 } ;

      char[]  arithmetic_operators  =  { '+', '-', '*', '/', '%' } ;

      int[] test_array  =  new  int[ 6 ] ;

      int[] another_array  =  { 0, 0, 0, 0, 0, 0 } ;

      int[,,] cube  =  new  int[ 4, 5, 6 ] ;

      int[,]  matrix  =  new int[ 4, 5 ] ;

      matrix[ 0, 0 ]  =  1 ;
      matrix[ 0, 4 ]  =  1 ;
      matrix[ 3, 0 ]  =  1 ;
      matrix[ 3, 4 ]  =  1 ;

      print_array( test_array, 6 ) ;

      print_array( another_array, 6 ) ;
   }
   It is possible to calculate with variables of type char
   if appropriate typecastings are made:

   static void Main()
   {
      char  first_char  =  ' ' ;
      char  second_char  =  'A' ;

      second_char  = (char) (  first_char  +  second_char ) ;

      Console.Write( "\n Result: " + second_char ) ;
   }

   static void Main()
   {
      float  some_float  = 400 ;

      double  some_double  =  0x44 ;


      Console.Write( "\n Give a hexadecimal number: " ) ;

      int integer_from_keyboard  =  Int32.Parse(
                           Console.ReadLine(), NumberStyles.HexNumber ) ;

      Console.Write( "\n Annoit luvun: " + integer_from_keyboard ) ;

   }
********/



