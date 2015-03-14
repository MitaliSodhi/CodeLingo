
//  months.cpp (c) 1998-2002 Kari Laitinen

#include  <iostream.h>

int main()
{
   char*  names_of_months[]  =

      { "January", "February", "March", "April", "May", "June",
        "July", "August", "September", "October", "November",
        "December"  }  ;

   cout <<  "\n The first month of year is "
        <<  names_of_months[ 0 ]  <<  "." ;

   cout <<  "\n\n The seventh month, " << names_of_months[ 6 ]
        <<  ", is named after Julius Caesar.\n" ;

   cout << hex << "\n Let's explore the memory: \n" ;

   for ( int month_index  =  0 ;
             month_index  <  4 ;
             month_index  ++  )
   {
      cout<< "\n Address " << (long) &names_of_months[ month_index ]
          << " contains "  << (long)  names_of_months[ month_index ]
          << " (Address of \""  <<    names_of_months[ month_index ]
          << "\")" ;
   }

   cout  <<  "\n" ;
   char*  memory_pointer  =  names_of_months[ 0 ] ;

   while ( *memory_pointer != 'b' )
   {
      cout << "\n Address " << (long) memory_pointer 
           << " contains  " << (int) *memory_pointer
           << "   "         <<       *memory_pointer ;
      memory_pointer  ++ ;
   }
}


