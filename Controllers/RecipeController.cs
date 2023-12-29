using Microsoft.AspNetCore.Mvc;
using RecipeApplication.Data;
using RecipeApplication.Models;
using System.Collections.Generic;

namespace RecipeApplication.Controllers
{
    public class RecipeController : Controller
    {
        private readonly Recipes recipes;

        public RecipeController(Recipes recipes)
        {
            this.recipes = recipes;
        }


        public IActionResult Index()
        {
            return View();
        }

        public ActionResult List()
        {
            var recipes = new Recipes().List();
            return View(recipes);
        }

        public ActionResult Details(Guid recipeId)
        {
            var recipe = new Recipes().FindById(recipeId);
            return View(recipe);
        }

        public ActionResult Add()
        {
            var newRecipe = new Recipe() { ID = Guid.NewGuid() };
            return View(newRecipe);
        }

        [HttpPost]
        public IActionResult Add(Recipe newRecipe)
        {
            if (ModelState.IsValid)
            {
                recipes.Add(newRecipe);
                return RedirectToAction(nameof(List));
            }
            return View(newRecipe);
        }

        public ActionResult Edit(Guid recipeId)
        {

            var recipe = new Recipes().FindById(recipeId);
            return View(recipe);
        }

        [HttpPost]
        public IActionResult Edit(Recipe editedRecipe)
        {
            if (ModelState.IsValid)
            {
                recipes.Update(editedRecipe);
                return RedirectToAction(nameof(List));
            }
            return View(editedRecipe);
        }

        public ActionResult Delete(Guid recipeId)
        {
            recipes.Remove(recipeId);
            return RedirectToAction(nameof(List));
        }
    }
}
