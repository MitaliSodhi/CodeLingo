
//  age_in_days.cpp  (c) 1998-2002 Kari Laitinen

#include  <iostream.h>
#include  "class_date.h"

int main()
{
   Date  date_of_birth( "14.07.1977" ) ;
   Date  current_date( "22.02.2002" ) ;

   int   day_counter  =  0 ;

   while  (  date_of_birth  <  current_date  )
   {
      date_of_birth.increment() ;
      day_counter  ++ ;
   }

   cout << "\n You are now " << day_counter << " days old.\n" ;
}



