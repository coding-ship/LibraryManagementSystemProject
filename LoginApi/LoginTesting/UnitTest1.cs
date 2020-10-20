using LoginApi.Controllers;
using LoginApi.Models;
using LoginApi.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Moq;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;

namespace LoginTesting
{
    public class Tests
    {
        DatabaseDbContext context;



List<Usercheck> user = new List<Usercheck>();
IQueryable<Usercheck> userdata;
Mock<DbSet<Usercheck>> mockSet;
Mock<DatabaseDbContext> usercontextmock;
[SetUp]
public void Setup()
{
    user = new List<Usercheck>()
            {
                new Usercheck{Id=1,UserName="abc",Password="abc123"}

            };
    userdata = user.AsQueryable();
    mockSet = new Mock<DbSet<Usercheck>>();
    mockSet.As<IQueryable<Usercheck>>().Setup(m => m.Provider).Returns(userdata.Provider);
    mockSet.As<IQueryable<Usercheck>>().Setup(m => m.Expression).Returns(userdata.Expression);
    mockSet.As<IQueryable<Usercheck>>().Setup(m => m.ElementType).Returns(userdata.ElementType);
    mockSet.As<IQueryable<Usercheck>>().Setup(m => m.GetEnumerator()).Returns(userdata.GetEnumerator());
    var p = new DbContextOptions<DatabaseDbContext>();
    usercontextmock = new Mock<DatabaseDbContext>(p);
    usercontextmock.Setup(x => x.Usercheck).Returns(mockSet.Object);



}


[Test]
public void LoginTestPass()
{

    Mock<IConfiguration> config = new Mock<IConfiguration>();
    config.Setup(p => p["Jwt:Key"]).Returns("ThisismySecretKey");
    var controller = new TokenValidateController(config.Object, usercontextmock.Object);
    var auth = controller.LoginResult(new Usercheck { Id = 1, UserName = "abc", Password = "abc123" }) as OkObjectResult;

    Assert.AreEqual(200, auth.StatusCode);

}

[Test]
public void LoginTestFail()
{
            Mock<IConfiguration> config = new Mock<IConfiguration>();
            config.Setup(p => p["Jwt:Key"]).Returns("ThisismySecretKey");
            var controller = new TokenValidateController(config.Object, usercontextmock.Object);
            var auth = controller.LoginResult(new Usercheck { Id = 1, UserName = "abc", Password = "c123" }) as OkObjectResult;
Assert.IsNull(auth);

}

    }
}