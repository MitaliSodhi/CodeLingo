
//  events.cpp (c) 1999-2002 Kari Laitinen

#include  <iostream.h>
#include  <string>
#include  <list>

#include  "class_date.h"

class  Event  :  public  Date
{
protected:
   string  event_description ;

public:
   Event( int  day_of_event,
          int  month_of_event,
          int  year_of_event,
          char given_event_description[] )
   {
      this_day   =  day_of_event ;
      this_month =  month_of_event ;
      this_year  =  year_of_event ;

      event_description  =  given_event_description ;
   }

   friend ostream& operator<<( ostream&  output_stream,
                               Event&    event_to_output )
   {
      Date  date_of_event( event_to_output.this_day,
                           event_to_output.this_month,
                           event_to_output.this_year,
                           event_to_output.date_print_format ) ;

      output_stream << date_of_event  <<  "   "
                    <<  event_to_output.event_description ;

      return  output_stream ;
   }
} ;


int main()
{
   Event  birth_of_lennon(
              9, 10, 1940, "John Lennon was born.") ;
   Event  birth_of_einstein(
             14,  3, 1879, "Albert Einstein was born." ) ;

   list<Event>  list_of_events ;

   list_of_events.push_back( birth_of_lennon ) ;
   list_of_events.push_back( birth_of_einstein ) ;
   list_of_events.push_back(
          Event( 8, 12, 1980, "John Lennon was shot in New York." ) ) ;

   cout << "\nEvents of list_of_events: \n" ;

   list<Event>::iterator event_on_list  = list_of_events.begin() ;

   while ( event_on_list  !=  list_of_events.end() )
   {
      cout << "\n   "  <<  *event_on_list ;

      event_on_list ++ ;
   }

   list<Event>  another_event_list ;

   another_event_list.push_front(
          Event( 1, 6, 1926, "Marilyn Monroe was born." ) ) ;
   another_event_list.push_front(
          Event( 5, 8, 1962, "Marilyn Monroe died." ) ) ;
   another_event_list.push_back(
          Event(15, 8, 1769, "Napoleon Bonaparte was born." ) ) ;
   another_event_list.push_back(
          Event(25,10, 1881, "Pablo Picasso was born." ) ) ;


   cout << "\n\nEvents of another_event_list: \n" ;

   event_on_list  =  another_event_list.begin() ;

   while ( event_on_list  !=  another_event_list.end() )
   {
      cout << "\n   " <<  *event_on_list ;

      event_on_list ++ ;
   }

   list_of_events.sort() ;
   another_event_list.sort() ;

   list_of_events.splice( list_of_events.begin(),
                          another_event_list ) ;

   cout << "\n\nEvents of list_of_events: \n" ;

   event_on_list  = list_of_events.begin() ;

   while ( event_on_list  !=  list_of_events.end() )
   {
      cout << "\n   "  <<  *event_on_list ;

      event_on_list ++ ;
   }
}




