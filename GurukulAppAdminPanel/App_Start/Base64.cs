using System;
using System.Text;

namespace GurukulAppAdminPanel.App_Start
{
    public class Base64
    {
        /****************************************
         * Title :: String encoding 
         * Description :: 
         * Parameter :: Plain Text
         * Return :: Encoding Text
         ****************************************/
        public static string Encode(string plainText)
        {
            try
            {
                if (plainText.Trim() != string.Empty)
                {
                    var plainTextBytes = Encoding.UTF8.GetBytes(plainText);
                    return Convert.ToBase64String(plainTextBytes);
                }
                else
                {
                    return "";
                }
            }   
            catch(Exception ex)
            {
                string ExMsg = "Title :: Encode method on Base64 Library \n Message :: ";
                ExMsg += ex.Message.ToString();
                FileHelper.LogWrite(ExMsg);
                return "";
            }
        }

        public static string Decode(string base64EncodedData)
        {
            try
            {
                if (base64EncodedData.Trim() != string.Empty)
                {
                    var base64EncodedBytes = Convert.FromBase64String(base64EncodedData);
                    return Encoding.UTF8.GetString(base64EncodedBytes);
                }
                else
                {
                    return "";
                }
            }
            catch(Exception ex)
            {
                string ExMsg = "Title :: Decode method on Base64 Library \n Message :: ";
                ExMsg += ex.Message.ToString();
                FileHelper.LogWrite(ExMsg);
                return "";
            }            
        }

        public static int RandomNumber(int Length = 3)
        {
            int min = 0, max = 0;
            switch (Length)
            {
                case 1: { min = 0; max = 9; } break;
                case 2: { min = 10; max = 99; } break;
                case 3: { min = 100; max = 999; } break;
                case 4: { min = 1000; max = 9999; } break;
                case 5: { min = 10000; max = 99999; } break;
                case 6: { min = 100000; max = 999999; } break;
                case 7: { min = 1000000; max = 9999999; } break;
                case 8: { min = 10000000; max = 99999999; } break;
                case 9: { min = 100000000; max = 999999999; } break;
                default: { min = 0; max = 9; } break;
            }
            Random random = new Random();
            return random.Next(min, max);
        }

        // Generate a random string with a given size  
        public static string RandomString(int size = 5, bool lowerCase = false)
        {
            StringBuilder builder = new StringBuilder();
            Random random = new Random();
            char ch;
            for (int i = 0; i < size; i++)
            {
                ch = Convert.ToChar(Convert.ToInt32(Math.Floor(26 * random.NextDouble() + 65)));
                builder.Append(ch);
            }
            if (lowerCase)
                return builder.ToString().ToLower();
            return builder.ToString();
        }

        // Generate a random password  
        public static string RandomPassword()
        {
            StringBuilder builder = new StringBuilder();
            builder.Append(RandomString(4, true));
            builder.Append(RandomNumber(4));
            builder.Append(RandomString(2, false));
            return builder.ToString();
        }
    }
}