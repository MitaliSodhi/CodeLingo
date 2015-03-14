
//  stringtest.cpp (c) 1999-2002 Kari Laitinen

#include  <iostream.h>
#include  <string>

int main()
{
   string  moviestar_name ;

   moviestar_name  =  "Marilyn Monroe" ;

   string  rockstar_name  =  "Elvis Presley" ;

   string  list_of_stars  =  moviestar_name + ", " + rockstar_name ;

   string  football_star  =  "Pele" ;

   list_of_stars  =  list_of_stars  + ", and " + football_star ;

   cout << "\n The stars are the following: " << list_of_stars  ;

   if ( football_star.find( "" ) != string::npos )
   {
      cout << "\n Empty string belongs to any string.  " ;
   }

}



