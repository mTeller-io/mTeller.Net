using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Models
{
    public class CashIn
    {
        public Guid Id { get; set; }
        public string SenderName { get; set; }
        public string ReceiverName { get; set; }
        public string ReceiverPhoneNumber { get; set; }
        public double SendingAmount { get; set; }
        public bool IsSendingChargePaidBySender { get; set; }
        public double SendingCost { get; set; }
        public DateTime TransactionDate { get; set; }
        public Guid AttendingEmployeeId { get; set; }
    }
}
