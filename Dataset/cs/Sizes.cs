//  Sizes.cs  (c) 2004 Kari Laitinen

//  www.naturalprogramming.com

//  Compilation: csc Sizes.cs /unsafe

using System ;

struct  TestStruct
{
   public long  a_long_member ;
   public int   an_int_member ;
}

class  Sizes
{
   unsafe static void Main()
   {
      Console.Write(
            "\n The following are the sizes of the basic variable"
         +  "\n types of C#:\n"
         +  "\n    byte        "   +  sizeof( byte )
         +  "\n    sbyte       "   +  sizeof( sbyte )
         +  "\n    char        "   +  sizeof( char )
         +  "\n    short       "   +  sizeof( short )
         +  "\n    ushort      "   +  sizeof( ushort )
         +  "\n    int         "   +  sizeof( int )
         +  "\n    uint        "   +  sizeof( uint )
         +  "\n    long        "   +  sizeof( long )
         +  "\n    ulong       "   +  sizeof( ulong )
         +  "\n    bool        "   +  sizeof( bool )
         +  "\n    float       "   +  sizeof( float )
         +  "\n    double      "   +  sizeof( double )
         +  "\n    decimal     "   +  sizeof( decimal )
         +  "\n    int*        "   +  sizeof( int* )
         +  "\n    void*       "   +  sizeof( void* )  + "\n" ) ;

      Console.Write(
            "\n The size of TestStruct is  "  + sizeof( TestStruct ) ) ;
   }
}



