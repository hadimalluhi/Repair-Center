using System;

namespace HomeApplianceRepairCenter
{
    // تعريف التفويض (Delegate)
    public delegate void RepairStatusHandler(string message);

    // واجهة العمليات (Interface)
    public interface IApplianceOperations
    {
        void StartRepair();
        string GetDetails();
    }

    // الفئة المجردة (Abstract Class)
    public abstract class Appliance : IApplianceOperations
    {
        private string serialNumber;
        private string brand;
        private string model;
        private double basePrice;
        private string status;

        // خاصية ثابتة (Static Member)
        private static int totalDevicesCount = 0;
        public static int TotalDevicesCount
        {
            get { return totalDevicesCount; }
        }

        // خاصية للقراءة فقط بعد الإنشاء (Read-only Property)
        public string SerialNumber
        {
            get { return serialNumber; }
        }

        public string Brand
        {
            get { return brand; }
            set { brand = value; }
        }

        public string Model
        {
            get { return model; }
            set { model = value; }
        }

        public double BasePrice
        {
            get { return basePrice; }
            set { basePrice = value > 0 ? value : 0; }
        }

        public string Status
        {
            get { return status; }
            set { status = value; }
        }

        protected Appliance(string serialNumber, string brand, string model, double basePrice)
        {
            if (!ValidationUtils.IsValidSerialNumber(serialNumber))
            {
                throw new ArgumentException("الرقم التسلسلي غير صالح!");
            }

            this.serialNumber = serialNumber;
            this.brand = brand;
            this.model = model;
            this.basePrice = basePrice;
            this.status = "قيد الانتظار";

            totalDevicesCount++;
        }

        public virtual void StartRepair()
        {
            Status = "قيد الصيانة";
            Console.WriteLine($"[صيانة] بدأت صيانة الجهاز ذو الرقم التسلسلي: {SerialNumber}");
        }

        public virtual string GetDetails()
        {
            return $"الرقم التسلسلي: {SerialNumber} | الماركة: {Brand} | الطراز: {Model} | السعر الأساسي: {BasePrice} | الحالة: {Status}";
        }

        // دالة مجردة (Abstract Method)
        public abstract double CalculateRepairCost();
    }
}