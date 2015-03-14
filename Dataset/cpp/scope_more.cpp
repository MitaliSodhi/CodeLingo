
//  scope_more.cpp (c) 2002 Kari Laitinen

#include  <iostream.h>


/*  The purpose of this program is to check how C++ compilers
    allocate space for the sub-local variables defined inside
    loops. It seems that both Borland C++ 5.5.1 and Microsoft
    C++ compilers reserve permanent space for the sub-locals.
    Permanent space means that the space is reserved for the
    entire lifetime of the function.
    I thought that the space of variable_yyy would be released
    and the same space would be allocalted to variable_zzz
    but this does not happen.
*/

void  test_variables()
{

   do
   {
      int  variable_yyy  =  0x5555 ;

      cout << "\n variable_yyy (loop)   contains "<< variable_yyy
           << " in address " << (long) &variable_yyy ;
   }
      while ( 1 == 0 ) ;

   do
   {
      int  variable_zzz  =  0x6666 ;

      cout << "\n variable_zzz (loop)   contains "<< variable_zzz
           << " in address " << (long) &variable_zzz ;
   }
      while ( 1 == 0 ) ;

   int  variable_xxx  =  0x4444 ;

   cout << "\n variable_xxx (local)  contains " << variable_xxx
        << " in address " << (long) &variable_xxx ;
}


int main()
{
   cout << hex ;

   test_variables() ;

}



