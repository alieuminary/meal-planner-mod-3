<template>
  <div id="app">
    <div id="nav">
      <h1 class="logo">SMPL</h1>
      <div class="menu">
      <router-link v-bind:to="{ name: 'home' }">Home</router-link>
      <router-link v-bind:to="{ name: 'recipes' }">My Recipes</router-link>
      <router-link v-bind:to="{ name: 'meal-plan' }">My Meal Plans</router-link> 
      <router-link v-bind:to="{ name: 'grocery-list' }">Grocery List</router-link> 
      <router-link id="logout-btn" v-bind:to="{ name: 'logout' }" v-if="$store.state.token != ''">Logout</router-link>
      </div>
      <!-- <nav-bar  /> -->
      <!-- <router-link v-bind:to="{ name: 'home' }">Home</router-link>&nbsp;|&nbsp;
      <router-link v-bind:to="{ name: 'logout' }" v-if="$store.state.token != ''">Logout</router-link> -->
       
    </div>
    <div id="container">
      <footer-bar />
    <router-view />      
    </div>

    <div id="footer">
      <div id="copyright">
        &copy;SMPL
      </div>
      <p>
        Follow Us! 
        <font-awesome-icon icon="fa-brands fa-facebook" />
        <font-awesome-icon icon="fa-brands fa-instagram" />
        <font-awesome-icon icon="fa-brands fa-twitter" />
      </p>
    </div>
  </div>
</template>

<script>
// import NavBar from '@/components/NavBar'
// import FooterBar from '@/components/FooterBar'

// export default {
//   name: 'app',
//   components:{
//     //NavBar,
//     FooterBar
//   }

// }
</script>


<style>
* {
  box-sizing: border-box;
  padding: 0;
  margin: 0;
  
}

#app {
  -webkit-font-smoothing: antialiased;
  -moz-osx-font-smoothing: grayscale;
  margin: 0 auto;
  max-width: 1200px;
  overflow: visible;
  text-align: center;  
  }

#container {
    background-color: #F2E2DC;
    padding: 35px;
  }

body, h1, h2, h3 {
  font-family: Lato, sans-serif;
  color: #233A41;
  font-size: 16px;
}

h1 {
  color: #023859;
  font-size: 3em;
  margin-bottom: 0.5em;
  }

h2 {
  color: #233A41;
  font-size: 1.75em;
  font-weight: 300;
  line-height: 1.5;
  margin-bottom: 0.25em;
  }

h3 {
  color: #233A41;
  font-size: 1.25em;
  font-weight: 400;
  line-height: 1.3;
  margin-bottom: 0.25em;
  }

.sr-only {
  color: #8C7A1C;
  font-size: 1.5em;
  font-weight: 600;
  text-transform: uppercase;
  }

button {
  display: block;
  align-items:center;
  line-height: 3em;
  padding: 10px;
  font-size: 1.5em;
  font-weight: 400;
  border: none;
  background-color: #F28749;
}

input {
  font-size: 1.25em;
  width: 100%;
  line-height: 3em;
  margin-bottom: 10px;
  text-align: center;
  border: none;
  background-color: #F2E2DC;
}

.logo {
  color: #F2E2DC;
  line-height: 1.2;
  font-size: 3em;
  font-weight: 300;
  margin: 50px;
}

#nav{
    display: flex;
    align-items: center;
    justify-content:space-between;
    gap: 20px;
    background-color: #32941E;
    height: 75px;
  }

.menu {
    display: flex;
    gap: 1em;
    font-size: 24px;
    letter-spacing: .05rem;
  }

.menu a {
    color: #fff;
    text-decoration: none;
    padding: 10px ;
  }

.menu a:hover {
    background-color: #F2E2DC;
    color: #32941E;
    border-radius: 0px;
    transition: 0.3s ease;
  }

#logout-btn {
    background-color: blue;
  }

#footer {
    display: flex;
    justify-content: center;
    align-items: center;
    background-color: #8C7A1C;
    width: 100%;
    height: 150px;
    padding: 0;
  }

#footer p {
    font-size: 16px;
    color: white;
  }


</style>