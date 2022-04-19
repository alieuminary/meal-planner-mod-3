<template>
    <div>
        <h1>My Meal Plan Page</h1>
        <p>Display meal plan Here</p>
        <calendar />
    </div>
</template>

<script>

import Calendar from '../components/Calendar.vue';

export default {
  components: {
    Calendar
  }
};
</script>
