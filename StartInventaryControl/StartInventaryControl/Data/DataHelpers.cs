using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StartInventaryControl.Data
{
    public static class DataHelpers
    {
        public static string ProductImagePath => $@"{App.HOME_DIR}\Image";
        public static string ProductImagePathNotFound => $@"{ProductImagePath}\default.jpg";
        public static IList<string> Genders { get; set; }
        public static IList<string> Colors { get; set; }
        public static IList<string> Sizes { get; set; }
    }
}
