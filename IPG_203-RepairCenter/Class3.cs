using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeApplianceRepairCenter
{
    public class Refrigerator : Appliance
    {
        private double freezerCapacity;

        public double FreezerCapacity
        {
            get { return freezerCapacity; }
            set { freezerCapacity = value; }
        }

        public Refrigerator(string serialNumber, string brand, string model, double basePrice, double freezerCapacity)
            : base(serialNumber, brand, model, basePrice)
        {
            this.freezerCapacity = freezerCapacity;
        }

        public override double CalculateRepairCost()
        {
            return BasePrice + (FreezerCapacity * 0.5);
        }

        public override string GetDetails()
        {
            return $"[ثلاجة] " + base.GetDetails() + $" | سعة الفريزر: {FreezerCapacity}L | التكلفة الكلية: {CalculateRepairCost()}";
        }
    }
}