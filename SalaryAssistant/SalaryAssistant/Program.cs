using System;

namespace SalaryAssistant
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Xahish olunur Umumi emek haqqinizi daxil edin:");
            float GrossProfit = float.Parse(Console.ReadLine());
            float TotalGrossProfit = GrossProfit;
            bool isWrittenCorrect;
            string MaritalStatus;
            int NumberOfChildren;
            string DisabilityStatus;
            float SalaryTax;
            int ChildCompensation = 0;
            int FamilyAssistance = 0;
            float SalaryTaxPercentage = 0;
            float DisabilityTaxDiscountPercent = 100;
            do
            {
                Console.WriteLine("Xahis olunur Aile veziyyetinizi qeyd edin (Evli),(Subay),(Dul):");
                MaritalStatus = Console.ReadLine().ToLower();
                if (MaritalStatus == "evli" || MaritalStatus == "subay" || MaritalStatus == "dul")
                {
                    isWrittenCorrect = false;
                }
                else
                {
                    isWrittenCorrect = true;
                }
            } while (isWrittenCorrect);
            if (MaritalStatus == "evli")
            {
                FamilyAssistance = FamilyAssistance + 50;
                TotalGrossProfit = TotalGrossProfit + FamilyAssistance;
            }
            if (MaritalStatus == "evli" || MaritalStatus == "dul")
            {
                Console.WriteLine("Ushaqlarinizin sayi haqqinda melumati daxil edin, yoxdursa (0) qeyd edin:");
                NumberOfChildren = Convert.ToInt32(Console.ReadLine());
                if (NumberOfChildren > 0)
                {
                    ChildCompensation = ChildCompensation + 30;
                }
                if (NumberOfChildren > 1)
                {
                    ChildCompensation = ChildCompensation + 25;
                }
                if (NumberOfChildren > 2)
                {
                    ChildCompensation = ChildCompensation + 20;
                }
                if (NumberOfChildren > 3)
                {
                    int n = NumberOfChildren - 3;
                    ChildCompensation = ChildCompensation + (15 * n);
                }
                TotalGrossProfit = TotalGrossProfit + ChildCompensation;
            }
            isWrittenCorrect = true;
            do
            {
                Console.WriteLine("Elillik ve saghlamliq imkanlari mehdudlughunuz varmidir? (He) ve ya (Yox) cavabindan isdifade edin:");
                DisabilityStatus = Console.ReadLine().ToLower();
                if (DisabilityStatus == "he" || DisabilityStatus == "yox")
                {
                    isWrittenCorrect = false;
                }
                else
                {
                    isWrittenCorrect = true;
                }
            } while (isWrittenCorrect);
            if (DisabilityStatus == "he")
            {
                DisabilityTaxDiscountPercent = 50;
            }
            if (GrossProfit <= 1000)
            {
                SalaryTaxPercentage = SalaryTaxPercentage + 15;
            }
            else if (GrossProfit <= 2000 && GrossProfit > 1000)
            {
                SalaryTaxPercentage = SalaryTaxPercentage + 20;
            }
            else if (GrossProfit <= 3000 && GrossProfit > 2000)
            {
                SalaryTaxPercentage = SalaryTaxPercentage + 25;
            }
            else
            {
                SalaryTaxPercentage = SalaryTaxPercentage + 30;
            }
            DisabilityTaxDiscountPercent = 100 - DisabilityTaxDiscountPercent;
            SalaryTaxPercentage = (SalaryTaxPercentage * DisabilityTaxDiscountPercent) / 100;
            SalaryTax = (TotalGrossProfit / 100) * SalaryTaxPercentage;
            float NetProfit = TotalGrossProfit - SalaryTax;
            Console.WriteLine("---------------------------------------------");
            Console.WriteLine($"Verilecek Aile Muavineti Mebleghi: {FamilyAssistance} manat");
            Console.WriteLine($"Verilecek Usaq Pulu Mebleghi: {ChildCompensation} manat");
            Console.WriteLine($"Gelir Vergisi Derecesi: {SalaryTaxPercentage}%");
            Console.WriteLine($"Gelir Vergisi Mebleghi: {SalaryTax.ToString("0.00")} manat");
            Console.WriteLine($"Umumi Emek Haqqiniz: {TotalGrossProfit} manat");
            Console.WriteLine($"Xalis emek haqqiniz: {NetProfit.ToString("0.00")} manat");
            Console.WriteLine("---------------------------------------------");
            int[] MonetaryUnits = { 200, 100, 50, 20, 10, 5, 1 };
            for (int i = 0; i < MonetaryUnits.Length; i++)
            {
                int UnitOfBanknote = Convert.ToInt32(Math.Floor(NetProfit / MonetaryUnits[i]));
                if (UnitOfBanknote != 0)
                {
                    Console.WriteLine($"{MonetaryUnits[i]}. pul vahidinden {UnitOfBanknote} eded chixardilacaq");
                }
                NetProfit = NetProfit - (MonetaryUnits[i] * UnitOfBanknote);
            }
            Console.WriteLine("---------------------------------------------");
        }
    }
}