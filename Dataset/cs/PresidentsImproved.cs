
//  PresidentsImproved.cs  (c) 2004 Kari Laitinen

//  http://www.naturalprogramming.com

//  2004-11-12  File created.
//  2004-11-12  Last modification.

//  Compilation: csc PresidentsImproved.cs Date.cs

//  Solutions to exercises 11-11, 11-12, 11-13, and 11-14.

using System ;

class  President
{
   string  president_name ;
   Date    birth_date_of_president ;
   string  birth_state_of_president ;
   string  party_name ;

   Date    inauguration_date ;
   Date    last_day_in_office  ;
   string  vice_president_name ;

   public President( string  given_president_name,
                     string  birth_date_as_string,
                     string  given_birth_state,
                     string  given_party_name,
                     string  inauguration_date_as_string,
                     string  last_day_in_office_as_string,
                     string  given_vice_president_name )
   {
      president_name  =   given_president_name  ;
      birth_date_of_president  =  new Date( birth_date_as_string ) ;
      birth_state_of_president =  given_birth_state ;
      party_name  =  given_party_name ;
      inauguration_date     =  new Date( inauguration_date_as_string ) ;
      last_day_in_office    =  new Date( last_day_in_office_as_string ) ;
      vice_president_name   =  given_vice_president_name ;
   }

   public string get_president_name()
   {
      return  president_name ;
   }

   public bool was_president_on( Date given_date )
   {
      return ( given_date.is_within_dates( inauguration_date,
                                           last_day_in_office ) ) ;
   }

   public bool was_born_in_state( string  given_state_name )
   {
      return ( birth_state_of_president.IndexOf( given_state_name ) !=  -1 ) ;
   }

   public string get_brief_president_info()
   {
      return ( "\n  "  +  president_name.PadRight( 25 )
            +  " president from  "  +  inauguration_date
            +  " to " +  last_day_in_office  ) ;
   }

   public string get_full_president_data()
   {
      int  years_in_office, months_in_office, days_in_office ;

      inauguration_date.get_distance_to( last_day_in_office,
                                         out  years_in_office,
                                         out  months_in_office,
                                         out  days_in_office ) ;
      return (  "\n  "
           +  president_name  +  "  born  "
           +  birth_date_of_president  +  ", "
           +  birth_state_of_president 
           +  "\n    Inauguration date  : " +  inauguration_date 
           +  "\n    Last day in office : " +  last_day_in_office
           +  "\n    Total time in office: " +  years_in_office
           +  " years, "  +  months_in_office  + " months, and "
           +  days_in_office  +  " days."
           +  "\n    Party: "  +  party_name 
           +  "\n    Vice president(s): "  +  vice_president_name ) ;
   }
}


class  PresidentInfoApplication
{
   President[]  president_table  =  new  President[ 80 ] ;

   int  number_of_presidents_in_table ;
   int  index_of_last_printing ;

   const int  SEARCH_NOT_READY       =  1 ;
   const int  SEARCH_IS_READY        =  2 ;
   const int  SEARCH_IS_SUCCESSFUL   =  3 ;
   const int  SEARCH_NOT_SUCCESSFUL  =  4 ;

