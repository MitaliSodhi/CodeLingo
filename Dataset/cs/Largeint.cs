
//  Largeint.cs  (c) 2003 Kari Laitinen

//  03.04.2003  File created.
//  05.04.2003  Last modification.

using System ;

class Largeint
{
   static void Main()
   {
      Console.Write( "\n This program can find the largest of three"
                  +  "\n integers you enter from the keyboard. \n\n") ;

      Console.Write( " Please, enter the first integer:  " ) ;
      int first_integer  =  Convert.ToInt32( Console.ReadLine() ) ;

      Console.Write( " Please, enter the second integer: " ) ;
      int second_integer  =  Convert.ToInt32( Console.ReadLine() ) ;

      Console.Write( " Please, enter the third integer:  " ) ;
      int third_integer  =  Convert.ToInt32( Console.ReadLine() ) ;

      int found_largest_integer ;

      if ( first_integer  >  second_integer )
      {
         found_largest_integer  =  first_integer ;
      }
      else
      {
         found_largest_integer  =  second_integer ;
      }

      if ( third_integer  >  found_largest_integer )
      {
         found_largest_integer  =  third_integer ;
      }

      Console.Write( "\n The largest integer is "
                  +  found_largest_integer  +  ".\n" ) ;
   }
}



