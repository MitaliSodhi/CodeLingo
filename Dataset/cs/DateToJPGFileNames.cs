
//  DateToJPGFileNames.cs  (c) 2004 Kari Laitinen

//  www.naturalprogramming.com

//  30.07.2003  File created.
//  31.01.2004  Last modification.

/*  This program can rename the .jpg files of a directory
    so that the last modification date of each file becomes
    part of the file name. The program was initially created
    to rename files produced by Samsung Digimax 350 SE camera.
    That camera does not put milliseconds to the file time.

    If the last write time of a .jpg file is 30th of January,
    2004 at 09:00 AM this program renames it like

        f20040130_0900__01.jpg

    To this name you can add a textual description in
    the following way

        f20040130_0900_kari_smiling_01.jpg

    When you test a program like DateToJPGFileNames.cs,
    which can do something to all the files of a directory (folder),
    it is best to run it in a directory that does not contain
    any important files. If this kind of program does not operate
    as specified, it can do a lot of harm if it does something
    unpleasant to all files of a directory.
*/

using System ;
using System.IO ;

class DateToJPGFileNames
{
   static void Main( string[] command_line_parameters )
   {
      string  picture_description  =  "" ;

      if ( command_line_parameters.Length  == 1 )
      {
         picture_description  =  command_line_parameters[ 0 ] ;
      }

      string[]  jpg_files_in_this_directory  =
                                      Directory.GetFiles( ".", "*.jpg" ) ;

      for ( int file_index  =  0 ;
                file_index  <  jpg_files_in_this_directory.Length ;
                file_index  ++ )
      {
         string  old_file_name  =  jpg_files_in_this_directory[ file_index ] ;

         DateTime  last_write_time  =  
                           File.GetLastWriteTime( old_file_name ) ;

         string  new_file_name  =  old_file_name.Substring( 0, 2 )
                                +  "f"
                                +  last_write_time.Year
                                +  last_write_time.Month.ToString("D2")
                                +  last_write_time.Day.ToString("D2")
                                +  "_"
                                +  last_write_time.Hour.ToString("D2")
                                +  last_write_time.Minute.ToString("D2")
                                +  "_" 
                                +  picture_description
                                +  "_"
                                +  ( file_index  +  1 ).ToString("D2")
                                +  ".jpg" ;

         Console.Write( "\n " + old_file_name + "  " + new_file_name ) ;

         File.Move( old_file_name, new_file_name ) ;
      }
   }
}