   public PresidentInfoApplication()
   {
      president_table[ 0 ]  =  new
       President( "George Washington",   "02/22/1732",  "Virginia",
       "Federalist", "04/30/1789", "03/03/1797", "John Adams");
      president_table[ 1 ]  =  new
       President("John Adams",  "10/30/1735",  "Massachusetts",
       "Federalist", "03/04/1797", "03/03/1801", "Thomas Jefferson");
      president_table[ 2 ]  =  new
       President("Thomas Jefferson", "04/13/1743",  "Virginia", "Dem.-Rep.",
       "03/04/1801", "03/03/1809", "Aaron Burr + George Clinton"); 
      president_table[ 3 ]  =  new
       President("James Madison",  "03/16/1751",  "Virginia", "Dem.-Rep.",
       "03/04/1809", "03/03/1817", "George Clinton + Elbridge Gerry" );
      president_table[ 4 ]  =  new
       President( "James Monroe", "04/28/1758", "Virginia", "Dem.-Rep.",
       "03/04/1817", "03/03/1825", "Daniel D. Tompkins" );
      president_table[ 5 ]  =  new
       President( "John Quincy Adams", "07/11/1767", "Massachusetts",
       "Dem.-Rep.", "03/04/1825", "03/03/1829", "John C. Calhoun" );
      president_table[ 6 ]  =  new
       President( "Andrew Jackson", "03/15/1767", "South Carolina","Democrat",
       "03/04/1829", "03/03/1837", "John C. Calhoun + Martin Van Buren" );
      president_table[ 7 ]  =  new
       President( "Martin Van Buren", "12/05/1782", "New York",
       "Democrat", "03/04/1837", "03/03/1841", "Richard M. Johnson" );
      president_table[ 8 ]  =  new
       President( "William Henry Harrison", "02/09/1773", "Virginia",
       "Whig", "03/04/1841", "04/04/1841", "John Tyler" );
      president_table[ 9 ]  =  new
       President( "John Tyler", "03/29/1790", "Virginia",
       "Whig", "04/06/1841", "03/03/1845", "" );
      president_table[ 10 ]  =  new
       President( "James Knox Polk", "11/02/1795", "North Carolina",
       "Democrat", "03/04/1845", "03/03/1849", "George M. Dallas" );
      president_table[ 11 ]  =  new
       President( "Zachary Taylor", "11/24/1784", "Virginia",
       "Whig", "03/05/1849", "07/09/1850", "Millard Fillmore" );
      president_table[ 12 ]  =  new
       President( "Millard Fillmore", "01/07/1800", "New York",
       "Whig", "07/10/1850", "03/03/1853", "" );
      president_table[ 13 ]  =  new
       President( "Franklin Pierce", "11/23/1804", "New Hampshire",
       "Democrat", "03/04/1853", "03/03/1857", "William R. King" );
      president_table[ 14 ]  =  new
       President( "James Buchanan", "04/23/1791", "Pennsylvania",
       "Democrat", "03/04/1857", "03/03/1861", "John C. Breckinridge");
      president_table[ 15 ]  =  new
       President( "Abraham Lincoln", "02/12/1809", "Kentucky", "Republican",
       "03/04/1861", "04/15/1865", "Hannibal Hamlin + Andrew Johnson" );
      president_table[ 16 ]  =  new
       President( "Andrew Johnson", "12/29/1808", "North Carolina",
       "Democrat", "04/15/1865", "03/03/1869", "" );
      president_table[ 17 ]  =  new
       President( "Ulysses Simpson Grant", "04/27/1822", "Ohio", "Republican",
       "03/04/1869", "03/03/1877", "Schuyler Colfax + Henry Wilson" );
      president_table[ 18 ]  =  new
       President( "Rutherford Birchard Hayes", "10/04/1822", "Ohio",
       "Republican", "03/04/1877", "03/03/1881", "William A. Wheeler");
      president_table[ 19 ]  =  new
       President( "James Abram Garfield", "11/19/1831", "Ohio",
       "Republican", "03/04/1881", "09/19/1881", "Chester Alan Arthur");
      president_table[ 20 ]  =  new
       President( "Chester Alan Arthur", "10/05/1829", "Vermont",
       "Republican", "09/20/1881", "03/03/1885", "" );
      president_table[ 21 ]  =  new
       President( "Grover Cleveland", "03/18/1837", "New Jersey",
       "Democrat", "03/04/1885", "03/03/1889", "Thomas A. Hendrics" );
      president_table[ 22 ]  =  new
       President( "Benjamin Harrison", "08/20/1933", "Ohio",
       "Republican", "03/04/1889", "03/03/1893", "Levi P. Morton" );
      president_table[ 23 ]  =  new
       President( "Grover Cleveland", "03/18/1837", "New Jersey",
       "Democrat", "03/04/1893", "03/03/1897", "Adlai E. Stevenson" );
      president_table[ 24 ]  =  new
       President( "William McKinley", "01/29/1843", "Ohio", "Republican",
       "03/04/1897", "09/14/1901", "Garret A. Hobart + Theodore Roosevelt" );
      president_table[ 25 ]  =  new
       President( "Theodore Roosevelt", "10/27/1858", "New York",
       "Republican", "09/14/1901","03/03/1909","Charles W. Fairbanks");
      president_table[ 26 ]  =  new
       President( "William Howard Taft", "09/15/1857", "Ohio",
       "Republican", "03/04/1909", "03/03/1913", "James S. Sherman");
      president_table[ 27 ]  =  new
       President( "Woodrow Wilson", "12/28/1856", "Virginia",
       "Democrat", "03/04/1913", "03/03/1921", "Thomas R. Marshall" );
      president_table[ 28 ]  =  new
       President( "Warren Gamaliel Harding", "11/02/1865", "Ohio",
       "Republican", "03/04/1921", "08/02/1923", "Calvin Coolidge" );
      president_table[ 29 ]  =  new
       President( "Calvin Coolidge", "07/04/1872", "Vermont",
       "Republican", "08/03/1923", "03/03/1929", "Charles G. Dawes" );
      president_table[ 30 ]  =  new
       President( "Herbert Clark Hoover", "08/10/1874", "Iowa",
       "Republican", "03/04/1929", "03/03/1933", "Charles Curtis" );
      president_table[ 31 ]  =  new
       President( "Franklin Delano Roosevelt","01/30/1882","New York",
       "Democrat", "03/04/1933", "04/12/1945",
       "John N. Garner + Henry A. Wallace + Harry S. Truman" );
      president_table[ 32 ]  =  new
       President( "Harry S. Truman", "05/08/1884", "Missouri",
       "Democrat", "04/12/1945", "01/20/1953", "Alben W. Barkley" );
      president_table[ 33 ]  =  new
       President( "Dwight David Eisenhover", "10/14/1890", "Texas",
       "Republican","01/20/1953","01/20/1961","Richard Milhous Nixon");
      president_table[ 34 ]  =  new
       President( "John Fitzgerald Kennedy", "05/29/1917", "Massachusetts",
       "Democrat", "01/20/1961", "11/22/1963", "Lyndon Baines Johnson" );
      president_table[ 35 ]  =  new
       President( "Lyndon Baines Johnson", "08/27/1908", "Texas",
       "Democrat", "11/22/1963", "01/20/1969", "Hubert H. Humphrey");
      president_table[ 36 ]  =  new
       President( "Richard Milhous Nixon", "01/09/1913", "California",
       "Republican", "01/20/1969", "08/09/1974",
       "Spiro T. Agnew + Gerald Rudolph Ford");
      president_table[ 37 ]  =  new
       President( "Gerald Rudolph Ford", "07/14/1913", "Nebraska",
       "Republican","08/09/1974","01/20/1977","Nelson A. Rockefeller");
      president_table[ 38 ]  =  new
       President( "Jimmy (James Earl) Carter", "10/01/1924", "Georgia",
       "Democrat", "01/20/1977", "01/20/1981", "Walter F. Mondale" );
      president_table[ 39 ]  =  new
       President( "Ronald Wilson Reagan", "02/06/1911", "Illinois",
       "Republican", "01/20/1981", "01/20/1989", "George Bush" ) ;
      president_table[ 40 ]  =  new
       President( "George Bush", "06/12/1924", "Massachusetts",
       "Republican", "01/20/1989", "01/20/1993", "Dan Quayle" ) ; 
      president_table[ 41 ]  =  new
       President( "Bill Clinton", "08/19/1946", "Arkansas",
       "Democrat", "01/20/1993", "01/20/2001", "Albert Gore" ) ;
      president_table[ 42 ]  =  new
       President( "George W. Bush", "07/06/1946", "Connecticut",
       "Republican", "01/20/2001", "01/20/2009", "Richard Cheney" ) ;

      //  The value of the following variable must be updated
      //  when new presidents are added to president_table.

      number_of_presidents_in_table  =  43 ; 

      index_of_last_printing  =  0 ;
   }

