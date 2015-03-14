
//  Calendars.cs  (c) 2003 Kari Laitinen

//  compile: csc Calendars.cs Date.cs

using System ;

class  EnglishCalendar
{
   protected  int  this_month ;
   protected  int  this_year ;

   protected  string[]  names_of_months ;
   protected  string    week_description ;

   public EnglishCalendar() {}

   public EnglishCalendar( int given_month, int given_year )
   {
      string[]  english_names_of_months  =  

         { "January", "February", "March", "April",
           "May", "June", "July", "August",
           "September", "October", "November", "December" } ;

      string  english_week_description  =

          " Week   Mon  Tue  Wed  Thu  Fri  Sat  Sun" ;

      names_of_months   =  english_names_of_months ;

      week_description  =  english_week_description ;

      this_month  =  given_month ;
      this_year   =  given_year  ;
   }


   public void print()
   {
      Date a_day_in_this_month  =  new  Date( 1, this_month, this_year ) ;

      int day_of_week_index   =  0 ;

      int day_of_week_of_first_day  =
                          a_day_in_this_month.index_for_day_of_week() ;

      Console.Write(
            "\n\n   "  +  names_of_months[ this_month - 1 ]
         +  "  "  +  this_year  +  "\n\n"  +  week_description   +  "\n\n" 
         +  a_day_in_this_month.get_week_number().ToString().PadLeft( 4 ) 
         +  "  " ) ;

      // The first week of a month is often an incomplete week, 
      // i.e., the first part of week belongs to the previous
      // month. In place of the days that belong to the previous
      // month we print just spaces.

      while ( day_of_week_index != day_of_week_of_first_day )
      {
         Console.Write( "     " )  ;
         day_of_week_index  ++ ;
      }

      while ( this_month  ==  a_day_in_this_month.month() )
      {
         if ( day_of_week_index  >=  7 )
         {
            Console.Write( "\n"  + 
              a_day_in_this_month.get_week_number().ToString().PadLeft( 4 )
              +  "  ") ;

            day_of_week_index  =  0 ;
         }

         Console.Write( a_day_in_this_month.day().ToString().PadLeft( 5 ) ) ;

         a_day_in_this_month.increment() ;

         day_of_week_index  ++  ;
      }

      Console.Write( "\n" ) ;
   }
}



class  SpanishCalendar  :  EnglishCalendar
{
   public SpanishCalendar( int given_month, int given_year )
   {
      string[]  spanish_names_of_months  =


         { "Enero", "Febrero", "Marzo", "Abril",
           "Mayo", "Junio", "Julio", "Agosto",
           "Septiembre", "Octubre", "Noviembre", "Deciembre" } ;

      string   spanish_week_description  =

           "Semana  Lun  Mar  Mie  Jue  Vie  Sab  Dom" ;

      names_of_months   =  spanish_names_of_months ;
      week_description  =  spanish_week_description ;

      this_month  =  given_month ;
      this_year   =  given_year  ;
   }
}


class  Calendars
{
   static void Main()
   {
      EnglishCalendar  an_english_calendar  =
                           new  EnglishCalendar( 5, 2005 ) ;

      an_english_calendar.print() ;

      SpanishCalendar  a_spanish_calendar  =
                           new  SpanishCalendar( 2, 2008 ) ;

      a_spanish_calendar.print() ;
   }
}


