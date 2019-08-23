using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using HobbyHub.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;

namespace HobbyHub.Controllers
{
    public class HomeController : Controller
    {
        private HobbyContext dbContext;
        public HomeController(HobbyContext context)
        {
            dbContext = context;
        }

        [Route("/")]
        [HttpGet]
        public IActionResult Register()
        {
            return View("RegisterView");
        }

        [Route("register")]
        [HttpPost]
        public IActionResult Register(User submitted_info)
        {
            submitted_info.CreatedAt = DateTime.Now;
            submitted_info.UpdatedAt = DateTime.Now;
            if (ModelState.IsValid)
            {
                // If a User exists with provided email
                if(dbContext.users.Any(u => u.UserName == submitted_info.UserName))
                {
                    // Manually add a ModelState error to the Email field, with provided
                    // error message
                    ModelState.AddModelError("UserName", "UserName already in use!");
                    return View("RegisterView");
                    // You may consider returning to the View at this point
                }
                //LOGIC FOR ADDING TO DB
                PasswordHasher<User> Hasher = new PasswordHasher<User>();
                submitted_info.Password = Hasher.HashPassword(submitted_info, submitted_info.Password);
                HttpContext.Session.SetInt32("ID", submitted_info.UserId);
                dbContext.Add(submitted_info);
                dbContext.SaveChanges();
                return RedirectToAction("loginuser");
            }else{
                Console.WriteLine("NOT VALID**************", ModelState.Keys);
                foreach(var error in ModelState)
                {
                    if (error.Value.Errors.Count > 0)
                    {
                        Console.WriteLine("err msg " + error.Value.Errors[0].ErrorMessage);
                    }
                }
            return View("RegisterView"); 
        }
}

        [Route("loginuser")]
        [HttpGet]
        public IActionResult loginuser()
        {
            return View("LoginView");
        }

        [Route("login")]
        [HttpPost]
        public IActionResult login(LoginUser databaseUser)
        {
            //Check if exists by querying db using Email
            User DatabaseUser = dbContext.users.SingleOrDefault(u => u.UserName == databaseUser.UserName);
            System.Console.WriteLine(DatabaseUser);
            if(DatabaseUser == null){
                ModelState.AddModelError("UserName","That UserName Doesn't Exist!");
                return View("LoginView");
            }
            System.Console.WriteLine(ModelState.IsValid);
            if(ModelState.IsValid)
            {
            var hasher = new PasswordHasher<LoginUser>();
                 // Verify provided password against hash stored in db
            var result = hasher.VerifyHashedPassword(databaseUser, DatabaseUser.Password, databaseUser.Password);

                 // result can be compared to 0 for failure
            if(result == 0){
                System.Console.WriteLine("Password failed");

                ModelState.AddModelError("UserName", "UserName or Password incorrect");
                System.Console.WriteLine("Didn't match password");
                return View("LoginView");
                     // handle failure (this should be similar to how "existing email" is handled)
            }
            System.Console.WriteLine("Login success");
            HttpContext.Session.SetInt32("ID", DatabaseUser.UserId);
            System.Console.WriteLine("Password Matched");
            return RedirectToAction("Dashboard");
        }
        return View("LoginView");    
        }

        [HttpGet]
        [Route("dashboard")]
        public IActionResult Dashboard()
        {
            if(HttpContext.Session.GetInt32("ID") == null)
            {
                return RedirectToAction("Register");
            }
            else
            {
            int? UserId = HttpContext.Session.GetInt32("ID");
            User CurrentUser = dbContext.users.SingleOrDefault(users => users.UserId == HttpContext.Session.GetInt32("ID"));
            List<Hobby> Allhobbies = dbContext.hobbies
                .Include(h => h.Fan).ToList();
            ViewBag.UserId = HttpContext.Session.GetInt32("ID");
            ViewBag.CurrentUser = CurrentUser;
            ViewBag.Allhobbies = Allhobbies;
            return View ("Dashboard");
        }
    }

