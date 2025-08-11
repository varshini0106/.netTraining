using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RailwayReservationSystem.Services;
using NUnit.Framework;
using NUnit.Framework.Legacy;

namespace Unit_Testing
{
    public class BaseTest
    {
        protected LoginService loginservice;

        [SetUp] //to initialize the object
        public void Setup()
        {
            loginservice = new LoginService();
        }
    }

    [TestFixture]
    public class User_Login : BaseTest
    {
        [Test]
        public void TrueUserLogin()
        {
            bool user = loginservice.UserLogin("alice", "alice123");
            ClassicAssert.AreEqual(user, true);            
        }
        [Test]
        public void FalseUserLogin()
        {
            bool user = loginservice.UserLogin("Bob", "bob123");
            ClassicAssert.AreNotEqual(user, true);
        }
    }

    [TestFixture]
    public class Admin_Login : BaseTest
    {
        [Test]
        public void TrueAdmin()
        {
            bool admin = loginservice.AdminLogin("admin", "admin123");
            ClassicAssert.AreEqual(admin, true);
        }
        [Test]
        public void FalseAdmin()
        {
            bool admin = loginservice.AdminLogin("new_admin", "admin456");
            ClassicAssert.AreNotEqual(admin, true);
        }
    }
}