   public void search_president_by_name()
   {
      Console.Write( "\n  Enter first, last, or full name of president: ") ;

      string  given_president_name  =  Console.ReadLine() ;

      int  president_index      =  0 ;
      int  array_search_status  =  SEARCH_NOT_READY ;

      while ( array_search_status == SEARCH_NOT_READY )
      {
         if ( president_table[ president_index ].get_president_name()
              .IndexOf( given_president_name )  !=  -1 )
         {
            array_search_status  =  SEARCH_IS_SUCCESSFUL ;
         }
         else if ( president_index  >=  number_of_presidents_in_table - 1 )
         {
            array_search_status  =  SEARCH_NOT_SUCCESSFUL ;
         }
         else
         {
            president_index  ++  ;
         }
      }

      if ( array_search_status  ==  SEARCH_IS_SUCCESSFUL )
      {
         Console.Write( "\n\n  THE #"  +  ( president_index + 1 ) 
              +  " PRESIDENT OF THE UNITED STATES:  \n" 

              +  president_table[ president_index ].
                                 get_full_president_data() ) ;

         index_of_last_printing  =  president_index ;
      }
      else
      {
         Console.Write( "\n\n  Sorry, could not find \""
              +  given_president_name  +  "\" in table.\n" ) ;
      }
   }

   public void search_president_for_given_date()
   {
      Console.Write( "\n Please, type in a date in form MM/DD/YYYY "
                  +  "\n Use two digits for days and months, and "
                  +  "\n four digits for year:  " ) ;

      string  date_as_string  =  Console.ReadLine() ;

      Date  date_of_interest  =  new  Date( date_as_string ) ;

      int  president_index      =  0 ;
      int  array_search_status  =  SEARCH_NOT_READY ;

      while ( array_search_status == SEARCH_NOT_READY )
      {
         if ( president_table[ president_index ].
                             was_president_on( date_of_interest ) )
         {
            array_search_status  =  SEARCH_IS_SUCCESSFUL ;
         }
         else if ( president_index  >=  number_of_presidents_in_table - 1)
         {
            array_search_status  =  SEARCH_NOT_SUCCESSFUL ;
         }
         else
         {
            president_index  ++  ;
         }
      }

      if ( array_search_status  ==  SEARCH_IS_SUCCESSFUL )
      {
         Console.Write( "\n\n  ON "   +  date_of_interest
              + ", THE PRESIDENT OF THE UNITED STATES WAS: \n"

              + president_table[ president_index ].
                              get_full_president_data() ) ;

         index_of_last_printing  =  president_index ;
      }
      else
      {
         Console.Write( "\n\n  Sorry, no president was on duty on "
                     +  date_of_interest  + ".\n" ) ;
      }
   }

