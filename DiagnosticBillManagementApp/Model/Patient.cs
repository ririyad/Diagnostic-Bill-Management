using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DiagnosticBillManagementApp.Model
{
    public class Patient
    {
        public string Name { get; set; }
        public DateTime DateOfBirth { get; set; }
        public int MobileNo { get; set; }
        public int TestTypeId { get; set; }
    }
}