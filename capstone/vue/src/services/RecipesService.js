import axios from 'axios';

const http = axios.create({
    baseURL: "https://localhost:44315"
});

export default {
    getList() {
        return http.get('/recipe');
    },
    getAreaById(areaId){
        return http.get(`/area/${areaId}`);
    },
    getCategoryById(categoryId){
        return http.get(`/category/${categoryId}`);
    },
    getRecipeById(recipeId){
        return http.get(`/recipe/${recipeId}`);
    },
    GetRecipesByCategoriesId(catId){
        return http.get(`/recipe/c=${catId}`);
    },
    GetRecipesByAreasId(areaId){
        return http.get(`/recipe/a=${areaId}`);
    },
    GetAllRecipesIngredientsByRecipeId(recipeId){
        return http.get(`/ri/${recipeId}`);
    },
    GetAllMyRecipes(userId){
        return http.get(`/planner/userId=${userId}`)
    },
    updateRecipe(recipe){
        console.log(recipe)
        alert(recipe.userId)
        return http.put('/recipe/update', recipe)
    },
    addRecipe(recipe) {
        return http.post(`/recipe`, recipe);
      },
    getAllIngredients() {
        return http.get('/ingredient');
    },
    getPlannerByUserId(id) {
        return http.get(`/planner/userId=${id}`);
    },
    saveRecipeToMyRecipes(recipe) {
        return http.post(`/userrecipes/post`, recipe);
    },
    getMyRecipesByUser() {
        return http.get('/userrecipes');
    }
}