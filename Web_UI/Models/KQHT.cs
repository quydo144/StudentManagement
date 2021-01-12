using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WWW_BaiTapLon.Models
{
    public class KQHT
    {
        public int kqhtid { get; set; }
        public int lophpid { get; set; }
        public string svid { get; set; }
        public string tenlhp { get; set; }
        public double? tk { get; set; }
        public double? gk { get; set; }
        public double? ck { get; set; }

        [DisplayFormat(DataFormatString = "{0:#,##0.000#}", ApplyFormatInEditMode = true)]
        public double? tongdiem { get; set; }
        public double bac4 { get; set; }
        public string xeploai { get; set; }

    }
}