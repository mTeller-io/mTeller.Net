using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Models
{
    public class CashOut
    {
        public Guid Id { get; set; }
        public string CashInPersonName { get; set; }
        public double CashOutAmount { get; set; }
        public DateTime TransactionDate { get; set; }
        public Guid AttendingEmployeeId { get; set; }
    }
}
