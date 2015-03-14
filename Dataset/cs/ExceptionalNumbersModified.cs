
//  ExceptionalNumbersModified.cs  (c) 2004 Kari Laitinen

//  http://www.naturalprogramming.com

//  2004-11-18  File created.
//  2004-11-18  Last modification.

//  The modifications proposed in Exercises 13-1 and 13-2 are
//  made into this program, but it is your task to study
//  the effect of the modifications.

using System ;

class  NumberTooSmallException : Exception
{
}

class  NumberTooLargeException : Exception
{
}

class ExceptionalNumbers
{
   static int get_number_from_keyboard()
   {
      int number_from_keyboard  =  Convert.ToInt32( Console.ReadLine() ) ;

      if ( number_from_keyboard  <=  99 )
      {
         throw new NumberTooSmallException() ;
      }
      else if ( number_from_keyboard  >=  999 )
      {
         throw new NumberTooLargeException() ;
      }

      return number_from_keyboard ;
   }

   static int get_number()
   {
      int number_from_above_method  =  1234 ;

      try
      {
         number_from_above_method  =  get_number_from_keyboard() ;
      }
      catch ( Exception )
      {
         Console.Write( "\n Exception caught by get_number(). " ) ;
      }
      finally
      {
         Console.Write( "\n finally block of get_number() executed. " ) ;
      }

      return  number_from_above_method ;
   }

   static void Main()
   {
      Console.Write( " Please, type in a number: " ) ;

      try
      {
         int  number_read_via_several_methods  =  get_number() ;

         Console.Write( "\n The number from keyboard is : "
                     +  number_read_via_several_methods  ) ;
      }
      catch ( NumberTooLargeException )
      {
         Console.Write( "\n NumberTooLargeException caught. " ) ;
      }
      catch ( Exception caught_exception )
      {
         Console.Write( "\n Some Exception was caught. Some info: "
                     +  "\n "  +  caught_exception.ToString() ) ;
      }
      finally
      {
         Console.Write( "\n finally block of Main() executed. " ) ;
      }
   }
}



