using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System;
using System.Collections.Generic;

namespace HomeApplianceRepairCenter
{
    public class RepairCenterManager
    {
        private List<Appliance> appliances = new List<Appliance>();

        // تعريف الحدث (Event)
        public event RepairStatusHandler OnRepairCompleted;

        public void AddAppliance(Appliance appliance)
        {
            appliances.Add(appliance);
            Console.WriteLine($"[إدارة] تم تسجيل الجهاز بنجاح: {appliance.SerialNumber}");
        }

        public Appliance FindAppliance(string serialNumber)
        {
            foreach (var app in appliances)
            {
                if (app.SerialNumber == serialNumber)
                    return app;
            }
            return null;
        }

        public void CompleteRepair(string serialNumber)
        {
            Appliance app = FindAppliance(serialNumber);
            if (app != null)
            {
                app.Status = "تم الإصلاح بنجاح";
                // إطلاق الحدث إشعاراً باكتكال الصيانة
                OnRepairCompleted?.Invoke($"إشعار النظام: تم الانتهاء من صيانة الجهاز رقم ({app.SerialNumber}) وتكلفته النهائية {app.CalculateRepairCost()} ليرة.");
            }
            else
            {
                Console.WriteLine("خطأ: لم يتم العثور على الجهاز المحدد!");
            }
        }

        public void DisplayAllAppliances()
        {
            Console.WriteLine("\n--- قائمة أجهزة مركز الصيانة الحالية ---");
            foreach (var app in appliances)
            {
                Console.WriteLine(app.GetDetails());
            }
        }

        public double GetTotalRepairCosts()
        {
            double total = 0;
            foreach (var app in appliances)
            {
                total += app.CalculateRepairCost();
            }
            return total;
        }
    }
}