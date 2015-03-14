
//  Letters.cs  (c) 2004 Kari Laitinen

using System ;

class Letters
{
   static void print_uppercase_letters()
   {
      Console.Write( "\n Uppercase English letters are: \n\n" ) ;

      for ( char letter_to_print  =  'A' ;
                 letter_to_print  <= 'Z' ;
                 letter_to_print  ++  )
      {
         Console.Write(  " "  +  letter_to_print ) ;
      }
   }

   static void print_lowercase_letters()
   {
      Console.Write( "\n\n Lowercase English letters are: \n\n" ) ;

      for ( char letter_to_print  =  'a' ;
                 letter_to_print  <= 'z' ;
                 letter_to_print  ++ )
      {
         Console.Write(  " "  +  letter_to_print ) ;
      }
   }

   static void print_letters()
   {
      print_uppercase_letters() ;
      print_lowercase_letters() ;
   }

   static void Main()
   {
      print_letters() ;
   }
}



