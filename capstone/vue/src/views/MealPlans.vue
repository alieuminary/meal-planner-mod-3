<template>
    <div>
        <h1>My Meal Plan Page</h1>
        <router-link
        tag="button"
        :to="{ name: 'AddPlan', params: {}}"
        class="btn editCard"
      >ADD NEW MEAL PLAN</router-link>
      <my-meal-plans />
        <calendar />
        
    </div>
</template>

<script>

import Calendar from '../components/Calendar.vue';
import MyMealPlans from '../components/MyMealPlans.vue';

export default {
  components: {
    Calendar,
    MyMealPlans
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
</style>
