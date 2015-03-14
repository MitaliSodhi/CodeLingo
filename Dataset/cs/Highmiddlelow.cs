
//  Highmiddlelow.cs (c) 2003 Kari Laitinen

using System ;

class  MemberClass
{
   public MemberClass( string  object_identifier )
   {
      Console.Write( "\n MemberClass object \"" 
                    +  object_identifier  + "\" was created." ) ;
   }
}

class  HighClass 
{
   MemberClass  some_data_member ;
   MemberClass  another_data_member 
                    =  new  MemberClass( "another_data_member" ) ;

   public HighClass()
   {
      Console.Write( "\n The constructor of HighClass started.") ;

      some_data_member  =  new  MemberClass( "some_data_member" ) ;

      Console.Write( "\n The constructor of HighClass ended.") ;
   }
}

class  MiddleClass  :  HighClass
{
   public MiddleClass()
   {
      Console.Write( "\n The constructor of MiddleClass started.");
      Console.Write( "\n The constructor of MiddleClass ended.");
   }

}

class  LowClass  :  MiddleClass
{
   MemberClass data_member_in_low_class  =
                   new MemberClass( "data_member_in_low_class" );

   public LowClass()
   {
      Console.Write( "\n The constructor of LowClass started." ) ;
      Console.Write( "\n The constructor of LowClass ended." ) ;
   }
} 

class Highmiddlelow
{
   static void Main()
   {
      LowClass  low_class_object  =  new  LowClass() ;
   }
}



