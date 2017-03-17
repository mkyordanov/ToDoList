﻿using Bytes2you.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ToDoList.Services.Contracts;
using Microsoft.AspNet.Identity;
using ToDoList.Models.Enums;

namespace ToDoList.Web.Controllers
{
    [Authorize]
    public class ToDoListController : Controller
    {
        private readonly IToDoListModelService toDoListModelService;
        public ToDoListController(IToDoListModelService toDoListModelService)
        {
            Guard.WhenArgument(toDoListModelService, "To-Do List service").IsNull().Throw();
            this.toDoListModelService = toDoListModelService;
        }
        [HttpGet]
        public ActionResult Create()
        {
            var categoryList = new List<SelectListItem>()
            {
                new SelectListItem { Text = "General", Value = "General", Selected=true},
                new SelectListItem { Text = "Personal", Value = "Personal"},
                new SelectListItem { Text = "Shopping", Value = "Shopping"},
                new SelectListItem { Text = "Work", Value = "Work"},
                new SelectListItem { Text = "Errands", Value = "Errands"},
                new SelectListItem { Text = "Entertainment", Value = "Entertainment"},
                new SelectListItem { Text = "Hobbies", Value = "Hobbies"}
            };
           
            return View(categoryList);
        }
        [HttpPost]
        public ActionResult Create(string name, bool isPublic, string category )
        {
            var selectedCategory = Enum.Parse(typeof(CategoryTypes), category);
            var userId = User.Identity.GetUserId();

            this.toDoListModelService.CreateToDoList(userId, name, isPublic,(CategoryTypes)selectedCategory);

            return RedirectToAction("Index", "Home");
        }
    }
}