using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeApplianceRepairCenter
{
    public class AirConditioner : Appliance
    {
        private int btuCapacity;

        public int BtuCapacity
        {
            get { return btuCapacity; }
            set { btuCapacity = value; }
        }

        public AirConditioner(string serialNumber, string brand, string model, double basePrice, int btuCapacity)
            : base(serialNumber, brand, model, basePrice)
        {
            this.btuCapacity = btuCapacity;
        }

        public override double CalculateRepairCost()
        {
            return BasePrice + (BtuCapacity * 0.02);
        }

        public override string GetDetails()
        {
            return $"[مكيف] " + base.GetDetails() + $" | الاستطاعة: {BtuCapacity} BTU | التكلفة الكلية: {CalculateRepairCost()}";
        }
    }
}
