<template>
  <div>
    <h1>Edit New PLan</h1>
    <update-meal-form :plannerId="parseInt($route.params.id)" />
  </div>
</template>

<script>
import UpdateMealForm from "@/components/UpdateMealForm";

export default {
  components: {
    UpdateMealForm
  }
};
</script>