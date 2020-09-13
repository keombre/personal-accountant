using Microsoft.AspNetCore.Identity;
using System;
using System.ComponentModel.DataAnnotations;

namespace PersonalAccountant.Entities
{
    public class TransactionEntity
    {
        [Key]
        public int Id { get; set; }

        public DateTime Date { get; set; }

        public int Ammount { get; set; }

        public TypeEntity Type { get; set; }

        public IdentityUser User { get; set; }

        public string Note { get; set; }
    }
}
