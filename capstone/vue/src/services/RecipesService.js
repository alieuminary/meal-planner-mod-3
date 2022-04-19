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
    }
}