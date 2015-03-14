
//  calendars.cpp  (c) 1999-2002 Kari Laitinen

//  02.07.1999  File created.
//  10.12.2002  Last modification.

#include  <iostream.h>
#include  <iomanip.h>
#include  "class_date.h"

class  English_calendar
{
protected:
   int  this_month ;
   int  this_year ;

   char**  names_of_months ;
   char*   week_description ;

public:
   English_calendar( int given_month  =  12,
                     int given_year   =  2004 ) ;
   void  print( ostream& output_stream ) ;
} ;

English_calendar::English_calendar( int given_month,
                                int given_year )
{
   static char*  english_names_of_months[]  =  

      { "January", "February", "March", "April",
        "May", "June", "July", "August",
        "September", "October", "November", "December" } ;

   static char   english_week_description[]  =

       " Week   Mon  Tue  Wed  Thu  Fri  Sat  Sun" ;

   this_month  =  given_month ;
   this_year   =  given_year  ;

   names_of_months   =  english_names_of_months ;

   week_description  =  english_week_description ;
}


void  English_calendar::print( ostream& output_stream )
{
   Date a_day_in_this_month( 1, this_month, this_year ) ;

   int day_of_week_index   =  0 ;

   int day_of_week_of_first_day  =
               a_day_in_this_month.index_for_day_of_week() ;

   output_stream 
        <<  "\n\n   "  <<  names_of_months[ this_month - 1 ]
        <<  "  "  <<  this_year  << "\n\n"
        <<  week_description  <<  "\n\n"  << setw( 4 )
        <<  a_day_in_this_month.get_week_number() << "  " ;

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


class  Spanish_calendar  :  public  English_calendar
{
public:
   Spanish_calendar( int given_month  =  1,
                     int given_year   =  2005 ) ;
} ;

Spanish_calendar::Spanish_calendar( int given_month,
                                    int given_year )

      : English_calendar( given_month, given_year )

{
   static char*  spanish_names_of_months[]  =

   { "Enero", "Febrero", "Marzo", "Abril",
     "Mayo", "Junio", "Julio", "Agosto",
     "Septiembre", "Octubre", "Noviembre", "Deciembre" } ;

   static char   spanish_week_description[]  =

     "Semana  Lun  Mar  Mie  Jue  Vie  Sab  Dom" ;


   names_of_months   =  spanish_names_of_months ;
   week_description  =  spanish_week_description ;
}

int main()
{
   English_calendar  an_english_calendar( 5, 2005 ) ;

   an_english_calendar.print( cout ) ;

   Spanish_calendar  a_spanish_calendar( 2, 2008 ) ;

   a_spanish_calendar.print( cout ) ;
}



