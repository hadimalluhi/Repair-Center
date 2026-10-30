using System;

namespace HomeApplianceRepairCenter
{
    public static class ValidationUtils
    {
        public static bool IsValidSerialNumber(string serial)
        {
            if (string.IsNullOrWhiteSpace(serial) || serial.Length < 4)
                return false;
            return true;
        }
    }
}