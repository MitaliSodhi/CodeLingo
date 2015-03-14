
//  YearcalendarKL.cs  (c) 2003 Kari Laitinen

//  http://www.naturalprogramming.com

//  2004-11-14  File created.
//  2004-11-14  Last modification.

//  compile: csc YearcalendarKL.cs Date.cs

//  A solution to exercise 12-5.

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


class  YearcalendarKL
{
   static void Main( string[] command_line_parameters )
   {
      if ( command_line_parameters.Length  ==  2 )
      {
         int given_year  =  Convert.ToInt32( command_line_parameters[ 1 ] ) ;

         string  requested_calendar_language  =
                         command_line_parameters[ 0 ].ToLower() ;

         if ( ( "spanish" ).IndexOf( requested_calendar_language ) !=  -1 )
         {
            for ( int month  =  1 ; month < 13 ; month ++ )
            {
               SpanishCalendar spanish_month_calendar  =
                                   new  SpanishCalendar( month, given_year ) ;

               spanish_month_calendar.print() ;
            }
         }
         else
         {
            for ( int month  =  1 ; month < 13 ; month ++ )
            {
               EnglishCalendar english_month_calendar  =
                                   new  EnglishCalendar( month, given_year ) ;

               english_month_calendar.print() ;
            }
         }
      }
      else
      {
         Console.Write( "\n  Wrong number of command line parameters.\n" ) ;
      }
   }
}


