using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Capstone.Service.Models;
using Capstone.Service;
using System.Data.SqlClient;

namespace Capstone
{
    public class mealPlannerApp
    {

        private string connectionString = "Server=.\\SQLEXPRESS;Database=final_capstone;Trusted_Connection=True;";
        private readonly ApiService apiService;

        public mealPlannerApp(string apiUrl)
        {
            apiService = new ApiService(apiUrl);
        }

        public void Run()
        {
            InputIngredientsIntoDatabase();
            InputCategoriesIntoDatabase();
            InputAreasIntoDatabase();
            InputRecipesIntoDatabase();
        }

        private void InputIngredientsIntoDatabase()
        {
            int ingredId = 0;
            try
            {
                List<Ingredient> ingreds = apiService.GetIngredientList();

                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    foreach (Ingredient ingred in ingreds)
                    {
                        SqlCommand cmd = new SqlCommand("INSERT INTO ingredient (name, description, type_id) " +
                                                    "OUTPUT INSERTED.ingred_id " +
                                                    "VALUES (@name, @description, (SELECT type_id FROM ingred_type WHERE name = @type_id));", conn);
                        cmd.Parameters.AddWithValue("@name", ingred.strIngredient);
                        cmd.Parameters.AddWithValue("@description", ingred.strDescription);
                        cmd.Parameters.AddWithValue("@type_id", ingred.strType);

                        ingredId = Convert.ToInt32(cmd.ExecuteScalar());
                        ingred.idIngredient = ingredId.ToString();
                    }

                }
            }
            catch (SqlException e)
            {
                Console.WriteLine(e);
            }
            Console.WriteLine("Successful Input");
        }


        private void InputCategoriesIntoDatabase()
        {
            int catId = 0;
            List<Categories> cats = apiService.GetCategoriesList();
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    foreach (Categories cat in cats)
                    {
                        SqlCommand cmd = new SqlCommand("INSERT INTO category (name, category_image, category_description) " +
                                                    "OUTPUT INSERTED.category_id " +
                                                    "VALUES (@name, @category_image, @category_description);", conn);
                        cmd.Parameters.AddWithValue("@name", cat.strCategory);
                        cmd.Parameters.AddWithValue("@category_image", cat.strCategoryThumb);
                        cmd.Parameters.AddWithValue("@category_description", cat.strCategoryDescription);

                        catId = Convert.ToInt32(cmd.ExecuteScalar());
                        cat.idCategory = catId.ToString();
                    }

                }
            }
            catch (SqlException e)
            {
                Console.WriteLine(e);
            }
            Console.WriteLine("Successful Input");
        }

        private void InputAreasIntoDatabase()
        {
            int areaId = 0;
            try
            {
                List<Areas> areas = apiService.GetAreasList();

                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    foreach (Areas area in areas)
                    {
                        SqlCommand cmd = new SqlCommand("INSERT INTO category (name) " +
                                                    "OUTPUT INSERTED.category_id " +
                                                    "VALUES (@name);", conn);
                        cmd.Parameters.AddWithValue("@name", area.strArea);


                        areaId = Convert.ToInt32(cmd.ExecuteScalar());
                        area.idArea = areaId.ToString();
                    }
                }
            }
            catch (SqlException e)
            {
                Console.WriteLine(e);
            }
            Console.WriteLine("Successful Input");
        }

        private void InputRecipesIntoDatabase()
        {
            int recipeId = 0;
            try
            {
                string alphabet = "abcdefghijklmnopqrstuvwxyz";

                foreach (char c in alphabet)
                {
                    List<Meals> recipes = apiService.GetMealsListByLetter(c);

                    using (SqlConnection conn = new SqlConnection(connectionString))
                    {
                        conn.Open();

                        foreach (Meals recipe in recipes)
                        {
                            SqlCommand cmd = new SqlCommand("INSERT INTO recipe (recipe_name, drink_alternate, category_id, area_id, instructions, recipe_image, recipe_tags, youtube, source, image_source, date) " +
                                                        "OUTPUT INSERTED.recipe_id " +
                                                        "VALUES (@recipe_name, @drink_alternate, (SELECT category_id FROM category WHERE name = @category_id), (SELECT area_id FROM area WHERE name = @area_id), @instructions, @recipe_image, @recipe_tags, @youtube, @source, @image_source, @date);", conn);
                            cmd.Parameters.AddWithValue("@recipe_name", recipe.strMeal);
                            cmd.Parameters.AddWithValue("@drink_alternate", recipe.strDrinkAlternate);
                            cmd.Parameters.AddWithValue("@category_id", recipe.strCategory);
                            cmd.Parameters.AddWithValue("@area_id", recipe.strArea);
                            cmd.Parameters.AddWithValue("@instructions", recipe.strInstructions);
                            cmd.Parameters.AddWithValue("@recipe_image", recipe.strMealThumb);
                            cmd.Parameters.AddWithValue("@recipe_tags", recipe.strTags);
                            cmd.Parameters.AddWithValue("@youtube", recipe.strYoutube);
                            cmd.Parameters.AddWithValue("@source", recipe.strSource);
                            cmd.Parameters.AddWithValue("@image_source", recipe.strImageSource);
                            cmd.Parameters.AddWithValue("@date", recipe.dateModified);

                            recipeId = Convert.ToInt32(cmd.ExecuteScalar());
                            recipe.idMeal = recipeId.ToString();
                        }

                    }
                }

            }
            catch (SqlException e)
            {
                Console.WriteLine(e);
            }
            Console.WriteLine("Successful Input");
        }

        //private void IngredientList()
        //{

        //    List<Ingredient> ingreds = apiService.GetIngredientList();
        //    if (ingreds != null)
        //    {
        //        Console.WriteLine("\n*********** Ingredients ***********");
        //        foreach (Ingredient ingred in ingreds)
        //        {
        //            Console.WriteLine($"Id: {ingred.idIngredient} | Description: {ingred.strDescription} | Name: {ingred.strIngredient} | Type: {ingred.strType}");
        //        }
        //        Console.WriteLine("****************************");
        //        Console.WriteLine("");

        //    }
        //}

    }
}
