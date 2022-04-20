<template>
  <div class="card">
      <h1> {{ card.recipeName }} </h1>
      <img :src="card.recipeImage">
      <h2>DIRECTIONS</h2>
      <p>{{card.instructions}}</p>
      <h2>INGREDIENTS</h2>
      <div
      v-for="ingred in ri"
      :key="ingred.riRecipeId"
      >
        {{ingred.name}}
      </div>

    <div class="recipeButtons">
      <div class="editRecipe">
        <button v-on:click="editMyRecipe()">Edit Recipe</button>
      </div>

      <div class="saveRecipe">
        <button v-on:click="saveMyRecipe()">Save Recipe</button>
      </div>

      <form class="recipeEdit" v-if="editable = true">
        <label>Directions</label>
        <input>
        <label>Ingredients</label>
        <input>
        <input>
        <input>
        <input>
        <input>        
        <input type="submit">

      </form>

    </div>
  </div>
</template>

<script>
import recipesService from "@/services/RecipesService.js";


export default {
  name: "card-detail",
//   components:{
//   },
  data(){
    return {
      card: {},
      ri: [],
      editable: false
    };
  },
  methods: {
    editMyRecipe(){
      this.editable ? this.editable = true : !this.editable;
    },
    saveMyRecipe(){

    }
  },
  created(){
    recipesService
        .getRecipeById(this.$route.params.id)
        .then(response => {
          this.card = response.data;
        });
    recipesService
        .GetAllRecipesIngredientsByRecipeId(this.$route.params.id)
        .then(response => {
          this.ri = response.data;
        });
  }
};
</script>

<style>

.recipeButtons{
  padding: 20px;
  display: flex;
  justify-content: center;
}

.recipeEdit{
  
}

</style>