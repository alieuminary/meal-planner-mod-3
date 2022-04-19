<template>
  <div class="all-recipes">
      <h2>Recipes</h2>
    <input type="text" v-model="searchBar" placeholder="search recipes">
    <label for="by">Search By:</label>
    <select class="by">
        <option v-for="index in by" :key="index">{{index}}</option>
    </select>
    <div class="container">
        <div
        class="cards"
        v-for="recipe in filteredRecipes"
        :key="recipe.recipeId"
        >
            <router-link :to="{ name: 'recipes', params: { id: recipe.recipeId } }">
                <div class="card">
                    <img :src="recipe.recipeImage" style="width:100%">
                    <h1>{{recipe.recipeName}}</h1>       
                </div>
            </router-link>
        </div>
    </div>
  </div>
</template>

<script>
import recipesService from "@/services/RecipesService.js";

export default {
    name: "recipe-list",
    data(){
        return{
            recipes: [],
            searchBar:'',
            by: ["Category","Area","Ingredients"]
        };
    },
    created() {
        recipesService.getList().then(response =>{
            this.recipes = response.data;
        })
    },
    computed: {
        filteredRecipes(){
            return this.recipes.filter((recipe) => {
                return recipe.recipeName.toLowerCase().match(this.searchBar);
            });
        }
    }
}
</script>

<style scoped>
.container{
  display:grid;
  grid-template-columns: repeat(auto-fit, minmax(200px,1fr));
  grid-gap: 10px;
}

.column{
    float: left;
    width: 25%;
    padding: 0 10px;
}

.card {
    box-shadow: 0 4px 8px 0 rgba(0,0,0,.2);
    max-width: 300px;
    margin: auto;
    text-align: center;
    font-family: Cambria, Cochin, Georgia, Times, 'Times New Roman', serif;
    font-size: 50%;
}
    
</style>