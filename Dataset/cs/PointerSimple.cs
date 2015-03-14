
//  PointerSimple.cs  (c) 2004 Kari Laitinen

//  www.naturalprogramming.com

//  Compilation: csc PointerSimple.cs /unsafe

using System ;

class PointerSimple
{
   unsafe static void Main()
   {
      int  first_integer   =  44, second_integer  =  66,
           third_integer   =  88 ;

      int*  pointer_to_integer ;

      Console.Write(
                     "\n Address of first_integer:  {0, 0:X8}" +  
                     "\n Address of second_integer: {1, 0:X8}" +
                     "\n Address of third_integer:  {2, 0:X8}",
                    (int) &first_integer, (int) &second_integer,
                    (int) &third_integer ) ;

      Console.Write(
         "\n\n first   second  third   *pointer    pointer \n" ) ;

      pointer_to_integer   =  &first_integer ;

      Console.Write( "\n   {0}     {1}       {2}       ",
                    first_integer, second_integer, third_integer ) ;
      Console.Write( "{0}       {1, 0:X8}", *pointer_to_integer,
                                      (int) pointer_to_integer ) ;

      second_integer      =  *pointer_to_integer ;
      *pointer_to_integer =  333 ;

      Console.Write( "\n  {0}     {1}       {2}      ",
                    first_integer, second_integer, third_integer ) ;
      Console.Write( "{0}       {1, 0:X8}", *pointer_to_integer,
                                      (int) pointer_to_integer ) ;

      pointer_to_integer  =  &third_integer ;
      *pointer_to_integer =  999 ;

      Console.Write( "\n  {0}     {1}      {2}      ",
                    first_integer, second_integer, third_integer ) ;
      Console.Write( "{0}       {1, 0:X8}\n", *pointer_to_integer,
                                        (int) pointer_to_integer ) ;
   }
}



