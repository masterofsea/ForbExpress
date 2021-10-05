using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ForbExpress.Models
{
    [EditorBrowsable(EditorBrowsableState.Never)]
    internal class IsExternalInit{}

    public static class DateTimeExtensions
    {
        public static int GetTotalMonthsFrom(this DateTime dt1, DateTime dt2)
        {
            var earlyDate = (dt1 > dt2) ? dt2.Date : dt1.Date;
            var lateDate = (dt1 > dt2) ? dt1.Date : dt2.Date;

            // Start with 1 month's difference and keep incrementing
            // until we overshoot the late date
            var monthsDiff = 1;
            while (earlyDate.AddMonths(monthsDiff) <= lateDate)
            {
                monthsDiff++;
            }

            return monthsDiff - 1;
        }
    }

    public class Contract : IEquatable<Contract>
    {
        public int Id { get; set; }
        
        public string Address { get; set; }
        
        public ContractState ContractState { get; set; }
        
        /// <summary>
        /// Дата заключения договора аренды
        /// </summary>
        [DisplayName("Дата заключения")]
        public DateTime ConclusionDate { get; set; }

        /// <summary>
        /// ИФНС
        /// </summary>
        [DisplayName("ИФНС")]
        public string Ifts { get; set; }
        
        /// <summary>
        /// Номер договора
        /// </summary>
        [DisplayName("Номер договора")]
        public string ContractNumber { get; set; }

        /// <summary>
        /// Дата начала договора
        /// </summary>
        public DateTime LeaseStartDate { get; set; }

        /// <summary>
        /// Дата завершения договора
        /// </summary>
        public DateTime LeaseEndDate { get; set; }

        /// <summary>
        /// Срок договора  в целом числе месяцев
        /// </summary>
        public int LeaseTerm { get; set; }

        /// <summary>
        /// Тип регистрации
        /// </summary>
        public RegistrationType RegistrationType { get; set; }

        public int? PartnerId { get; set; }
        /// <summary>
        /// ИНформация о партнере
        /// </summary>
        public Partner Partner { get; set; }

        public int LesseeId { get; set; }
        /// <summary>
        /// ИНформация об арендаторе
        /// </summary>
        public Lessee Lessee { get; set; }

        [DisplayName("Цена 1")]
        public decimal Price1 { get; set; }

        [DisplayName("Цена 2")]
        public decimal Price2 { get; set; }
        
        public PaymentForm PaymentForm { get; set; }
        
        [DisplayName("Оплачено")]
        public bool Paid { get; set; }
        
        public bool Receipt { get; set; }

        public decimal Penalty { get; set; }

        public bool IsReturnableCopy { get; set; }

        public bool MonthlyActs { get; set; }
        
        public int? MailContractId { get; set; }
        public MailContract MailContract { get; set; }
        
        [Display(Name = "Хранение документов")]
        public bool DocumentsStorage { get; set; }
        

        public bool Equals(Contract other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return Id == other.Id;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;

            return obj.GetType() == GetType() && Equals((Contract)obj);
        }

        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }
    }

    public enum RegistrationType
    {
        New,
        Change,
        Prolongation
    }

    public class MailContract
    {
        public int Id { get; set; }
        
        public string MailContractNumber { get; set; }
        
        public DateTime ConclusionDate { get; set; }

        public DateTime LeaseBeginDate { get; set; }

        public DateTime LeaseEndDate { get; set; }

        public int LeaseTerm { get; set; }

        public bool HasProxy { get; set; }
        
        public decimal Price1 { get; set; }
        
        public decimal Price2 { get; set; }
        
        public DateTime ControlDate { get; set; }
        
        public string Responsible { get; set; }
    }


    public enum Ifts
    {
        All = 0,
        First = 24,
        Second = 38,
        Third = 42,
        Fourth = 64
    }
    public enum ContractState
    {
        Active,
        Disabled    
    }
    
    public enum PaymentForm 
    {
        Mixed,
        NonCash,
        Cash
    }
}