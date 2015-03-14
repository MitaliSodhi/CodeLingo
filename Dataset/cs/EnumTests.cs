
//  EnumTests.cs  (c) 2004 Kari Laitinen

//  www.naturalprogramming.com

using System ;

enum  TimeOfYear
{
   WINTER      =   1,
   SPRING      =   4,
   SUMMER      =   7,
   AUTUMN      =  10,
   FALL        =  10
}

enum SpanishDayOfWeek
{
   Lunes,
   Martes,
   Miercoles,
   Jueves,
   Viernes,
   Sabado,
   Domingo
}

/*  My understanding is that, when an enum constant like
    SpanishDayOfWeek.Miercoles is concatenated to a string
    with the operator +, the constant is first converted to
    an Enum object in an automatic (implicit) boxing
    operation, and then the ToString() method is invoked
    for the boxed enum value. The ToString() of class Enum
    works so that in returns a string that contains the
    constant name as a string.  */

class EnumTests
{
   static void Main()
   {
      SpanishDayOfWeek  some_day  =  SpanishDayOfWeek.Domingo ;

      Console.Write( "\n "  +  some_day ) ; // Prints a string!

      Console.Write( "\n "  +  (int) some_day ) ; // Prints a number!

      string  some_string  =  "zzzzz "  +  SpanishDayOfWeek.Miercoles ;

      Console.Write( "\n "  +  some_string ) ;

   }
}



