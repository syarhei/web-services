using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace testing.Code.Models {
    public class MSU {
        public string s;
        public int k;
        public float f;

        public MSU() { }
        public MSU(string s, int k, float f) {
            this.s = s;
            this.k = k;
            this.f = f;
        }
    }
}