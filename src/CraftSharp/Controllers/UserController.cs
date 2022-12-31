﻿using CraftSharp.Models;
using CraftSharp.Services;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Globalization;
using System.Net;

namespace CraftSharp.Controllers
{
    [Microsoft.AspNetCore.Mvc.Route("[controller]/[action]")]
    public class UserController : Controller
    {
        [HttpPost]
        public IActionResult SetUser([FromBody] String user)
        {
            if (user != null)
            {
                HttpContext.Response.Cookies.Append(
                    "CurrentUser", user
                    );
            }
            Console.WriteLine("USER : " + user);

            return Ok(new { result = "userCookieSet" });
        }

        public IActionResult DeleteUser()
        {

            this.HttpContext.Response.Cookies.Delete(
                "CurrentUser"
                );
            return Ok(new { result = "userCookieDeleted" });

        }

        public IActionResult GetUser()
        {
            var jsonUser = HttpContext.Request.Cookies["CurrentUser"];
            return Ok(new { result = JsonConvert.DeserializeObject<CurrentUser>(jsonUser) });
        }
    }
}