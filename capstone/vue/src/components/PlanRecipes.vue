<template>
    <div>
      
    </div>
</template>


<script>
import recipesService from "@/services/RecipesService.js";

export default {
  name: "plan-recipes",
  data(){
    return {
      searchBar:'',
      ingredientList: [],
      groceryList:[]
    };
  },
  methods: {
    addToGroceries(item){
      this.groceryList.push(item);
    }
  },
 created(){
    recipesService.getAllIngredients().then(response => {
          this.ingredientList = response.data;
        });
  },
}
</script>