using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Web;

namespace GurukulAppAdminPanel.App_Start
{
    public class FileUpload
    {
        private static string _UploadPath = string.Empty;
        private static string _NewName = string.Empty;
        private static string _file_name = string.Empty;
        private static ulong _MaxSize = 0;
        private static long _MaxWidth = 0;
        private static long _MaxHeight = 0;
        private static string _AllowedTypes = string.Empty;
        private static bool _Overwrite = false;
        private static bool _EncryptName = false;
        private static bool _RemoveSpaces = true;
        private static Array _AllowTypeArray = null;
        private static List<string> _ErrorArray = new List<string>();
        private static string _BulletSign = "* ";
        private static string _FileName_without_Extension = string.Empty;
        private static string _FileExtension_without_Name = string.Empty;

        /****************************************
         * Title :: Config Initilize through Constructor
         * Description :: 
         * Parameter :: Config Array
         * Return :: none
         ****************************************/
        public FileUpload(SortedList _Config = null)
        {
            try
            {
                if (_Config != null)
                {
                    if (_Config.Count > 0)
                    {
                        if (_Config.ContainsKey("new_file_name")) { _NewName = _Config["new_file_name"].ToString(); }
                        if (_Config.ContainsKey("file_name")) { _file_name = _Config["file_name"].ToString(); }
                        if (_Config.ContainsKey("upload_path")) { _UploadPath = _Config["upload_path"].ToString(); }
                        if (_Config.ContainsKey("max_size")) { _MaxSize = Convert.ToUInt64(_Config["max_size"]); }
                        if (_Config.ContainsKey("max_width")) { _MaxWidth = Convert.ToInt64(_Config["max_width"]); }
                        if (_Config.ContainsKey("max_height")) { _MaxHeight = Convert.ToInt64(_Config["max_height"]); }
                        if (_Config.ContainsKey("allowed_types")) { _AllowedTypes = _Config["allowed_types"].ToString(); _AllowTypeArray = _StringToArray(_AllowedTypes, "|"); }
                        if (_Config.ContainsKey("encrypt_name")) { _EncryptName = Convert.ToBoolean(_Config["encrypt_name"]); }
                        if (_Config.ContainsKey("overwrite")) { _Overwrite = Convert.ToBoolean(_Config["overwrite"]); }
                        if (_Config.ContainsKey("remove_spaces")) { _RemoveSpaces = Convert.ToBoolean(_Config["remove_spaces"]); }

                    }
                }
            }
            catch(Exception ex)
            {
                string ExMsg = "Title :: Constructor initialize on File Upload Library \n Message :: ";
                ExMsg += ex.Message.ToString();
                FileHelper.LogWrite(ExMsg);
            }
            
        }
        /****************************************
         * Title :: Config Initilize 
         * Description :: 
         * Parameter :: Config Array
         * Return :: none
         ****************************************/
        public void Initialize(SortedList _Config = null)
        {
            try
            {
                if (_Config != null)
                {
                    if (_Config.Count > 0)
                    {
                        if (_Config.ContainsKey("new_file_name")) { _NewName = _Config["new_file_name"].ToString(); }
                        if (_Config.ContainsKey("file_name")) { _file_name = _Config["file_name"].ToString(); }
                        if (_Config.ContainsKey("upload_path")) { _UploadPath = _Config["upload_path"].ToString(); }
                        if (_Config.ContainsKey("max_size")) { _MaxSize = Convert.ToUInt64(_Config["max_size"]); }
                        if (_Config.ContainsKey("max_width")) { _MaxWidth = Convert.ToInt64(_Config["max_width"]); }
                        if (_Config.ContainsKey("max_height")) { _MaxHeight = Convert.ToInt64(_Config["max_height"]); }
                        if (_Config.ContainsKey("allowed_types")) { _AllowedTypes = _Config["allowed_types"].ToString(); _AllowTypeArray = _StringToArray(_AllowedTypes, "|"); }
                        if (_Config.ContainsKey("encrypt_name")) { _EncryptName = Convert.ToBoolean(_Config["encrypt_name"]); }
                        if (_Config.ContainsKey("overwrite")) { _Overwrite = Convert.ToBoolean(_Config["overwrite"]); }
                        if (_Config.ContainsKey("remove_spaces")) { _RemoveSpaces = Convert.ToBoolean(_Config["remove_spaces"]); }

                    }
                }
            }
            catch (Exception ex)
            {
                string ExMsg = "Title :: Initialize method on File Upload Library \n Message :: ";
                ExMsg += ex.Message.ToString();
                FileHelper.LogWrite(ExMsg);
            }
        }
        /****************************************
         * Title :: File Upload 
         * Description :: 
         * Parameter :: FileData
         * Return :: none
         ****************************************/
        public void Upload(HttpPostedFileBase FileData)
        {
            try
            {
                if (_FileValidation(FileData))
                {
                    string _FilePath = Path.Combine(_UploadPath, _NewName);
                    FileData.SaveAs(_FilePath);
                }                
            }
            catch(Exception ex)
            {
                string ExMsg = "Title :: Upload method on File Upload Library \n Message :: ";
                ExMsg += ex.Message.ToString();
                FileHelper.LogWrite(ExMsg);
            }
            
        }
        /****************************************
         * Title :: Display Error Array 
         * Description :: 
         * Parameter :: 
         * Return :: Array list
         ****************************************/
        public List<string> DisplayError()
        {
            try
            {
                if(_ErrorArray.Count > 0)
                {
                    return _ErrorArray;
                }
                else
                {
                    return new List<string>();
                }
            }
            catch(Exception ex)
            {
                string ExMsg = "Title :: _StringToArray method on File Upload Library \n Message :: ";
                ExMsg += ex.Message.ToString();
                FileHelper.LogWrite(ExMsg);
                return new List<string>();
            }
        }
        /****************************************
         * Title :: Display File Data Array 
         * Description :: 
         * Parameter :: 
         * Return :: Array list
         ****************************************/
        public SortedList DisplayData()
        {
            try
            {
                SortedList _DisplayData = new SortedList();
                _DisplayData.Add("FileName", _NewName);
                _DisplayData.Add("FileExtension", _FileExtension_without_Name);
                _DisplayData.Add("UploadPath", _UploadPath);

                return _DisplayData;
            }
            catch (Exception ex)
            {
                string ExMsg = "Title :: DisplayData method on File Upload Library \n Message :: ";
                ExMsg += ex.Message.ToString();
                FileHelper.LogWrite(ExMsg);
                return new SortedList();
            }
        }
        /********************************************************
         * Title :: String to Array by User define Delemeter 
         * Description :: 
         * Parameter :: Data, Delemeter
         * Return :: Array
         ********************************************************/
        private Array _StringToArray(string Data, string Delemeter)
        {
            try
            {
                Array _ArrayData = null;
                if (Data != string.Empty && Delemeter != string.Empty)
                {
                    _ArrayData = Data.Split(new string[] { Delemeter }, StringSplitOptions.None);
                    return _ArrayData;
                }
                else
                {
                    return _ArrayData;
                }
            }  
            catch(Exception ex)
            {
                string ExMsg = "Title :: _StringToArray method on File Upload Library \n Message :: ";
                ExMsg += ex.Message.ToString();
                FileHelper.LogWrite(ExMsg);
                return null;
            }
        }
        /********************************************************
         * Title :: File Validation checking 
         * Description :: 
         * Parameter :: Post File Data
         * Return :: true/false
         ********************************************************/
        private bool _FileValidation(HttpPostedFileBase _File)
        {
            try
            {
                if(_File.ContentLength > 0)
                {
                    // Check File Extenstion
                    _FileExtension_without_Name = Path.GetExtension(_File.FileName);
  
                    if (!_CheckExtension(_FileExtension_without_Name)){_ErrorArray.Add(_BulletSign+"File extension does not matched.");}
                    // Check File Size
                    ulong size = Convert.ToUInt64(_File.ContentLength);
                    if (!_CheckFileSize(size)) { _ErrorArray.Add(_BulletSign + "File size must be valid."); }
                    // Check File Name 
                    if(_file_name.Trim() != string.Empty || _NewName.Trim() != string.Empty)
                    {
                        // File Rename
                        if (_NewName.Trim() != string.Empty)
                        {
                            // For New Name
                            _FileName_without_Extension = Path.GetFileNameWithoutExtension(_NewName);
                            _Rename(_FileName_without_Extension, _FileExtension_without_Name);
                        }
                        else
                        {
                            // for file exist name
                            _FileName_without_Extension = Path.GetFileNameWithoutExtension(_file_name);
                            _Rename(_FileName_without_Extension, _FileExtension_without_Name);
                        }
                    }
                    else
                    {
                        _NewName = Path.GetFileName(_File.FileName);
                    }
                    // Check file upload Path exist
                    if(!_CheckUploadPath(_UploadPath)) { _ErrorArray.Add(_BulletSign + "File upload path could not found."); }
                    // Check Overwrite 
                    _CheckOverwrite(); // check if file exists.
                    _RemoveSpace(_NewName); // Remove all spaces from file name
                    // File Rezing
                    if (_MaxWidth > 0 && _MaxHeight > 0)
                    {
                        if(!_ImageResize(_UploadPath + _NewName))
                        {
                            _ErrorArray.Add(_BulletSign + "File Max Width and Max Height should be valid.");
                        }
                    }
                    

                    // Check if error data avail or not
                    if (_ErrorArray.Count > 0)
                    {
                        return false;
                    }
                    else
                    {
                        return true;
                    }                    
                }
                else
                {
                    return false;
                }                
            }
            catch(Exception ex)
            {
                string ExMsg = "Title :: _FileValidation method on File Upload Library \n Message :: ";
                ExMsg += ex.Message.ToString();
                FileHelper.LogWrite(ExMsg);
                return false;
            }
        }
        /********************************************************
         * Title :: File Extension checking 
         * Description :: 
         * Parameter :: Extension string
         * Return :: true/false
         ********************************************************/
        private bool _CheckExtension(string Extension)
        {
            try
            {
                return Array.IndexOf(_AllowTypeArray, Extension.Remove(0,1)) != -1;
            }
            catch (Exception ex)
            {
                string ExMsg = "Title :: _CheckExtension method on File Upload Library \n Message :: ";
                ExMsg += ex.Message.ToString();
                FileHelper.LogWrite(ExMsg);
                return false;
            }
        }
        /********************************************************
         * Title :: File Size checking 
         * Description :: 
         * Parameter :: File Size
         * Return :: true/false
         ********************************************************/
        private bool _CheckFileSize(ulong Size)
        {
            try
            {
                if(Size > 0)
                {
                    return Size <= _MaxSize ? true : false;
                }
                else
                {
                    return false;
                }
                
            }
            catch (Exception ex)
            {
                string ExMsg = "Title :: _CheckExtension method on File Upload Library \n Message :: ";
                ExMsg += ex.Message.ToString();
                FileHelper.LogWrite(ExMsg);
                return false;
            }
        }
        /****************************************
         * Title :: File Rename 
         * Description :: 
         * Parameter :: FileData
         * Return :: none
         ****************************************/
        private bool _Rename(string _FileName, string extension)
        {
            try
            {
                if (_FileName.Trim() != string.Empty && extension.Trim() != string.Empty)
                {
                    if (_EncryptName)
                    {
                        _FileName = Base64.Encode(_FileName);
                        _NewName = _FileName + "" + extension;
                    }
                    else
                    {
                        _NewName = _FileName + "" + extension;
                    }
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                string ExMsg = "Title :: _Rename method on File Upload Library \n Message :: ";
                ExMsg += ex.Message.ToString();
                FileHelper.LogWrite(ExMsg);
                return false;
            }

        }
        /********************************************************
         * Title :: Remove Space in File Name
         * Description :: 
         * Parameter :: File Name
         * Return :: true/false
         ********************************************************/
        private bool _RemoveSpace(string _FileName)
        {
            try
            {
                if (_FileName.Trim() != string.Empty)
                {
                    _NewName = _FileName.Replace(" ","_");
                    return true;
                }
                else
                {
                    return false;
                }

            }
            catch (Exception ex)
            {
                string ExMsg = "Title :: _RemoveSpace method on File Upload Library \n Message :: ";
                ExMsg += ex.Message.ToString();
                FileHelper.LogWrite(ExMsg);
                return false;
            }
        }
        /********************************************************
         * Title :: Check File Upload Path
         * Description :: 
         * Parameter :: File Name
         * Return :: true/false
         ********************************************************/
        private bool _CheckUploadPath(string _FilePath)
        {
            try
            {
                if (_FilePath.Trim() != string.Empty)
                {
                    return DirectoryHelper.Exists(_FilePath);
                }
                else
                {
                    return false;
                }

            }
            catch (Exception ex)
            {
                string ExMsg = "Title :: _CheckUploadPath method on File Upload Library \n Message :: ";
                ExMsg += ex.Message.ToString();
                FileHelper.LogWrite(ExMsg);
                return false;
            }
        }
        /********************************************************
         * Title :: Check File Upload Path
         * Description :: 
         * Parameter :: File Name
         * Return :: true/false
         ********************************************************/
        private bool _CheckOverwrite()
        {
            try
            {
                if (!_Overwrite)
                {
                    if (_UploadPath.Trim() != string.Empty)
                    {
                        if(FileHelper.Exists(_UploadPath + _NewName))
                        {
                            _FileName_without_Extension = Path.GetFileNameWithoutExtension(_NewName);
                            _FileName_without_Extension += Base64.RandomNumber(2).ToString();
                            _Rename(_FileName_without_Extension, _FileExtension_without_Name);
                            return true;
                        }
                        else
                        {
                            return true;
                        }
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                string ExMsg = "Title :: _CheckOverwrite method on File Upload Library \n Message :: ";
                ExMsg += ex.Message.ToString();
                FileHelper.LogWrite(ExMsg);
                return false;
            }
        }
        /********************************************************
         * Title :: Image File Resize
         * Description :: 
         * Parameter :: File Name
         * Return :: true/false
         ********************************************************/
        private bool _ImageResize(string _ImagePath)
        {
            try
            {
                Image imgOriginal = Image.FromFile(_ImagePath);
                //pass in whatever value you want
                Image imgActual = Scale(imgOriginal);
                imgOriginal.Dispose();
                imgActual.Save(_ImagePath);
                imgActual.Dispose();
                ImageResult.ImageName = _NewName;
                return true;
            }
            catch(Exception ex)
            {
                string ExMsg = "Title :: _ImageResize method on File Upload Library \n Message :: ";
                ExMsg += ex.Message.ToString();
                FileHelper.LogWrite(ExMsg);
                return false;
            }
        }
        /********************************************************
         * Title :: Image File Scale
         * Description :: 
         * Parameter :: File Name
         * Return :: true/false
         ********************************************************/
        private Image Scale(Image imgPhoto)
        {
            float sourceWidth = imgPhoto.Width;
            float sourceHeight = imgPhoto.Height;
            float destHeight = 0;
            float destWidth = 0;
            int sourceX = 0;
            int sourceY = 0;
            int destX = 0;
            int destY = 0;
            // force resize, might distort image
            if (_MaxWidth != 0 && _MaxHeight != 0)
            {
                destWidth = _MaxWidth;
                destHeight = _MaxHeight;
            }
            // change size proportially depending on width or height
            else if (_MaxHeight != 0)
            {
                destWidth = (float)(_MaxHeight * sourceWidth) / sourceHeight;
                destHeight = _MaxHeight;
            }
            else
            {
                destWidth = _MaxWidth;
                destHeight = (float)(sourceHeight * _MaxWidth / sourceWidth);
            }
            Bitmap bmPhoto = new Bitmap((int)destWidth, (int)destHeight,
            PixelFormat.Format32bppPArgb);
            bmPhoto.SetResolution(imgPhoto.HorizontalResolution, imgPhoto.VerticalResolution);
            Graphics grPhoto = Graphics.FromImage(bmPhoto);
            grPhoto.InterpolationMode = InterpolationMode.HighQualityBicubic;
            grPhoto.DrawImage(imgPhoto,
            new Rectangle(destX, destY, (int)destWidth, (int)destHeight),
            new Rectangle(sourceX, sourceY, (int)sourceWidth, (int)sourceHeight),
            GraphicsUnit.Pixel);
            grPhoto.Dispose();
            return bmPhoto;
        }





    }

    public class ImageResult
    {
        public static bool Success { get; set; }
        public static string ImageName { get; set; }
        public static string ErrorMessage { get; set; }
    }
}