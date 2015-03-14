
//  titanic.cpp  (c) 2000-2002 Kari Laitinen

#include  <iostream.h>

#include  "class_current_date.h"

int main()
{
   Date  date_when_titanic_sank( "04/15/1912" ) ;

   Current_date  date_of_today ;

   int   years_ago, months_ago, days_ago ;

   date_of_today.get_distance_to( date_when_titanic_sank,
                                  years_ago,
                                  months_ago,
                                  days_ago ) ;

   cout << "\n Today it is " << date_of_today
        << ".\n On " << date_when_titanic_sank
        << ", the famous ship \"Titanic\" went to"
        << "\n the bottom of Atlantic Ocean."
        << "\n That happened " << years_ago << " years, "
        << months_ago  << " months, and "
        << days_ago    << " days ago. \n\n" ;
}



