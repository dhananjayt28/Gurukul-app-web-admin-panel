using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using System.Security.AccessControl;
using System.Security.Principal;

namespace GurukulAppAdminPanel.App_Start
{
    public class FileHelper
    {
        
        public static string Path = string.Empty;  // Public Path, given by user
        private static string _FilePath = string.Empty; // global file path variable


        /***********************************************
         * Title :: Create file
         * Description :: 
         * Parameter :: FilePath
         * Return :: true/false
         ***********************************************/
        public static bool Create(string FilePath)
        {
            try
            {
                if (Path != string.Empty)
                {
                    _FilePath = ServerPath(Path);
                }
                else if (FilePath != string.Empty)
                {
                    _FilePath = ServerPath(FilePath);
                }
                if (!File.Exists(_FilePath))
                {
                    File.Create(_FilePath).Dispose(); //if file not exists
                    return true;
                }
                else
                {
                    File.Create(_FilePath).Dispose(); //if file exists
                    return true;
                }
            }
            catch(Exception ex)
            {
                LogWrite(ex.Message.ToString());
                return false;
            }
        }
        /***********************************************
         * Title :: Delete file
         * Description :: 
         * Parameter :: FilePath
         * Return :: true/false
         ***********************************************/
        public static bool Delete(string FilePath)
        {
            try
            {
                if (Path != string.Empty)
                {
                    _FilePath = ServerPath(Path);
                }
                else if (FilePath != string.Empty)
                {
                    _FilePath = ServerPath(FilePath);
                }
                if (!File.Exists(_FilePath))
                {
                    File.Delete(_FilePath); //if file not exists
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                LogWrite(ex.Message.ToString());
                return false;
            }
        }
        /***********************************************
         * Title :: Clear file Data
         * Description :: 
         * Parameter :: FilePath
         * Return :: true/false
         ***********************************************/
        public static bool Clear(string FilePath)
        {
            try
            {
                if (Path != string.Empty)
                {
                    _FilePath = ServerPath(Path);
                }
                else if (FilePath != string.Empty)
                {
                    _FilePath = ServerPath(FilePath);
                }
                if (_FilePath == string.Empty) { return false; }
                File.WriteAllText(_FilePath, string.Empty);
                return true;
            }
            catch (Exception ex)
            {
                LogWrite(ex.Message.ToString());
                return false;
            }
        }
        /***********************************************
         * Title :: Create and Write text into Logfile
         * Description :: 
         * Parameter :: Message
         * Return :: none
         ***********************************************/
        public static void LogWrite(string Message)
        {
            if (!string.IsNullOrEmpty(Message))
            {
                string _FilePath = ServerPath(Constant.LOG_FILE_PATH);
                string _LogText = string.Empty;
                if (DirectoryHelper.Create(ServerPath(Constant.LOG_DIR_PATH)))
                {
                    // Check File exists ot not
                    if (!File.Exists(_FilePath))
                    {
                        //if file not exists
                        File.Create(_FilePath).Dispose();
                    }

                    _LogText += "=================================================\n";
                    _LogText += "Date : " + DateTime.Now.ToString("dd/MM/yyyy h:mm tt") + "\n";
                    _LogText += "" + Message + "\n\n";

                    var fileLines = File.ReadAllLines(_FilePath);
                    List<string> fileItems = new List<string>(fileLines);
                    if (fileItems.Count > 0)
                    {
                        using (StreamWriter sw = File.AppendText(_FilePath))
                        {
                            sw.WriteLine(_LogText);
                            sw.Close();
                        }
                    }
                    else
                    {
                        File.WriteAllText(_FilePath, _LogText);
                    }
                }
            }
        }
        /***********************************************
         * Title :: Get Server Maped file path of any kind of file
         * Description :: 
         * Parameter :: File Path
         * Return :: Server file path
         ***********************************************/
        public static string ServerPath(string FilePath)
        {
            if (!string.IsNullOrEmpty(FilePath))
            {
                return HttpContext.Current.Server.MapPath(FilePath);
            }
            else
            {
                return string.Empty;
            }            
        }
        /***********************************************
         * Title :: Access Grant file
         * Description :: 
         * Parameter :: FilePath, AccessModifier
         * Return :: none
         ***********************************************/
        public static void GrantAccess(string fullPath, string AccessModifier = "")
        {
            string[] _AccessModifier = new string[] { "R", "r", "W", "w", "R/W", "r/w" };
            DirectoryInfo dInfo = new DirectoryInfo(fullPath);
            DirectorySecurity dSecurity = dInfo.GetAccessControl();
            if (_AccessModifier.Contains(AccessModifier))
            {
                switch (AccessModifier.ToLower())
                {
                    case "r": {
                            dSecurity.AddAccessRule(new FileSystemAccessRule(
                                new SecurityIdentifier(WellKnownSidType.WorldSid, null), 
                                FileSystemRights.Read, 
                                InheritanceFlags.ObjectInherit | InheritanceFlags.ContainerInherit, 
                                PropagationFlags.NoPropagateInherit, 
                                AccessControlType.Allow
                                )
                             );
                        } break;
                    case "w":
                        {
                            dSecurity.AddAccessRule(new FileSystemAccessRule(
                                new SecurityIdentifier(WellKnownSidType.WorldSid, null),
                                FileSystemRights.Write,
                                InheritanceFlags.ObjectInherit | InheritanceFlags.ContainerInherit,
                                PropagationFlags.NoPropagateInherit,
                                AccessControlType.Allow
                                )
                             );
                        }
                        break;
                    case "r/w":
                        {
                            dSecurity.AddAccessRule(new FileSystemAccessRule(
                                new SecurityIdentifier(WellKnownSidType.WorldSid, null),
                                FileSystemRights.FullControl,
                                InheritanceFlags.ObjectInherit | InheritanceFlags.ContainerInherit,
                                PropagationFlags.NoPropagateInherit,
                                AccessControlType.Allow
                                )
                             );
                        }
                        break;
                }
            }
            dInfo.SetAccessControl(dSecurity);
        }
        /***********************************************
         * Title :: File Exists
         * Description :: 
         * Parameter :: FilePath
         * Return :: true/false
         ***********************************************/
        public static bool Exists(string FilePath)
        {
            try
            {
                if(FilePath.Trim() != string.Empty)
                {
                    return File.Exists(FilePath);
                }
                else
                {
                    return false;
                }
                
            }
            catch(Exception ex)
            {
                string ExMsg = "Title :: Exists method on File Helper \n Message :: ";
                ExMsg += ex.Message.ToString();
                LogWrite(ExMsg);
                return false;
            }
        }
    }
}