<template>
    <div class="content-one-column">
        <h1>My Meal Plan Page</h1>
        <router-link
        tag="button"
        :to="{ name: 'AddPlan', params: {}}"
        class="btn editCard"
      >ADD NEW MEAL PLAN</router-link>
      <my-meal-plans :userId="userId" />
        <!-- <calendar /> -->
        
    </div>
</template>

<script>

// import Calendar from '../components/Calendar.vue';
import MyMealPlans from '../components/MyMealPlans.vue';
import recipesService from "@/services/RecipesService.js";

export default {
  components: {
    // Calendar,
    MyMealPlans
  },
   data() {
    return {
      userId: "",
    };
  },
  created() {
    recipesService.getUserId().then(response => {
          this.userId = response.data;
        });
  }
};
</script>

<style scoped>
* {
  box-sizing: border-box;
  padding: 0 3rem;
  margin: 0;
}

.content-one-column {
  display: grid;
  width: 100%;
  margin: 0;
  padding: 0;  
}

button {
  margin: 2rem 0;
}

</style>
