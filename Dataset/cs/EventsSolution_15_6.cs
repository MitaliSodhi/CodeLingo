
//  EventsSolution_15_6.cs (c) 2004 Kari Laitinen

//  http://www.naturalprogramming.com

//  2004-11-24  File created.
//  2004-11-24  Last modification.

//  Compilation: csc EventsSolution_15_6.cs Date.cs

using System ;
using System.Collections ;

class  Event  :  Date, IComparable
{
   protected string event_description ;

   public Event( int  day_of_event,
                 int  month_of_event,
                 int  year_of_event,
                 string given_event_description )
   {
      this_day   =  day_of_event ;
      this_month =  month_of_event ;
      this_year  =  year_of_event ;

      event_description  =  given_event_description ;
   }

   public override string ToString()
   {
      Date  date_of_event  =  new  Date( this_day,
                                         this_month,
                                         this_year,
                                         date_print_format ) ;

      return ( date_of_event  +  "   "  +  event_description ) ;
   }

   public int CompareTo( object object_to_compare_to )
   {
      Event event_to_compare_to  =  (Event) object_to_compare_to ;

      int  comparison_result  =  0 ;  //  Events of the same date

      if ( this.is_earlier_than( event_to_compare_to ) )
      {
         comparison_result  =  -1 ;   //  "this" has earlier date.
      }
      else if ( this.is_later_than( event_to_compare_to ) )
      {
         comparison_result  =  1 ;    //  "this" has later date.
      }

      return  comparison_result ;
   }
}


class  EventsSolution_15_6
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

      list_of_events.Insert( 1,
         new Event( 30, 7, 1947, "Arnold Schwarzenegger was born." ) ) ;
      list_of_events.Insert( 2,
         new Event( 26, 7, 1943, "Mick Jagger was born." ) ) ;
      list_of_events.Insert( 2,
         new Event( 16, 8, 1958, "Madonna was born." ) ) ;
      list_of_events.Insert( 2,
         new Event(  6, 2, 1945, "Bob Marley was born." ) ) ;
      list_of_events.Reverse() ;

      Console.Write( "\n\nEvents of list_of_events: \n" ) ;

      foreach ( Event  event_on_list  in  list_of_events )
      {
         Console.Write( "\n   "  +  event_on_list ) ;
      }
   }
}





