
//  ArrayListMethodsWithEnumerator.cs  (c) 2004 Kari Laitinen

//  www.naturalprogramming.com

//  This program works in the same way as ArrayListMethods.cs
//  print_array() method uses an IEnumerator in this version.

using System ;
using System.Collections ;

class ArrayListMethodsWithEnumerator
{
   static void print_array( ArrayList given_array )
   {
      Console.Write( "\n\n " ) ;

      IEnumerator element_to_print  =  given_array.GetEnumerator() ;

      while ( element_to_print.MoveNext() )
      {
         Console.Write(
               element_to_print.Current.ToString().PadLeft( 5 ) ) ;
      }
   }

   static void Main()
   {
      ArrayList  array_of_integers  =  new  ArrayList() ;

      array_of_integers.Add( 202 ) ;
      array_of_integers.Add( 101 ) ;
      array_of_integers.Add( 505 ) ;
      array_of_integers.Add( 404 ) ;

      Console.Write( "\n Value 404 has index:  "
                  +  array_of_integers.IndexOf( 404 )  ) ;

      print_array( array_of_integers ) ;

      array_of_integers.Insert( 2, 999 ) ;
      array_of_integers.Insert( 2, 888 ) ;
      print_array( array_of_integers ) ;

      array_of_integers.RemoveAt( 4 ) ;
      print_array( array_of_integers ) ;

      array_of_integers.Remove( 888 ) ;
      print_array( array_of_integers ) ;

      ArrayList  array_of_characters  =  ArrayList.Repeat( 'Z', 5 ) ;
      print_array( array_of_characters ) ;

      array_of_integers.AddRange( array_of_characters ) ;
      print_array( array_of_integers ) ;

      array_of_integers.RemoveRange( 3, 6 ) ;
      print_array( array_of_integers ) ;

      array_of_integers.Clear() ;
      array_of_integers.Add( 99.99 ) ;
      print_array( array_of_integers ) ;
   }
}



