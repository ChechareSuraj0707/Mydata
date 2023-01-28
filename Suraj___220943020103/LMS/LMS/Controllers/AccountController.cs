using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using LMS.Models;
using BOL;
using SAL;

namespace LMS.Controllers;

public class AccountController : Controller
{
    private readonly ILogger<AccountController> _logger;

    public AccountController(ILogger<AccountController> logger)
    {
         Console.WriteLine("Account constructor is invoked....");
      

        _logger = logger;
    }

    
    [HttpGet]
    public IActionResult Login()
    {
       
        return View();
       
    }


    [HttpPost]
    public IActionResult Login(string email, string password)
    {
      

         AccountService c=new AccountService();
          bool status=c.LoginCheck(email,password);
          Console.WriteLine(status);

          if (status)
          {
            Response.Redirect("/Topic/index");
          }
      
        return View();
    }

    
   
}
