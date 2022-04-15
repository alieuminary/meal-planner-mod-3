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
      <!-- <footer-bar /> -->
    <router-view />      
    </div>

    <div id="footer">
      <div id="copyright">
        <p>&copy; SMPL </p>
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
@import url('https://fonts.googleapis.com/css2?family=Montserrat:ital,wght@0,400;0,500;0,600;1,400;1,500;1,600&display=swap');
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
    background-color: #faf8f6;
    padding: 75px 0px 25px 0px;
  }

body {
  font-family: 'Montserrat', sans-serif;
  letter-spacing: 0.05em;
  color: #262f35;
  font-size: 1em;
}

h1 {
  /* font-family: Georgia, 'Times New Roman', Times, serif; */
  font-family: 'Montserrat', sans-serif;
  letter-spacing: 0.05em;
  font-weight: 600;
  font-size: 3em;
  margin-bottom: 0.5em;
  }

h2 {
  font-family: 'Montserrat', sans-serif;
  font-size: 1.75em;
  font-weight: 400;
  line-height: 1.5;
  margin-bottom: 0.25em;
  }

h3 {
  font-family: 'Montserrat', sans-serif;
  font-size: 1.25em;
  font-weight: 500;
  line-height: 1.3;
  margin-bottom: 0.25em;
  }

.sr-only {
  font-family: Georgia, 'Times New Roman', Times, serif;
  font-size: 1.5em;
  font-weight: 600;
  text-transform: uppercase;
  }

button {
  font-family: 'Montserrat', sans-serif;
  color: #262f35;
  font-size: 1.75em;
  font-weight: 600;
  display: block;
  align-items:center;
  line-height: 2em;
  padding: 10px;
  border: none;
  background-color: #f5c177;
}

input {
  font-family: 'Montserrat', sans-serif;
  font-size: 1.25em;
  width: 100%;
  line-height: 3em;
  margin-bottom: 10px;
  text-align: center;
  border: none;
  background-color: #e9e9e9;
}

.logo {
  font-family: 'Montserrat', sans-serif;
  color: #f5c177;
  line-height: 1.2;
  font-size: 3em;
  font-weight: 400;
  margin: 50px;
}

#nav{
    display: flex;
    align-items: center;
    justify-content:space-between;
    gap: 20px;
    background-color: #54782c;
    height: 75px;
  }

.menu {
    display: flex;
    padding-right: 30px;
    gap: 1em;
    font-size: 24px;
    letter-spacing: .05rem;
  }

.menu a {
    color: #fff;
    text-decoration: none;
    padding: 10px ;
    border: #c6c6c6 solid 1px;
  }

.menu a:hover {
    background-color: #f5c177;
    color: #000;
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
    background-color: #BFA38A;
    width: 100%;
    height: 150px;
    padding: 0;
  }

#footer p {
    font-size: 1.25em;
}


</style>