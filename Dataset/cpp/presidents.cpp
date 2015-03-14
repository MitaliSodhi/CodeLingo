
//  presidents.cpp  (c) 1997-2002 Kari Laitinen

//  17.01.1997   File created.
//  13.08.2002   iomanip.h not used by this file any more.
//  06.11.2004   Last modification.

#include <iostream.h>
#include <string.h>
#include "useful_functions.h"
#include "useful_constants.h"
#include "class_date.h"

class  President
{
protected:
   char   president_name             [ 40 ] ;
   Date   birth_date_of_president ;
   char   birth_state_of_president   [ 20 ] ;
   char   party_name                 [ 20 ] ;

   Date   inauguration_date ;
   Date   last_date_of_service  ;
   char   vice_president_name        [ 60 ] ;

public:
   President() {}
   President( char [], char [], char [], char [],
              char [], char [], char [] ) ;
   char* get_president_name() { return  president_name ; }

   bool  was_president_on( Date  given_date ) ;
   void  print_brief_president_info() ;
   void  print_full_president_data() ;
} ;

President::President( char  given_president_name[],
                      char  birth_date_as_string[],
                      char  given_birth_state[],
                      char  given_party_name[],
                      char  inauguration_date_as_string[],
                      char  last_date_of_service_as_string[],
                      char  given_vice_president_name[] )
{
   strcpy( president_name, given_president_name ) ;
   birth_date_of_president  =  Date( birth_date_as_string ) ;
   strcpy( birth_state_of_president, given_birth_state ) ;
   strcpy( party_name, given_party_name ) ;
   inauguration_date     =  Date( inauguration_date_as_string ) ;
   last_date_of_service  =  Date( last_date_of_service_as_string ) ;
   strcpy( vice_president_name, given_vice_president_name ) ;
}


bool President::was_president_on( Date given_date )
{
   return ( given_date.is_within_dates( inauguration_date,
                                        last_date_of_service ) ) ;
}


void President::print_brief_president_info()
{
   char  president_name_to_print[ 80 ] ;

   strcpy( president_name_to_print, president_name ) ;
   strcat( president_name_to_print, "                           " ) ;
   president_name_to_print[ 25 ]  =  0 ; // NULL at the end of string

   cout <<  "\n  "  <<  president_name_to_print
        <<  " president from  "  <<  inauguration_date
        <<  " to " <<  last_date_of_service  ;
}

void President::print_full_president_data()
{
   int  years_of_service, months_of_service, days_of_service ;

   inauguration_date.get_distance_to( last_date_of_service,
                                      years_of_service,
                                      months_of_service,
                                      days_of_service ) ;
   cout <<  "\n  "
        <<  president_name  <<  "  born  "
        <<  birth_date_of_president  <<  ", "
        <<  birth_state_of_president 
        <<  "\n    Inauguration date : " << inauguration_date 
        <<  "\n    Last date of service : " <<  last_date_of_service
        <<  "\n    Total service time: " <<  years_of_service
        <<  " years, "  <<  months_of_service  << " months, and "
        <<  days_of_service  <<  " days."
        <<  "\n    Party: "  <<  party_name 
        <<  "\n    Vice president(s): "  <<  vice_president_name ;
}


class  President_info_application
{
protected:

   President  president_table[ 80 ] ;

   int        number_of_presidents_in_table ;
   int        index_of_last_printing ;

public:

   President_info_application() ;
   void  search_president_by_name() ;
   void  search_president_for_given_date() ;
   void  print_data_of_next_president() ;
   void  print_list_of_all_presidents() ;

   void  run() ;
} ;

