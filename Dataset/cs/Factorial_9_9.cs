
//  Factorial_9_9.cs  (c) 2004 Kari Laitinen

//  http://www.naturalprogramming.com

//  2004-11-06  File created.
//  2004-11-06  Last modification.

//  A solution to Exercise 9-9.

using System ;

class Factorial_9_9
{
   static void print_factorial( int given_integer ) 
   {
      Console.Write( "\n The factorial of "  +  given_integer
                  +  " is "  +  given_integer  +  "! = " ) ;

      int  calculated_factorial  =  1  ;

      while ( given_integer  >  1 )
      {
         calculated_factorial  =  calculated_factorial  *  given_integer ;

         Console.Write( given_integer  +  "*" ) ;

         given_integer  --  ;
      }

      Console.Write(  "1 = "  +  calculated_factorial ) ;
   }


   static void Main( string[] command_line_parameters )
   {
      int  integer_from_keyboard ;

      if ( command_line_parameters.Length  ==  1 )
      {
         integer_from_keyboard  =  
                  Convert.ToInt32( command_line_parameters[ 0 ] ) ;
      }
      else
      {
         Console.Write( "\n Type in a positive integer: " ) ;
         integer_from_keyboard = Convert.ToInt32( Console.ReadLine());
      }

      print_factorial( integer_from_keyboard ) ;
   }
}



