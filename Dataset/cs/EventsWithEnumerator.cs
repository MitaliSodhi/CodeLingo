
//  EventsWithEnumerator.cs (c) 2004 Kari Laitinen

//  www.naturalprogramming.com

//  This program works like Events.cs.
//  An enumerator is used here to iterate through the an array.

//  Compilation: csc EventsWithEnumerator.cs Date.cs

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

      int  comparison_result  =  0 ;  //  This means equal objects

      if ( this.is_earlier_than( event_to_compare_to ) )
      {
         comparison_result  =  -1 ;
      }
      else if ( this.is_later_than( event_to_compare_to ) )
      {
         comparison_result  =  1 ;
      }

      return  comparison_result ;
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

      IEnumerator event_on_list  =  list_of_events.GetEnumerator() ;

      while ( event_on_list.MoveNext() )
      {
         Console.Write( "\n   "  +  event_on_list.Current ) ;
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

      event_on_list  =  another_event_list.GetEnumerator() ;

      while ( event_on_list.MoveNext() )
      {
         Console.Write( "\n   "  +  event_on_list.Current ) ;
      }

      list_of_events.Sort() ;
      another_event_list.Sort() ;

      list_of_events.InsertRange( 0, another_event_list ) ;

      Console.Write( "\n\nEvents of list_of_events: \n" ) ;

      event_on_list  =  list_of_events.GetEnumerator() ;

      while ( event_on_list.MoveNext() )
      {
         Console.Write( "\n   "  +  event_on_list.Current ) ;
      }
   }
}





