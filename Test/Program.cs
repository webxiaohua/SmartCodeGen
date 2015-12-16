using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {
            Test.Business.user userBusiness = new Business.user();
            int result = userBusiness.Add(new Test.Model.user()
            {
                Id = 1,
                LoginName = "Robin",
                Password = "123123",
                Age = 23,
                CreateTime = DateTime.Now,
                UserSex = 1
            });
            Console.WriteLine(result != 0 ? "新增成功" : "新增失败");
            Console.Read();
        }
    }
}
