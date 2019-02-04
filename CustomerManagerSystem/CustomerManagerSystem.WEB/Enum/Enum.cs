using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace CustomerManagerSystem.WEB.Enum
{
    public class Enum
    {
        public enum Role
        {
            [Description("Administrator")]
            Administrator = 1,

            [Description("Seller")]
            Seller = 2,
        }

        public enum Gender
        {
            [Description("Male")]
            Male = 1,

            [Description("Female")]
            Female = 2,
        }

        public enum Classification
        {
            [Description("Classification1")]
            Classification1 = 1,

            [Description("Classification2")]
            Classification2 = 2,

            [Description("Classification3")]
            Classification3 = 3
        }
    }
}