        [HttpGet("createHobby")]
        public IActionResult CreateHobby()
        {
            if (HttpContext.Session.GetInt32("ID") == null)
            {
                return RedirectToAction("Register");
            }
            return View("CreateHobby");
        }

        [HttpPost("processHobby")]
        public IActionResult ProcessHobby(Hobby hobby)
        {
            if(ModelState.IsValid)
            {
                int? sessionUser = HttpContext.Session.GetInt32("ID");
                hobby.UserId = (int)sessionUser;
                dbContext.Add(hobby);
                dbContext.SaveChanges();
                var hobby_id = hobby.HobbyId;
                return RedirectToAction("Dashboard");
            }
            return View("CreateHobby");
        }

        [HttpGet("ShowOneHobby/{hobbyId}")]
        public IActionResult ShowOneHobby(int hobbyId)
        {
            if (HttpContext.Session.GetInt32("ID") == null)
            {
                return RedirectToAction("Register");
            }
            Hobby CurrentHobby = dbContext.hobbies
            .Include(h => h.Fan)
                .ThenInclude(f => f.User)
                    .SingleOrDefault(h => h.HobbyId == hobbyId);
                ViewBag.CurrentHobby = CurrentHobby;
                ViewBag.UserId = HttpContext.Session.GetInt32("ID");            
            return View(CurrentHobby); 
        }

        [HttpGet("join/{hobbyId}")]       
        public IActionResult JoinTheHobby(int hobbyId)
        {
            if(HttpContext.Session.GetInt32("ID") == null)
            {
                return RedirectToAction("Register");
            }
            int? sessionUser = HttpContext.Session.GetInt32("ID");
            Fan newFan = new Fan();
            newFan.HobbyId = hobbyId;
            newFan.UserId = (int) sessionUser;
            dbContext.fans.Add(newFan);
            dbContext.SaveChanges();
            return RedirectToAction("Dashboard");
        }

        [HttpGet("hobby/edit/{hobbyId}")]
        public IActionResult EditHobby(int hobbyId)
        {
            if(HttpContext.Session.GetInt32("ID") == null)
            {
                return RedirectToAction("Register");
            }
            int? sessionUser = HttpContext.Session.GetInt32("ID");
            Hobby CurrentHobby = dbContext.hobbies
                .Include(h => h.Fan)
                    .ThenInclude(f => f.User)
                        .SingleOrDefault(h => h.HobbyId == hobbyId);
                    ViewBag.CurrentHobby = CurrentHobby;
                    ViewBag.UserId = HttpContext.Session.GetInt32("ID");
            return View(CurrentHobby);
        }

        [HttpPost("hobby/edit/{hobbyId}/post")]
        public IActionResult PostEditHobby(int hobbyId, Hobby hobby)
        {
           if(ModelState.IsValid)
            {
                int? sessionUser = HttpContext.Session.GetInt32("ID");
                Hobby editedHobby = dbContext.hobbies.FirstOrDefault(h => h.HobbyId == hobbyId);
                editedHobby.Name = hobby.Name;
                editedHobby.Description = hobby.Description;
                dbContext.SaveChanges();
                return RedirectToAction("Dashboard");
            }
            return View("EditHobby");
        }

        [HttpGet("delete/{hobbyId}")]
        public IActionResult Delete(int hobbyId)
        {
            if (HttpContext.Session.GetInt32("ID") == null)
            {
                return RedirectToAction("Register");
            }
            Hobby theHobby = dbContext.hobbies.SingleOrDefault(h => h.HobbyId == hobbyId);
            dbContext.hobbies.Remove(theHobby);
            dbContext.SaveChanges();
            return RedirectToAction("Dashboard");
        }

        [HttpGet("logout")]     //CLEAR SESSION, REDIRECT TO LOGIN: LOGOUT
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("loginuser");
        }
    }   
}

