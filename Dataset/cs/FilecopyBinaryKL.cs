
//  FilecopyBinaryKL.cs  (c) 2004 Kari Laitinen

//  www.naturalprogramming.com

//  2003-12-09  File created.
//  2004-11-19  Last modification.

//  This program works in the same way as Filecopy.cs except
//  that the given file is copied as a binary file.

//  A solution to Exercise 14-7.

using System ;
using System.IO ;  // Classes for file handling.

class FilecopyBinaryKL
{
   static void Main()
   {
      Console.Write( "\n This program copies text from one file"
                   + "\n to another file. Please, give the name of"
                   + "\n the file to be copied: " ) ;

      string  name_of_file_to_be_copied  =  Console.ReadLine() ;

      Console.Write( "\n Give the name of the duplicate file: " ) ;

      string  name_of_new_duplicate_file  =  Console.ReadLine() ;

      try
      {
         FileStream file_to_be_copied  =
                          File.OpenRead( name_of_file_to_be_copied ) ;

         FileStream new_duplicate_file  =
                          File.Open( name_of_new_duplicate_file,
                                     FileMode.Create,
                                     FileAccess.Write ) ;

         Console.Write( "\n Copying in progress ... \n" ) ;

         int  total_number_of_bytes_copied  =  0 ;

         //  If this program were used for serious file copying
         //  operations, it might be better to use a larger array
         //  (input buffer) into which bytes are read.

         byte[]  bytes_from_file  =  new  byte[ 128 ] ;

         int number_of_bytes_read  ;

         while (( number_of_bytes_read  =
                    file_to_be_copied.Read( bytes_from_file, 0,
                                            bytes_from_file.Length ))  >  0 )
         {
            new_duplicate_file.Write( bytes_from_file, 0,
                                      number_of_bytes_read ) ;

            total_number_of_bytes_copied  +=  number_of_bytes_read ;
         }

         Console.Write( "\n Copying ready. "  +  total_number_of_bytes_copied
                      + " bytes were copied. \n" ) ;

         file_to_be_copied.Close() ;
         new_duplicate_file.Close() ;
      }
      catch ( FileNotFoundException )
      {
         Console.Write( "\n Cannot open "  +  name_of_file_to_be_copied ) ;
      }
      catch ( Exception )
      {
         Console.Write( "\n File error. Probably cannot write to "
                     +  name_of_new_duplicate_file ) ;
      }
   }
}