President_info_application::President_info_application()
{
   President  data_of_all_presidents []  =
   {
    President( "George Washington",   "02/22/1732",  "Virginia",
    "Federalist", "04/30/1789", "03/03/1797", "John Adams"),
    President("John Adams",  "10/30/1735",  "Massachusetts",
    "Federalist", "03/04/1797", "03/03/1801", "Thomas Jefferson"),
    President("Thomas Jefferson", "04/13/1743",  "Virginia",
    "Dem.-Rep.", "03/04/1801", "03/03/1809",
    "Aaron Burr + George Clinton"), 
    President("James Madison",  "03/16/1751",  "Virginia",
    "Dem.-Rep.","03/04/1809", "03/03/1817",
    "George Clinton + Elbridge Gerry" ),
    President( "James Monroe", "04/28/1758", "Virginia", "Dem.-Rep.",
    "03/04/1817", "03/03/1825", "Daniel D. Tompkins" ),
    President( "John Quincy Adams", "07/11/1767", "Massachusetts",
    "Dem.-Rep.", "03/04/1825", "03/03/1829", "John C. Calhoun" ),
    President( "Andrew Jackson", "03/15/1767", "South Carolina",
    "Democrat", "03/04/1829", "03/03/1837",
    "John C. Calhoun + Martin Van Buren" ),
    President( "Martin Van Buren", "12/05/1782", "New York",
    "Democrat", "03/04/1837", "03/03/1841", "Richard M. Johnson" ),
    President( "William Henry Harrison", "02/09/1773", "Virginia",
    "Whig", "03/04/1841", "04/04/1841", "John Tyler" ),
    President( "John Tyler", "03/29/1790", "Virginia",
    "Whig", "04/06/1841", "03/03/1845", "" ),
    President( "James Knox Polk", "11/02/1795", "North Carolina",
    "Democrat", "03/04/1845", "03/03/1849", "George M. Dallas" ),
    President( "Zachary Taylor", "11/24/1784", "Virginia",
    "Whig", "03/05/1849", "07/09/1850", "Millard Fillmore" ),
    President( "Millard Fillmore", "01/07/1800", "New York",
    "Whig", "07/10/1850", "03/03/1853", "" ),
    President( "Franklin Pierce", "11/23/1804", "New Hampshire",
    "Democrat", "03/04/1853", "03/03/1857", "William R. King" ),
    President( "James Buchanan", "04/23/1791", "Pennsylvania",
    "Democrat", "03/04/1857", "03/03/1861", "John C. Breckinridge"),
    President( "Abraham Lincoln", "02/12/1809", "Kentucky",
    "Republican", "03/04/1861", "04/15/1865",
    "Hannibal Hamlin + Andrew Johnson" ),
    President( "Andrew Johnson", "12/29/1808", "North Carolina",
    "Democrat", "04/15/1865", "03/03/1869", "" ),
    President( "Ulysses Simpson Grant", "04/27/1822", "Ohio",
    "Republican", "03/04/1869", "03/03/1877",
    "Schuyler Colfax + Henry Wilson" ),
    President( "Rutherford Birchard Hayes", "10/04/1822", "Ohio",
    "Republican", "03/04/1877", "03/03/1881", "William A. Wheeler"),
    President( "James Abram Garfield", "11/19/1831", "Ohio",
    "Republican", "03/04/1881", "09/19/1881", "Chester Alan Arthur"),
    President( "Chester Alan Arthur", "10/05/1829", "Vermont",
    "Republican", "09/20/1881", "03/03/1885", "" ),
    President( "Grover Cleveland", "03/18/1837", "New Jersey",
    "Democrat", "03/04/1885", "03/03/1889", "Thomas A. Hendrics" ),
    President( "Benjamin Harrison", "08/20/1933", "Ohio",
    "Republican", "03/04/1889", "03/03/1893", "Levi P. Morton" ),
    President( "Grover Cleveland", "03/18/1837", "New Jersey",
    "Democrat", "03/04/1893", "03/03/1897", "Adlai E. Stevenson" ),
    President( "William McKinley", "01/29/1843", "Ohio",
    "Republican", "03/04/1897", "09/14/1901",
    "Garret A. Hobart + Theodore Roosevelt" ),
    President( "Theodore Roosevelt", "10/27/1858", "New York",
    "Republican", "09/14/1901","03/03/1909","Charles W. Fairbanks"),
    President( "William Howard Taft", "09/15/1857", "Ohio",
    "Republican", "03/04/1909", "03/03/1913", "James S. Sherman"),
    President( "Woodrow Wilson", "12/28/1856", "Virginia",
    "Democrat", "03/04/1913", "03/03/1921", "Thomas R. Marshall" ),
    President( "Warren Gamaliel Harding", "11/02/1865", "Ohio",
    "Republican", "03/04/1921", "08/02/1923", "Calvin Coolidge" ),
    President( "Calvin Coolidge", "07/04/1872", "Vermont",
    "Republican", "08/03/1923", "03/03/1929", "Charles G. Dawes" ),
    President( "Herbert Clark Hoover", "08/10/1874", "Iowa",
    "Republican", "03/04/1929", "03/03/1933", "Charles Curtis" ),
    President( "Franklin Delano Roosevelt","01/30/1882","New York",
    "Democrat", "03/04/1933", "04/12/1945",
    "John N. Garner + Henry A. Wallace + Harry S. Truman" ),
    President( "Harry S. Truman", "05/08/1884", "Missouri",
    "Democrat", "04/12/1945", "01/20/1953", "Alben W. Barkley" ),
    President( "Dwight David Eisenhover", "10/14/1890", "Texas",
    "Republican","01/20/1953","01/20/1961","Richard Milhous Nixon"),
    President( "John Fitzgerald Kennedy", "05/29/1917",
    "Massachusetts", "Democrat", "01/20/1961", "11/22/1963",
    "Lyndon Baines Johnson" ),
    President( "Lyndon Baines Johnson", "08/27/1908", "Texas",
    "Democrat", "11/22/1963", "01/20/1969", "Hubert H. Humphrey"),
    President( "Richard Milhous Nixon", "01/09/1913", "California",
    "Republican", "01/20/1969", "08/09/1974",
    "Spiro T. Agnew + Gerald Rudolph Ford"),
    President( "Gerald Rudolph Ford", "07/14/1913", "Nebraska",
    "Republican","08/09/1974","01/20/1977","Nelson A. Rockefeller"),
    President( "Jimmy (James Earl) Carter", "10/01/1924", "Georgia",
    "Democrat", "01/20/1977", "01/20/1981", "Walter F. Mondale" ),
    President( "Ronald Wilson Reagan", "02/06/1911", "Illinois",
    "Republican", "01/20/1981", "01/20/1989", "George Bush" ),
    President( "George Bush", "06/12/1924", "Massachusetts",
    "Republican", "01/20/1989", "01/20/1993", "Dan Quayle" ), 
    President( "Bill Clinton", "08/19/1946", "Arkansas",
    "Democrat", "01/20/1993", "01/20/2001", "Albert Gore" ),
    President( "George W. Bush", "07/06/1946", "Connecticut",
    "Republican", "01/20/2001", "01/20/2009", "Richard Cheney" )
   } ;

   number_of_presidents_in_table  =  sizeof( data_of_all_presidents )
                                     / sizeof( President ) ;

   move_objects( number_of_presidents_in_table,
                 data_of_all_presidents,
                 president_table ) ;

   index_of_last_printing  =  0 ;
}

