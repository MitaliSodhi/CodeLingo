
//  december_calendars.cpp  (c) 1997 - 2002 Kari Laitinen

//  15.10.2001  File created.
//  10.12.2002  Last modification.


#include  <iostream.h>
#include  <iomanip.h>
#include  <string.h>
#include  "class_date.h"


char*  names_of_months[]  =  

   { "January", "February", "March", "April",
     "May", "June", "July", "August",
     "September", "October", "November", "December" } ;


class  Month_calendar
{
protected:
   int  this_month ;
   int  this_year ;

   Date first_day_of_month ;

public:
   Month_calendar( int given_month  =  1,
                   int given_year   =  1999 ) ;
   void  print( ostream& output_stream ) ;
} ;

Month_calendar::Month_calendar( int given_month,
                                int given_year )
{
   this_month  =  given_month ;
   this_year   =  given_year  ;

   first_day_of_month  =  Date( 1, this_month, this_year ) ;
}


void  Month_calendar::print( ostream& output_stream )
{
   int day_of_week_index   =  0 ;

   int day_of_week_of_first_day  =
                  first_day_of_month.index_for_day_of_week() ;

   Date a_day_in_this_month( first_day_of_month ) ;

   output_stream 
        <<  "\n\n   "  <<  names_of_months[ this_month - 1 ]
        <<  "  "  <<  this_year  << "\n\n"
        <<  " Week   Mon  Tue  Wed  Thu  Fri  Sat  Sun\n\n" ;

   output_stream  << setw( 4 )
                  << first_day_of_month.get_week_number() << "  " ;


   // The first week of a month is often an incomplete week, 
   // i.e., the first part of week belongs to the previous
   // month. In place of the days that belong to the previous
   // month we print just spaces.

   while ( day_of_week_index != day_of_week_of_first_day )
   {
      output_stream  <<  "     "  ;
      day_of_week_index  ++ ;
   }

   while ( this_month  ==  a_day_in_this_month.month() )
   {
      if ( day_of_week_index  >=  7 )
      {
         output_stream  <<  "\n"  <<  setw( 4 )
                        <<  a_day_in_this_month.get_week_number()
                        << "  " ;

         day_of_week_index  =  0 ;
      }

      output_stream  <<  setw( 5 )
                     <<  a_day_in_this_month.day() ;

      a_day_in_this_month.increment() ;
      day_of_week_index  ++  ;
   }

   output_stream  <<  "\n" ;
}


void  print_calendar_of_a_month( int year, int month )
{

   Month_calendar  desired_month_calendar( month, year ) ;

   desired_month_calendar.print( cout ) ;
}


int main()
{
   for ( int year  =  1888 ;
             year  <  2012 ;
             year  ++ )
   {
      print_calendar_of_a_month( year, 12 ) ;

   }

}



