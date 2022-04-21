<template>
    <div class="content-one-column">
        <h1>My Meal Plan Page</h1>
        <meal-plan-form />
        <calendar />
    </div>
</template>

<script>

import Calendar from '../components/Calendar.vue';
import MealPlanForm from '../components/MealPlanForm.vue'

export default {
  components: {
    Calendar,
    MealPlanForm
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
