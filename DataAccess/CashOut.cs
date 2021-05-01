using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Models
{
    public class CashOut
    {
        public Guid Id { get; set; }
        public string ReceiverName { get; set; }
        public string ReceiverPhoneNumber { get; set; }
        public double PaidAmount { get; set; }
        public DateTime TransactionDate { get; set; }
        public Guid AttendingEmployeeId { get; set; }
    }
}
