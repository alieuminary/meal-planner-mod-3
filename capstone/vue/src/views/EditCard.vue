<template>
  <div>
    <h1>Edit Card</h1>
    <card-form :recipeId="parseInt($route.params.id)" />
  </div>
</template>

<script>
import CardForm from "@/components/CardForm";

export default {
  components: {
    CardForm
  }
};
</script>
