using CRUD_application_2.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using NUnit.Framework;

namespace CRUD_application_2.Controllers
{
    public class UserController : Controller
    {
        public static System.Collections.Generic.List<User> userlist = new System.Collections.Generic.List<User>();
        // GET: User
        public ActionResult Index()
        {
            // Implement the Index method here
            return View(userlist);

        }
 
        // GET: User/Details/5
        public ActionResult Details(int id)
        {
            // Implement the details method here
            var user = userlist.FirstOrDefault(u => u.Id == id);
            if (user == null)
            {
                return HttpNotFound();
            }

            return View(user);

        }
 
        // GET: User/Create
        public ActionResult Create()
        {
            //Implement the Create method here
            return View();
        }
 
        // POST: User/Create
        [HttpPost]
        public ActionResult Create(User user)
        {
            // Implement the Create method (POST) here
            if (ModelState.IsValid)
            {
                userlist.Add(user);
                return RedirectToAction("Index");
            }
            return View(user);
        }
 
        // GET: User/Edit/5
        public ActionResult Edit(int id)
        {
            // This method is responsible for displaying the view to edit an existing user with the specified ID.
            // It retrieves the user from the userlist based on the provided ID and passes it to the Edit view.
            // If no user is found with the provided ID, it returns a HttpNotFoundResult.
            var user = userlist.FirstOrDefault(u => u.Id == id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);

        }
 
        // POST: User/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, User user)
        {
            // This method is responsible for handling the HTTP POST request to update an existing user with the specified ID.
            // It receives user input from the form submission and updates the corresponding user's information in the userlist.
            // If successful, it redirects to the Index action to display the updated list of users.
            // If no user is found with the provided ID, it returns a HttpNotFoundResult.
            // If an error occurs during the process, it returns the Edit view to display any validation errors.
            if (ModelState.IsValid)
            {
                var existingUser = userlist.FirstOrDefault(u => u.Id == id);
                if (existingUser != null)
                {
                    existingUser.Name = user.Name;
                    existingUser.Email = user.Email;                    
                    return RedirectToAction("Index");
                }
                else
                {
                    return HttpNotFound();
                }
            }
            return View(user);
        }
 
        // GET: User/Delete/5
        public ActionResult Delete(int id)
        {
            // Implement the Delete method here
            var user = userlist.FirstOrDefault(u => u.Id == id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

 
        // POST: User/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            // Implement the Delete method (POST) here
            var user = userlist.FirstOrDefault(u => u.Id == id);    
            if (user != null)
            {
                userlist.Remove(user);
            }
            return RedirectToAction("Index");
        }

       // create search functionality         
        public ActionResult Search(string searchTerm)
        {
            var searchResult = userlist.Where(x => x.Name.Contains(searchTerm) || x.Email.Contains(searchTerm)).ToList();
            return View("Index", searchResult);
        }

    }

    //[TestFixture]
    //public class UserControllerTests
    //{
    //    private UserController _userController;
    //    private List<User> _users;

    //    [SetUp]
    //    public void Setup()
    //    {
    //        _userController = new UserController();

    //        _users = new List<User>
    //    {
    //        new User { Id = 1, Name = "User1", Email = "user1@example.com" },
    //        new User { Id = 2, Name = "User2", Email = "user2@example.com" },
    //        new User { Id = 3, Name = "User3", Email = "user3@example.com" },
    //    };

    //        UserController.userlist = _users;
    //    }

    //    [Test]
    //    public void Delete_UserExists_ReturnsViewWithUser()
    //    {
    //        var result = _userController.Delete(1) as ViewResult;
    //        var model = result.Model as User;

    //        Assert.IsNotNull(result);                        
    //        Assert.AreEqual("User1", model.Name);
    //    }

    //    [Test]
    //    public void Delete_UserDoesNotExist_ReturnsHttpNotFound()
    //    {
    //        var result = _userController.Delete(4);

    //        Assert.IsInstanceOf<HttpNotFoundResult>(result);
    //    }

    //    [Test]
    //    public void Create_ValidUser_AddsUserToListAndRedirects()
    //    {
    //        var newUser = new User { Id = 4, Name = "User4", Email = "user4@example.com" };
    //        var result = _userController.Create(newUser) as RedirectToRouteResult;

    //        Assert.IsNotNull(result);
    //        Assert.AreEqual(4, UserController.userlist.Count);
    //        Assert.AreEqual("Index", result.RouteValues["action"]);
    //    }

    //    // Add more tests for other methods as needed
    //}

}

