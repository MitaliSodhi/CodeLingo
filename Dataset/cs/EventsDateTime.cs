
//  EventsDateTime.cs (c) 2004 Kari Laitinen

//  http://www.naturalprogramming.com

//  2004-02-12  File created.
//  2004-11-24  Last modification.

//  A solution to Exercise 15-9.

//  This version uses struct DateTime instead of class Date.


using System ;
using System.Collections ;

class  Event  : IComparable
{
   protected  DateTime  date_of_event ;
   protected  string    event_description ;

   public Event( int  day_of_event,
                 int  month_of_event,
                 int  year_of_event,
                 string given_event_description )
   {
      date_of_event  =  new  DateTime( year_of_event,
                                       month_of_event,
                                       day_of_event ) ;

      event_description  =  given_event_description ;
   }

   public override string ToString()
   {
      return ( date_of_event.ToShortDateString().PadRight( 10 ) 
            +  "   "  +  event_description ) ;
   }

   public int CompareTo( object object_to_compare_to )
   {
      Event event_to_compare_to  =  (Event) object_to_compare_to ;

      return  date_of_event.CompareTo(
                          event_to_compare_to.date_of_event ) ;
   }
}


class  Events
{
   static void Main()
   {
      Event  birth_of_lennon   =  new  Event(
                 9, 10, 1940, "John Lennon was born.") ;
      Event  birth_of_einstein =  new  Event(
                14,  3, 1879, "Albert Einstein was born." ) ;

      ArrayList  list_of_events  =  new  ArrayList() ;

      list_of_events.Add( birth_of_lennon ) ;
      list_of_events.Add( birth_of_einstein ) ;
      list_of_events.Add( new
          Event( 8, 12, 1980, "John Lennon was shot in New York." ) ) ;

      Console.Write( "\nEvents of list_of_events: \n" ) ;

      int event_index  =  0 ;

      while ( event_index  <  list_of_events.Count )
      {
         Console.Write( "\n   "  +  list_of_events[ event_index ] ) ;
         event_index  ++ ;
      }

      ArrayList  another_event_list  =  new  ArrayList() ;

      another_event_list.Insert( 0,
         new Event( 1, 6, 1926, "Marilyn Monroe was born." ) ) ;
      another_event_list.Insert( 0,
         new Event( 5, 8, 1962, "Marilyn Monroe died." ) ) ;
      another_event_list.Add(
         new Event(15, 8, 1769, "Napoleon Bonaparte was born." ) ) ;
      another_event_list.Add(
         new Event(25,10, 1881, "Pablo Picasso was born." ) ) ;


      Console.Write( "\n\nEvents of another_event_list: \n" ) ;

      for ( event_index  =  0 ;
            event_index  <  another_event_list.Count ;
            event_index  ++ )
      {
         Console.Write( "\n   "  +  another_event_list[ event_index ] ) ;
      }

      list_of_events.Sort() ;
      another_event_list.Sort() ;

      list_of_events.InsertRange( 0, another_event_list ) ;

      Console.Write( "\n\nEvents of list_of_events: \n" ) ;

      foreach ( Event  event_on_list  in  list_of_events )
      {
         Console.Write( "\n   "  +  event_on_list ) ;
      }
   }
}





