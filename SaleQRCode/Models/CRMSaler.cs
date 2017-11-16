using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SaleQRCode {
    public class CRMSaler {
        public int Id { set; get; }
        public string Name { set; get; }
        public int Mobile { set; get; }
        public int Status { set; get; }
        public DateTime GMTCreate { set; get; }
        public DateTime GMTModified { set; get; }
        public int QRCodeId { set; get; }
    }
}