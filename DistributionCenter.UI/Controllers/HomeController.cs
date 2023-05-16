using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using DistributionCenter.UI.Models;
using Microsoft.AspNetCore.Hosting.Server;

namespace DistributionCenter.UI.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        return View();
    }

    [HttpPost("UploadFiles")]
    public async Task<IActionResult> Post(IFormFile files)
    {


        // full path to file in temp location
        var filePath = Path.GetTempFileName();
        if (files.Length > 0)
        {
            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await files.CopyToAsync(stream);
            }
        }


        // process uploaded files
        // Don't rely on or trust the FileName property without validation.

        return Ok(new { filePath });
    }

    [HttpPost]
    public ActionResult UploadFile(IFormFile file)
    {
        try
        {
            if (file.Length > 0)
            {
                string _FileName = Path.GetFileName(file.FileName);
                string _path = Path.Combine(Server.MapPath("~/UploadedFiles"), _FileName);
                file.(_path);
            }
            ViewBag.Message = "File Uploaded Successfully!!";
            return View();
        }
        catch
        {
            ViewBag.Message = "File upload failed!!";
            return View();
        }
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}

