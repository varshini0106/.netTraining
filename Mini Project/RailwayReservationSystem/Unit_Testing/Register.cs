
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using RailwayReservationSystem.Services;
//using NUnit.Framework;
//using NUnit.Framework.Legacy;


//namespace Unit_Testing
//{
//    [TestFixture]
//    public class Register
//    {
//        RegisterService registerservice = new RegisterService();
//        [Test]
//        public void Register_User()
//        {
//            bool user = registerservice.Register("arka");
//            ClassicAssert.AreEqual(user, true);
//        }
//        [Test]
//        public void Register_NonUser()
//        {
//            bool user = registerservice.Register("chaitra");
//            ClassicAssert.AreEqual(user, true);
//        }
//    }
//}
