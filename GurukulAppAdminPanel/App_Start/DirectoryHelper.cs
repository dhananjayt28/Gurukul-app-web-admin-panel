using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;

namespace GurukulAppAdminPanel.App_Start
{
    public class DirectoryHelper
    {
        // Public 
        public static string DirPath = string.Empty;
        public static string SourceDirPath = string.Empty;
        public static string DestinationDirPath = string.Empty;
        // Private
        private static string _DirPath = string.Empty;
        private static string _SourcePath = string.Empty;
        private static string _DestinationPath = string.Empty;


        /*******************************************
         * Title :: Make Directory
         * Description :: Creates all directories and subdirectories in the specified path unless they already exist.
         * Param :: Path
         * return :: true/false
         *******************************************/
        public static bool Create(string Path)
        {
            try
            {
                if(DirPath != string.Empty)
                {
                    _DirPath = DirPath;
                }
                else if(Path != string.Empty)
                {
                    _DirPath = Path;
                }
                else
                {
                    return false;
                }
                // If directory does not exist, create it.
                if (!Directory.Exists(_DirPath))
                {
                    Directory.CreateDirectory(_DirPath);
                    return true;
                }
                else
                {
                    return true;
                }
            }
            catch(Exception ex)
            {
                FileHelper.LogWrite(ex.Message.ToString());
                return false;
            }
        }
        /*******************************************
         * Title :: Delete Directory
         * Description :: Deletes an empty directory from a specified path.
         * Param :: Path
         * return :: true/false
         *******************************************/
        public static bool Delete(string Path)
        {
            try
            {
                if (DirPath != string.Empty)
                {
                    _DirPath = DirPath;
                }
                else if (Path != string.Empty)
                {
                    _DirPath = Path;
                }
                else
                {
                    return false;
                }
                // If directory does exist, delete it.
                if (Directory.Exists(_DirPath))
                {
                    Directory.Delete(_DirPath);
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch(Exception ex)
            {
                FileHelper.LogWrite(ex.Message.ToString());
                return false;
            }
        }
        /*******************************************
         * Title :: Delete Directory
         * Description :: Deletes the specified directory and, if indicated, any subdirectories and files in the directory.
         * Param :: Path, boolean
         * return :: true/false
         *******************************************/
        public static bool Delete(string Path, bool _val = false)
        {
            try
            {
                if (DirPath != string.Empty)
                {
                    _DirPath = DirPath;
                }
                else if (Path != string.Empty)
                {
                    _DirPath = Path;
                }
                else
                {
                    return false;
                }
                // If directory does exist, delete it.
                if (Directory.Exists(_DirPath))
                {
                    Directory.Delete(_DirPath, _val);
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                FileHelper.LogWrite(ex.Message.ToString());
                return false;
            }
        }
        /*******************************************
         * Title :: Exists Directory
         * Description :: Determines whether the given path refers to an existing directory on disk.
         * Param :: Path
         * return :: true/false
         *******************************************/
        public static bool Exists(string Path)
        {
            try
            {
                if (DirPath != string.Empty)
                {
                    _DirPath = DirPath;
                }
                else if (Path != string.Empty)
                {
                    _DirPath = Path;
                }
                else
                {
                    return false;
                }
                // If directory does exist, delete it.
                if (Directory.Exists(_DirPath))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                FileHelper.LogWrite(ex.Message.ToString());
                return false;
            }
        }
        /*******************************************
         * Title :: Move Directory
         * Description :: Moves a file or a directory and its contents to a new location.
         * Param :: SourceDir, DestinationDir
         * return :: true/false
         *******************************************/
        public static bool Move(string SourceDir, string DestinationDir)
        {
            try
            {
                // Source Path Config
                if (SourceDirPath != string.Empty)
                {
                    _SourcePath = SourceDirPath;
                }
                else if (SourceDir != string.Empty)
                {
                    _SourcePath = SourceDir;
                }
                else
                {
                    return false;
                }
                // Destination Path Config
                if (DestinationDir != string.Empty)
                {
                    _DestinationPath = DestinationDir;
                }
                else if (DestinationDirPath != string.Empty)
                {
                    _DestinationPath = DestinationDirPath;
                }
                else
                {
                    return false;
                }

                // If directory does exist, delete it.
                if (Directory.Exists(_SourcePath) && Directory.Exists(_DestinationPath))
                {
                    Directory.Move(_SourcePath, _DestinationPath);
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                FileHelper.LogWrite(ex.Message.ToString());
                return false;
            }
        }
    }
}