
//  letters.cpp (c) 1998-2004 Kari Laitinen

#include  <iostream.h>

void  print_uppercase_letters()
{
   cout << "\n Uppercase English letters are: \n\n" ;

   for ( char letter_to_print  =  'A' ;
              letter_to_print  <= 'Z' ;
              letter_to_print  ++  )
   {
      cout  <<  " "  <<  letter_to_print ;
   }
}

void  print_lowercase_letters()
{
   cout << "\n\n Lowercase English letters are: \n\n" ;

   for ( char letter_to_print  =  'a' ;
              letter_to_print  <= 'z' ;
              letter_to_print  ++ )
   {
      cout  <<  " "  <<  letter_to_print ;
   }
}

void  print_letters()
{
   print_uppercase_letters() ;
   print_lowercase_letters() ;
}

int main()
{
   print_letters() ;
}