void
President_info_application::search_president_by_name()
{
   char  given_president_name[ 40 ] ;

   cout << "\n  Enter first, last, or full name of president: " ;
   cin.getline( given_president_name, sizeof( given_president_name ) ) ;

   int  president_index         =  0 ;
   int  table_search_status  =  SEARCH_NOT_READY ;

   while ( table_search_status == SEARCH_NOT_READY )
   {
      if ( strstr(
              president_table[ president_index ].get_president_name(),
              given_president_name ) )
      {
         table_search_status  =  SEARCH_WAS_SUCCESSFUL ;
      }
      else if ( president_index  >=  number_of_presidents_in_table - 1 )
      {
         table_search_status  =  SEARCH_NOT_SUCCESSFUL ;
      }
      else
      {
         president_index  ++  ;
      }
   }

   if ( table_search_status  ==  SEARCH_WAS_SUCCESSFUL )
   {
      cout << "\n\n  THE #"  <<  ( president_index + 1 ) 
           << " PRESIDENT OF THE UNITED STATES:  \n" ;

      president_table[ president_index ].
                              print_full_president_data() ;

      index_of_last_printing  =  president_index ;
   }
   else
   {
      cout << "\n\n  Sorry, could not find \""
           <<  given_president_name  <<  "\" in table.\n" ;
   }
}

