
//  days10000.cpp  (c) 1998-2002 Kari Laitinen

#include  <iostream.h>
#include  "class_date.h"

int main()
{
   char  date_of_birth_as_string[ 20 ] ;

   cout << "\n Type in your date of birth either as DD.MM.YYYY "
           "\n or as MM/DD/YYYY. Use two digits for days and months "
           "\n and four digits for the year:  " ;

   cin.getline( date_of_birth_as_string,
                sizeof( date_of_birth_as_string ) ) ;

   Date  date_of_birth( date_of_birth_as_string ) ;

   Date  date_to_increment( date_of_birth ) ;

   int   day_counter  =  0 ;

   while  (  day_counter  <  10000  )
   {
      date_to_increment.increment() ;
      day_counter  ++ ;
   }

   cout <<  "\n\n   You are 10000 days old on " 
        <<  date_to_increment ;

   while  (  day_counter  <  20000 )
   {
      date_to_increment.increment() ;
      day_counter  ++ ;
   }

   cout <<  "\n   You are 20000 days old on "
        <<  date_to_increment ;
}



