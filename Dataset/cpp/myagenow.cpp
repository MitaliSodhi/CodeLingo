
//  myagenow.cpp  (c) 1999-2002 Kari Laitinen

#include  <iostream.h>
#include  <iomanip.h>
#include  <time.h>
#include  "class_date.h"
#include  "class_current_date.h"

int main()
{
   Date          birthday( 12, 9, 1968 ) ;
   Current_date  today ;

   int   years_of_age, months_of_age, days_of_age ;

   birthday.get_distance_to( today,
                             years_of_age,
                             months_of_age,
                             days_of_age   ) ;

   cout  << "\n\n  My age is : "
         << years_of_age  << " years "
         << months_of_age << " months "
         << days_of_age   << " days.\n\n" ;
}


