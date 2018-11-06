using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;

namespace GurukulAppAdminPanel.App_Start
{
    public class ImageResize
    {
        private static double _MaxWidth = 0;
        private static double _MaxHeight = 0;
        private static string _SourcePath = string.Empty;
        private static string _UploadPath = string.Empty;
        private static bool _CreateThumb = false;
        private static string _ThumbMaker = "_thumb";
        private static bool _MaintainRatio = true;
        private static string _FileRawName = string.Empty;
        private static string _FileName = string.Empty;
        private static string _FileName_without_extension = string.Empty;
        private static string _FileExtension_without_name = string.Empty;

        /*******************************************
         * Title :: Constractor Initialize
         * Description :: 
         * Parameter :: _Config array
         * Return :: none
         *******************************************/
        //_Config["source_image"] = "";
        //_Config["dest_image"] = "";
        //_Config["width"] = "";
        //_Config["height"] = "";
        //_Config["create_thumb"] = "";
        //_Config["thumb_marker"] = "";
        //_Config["maintain_ratio"] = "";
        public ImageResize(SortedList _Config = null)
        {
            try
            {
                if (_Config != null)
                {
                    if (_Config.Count > 0)
                    {                        
                        if (_Config.ContainsKey("source_image")) { _SourcePath = _Config["source_image"].ToString(); }
                        if (_Config.ContainsKey("dest_image")) { _UploadPath = _Config["dest_image"].ToString(); }
                        if (_Config.ContainsKey("width")) { _MaxWidth = (double)_Config["width"]; }
                        if (_Config.ContainsKey("height")) { _MaxHeight = (double)_Config["height"]; }
                        if (_Config.ContainsKey("create_thumb")) { _CreateThumb = Convert.ToBoolean(_Config["create_thumb"]); }
                        if (_Config.ContainsKey("thumb_marker")) { _SourcePath = _Config["thumb_marker"].ToString(); }
                        if (_Config.ContainsKey("maintain_ratio")) { _MaintainRatio = Convert.ToBoolean(_Config["maintain_ratio"]); }
                    }
                }
            }
            catch (Exception ex)
            {
                string ExMsg = "Title :: ImageResize method on Image Resize Library \n Message :: ";
                ExMsg += ex.Message.ToString();
                FileHelper.LogWrite(ExMsg);
            }
        }
        /*******************************************
         * Title :: Initialize Config Data
         * Description :: 
         * Parameter :: _Config array
         * Return :: none
         *******************************************/
        public void initialize(SortedList _Config = null)
        {
            try
            {
                if (_Config != null)
                {
                    if (_Config.Count > 0)
                    {
                        if (_Config.ContainsKey("source_image")) { _SourcePath = _Config["source_image"].ToString(); }
                        if (_Config.ContainsKey("dest_image")) { _UploadPath = _Config["dest_image"].ToString(); }
                        if (_Config.ContainsKey("width")) { _MaxWidth = (double)_Config["width"]; }
                        if (_Config.ContainsKey("height")) { _MaxHeight = (double)_Config["height"]; }
                        if (_Config.ContainsKey("create_thumb")) { _CreateThumb = Convert.ToBoolean(_Config["create_thumb"]); }
                        if (_Config.ContainsKey("thumb_marker")) { _SourcePath = _Config["thumb_marker"].ToString(); }
                        if (_Config.ContainsKey("maintain_ratio")) { _MaintainRatio = Convert.ToBoolean(_Config["maintain_ratio"]); }
                    }
                }
            }
            catch (Exception ex)
            {
                string ExMsg = "Title :: Resize method on Image Resize Library \n Message :: ";
                ExMsg += ex.Message.ToString();
                FileHelper.LogWrite(ExMsg);
            }
        }
        /*******************************************
         * Title :: Resize 
         * Description :: 
         * Parameter :: none
         * Return :: none
         *******************************************/
        public void Resize()
        {
            try
            {
                var image = Image.FromFile(_SourcePath);
                var ratioX = (double)_MaxWidth / image.Width;
                var ratioY = (double)_MaxHeight / image.Height;
                var ratio = Math.Min(ratioX, ratioY);
                var newWidth = (int)(image.Width * ratio);
                var newHeight = (int)(image.Height * ratio);
                var newImage = new Bitmap(newWidth, newHeight);

                _FileRawName = Path.GetFileName(_SourcePath);
                _FileName_without_extension = Path.GetFileNameWithoutExtension(_FileRawName);
                _FileExtension_without_name = Path.GetExtension(_FileRawName);
                Graphics thumbGraph = Graphics.FromImage(newImage);

                if (_MaintainRatio)
                {
                    thumbGraph.CompositingQuality = CompositingQuality.HighQuality;
                    thumbGraph.SmoothingMode = SmoothingMode.HighQuality;
                    //thumbGraph.InterpolationMode = InterpolationMode.HighQualityBicubic;
                }
                thumbGraph.DrawImage(image, 0, 0, newWidth, newHeight);

                image.Dispose();

                if (_CreateThumb)
                {
                    _FileName = _FileName_without_extension + _ThumbMaker + _FileExtension_without_name;
                }
                string fileRelativePath = _UploadPath + Path.GetFileName(_FileName);
                newImage.Save(HttpContext.Current.Server.MapPath(fileRelativePath), newImage.RawFormat);
                //return fileRelativePath;
            }
            catch(Exception ex)
            {
                string ExMsg = "Title :: Resize method on Image Resize Library \n Message :: ";
                ExMsg += ex.Message.ToString();
                FileHelper.LogWrite(ExMsg);
            }
        }
    }
}