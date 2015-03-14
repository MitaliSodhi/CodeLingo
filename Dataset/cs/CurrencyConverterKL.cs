
//  CurrencyConverterKL.cs  (c) 2004 Kari Laitinen

//  http://www.naturalprogramming.com

//  2004-10-28  File created.
//  2004-11-05  Last modification.

using System ;

class CurrencyConverterKL
{
   static void Main()
   {
      Console.Write( "\n Type D to convert Dollars to Yen, or"
                  +  "\n type Y to convert Yen to Dollars!     " ) ;

      char currency_selection  =  Convert.ToChar( Console.ReadLine() ) ;

      double  amount_of_yen, amount_of_dollars  ;

      //  On October 28, 2004, you needed 106.61 Yen to buy
      //  one U.S. dollar.

      double  exchange_rate  =  106.61 ;

      if ( ( currency_selection  ==  'D' ) || 
           ( currency_selection  ==  'd' ) )
      {
         Console.Write( "\n Give dollar amount to convert: " ) ;
         amount_of_dollars  =  Convert.ToDouble( Console.ReadLine() ) ;

         amount_of_yen   =   exchange_rate  *  amount_of_dollars ;

         Console.Write( "\n "  +  amount_of_dollars  +  " U.S. dollars is "
                     +  amount_of_yen  +  " Japanese yen\n" ) ;
      }
      else if ( ( currency_selection  ==  'Y' ) ||
                ( currency_selection  ==  'y' ) )
      {
         Console.Write( "\n Give yen amount to convert: " ) ;
         amount_of_yen  =  Convert.ToDouble( Console.ReadLine() ) ;

         amount_of_dollars   =   amount_of_yen  /  exchange_rate ;

         Console.Write( "\n "  +  amount_of_yen  +  " Japanese yen is "
                     +  amount_of_dollars  +  " U.S. dollars\n" ) ;
      }
      else
      {
         Console.Write( "\n I do not understand \""
                     +  currency_selection   +  "\".\n" ) ;
      }
   }
}



