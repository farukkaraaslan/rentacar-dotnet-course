using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Constants
{
    public class Messagess
    {
        public static class Brand
        {
            public static string AllReadyExists = "BRAND_ALL_READY_EXİSTS";
            public static string NotExists = "BRAND_NOT_EXISTS";
        }
        public static class Car
        {
            public static string AllReadyExists = "CAR_ALL_READY_EXİSTS";
            public static string PlateIsValid = "PLATE_IS_NOT_VALID";
            public static string NotExists = "CAR_NOT_EXISTS";
            public static string CarNotAvailable = "CAR_NOT_AVAILABLE";
        }

        public static class Color
        {
            public static string AllReadyExists = "COLOR_ALL_READY_EXİSTS";
            public static string NotExists = "COLOR_NOT_EXISTS";
        }
    }
}
