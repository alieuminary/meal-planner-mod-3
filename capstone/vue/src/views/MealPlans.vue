<template>
    <div>
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

</style>
