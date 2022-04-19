<template>
  <div class="home">
    <h1>3 ways we help keep cooking and shopping SMPL!</h1>
    <div class="myButton">
      <button>
      <router-link v-bind:to="{ name: 'all-recipes'}">All Recipes</router-link>
      </button>
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

.myButton{
  display: flex;
  justify-content: center;
}
</style>