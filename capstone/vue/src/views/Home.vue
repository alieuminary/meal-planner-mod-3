<template>
<div class="content-one-column">
  <h1>Cooking &#38; Shopping, it's SMPL!</h1>
  <div class="grid3-columns">
    <div class="left1">
      <h2>Over 1,000 recipes</h2>
      <p>Edit or save recipes, and find cooking instructions.</p>
      <router-link class="button-standard" tag="button" v-bind:to="{ name: 'all-recipes'}">All Recipes</router-link>
    </div>
    <div class="middle">
        <h2>Add favorite meals</h2>
        <p>Enter a new recipe into your favorites.</p>
        <router-link class="button-standard"
        tag="button"
        :to="{ name: 'AddCard', params: {}}"
      >Create Recipe</router-link>
    </div>
    <div class="right2">
        <h2>Too busy to cook?</h2>
      <p>Save time, create a grocery list.</p>
    </div> 
  </div>
</div>
      
</template>

<script>
export default {
  name: "home"
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

/* 3-COLUMN GRID */
.grid3-columns {
  display: grid;
  grid-template-columns: 1fr 1fr 1fr;
  gap: 1rem;
}
.left1 {
  grid-area: left;
  grid-area: 1/1/2/2;
  border: 2px solid #c6c6c6;
  text-align: left;
  padding: 1rem;
}

.middle {
  grid-area: middle;
  grid-area: 1/2/2/3;
  border: 2px solid #c6c6c6;
  text-align: let;
  padding: 1rem;
}

.right2 {
  grid-area: right;
  grid-area: 1/3/2/4;
  border: 2px solid #c6c6c6;
  text-align: left;
  padding: 1rem;
}

.button-standard {
  width: 100%;
  margin-top: 1rem;
  padding: 1rem 0;
}

@media (max-width: 650px) {
.grid3-columns {
    grid-template-columns: 1fr;
    grid-template-rows: repeat(3, 1fr);
    margin: 0 0 0 0;
    grid-template-areas: 
    "left1" 
    "middle"
    "right1";
  }
 .left1 {
  grid-area: left;
  grid-area: 1/1/2/2;
  text-align: center;
  padding: 1rem;
}
.middle {
  grid-area: middle;
  grid-area: 2/1/3/2;
  text-align: center;
  padding: 1rem;
}
.right2 {
  grid-area: right;
  grid-area: 3/1/4/2;
  text-align: center;
  padding: 1rem;
}
}
</style>