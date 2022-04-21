<template>
  <nav class="flex-header">
    <div class="logo">SMPL</div>
    <router-link class="menu" tag= "nav-link" v-bind:to="{ name: 'home' }"><a href="">Home</a></router-link>
    <router-link class="menu" tag= "nav-link" v-bind:to="{ name: 'recipes' }" v-if="$store.state.token != ''"><a href="">My Recipes</a></router-link>
    <router-link class="menu" tag= "nav-link" v-bind:to="{ name: 'meal-plan' }" v-if="$store.state.token != ''"><a href="">My Meal Plans</a></router-link> 
    <router-link class="menu" tag= "nav-link" v-bind:to="{ name: 'grocery-list' }" v-if="$store.state.token != ''"><a href="">Grocery List</a></router-link> 
    <router-link  class="btn-logout" id="logout-btn" tag= "button1" v-bind:to="{ name: 'logout' }" v-if="$store.state.token != ''">Logout</router-link>
  </nav>
</template>

<script>
export default {
    name: 'nav-bar',
}
</script>

<style>
.flex-header {
  display: flex;
  align-items: center;
  width: auto;
  background: #54782c;
  padding: 1rem 2rem;
  margin: 0;
  height: auto;
  text-align: center;
}
.logo {
  flex: 1 1 100px;
  color: #f5c177;
  font-size: 3em;
  font-weight: 400;
  letter-spacing: 0.05em;
  text-align: left;
}

.menu {
  flex: 0 0 auto;

  /* alignment */
}

.menu a {
  text-decoration: none;
  border: none;
  font-size: 1.5rem;
  color: #fff;
  padding: 1rem;
}

.menu a:hover {
  color: #000;
  background: #f5c177;
}

.menu a:active {
  background: #f5c177;
}

#logout-btn {
  background: rgb(256, 256, 256, 0.3);
  color: white;
  margin: 0 0 0 2rem;
  transition-duration: 0.4s;
  font-size: 1.5rem;
  font-weight: 600;
  border: none;
  text-decoration: none;
  padding: 1rem 2rem;
  text-align: center;
  text-decoration: none;
  display: inline-block;
}

#logout-btn:hover {
  background-color: #faf8f6; 
  color: #c6c6c6;
}

@media (max-width: 1100px) {
.flex-header {
  flex-wrap: wrap;
  margin: 0;
  padding: 0;
  } 

.logo {
    text-align: center;
    background: #faf8f6;
  }

.menu {
    flex: 1 1 100%;
    border-bottom: none;
    text-align: center;
    padding: 1rem;
    border-bottom: 1px solid white;
  }

#logout-btn {
    flex: 1;
    border-bottom: none;
    text-align: center;
    padding: 1rem;
    margin: 0;
}

}
</style>