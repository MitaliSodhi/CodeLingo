
//  weddingdates_better.cpp (c) 1999-2004 Kari Laitinen

//  This program works in the same way as weddingdates.cpp
//  but this one includes the file <iostream> instead of
//  <iostream.h> and there is the appropriate using statement.
//  This program can probably be compiled with a wider range of
//  of C++ compilers as this is a more standard C++ program.

#include  <iostream>
#include  <sstream>   // class stringstream etc.
#include  <string>    // class string etc.

using namespace std ;

#include  "class_current_date.h"

int main()
{
   Current_date  date_to_increment ;

   int   number_of_dates_printed  =  0 ;

   cout <<"\n These are easy-to-remember dates for weddings and"
          "\n other important events because the days and months"
          "\n consist of the digits used in the year: \n" ;

   while ( number_of_dates_printed  <  60 )
   {
      stringstream  date_as_stream ;

      date_as_stream  <<  date_to_increment ;

      string  day_as_string, month_as_string, year_as_string ;

      // date_as_stream contains the date in the American format
      // MM/DD/YYYY because that is the default format in class
      // Current_date. Next we use the getline function to extract
      // the different parts of the date.

      getline( date_as_stream, month_as_string, '/' ) ;
      getline( date_as_stream, day_as_string,   '/' ) ;
      getline( date_as_stream, year_as_string ) ;

      if ( day_as_string.find_first_not_of( year_as_string ) ==
                                                      string::npos  &&
           month_as_string.find_first_not_of( year_as_string ) ==
                                                      string::npos  )
      {
         // Now we have found a date that meets our requirements.

         if ( number_of_dates_printed  %  5  ==  0 )
         {
            cout  <<  "\n" ;
         }

         cout << "   " << date_to_increment  ;

         number_of_dates_printed  ++  ;
      }

      date_to_increment.increment() ;
   }
}


/******

   Here the above program is implemented by using standard
   C-style strings and corresponding streams.


#include  <iostream.h>
#include  <iomanip.h>
#include  <strstrea.h>  // definitions for strstream etc.
#include  <string.h>
#include  <time.h>

#include  "date_class.h"
#include  "current_date_class.h"

void  main()
{
   Current_date  date_to_increment ;

   int   number_of_dates_printed  =  0 ;

   cout <<"\n The following might be nice dates for weddings and"
          "\n other important events because the digits used in"
          "\n days and months are also in the year. So these "
          "\n dates should be easy to remember: \n" ;

   while ( number_of_dates_printed  <  60 )
   {
      strstream  date_as_stream ;

      date_as_stream  <<  date_to_increment ;

      char  day_as_string[ 5 ] ;
      char  month_as_string[ 5 ] ;
      char  year_as_string[ 7 ] ;

      date_as_stream.getline( month_as_string,
                              sizeof( month_as_string ), '/' ) ;
      date_as_stream.getline( day_as_string,
                              sizeof( day_as_string ),   '/' ) ;
      date_as_stream.getline( year_as_string,
                              sizeof( year_as_string ) ) ;


      if ( strchr( year_as_string, day_as_string[ 0 ] )   &&
           strchr( year_as_string, day_as_string[ 1 ] )   &&
           strchr( year_as_string, month_as_string[ 0 ] ) &&
           strchr( year_as_string, month_as_string[ 1 ] ) )
      {
         // Now we have found a date that meet our requirements.

         if ( number_of_dates_printed  %  5  ==  0 )
         {
            cout  <<  "\n" ;
         }

         cout << "   " << date_to_increment  ;

         number_of_dates_printed  ++  ;
      }

      date_to_increment.increment() ;
   }
}

******************/




