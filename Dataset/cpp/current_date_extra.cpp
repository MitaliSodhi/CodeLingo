
//  current_date_extra.cpp (c) 1999-2002 Kari Laitinen

//  This version includes "class_current_date_extra.h"
//  instead of "class_current_date.h".

#include  <iostream.h>
#include  <iomanip.h>
#include  <time.h>

#include  "class_date.h"
#include  "class_current_date_extra.h"


int main()
{
   Current_date  date_now ;
   Current_date  european_date( 'E' ) ;

   cout << "\n\n Now it is: " << date_now
        << "\n The same printed in European way: "<< european_date
        << "\n It is " ;

   date_now.print_day_of_week( cout ) ;

   cout << " today. \n" ;
}


