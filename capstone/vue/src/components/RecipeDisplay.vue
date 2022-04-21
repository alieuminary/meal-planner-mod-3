<template>
  <div class="all-recipes">

    <div class="recipe-container"

        v-for="recipe in this.$store.state.myRecipes"
        v-bind:key="recipe.id">
        <h2>{{ recipe.recipeName }}</h2>
        <img class="recipeImage" v-bind:src="recipe.recipeImage"/>

        <div id="recipe-modify-container">
            <button class="recipe-modify-btns direction-btn" v-on:click="changeDisplay(), getIngredients(recipe)">Recipe Instructions
            </button> 
            <button class="recipe-modify-btns delete-btn" v-on:click="deleteRecipe(recipe.recipeId)">DELETE</button>
        </div>
        <div class="instructions" v-if="displayInstructions">
        <h2>Instructions</h2>
        <p
        v-for="(instruct,index) in instructionsIntoArray(recipe.instructions)"
        :key="index">
        {{index + 1}}. {{instruct}}
        </p>
        <h2>Ingredients</h2>
        <div 
        v-for="(ingred, index) in ingredients" 
        :key="ingred.riRecipeId"
        >
        {{index + 1}}. {{ingred.name}}
        </div>
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
                .deleteFromMyRecipes(recipeId)
                .then(response => {
                if (response.status === 200) {
                this.$router.go(0)}})
            },
        instructionsIntoArray(txt){
        const array = txt.split(". ");
        return array;
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

.recipe-modify-btns {
    
    background-color: transparent;
    border: 2px solid black;
    color: black;
    padding: .25em;
    margin: .5em;
    font-size: 16px;
    cursor: pointer;
}

button {
    border: 2px solid black;
    padding: .25em;
    margin: .5em;
    font-size: 20px;
}

.recipeImage{
    width: 30%;
}

.instructions{

}
    
</style>