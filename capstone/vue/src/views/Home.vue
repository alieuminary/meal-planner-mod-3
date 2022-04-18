<template>
  <div class="home">
    <h1>3 ways we help keep cooking and shopping SMPL!</h1>
    <button>
      <router-link v-bind:to="{ name: 'all-recipes'}">All Recipes</router-link>
    </button>
    <div>
      <p>enter flex box in here</p>
    </div>
  </div>
</template>

<script>
export default {
  name: "home"
};
</script>

<style scoped>
.home {
  width: 80%;
  margin: auto;
  padding: 20px;  
}

button{
  display: flex;
  justify-content: center
}
</style>