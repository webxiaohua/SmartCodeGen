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
            TestAdd();
            //TestDelete();
            //TestUpdate();
            //TestSelectSingle();
            //TestSelectAll();
            Console.Read();
        }

        public static void TestAdd()
        {
            Test.Business.User UserBusiness = new Business.User();
            int result = UserBusiness.Add(new Test.Model.User()
            {
                LoginName = "Hotss",
                Password = "798978",
                Age = 23,
                CreateTime = DateTime.Now,
                UserSex = 1
            });
            Console.WriteLine(result != 0 ? "新增成功" : "新增失败");
        }

        public static void TestDelete()
        {
            Test.Business.User UserBusiness = new Business.User();
            int result = UserBusiness.Delete(1);
            Console.WriteLine(result != 0 ? "删除成功" : "删除失败");
        }

        public static void TestSelectAll()
        {
            Test.Business.User UserBusiness = new Business.User();
            List<Test.Model.User> UserList = UserBusiness.GetAll();
            foreach (var item in UserList)
            {
                Console.WriteLine(item.LoginName + "\t" + item.Password);
            }
        }

        public static void TestSelectSingle()
        {
            Test.Business.User UserBusiness = new Business.User();
            Test.Model.User User = UserBusiness.Get(3);
            Console.WriteLine("用户名：" + User.LoginName + "\t" + "创建时间：" + User.CreateTime.ToString());
        }

        public static void TestUpdate()
        {
            Test.Business.User UserBusiness = new Business.User();
            int result = UserBusiness.Update(new Test.Model.User()
            {
                Id = 2,
                LoginName = "Hots",
                Password = "123456",
                CreateTime = DateTime.Now
            });
            Console.WriteLine(result != 0 ? "更新成功" : "更新失败");
        }
    }
}
