using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DiagnosticBillManagementApp.Model
{
    public class Tests
    {
        public int Id { get; set; }
        public string TestName { get; set; }
        public int Fee { get; set; }
        public int TypeNameId { get; set; }
    }
}