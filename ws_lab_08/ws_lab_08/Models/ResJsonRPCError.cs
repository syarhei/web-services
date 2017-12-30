using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ws_lab_08.Models {
    public class ResJsonRPCError {
        public string Id { get; set; }
        public string Jsonrpc { get; set; }
        public string Error { get; set; }
    }
}