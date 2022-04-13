<template>

    <nav id='nav-container'>
        <router-link class="nav-btn" v-bind:to="{ name: 'home' }">Home</router-link>&nbsp;&nbsp;
        <router-link class="nav-btn" tag= "button" v-bind:to="{ name: 'recipes' }" v-if="$store.state.token != ''">My Recipes</router-link>
        <router-link class="nav-btn" tag= "button" v-bind:to="{ name: 'meal-plan' }" v-if="$store.state.token != ''">My Meal Plans</router-link> 
        <router-link class="nav-btn" tag= "button" v-bind:to="{ name: 'grocery-list' }" v-if="$store.state.token != ''">Grocery List</router-link> 
        <router-link class="nav-btn" id="logout-btn" v-bind:to="{ name: 'logout' }" v-if="$store.state.token != ''">Logout</router-link>
    </nav>
</template>


<script>


export default {
    name: 'nav-bar',

}
</script>



<style>

#nav-container {
    display: flex;
    flex-direction: row;
    background-color: #32941ee1;
    align-items: center;
    justify-content: center;
    

}

.nav-btn {
    color: #fff;
    background-color: transparent;
    border-color: transparent;
    padding: 10px 20px;
    
}

* {
    margin: 0;
    padding: 0;
    box-sizing: border-box;
}





</style>