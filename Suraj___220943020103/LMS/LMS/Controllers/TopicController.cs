using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using LMS.Models;

namespace LMS.Controllers;

public class TopicController : Controller
{
    private readonly ILogger<TopicController> _logger;

    public TopicController(ILogger<TopicController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        return View();
    }

    
   
}
