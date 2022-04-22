<template>
<div>
    <div v-for="plan in rpList" v-bind:key="plan.rpId">
        <div>
            <div>{{getRecipeName(plan.recipeId)}}</div> 
            <select class="btn-search">
                <option  v-for="index in days" :key="index">{{index}}</option>
            </select>
        </div>
    
    </div>
    {{this.plannerId}}
</div>
</template>


<script>
import recipesService from "@/services/RecipesService.js";

export default {
  name: "plan-recipes",
  data(){
    return {
      rpList: [],
      recipes: [],
      days:["Sunday","Monday","Tuesday","Wednesday","Thursday","Friday","Saturday"]
    };
  },
  methods: {
      getRecipeName(recipeId){
          for(let i=0;i<this.recipes.length;i++){
              if(this.recipes[i].recipeId == recipeId){
                  return this.recipes[i].recipeName
              }
          }
      }
  },
 created(){
    recipesService.getRpByPlannerId(this.$route.params.id).then(response => {
          this.rpList = response.data;
        });
    recipesService.getList().then(response => {
          this.recipes = response.data;
        });    
  },
}
</script>