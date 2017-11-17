using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SaleQRCode {
    public class Saler {
        public int Id { set; get; }
        public string Name { set; get; }
        public string Mobile { set; get; }
        public int Status { set; get; }
        public DateTime GMTCreate { set; get; }
        public DateTime GMTModified { set; get; }
        public int QRCodeId { set; get; }
    }
}