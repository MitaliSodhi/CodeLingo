
//  Commanding.cs (c) 2003 Kari Laitinen

using System  ;

class  Commanding
{
   static void Main( string[]  command_line_parameters )
   {
      Console.Write( "\n Method Main() was given the following "
                  +  command_line_parameters.Length + " strings"
                  +  "\n as command line parameters: \n" ) ;

      int  parameter_index  =  0 ;

      while ( parameter_index  <  command_line_parameters.Length )
      {
         Console.Write(
             "\n     " + command_line_parameters[ parameter_index ] ) ;

         parameter_index  ++ ;
      }
   }
}




