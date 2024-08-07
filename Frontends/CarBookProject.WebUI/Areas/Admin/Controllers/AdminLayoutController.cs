﻿using Microsoft.AspNetCore.Mvc;

namespace CarBookProject.WebUI.Areas.Admin.Controllers;

[Area("Admin")]
public class AdminLayoutController : Controller
{
    public IActionResult Index()
    {
        return View();
    }

    public IActionResult AdminHeaderPartial()
    {
        return View();
    }

    public IActionResult AdminNavbarPartial()
    {
        return View();
    }

    public IActionResult AdminSidebarPartial()
    {
        return View();
    }

    public IActionResult AdminFooterPartial()
    {
        return View();
    }

    public IActionResult AdminScriptPartial()
    {
        return View();
    }
}
