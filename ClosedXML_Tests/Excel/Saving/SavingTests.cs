﻿using ClosedXML.Excel;
using NUnit.Framework;
using System.IO;

namespace ClosedXML_Tests.Excel.Saving
{
    [TestFixture]
    public class SavingTests
    {
        [Test]
        public void CanSuccessfullySaveFileMultipleTimes()
        {
            using (var wb = new XLWorkbook())
            {
                var sheet = wb.Worksheets.Add("TestSheet");
                var memoryStream = new MemoryStream();
                wb.SaveAs(memoryStream, true);

                for (int i = 1; i <= 3; i++)
                {
                    sheet.Cell(i, 1).Value = "test" + i;
                    wb.SaveAs(memoryStream, true);
                }

                memoryStream.Close();
                memoryStream.Dispose();
            }
        }
    }
}
