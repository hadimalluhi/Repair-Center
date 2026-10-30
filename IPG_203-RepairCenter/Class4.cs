using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeApplianceRepairCenter
{
    public class WashingMachine : Appliance
    {
        private int drumCapacity;

        public int DrumCapacity
        {
            get { return drumCapacity; }
            set { drumCapacity = value; }
        }

        public WashingMachine(string serialNumber, string brand, string model, double basePrice, int drumCapacity)
            : base(serialNumber, brand, model, basePrice)
        {
            this.drumCapacity = drumCapacity;
        }

        public override double CalculateRepairCost()
        {
            return BasePrice + (DrumCapacity * 15);
        }

        public override string GetDetails()
        {
            return $"[غسالة] " + base.GetDetails() + $" | سعة الحوض: {DrumCapacity}kg | التكلفة الكلية: {CalculateRepairCost()}";
        }
    }
}