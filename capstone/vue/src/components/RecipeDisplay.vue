<template>
  <div class="all-recipes">

    <div class="recipe-container"

        v-for="recipe in this.$store.state.myRecipes"
        v-bind:key="recipe.id">
        <h2>{{ recipe.recipeName }}</h2>
        <img class="recipeImage" v-bind:src="recipe.recipeImage"/>

        <div id="recipe-modify-container">
            <button class="direction-btn" v-on:click="changeDisplay(), getIngredients(recipe)">Recipe Instructions
            </button> 
            <button class="delete-btn" v-on:click="deleteRecipe(recipe.recipeId)">DELETE</button>
        </div>
        <div class="instructions" v-if="displayInstructions">
            {{recipe.instructions}}
        </div>
    </div>
  </div>
</template>

<script>
import recipesService from "@/services/RecipesService.js";

export default {
    data() {
        return {
            displayInstructions: false,
            ingredients: []
        }
    },
    name: "recipe-display",
    methods: {
        getRecipes() {
            recipesService.getMyRecipesByUser().then(response => {
                this.$store.commit("SET_RECIPES", response.data);
            });
        },
        getIngredients(recipe) {
            recipesService.GetAllRecipesIngredientsByRecipeId(recipe.recipeId).then(response => {
                this.ingredients = response.data;
            })
        },
        changeDisplay() {
            if (!this.displayInstructions){
                this.displayInstructions = true;
            }
            else {
                this.displayInstructions = false;
            }
        },
        deleteRecipe(recipeId){
            recipesService
                .deleteFromMyRecipes(recipeId);
                }
            },
    created() {
    this.getRecipes();
    }
}
</script>

<style>
.recipe-container{
  display: flex; 
  flex-direction: column;
  align-items: center;
  border: 1px black solid;
  border-radius: 6px;
  padding: 1rem;
  margin: 10px;
}

#recipe-modify-container {
    display: flex;
    flex-direction: row;
    justify-content: center;
}



.recipeImage{
    width: 30%;
}
</style>