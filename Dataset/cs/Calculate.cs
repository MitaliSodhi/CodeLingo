
//  Calculate.cs  (c) 2003 Kari Laitinen

using System ;

class Calculate
{
   static void print_calculations ( int first_integer,
                                    int second_integer )
   {
      Console.Write( "\n    "  +  first_integer  +  " + "
                  +  second_integer  +  " = "
                  +  ( first_integer  +  second_integer ) 
                  +  "\n    "  +  first_integer  +  " - "
                  +  second_integer  +  " = "
                  +  ( first_integer - second_integer )
                  +  "\n    "  +  first_integer  +  " * "
                  +  second_integer  +  " = "
                  +  first_integer * second_integer ) ;

      if ( second_integer  !=  0 )
      {
         Console.Write( "\n    "  +  first_integer  +  " / "
                     +  second_integer  +  " = "
                     +  first_integer / second_integer
                     +  "\n    "  +  first_integer  +  " % "
                     +  second_integer  +  " = "
                     +  first_integer % second_integer  +  "\n" ) ;
      }
      else
      {
         Console.Write( "\n    Cannot divide with zero. \n" ) ;
      }
   }

   static void Main( string[] command_line_parameters )
   {
      int  first_operand, second_operand ;

      if ( command_line_parameters.Length  ==  2 )
      {
         first_operand   =  Convert.ToInt32( command_line_parameters[ 0 ] ) ;
         second_operand  =  Convert.ToInt32( command_line_parameters[ 1 ] ) ;

         print_calculations( first_operand, second_operand ) ;
      }
      else
      {
         Console.Write( "\n This program calculates with integers."
                     +  "\n\n   Give first integer:   " ) ;
         first_operand   =  Convert.ToInt32( Console.ReadLine() ) ;
         Console.Write( "   Give second integer:  " ) ;
         second_operand  =  Convert.ToInt32( Console.ReadLine() ) ;

         print_calculations( first_operand, second_operand ) ;
      }
   }
}



