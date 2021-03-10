using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShortUrl.CMD
{
    class Program
    {
        static void Main(string[] args)
        {
            int i = 1;//701882
            List<string> codeList = new List<string>();
            var cen = new GenerateShortURL();
            while (i<99999999)
            {
                // cen.ConfusionConvert(i) //先插入数据，产生自增ID，然后用自增ID生成随机字符串
                //var long = md5Str.ToString()

                //var val = DateTime.Now.toun + i;  //Utils.GenerateCode(6);//
                var code = cen.ConfusionConvert(i);//Utils.GenerateCode(); // cen.ConfusionConvert(i);//GetChart(4, i+new Random().Next(1,10)+1000000);//GenerateUniqueText(4);//GetChart(4, GuidToLongID());//GetRandString(6, 90000000);// GenerateRandomCode(4);//
               // Console.WriteLine($"Num : {i}");
               // Console.WriteLine($"Code : {code}");
                //if (codeList.Contains(code))
                //{
                    //codeList.OrderBy(c => c);
                    //foreach (var item in codeList)
                    //{
                    //    Console.WriteLine(item);
                    //}
                 //   Console.WriteLine("任务结束");
                 //   Console.ReadKey();
               // }
                codeList.Add(code);
                i++;
            }
            Console.WriteLine("去从前：" + codeList.Count);
            Console.WriteLine("去从后：" + codeList.Distinct().Count());
            Console.ReadKey();
            Console.WriteLine("Hello World!");
        }
    }
}