void
President_info_application::search_president_for_given_date()
{
   char  date_as_string[ 20 ] ;

   cout << "\n Please, type in a date in form MM/DD/YYYY "
           "\n Use two digits for days and months, and "
           "\n four digits for year:  "  ;
   cin.getline( date_as_string, sizeof( date_as_string ) ) ;

   Date  date_of_interest( date_as_string ) ;

   int  president_index         =  0 ;
   int  table_search_status  =  SEARCH_NOT_READY ;

   while ( table_search_status == SEARCH_NOT_READY )
   {
      if ( president_table[ president_index ].
                             was_president_on( date_of_interest ) )
      {
         table_search_status  =  SEARCH_WAS_SUCCESSFUL ;
      }
      else if ( president_index  >=  number_of_presidents_in_table - 1)
      {
         table_search_status  =  SEARCH_NOT_SUCCESSFUL ;
      }
      else
      {
         president_index  ++  ;
      }
   }

   if ( table_search_status  ==  SEARCH_WAS_SUCCESSFUL )
   {
      cout << "\n\n  ON "   <<  date_of_interest
           << ", THE PRESIDENT OF THE UNITED STATES WAS: \n" ;

      president_table[ president_index ].
                              print_full_president_data() ;

      index_of_last_printing  =  president_index ;
   }
   else
   {
      cout << "\n\n  Sorry, no president was on duty on "
           <<  date_of_interest  << ".\n" ;
   }
}

void
President_info_application::print_data_of_next_president()
{
   index_of_last_printing   ++  ;

   if ( index_of_last_printing  <  number_of_presidents_in_table )
   {
      cout << "\n\n  THE #"  <<  ( index_of_last_printing + 1 ) 
           << " PRESIDENT OF THE UNITED STATES:  \n" ;

      president_table[ index_of_last_printing ].
                              print_full_president_data() ;
   }
   else
   {
      cout << "\n Sorry, no more presidents in table." ;
   }
}

void
President_info_application::print_list_of_all_presidents()
{
   int  president_index  =  0 ;

   while ( president_index  <  number_of_presidents_in_table )
   {
      president_table[ president_index ].
                             print_brief_president_info() ;
      president_index  ++ ;

      if ( ( president_index  %  15 ) ==  0 )
      {
         char useless_string[ 10 ] ;
         cout << "\nPress <Enter> to continue ....." ;
         cin.getline( useless_string, sizeof( useless_string ) ) ;
      }
   }
}


void
President_info_application::run()
{
   char  user_selection[]  =  "????"  ;

   cout << "\n This program provides information about all"
           "\n presidents of the U.S.A. Please, select from"
           "\n the following menu by typing in a letter. " ;

   while ( user_selection[ 0 ]  !=  'e' )
   {
      cout << "\n\n   p   Search president by name."
                "\n   d   Search president for a given date."
                "\n   n   Print data of next president."
                "\n   a   Print list of all presidents."
                "\n   e   Exit the program.\n\n   " ;

      cin.getline( user_selection, sizeof( user_selection ) ) ;

      if ( user_selection[ 0 ]  ==  'p' )
      {
         search_president_by_name() ;
      }
      else if ( user_selection[ 0 ]  ==  'd' )
      {
         search_president_for_given_date() ;
      }
      else if ( user_selection[ 0 ]  ==  'n' )
      {
         print_data_of_next_president() ;
      }
      else if ( user_selection[ 0 ]  ==  'a' )
      {
         print_list_of_all_presidents() ;
      }
   }
}

int main()
{
   President_info_application  this_president_info_application ;

   this_president_info_application.run() ;
}


