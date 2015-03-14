
//  CurrentDate.cs (c) 2003 Kari Laitinen

using  System ;

class  CurrentDate  :  Date
{
   public CurrentDate() 
   {
      DateTime  current_system_date  =  DateTime.Today ;

      this_day    =  current_system_date.Day ;
      this_month  =  current_system_date.Month ;
      this_year   =  current_system_date.Year ;

      date_print_format  =  'A' ;
   }

   public CurrentDate( char given_date_print_format ) 

      : this()
   {
      date_print_format  =  given_date_print_format ;
   }
}





