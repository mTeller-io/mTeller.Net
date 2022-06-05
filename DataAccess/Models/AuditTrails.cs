using System;
using System.ComponentModel.DataAnnotations;

namespace DataAccess.Models
{
    public class AuditTrails
    {
        //Identity primary key
        [Key]
        public int AuditId { get; set; }

        //The global unique id
        public Guid AuditUId = Guid.NewGuid();

        //The type of audit activity. e.g Add,Update,Delete,View
        public string AuditType { get; set; }

        //The id of the entity being audited
        public int EntitypeID { get; set; }

        //The identity number identifying the record in the entity
        public int RecId { get; set; }

        //The name of user performing the activity being audited
        public string UserName { get; set; }

        //The screen name of activity being audited
        public string Source { get; set; }

        // Automated process name if the activity was not performed by a user
        public string Process { get; set; }

        // The computer name which performed the activity
        public string ComputerID { get; set; }

        //The json format details of the data bein processed by the activity
        public string Data { get; set; }

        //The audit logging date
        public DateTime AuditDateTime { get; set; }
    }
}