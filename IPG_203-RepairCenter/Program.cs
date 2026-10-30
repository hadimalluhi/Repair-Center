using System;

namespace HomeApplianceRepairCenter
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            Console.WriteLine("=== نظام إدارة مركز صيانة الأجهزة المنزلية (OOP Project) ===");

            RepairCenterManager manager = new RepairCenterManager();

            // ربط الحدث (Event) لطباعة الرسائل الإشعارية تلقائياً
            manager.OnRepairCompleted += (string message) =>
            {
                Console.WriteLine($"\n*** [تنبيه الحدث - EVENT] {message} ***\n");
            };

            // إنشاء الأجهزة
            Appliance ref1 = new Refrigerator("REF-1001", "Samsung", "Digital Inverter", 250, 180);
            Appliance wm1 = new WashingMachine("WM-2002", "LG", "TurboWash", 300, 9);
            Appliance ac1 = new AirConditioner("AC-3003", "Gree", "Inverter Pro", 450, 18000);

            // إضافة الأجهزة إلى المدير
            manager.AddAppliance(ref1);
            manager.AddAppliance(wm1);
            manager.AddAppliance(ac1);

            // طباعة العداد الثابت (Static Property)
            Console.WriteLine($"\n[معلومة النظام] إجمالي عدد الأجهزة المسجلة بالمركز: {Appliance.TotalDevicesCount}");

            // عرض كافة التفاصيل (تعدد الأشكال Polymorphism)
            manager.DisplayAllAppliances();

            // تنفيذ عملية صيانة وإطلاق الحدث
            Console.WriteLine("\n--- بدء سير العمليات في المركز ---");
            ref1.StartRepair();
            manager.CompleteRepair("REF-1001");

            // حساب التكلفة الكلية
            Console.WriteLine($"إجمالي تكاليف الإصلاح لكافة الأجهزة: {manager.GetTotalRepairCosts()} ليرة سورية.");

            Console.WriteLine("\nاضغط على أي مفتاح لإغلاق البرنامج...");
            Console.ReadKey();
        }
    }
}