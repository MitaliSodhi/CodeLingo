
//  FirstMultilanguageVersion.cs  (c) 2004 Kari Laitinen

//  www.naturalprogramming.com

//#define  ENGLISH_LANGUAGE_SELECTED
#define  SPANISH_LANGUAGE_SELECTED
//#define  GERMAN_LANGUAGE_SELECTED

using System ;

class First
{
   static void Main()
   {
      #if  ENGLISH_LANGUAGE_SELECTED
         Console.Write( "I am a simple computer program." ) ;
      #elif  SPANISH_LANGUAGE_SELECTED
         Console.Write( "Soy una programa simple para un ordenador." ) ;
      #elif  GERMAN_LANGUAGE_SELECTED
         Console.Write( "Ich bin ein ...." ) ;
      #else
         Console.Write( "\n Application Error." ) ;
         Console.Write( "\n No output language has been selected." ) ;
      #endif
   }
}



