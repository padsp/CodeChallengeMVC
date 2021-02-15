using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CodeChallengeMVC.Models
{
    public enum AccountStatuses
    {
        Active = 0,
        Inactive = 1,
        Overdue = 2
    }

    public class AccountModel
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public decimal AmountDue { get; set; }
        public DateTime? PaymentDueDate { get; set; }
        public AccountStatuses AccountStatusId { get; set; }
    }
}