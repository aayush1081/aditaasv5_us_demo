using Microsoft.AspNetCore.Antiforgery;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace V5WinService.Classes
{
    public static class CLS_ColorScale
    {
        static Dictionary<string, string> coll_HSL_Hax_Color = new Dictionary<string, string>();

        public static string ColorFromHSL(string hsl_CSV)
        {
            if (coll_HSL_Hax_Color.ContainsKey(hsl_CSV))
                return coll_HSL_Hax_Color[hsl_CSV];
            else
            {
                var h = float.Parse(hsl_CSV.Split(',')[0].Trim().Replace("%", ""));
                var s = float.Parse(hsl_CSV.Split(',')[1].Trim().Replace("%", "")) / 100;
                var l = float.Parse(hsl_CSV.Split(',')[2].Trim().Replace("%", "")) / 100;
                double p2;
                if (l <= 0.5)
                    p2 = l * (1 + s);
                else
                    p2 = l + s - l * s;

                double p1 = 2 * l - p2;
                double double_r, double_g, double_b;
                if (s == 0)
                {
                    double_r = l;
                    double_g = l;
                    double_b = l;
                }
                else
                {
                    double_r = QqhToRgb(p1, p2, h + 120);
                    double_g = QqhToRgb(p1, p2, h);
                    double_b = QqhToRgb(p1, p2, h - 120);
                }
                // Convert RGB to the 0 to 255 range.
                var r = (int)(double_r * 255.0);
                var g = (int)(double_g * 255.0);
                var b = (int)(double_b * 255.0);
                var colorHex = RGBToHexadecimal(Color.FromArgb(r, g, b));
                if (coll_HSL_Hax_Color.ContainsKey(hsl_CSV) == false)
                    coll_HSL_Hax_Color.Add(hsl_CSV, colorHex);
                return colorHex;
            }

        }

        private static double QqhToRgb(double q1, double q2, double hue)
        {
            if (hue > 360) hue -= 360;
            else if (hue < 0) hue += 360;

            if (hue < 60) return q1 + (q2 - q1) * hue / 60;
            if (hue < 180) return q2;
            if (hue < 240) return q1 + (q2 - q1) * (240 - hue) / 60;
            return q1;
        }

        public static string RGBToHexadecimal(Color rgb)
        {
            string rs = DecimalToHexadecimal(rgb.R);
            string gs = DecimalToHexadecimal(rgb.G);
            string bs = DecimalToHexadecimal(rgb.B);

            return '#' + rs + gs + bs;
        }


        public static string DecimalToHexadecimal(int dec)
        {
            if (dec <= 0)
                return "00";

            int hex = dec;
            string hexStr = string.Empty;

            while (dec > 0)
            {
                hex = dec % 16;

                if (hex < 10)
                    hexStr = hexStr.Insert(0, Convert.ToChar(hex + 48).ToString());
                else
                    hexStr = hexStr.Insert(0, Convert.ToChar(hex + 55).ToString());

                dec /= 16;
            }
            return hexStr;
        }

    }

    public struct ColorRGB
    {
        #region Fields
        private byte r;
        private byte g;
        private byte b;
        #endregion

        /// <summary>
        /// Gets or sets the Red value.
        /// </summary>
        /// <value>The R.</value>
        public byte R
        {
            get { return r; }
            set { r = value; }
        }


        /// <summary>
        /// Gets or sets the Green value.
        /// </summary>
        /// <value>The G.</value>
        public byte G
        {
            get { return g; }
            set { g = value; }
        }



        /// <summary>
        /// Gets or sets the Blue value.
        /// </summary>
        /// <value>The B.</value>
        public byte B
        {
            get { return b; }
            set { b = value; }
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="T:ColorRGB"/> class.
        /// </summary>
        /// <param name="value">The value.</param>
        public ColorRGB(Color value)
        {
            this.r = value.R;
            this.g = value.G;
            this.b = value.B;
        }
        /// <summary>
        /// Implicit conversion of the specified RGB.
        /// </summary>
        /// <param name="rgb">The RGB.</param>
        /// <returns></returns>
        public static implicit operator Color(ColorRGB rgb)
        {
            Color c = Color.FromArgb(255, rgb.R, rgb.G, rgb.B);
            return c;
        }
        /// <summary>
        /// Explicit conversion of the specified c.
        /// </summary>
        /// <param name="c">The c.</param>
        /// <returns></returns>
        public static explicit operator ColorRGB(Color c)
        {
            return new ColorRGB(c);
        }
    }
}
