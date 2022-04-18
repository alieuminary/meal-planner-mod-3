<template>
  <div class="all-recipes">
      <h2>Recipes</h2>

    <div class="recipe-container"
        v-for="recipe in this.$store.state.recipes"
        v-bind:key="recipe.id">

        <h3>{{ recipe.recipeName }}</h3>
        <h3> recipe </h3>

        <div id="recipe-modify-container">
            <button class="recipe-modify-btns direction-btn">Recipe Instructions</button>
            <button class="recipe-modify-btns modify-btn">Add to My Recipes</button>
        </div>

    </div>
  </div>
</template>

<script>
import recipesService from "@/services/RecipesService.js";

export default {
    name: "recipe-list",
    methods: {
        getRecipes() {
            recipesService.list().then(response => {
                this.$store.commit("SET_RECIPES", response.data)
            })
        },
        created() {
            this.getRecipes();
        }
    }
}
</script>

<style>
.recipe-container{
  display: flex; 
  flex-direction: column;
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
    
</style>