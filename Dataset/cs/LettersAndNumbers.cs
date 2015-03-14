
//  LettersAndNumbers.cs  (c) 2004 Kari Laitinen

//  http://www.naturalprogramming.com

//  2004-11-05  File created.
//  2004-11-05  Last modification.

//  Solution to exercise 9-1.

using System ;

class LettersAndNumbers
{
   static void print_numerical_symbols()
   {
      Console.Write( "\n\n Our numerical symbols are: \n\n" ) ;

      for ( char numerical_symbol_to_print  =  '0' ;
                 numerical_symbol_to_print  <= '9' ;
                 numerical_symbol_to_print  ++  )
      {
         Console.Write(  " "  +  numerical_symbol_to_print ) ;
      }

      //  Alternatively you can write the above loop in the
      //  following way:

      // for ( int number_to_print  =   0 ;
      //           number_to_print  <=  9 ;
      //           number_to_print  ++  )
      // {
      //    Console.Write(  " "  +  number_to_print ) ;
      // }
   }

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

   static void print_letters_and_numbers()
   {
      print_uppercase_letters() ;
      print_lowercase_letters() ;
      print_numerical_symbols() ;
   }

   static void Main()
   {
      print_letters_and_numbers() ;
   }
}



