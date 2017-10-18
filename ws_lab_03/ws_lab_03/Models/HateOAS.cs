using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ws_lab_03.Models {
    public class HateOAS {
        public string href { get; set; }
        public string rel { get; set; }

        public HateOAS(string href, string rel) {
            this.href = href;
            this.rel = rel;
        }

    }
}