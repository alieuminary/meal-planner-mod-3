<template>
  <div class="card">
      <h1> {{ card.recipeName }} </h1>
      <img :src="card.recipeImage">
      <h2>Cooking Instructions</h2>
      <p
      v-for="(instruct,index) in instructionsIntoArray(card.instructions)"
      :key="index">
        {{instruct}}
      </p>
      <h2>Ingredients</h2>
      <div 
      v-for="ingred in ri"
      :key="ingred.riRecipeId"
      >
        {{ingred.name}}
      </div>

    <div class="recipeButtons">
      <router-link
        tag="button"
        :to="{ name: 'EditCard', params: {id: $route.params.id}}"
        class="btn editCard"
      >Edit Recipe</router-link>

      <button v-on:click="saveMyRecipe()">Save Recipe</button>

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
      editable: false,
    };
  },
  methods: {
    saveMyRecipe(){
      alert("Successfully added to your recipes");
      recipesService
        .saveRecipeToMyRecipes(this.card)
    },
    instructionsIntoArray(txt){
        const array = txt.split(". ");
        return array;
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


</style>