   public void search_presidents_born_in_certain_state()
   {
      Console.Write( "\n Please, type in a state name: " ) ;

      string  given_state  =  Console.ReadLine() ;

      Console.Write( "\n The presidents born in "  +  given_state
                  +  " are:  \n" ) ;

      int  president_index      =  0 ;

      while ( president_index  <  number_of_presidents_in_table ) 
      {
         if ( president_table[ president_index ].
                             was_born_in_state( given_state ) )
         {
            Console.Write( president_table[ president_index ].
                                              get_brief_president_info() ) ;
         }

         president_index  ++  ;
      }
   }

   public void print_data_of_next_president()
   {
      index_of_last_printing   ++  ;

      if ( index_of_last_printing  <  number_of_presidents_in_table )
      {
         Console.Write( "\n\n  THE #"  +  ( index_of_last_printing + 1 ) 
              + " PRESIDENT OF THE UNITED STATES:  \n" 

              + president_table[ index_of_last_printing ].
                                     get_full_president_data() ) ;
      }
      else
      {
         Console.Write( "\n Sorry, no more presidents in table." ) ;
      }
   }

   public void print_data_of_previous_president()
   {
      if ( index_of_last_printing  >  0 )
      {
         index_of_last_printing   --  ;

         Console.Write( "\n\n  THE #"  +  ( index_of_last_printing + 1 ) 
              + " PRESIDENT OF THE UNITED STATES:  \n" 

              + president_table[ index_of_last_printing ].
                                     get_full_president_data() ) ;
      }
      else
      {
         Console.Write( "\n Sorry, no previous presidents." ) ;
      }
   }

   public void print_list_of_all_presidents()
   {
      int  president_index  =  0 ;

      while ( president_index  <  number_of_presidents_in_table )
      {
         Console.Write( president_table[ president_index ].
                                      get_brief_president_info() ) ;
         president_index  ++ ;

         if ( ( president_index  %  15 ) ==  0 )
         {
            Console.Write( "\nPress <Enter> to continue ....." ) ;
            string  any_string_from_keyboard  =  Console.ReadLine() ;
         }
      }
   }


   public void run()
   {
      string  user_selection  =  "????"  ;

      Console.Write("\n This program provides information about all"
                 +  "\n presidents of the U.S.A. Please, select from"
                 +  "\n the following menu by typing in a letter. ") ;

      while ( user_selection[ 0 ]  !=  'e' &&
              user_selection[ 0 ]  !=  'q' )  //  Solution to 11-11.
      {
         Console.Write("\n\n   p   Search president by name."
                      +  "\n   d   Search president for a given date."
                      +  "\n   s   Search presidents born in certain state."
                      +  "\n   n   Print data of next president."
                      +  "\n   f   Print date of former (previous) president"
                      +  "\n   a   Print list of all presidents."
                      +  "\n   e or q   Exit the program.\n\n   " ) ;

         user_selection  =  Console.ReadLine() ;

         //  The first "if" is the solution to Exercise 11-4

         if ( user_selection.Length  ==  0 )
         {
            //  The user hit only the Enter key.

            user_selection  =  "????" ;
         }
         else if ( user_selection[ 0 ]  ==  'p' )
         {
            search_president_by_name() ;
         }
         else if ( user_selection[ 0 ]  ==  'd' )
         {
            search_president_for_given_date() ;
         }
         else if ( user_selection[ 0 ]  ==  's' )
         {
            search_presidents_born_in_certain_state() ;
         }
         else if ( user_selection[ 0 ]  ==  'n' )
         {
            print_data_of_next_president() ;
         }
         else if ( user_selection[ 0 ]  ==  'f' )
         {
            print_data_of_previous_president() ;
         }
         else if ( user_selection[ 0 ]  ==  'a' )
         {
            print_list_of_all_presidents() ;
         }
      }
   }
}


class  PresidentInfoApplicationRunner
{
   static void Main()
   {
      PresidentInfoApplication  this_president_info_application
                                  = new PresidentInfoApplication() ;

      this_president_info_application.run() ;
   }
}



