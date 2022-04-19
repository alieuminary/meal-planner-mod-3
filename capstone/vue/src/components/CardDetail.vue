<template>
  <div>
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
      ri: []
    };
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