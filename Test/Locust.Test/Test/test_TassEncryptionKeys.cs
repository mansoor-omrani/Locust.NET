using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Locust.Test.Test
{
    public class test_TassEncryptionKeys:BaseTest
    {
        public override void Test()
        {
            var serialno = "TO0X-NRAS-R73Q-83OM";
            var hardwarecode = "CX123456";
            var activationkey = "BS6R-EA72-YJN7-2GY6";

            System.Console.WriteLine("Key0: " + TassEncryptionKeys.Key0(serialno));
            System.Console.WriteLine("Key1: " + TassEncryptionKeys.Key1(hardwarecode, serialno));
            System.Console.WriteLine("Key2: " + TassEncryptionKeys.Key2(hardwarecode));
            System.Console.WriteLine("Key3: " + TassEncryptionKeys.Key3(hardwarecode, activationkey));

            /*
             * result:
              
                Key0: YXYHan1qcmBmAQFn
                Key1: FxcBan1mdGURbwJj
                Key2: dmEGAAAMBgV3bgME
                Key3: AQsHYHZ1AgQaEn8F
             */
        }
    }
}
