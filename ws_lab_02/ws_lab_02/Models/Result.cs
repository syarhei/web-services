using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ws_lab_02.Models {
    public class Result {
        public static int result = 0;
        public static ConcurrentStack<int> stack = new ConcurrentStack<int>();
    }
}