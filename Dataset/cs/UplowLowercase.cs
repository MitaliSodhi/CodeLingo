
//  Uplow.cs  (c) 2004 Kari Laitinen

//  http://www.naturalprogramming.com

//  2004-11-25  File created.
//  2004-11-25  Last modification.

//  A solution to Exercise 16-2.

using System ;
using System.Text ;  // Class StringBuilder etc.

class Uplow
{
   static string convert_string_lowercase( string given_string )
   {
      StringBuilder modified_string  =  new StringBuilder( given_string ) ;

      int  character_index  =  0 ;

      while ( character_index  <  modified_string.Length )
      {
         if ( modified_string[ character_index ]  >=  'A'  &&
              modified_string[ character_index ]  <=  'Z'  )
         {
            modified_string[ character_index ]  =  
               (char)  ( modified_string[ character_index ]  |  0x20 ) ;
         }

         character_index  ++  ;
      }

      return  modified_string.ToString() ;
   }

   static string convert_string_uppercase( string given_string )
   {
      StringBuilder modified_string  =  new StringBuilder( given_string ) ;

      int  character_index  =  0 ;

      while ( character_index  <  modified_string.Length )
      {
         if ( modified_string[ character_index ]  >=  'a'  &&
              modified_string[ character_index ]  <=  'z'  )
         {
            modified_string[ character_index ]  =  
               (char)  ( modified_string[ character_index ]  &  0xDF ) ;
         }

         character_index  ++  ;
      }

      return  modified_string.ToString() ;
   }

   static void Main()
   {
      string  test_string  =    "Hejlsberg, Wiltamuth, and Golde"
                             +  " are inventors of C#." ;

      Console.Write( "\n Original string:   "  +  test_string ) ;

      string  uppercase_string  =  convert_string_uppercase( test_string ) ;

      Console.Write( "\n After conversion:  "  +  uppercase_string ) ;

      Console.Write( "\n Better conversion: "
                  +  test_string.ToUpper() ) ;

      string  lowercase_string  =  convert_string_lowercase( test_string ) ;

      Console.Write( "\n After lowercasing: "  +  lowercase_string ) ;

      Console.Write( "\n Better lowercasing:"
                  +  test_string.ToLower() ) ;
   }
}






