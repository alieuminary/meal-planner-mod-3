<template>
    <div>
        <h1>My Recipes Page</h1>
        <p>Display Recipes Here</p>
        <recipe-display/>


    </div>
</template>

<script>
import RecipeDisplay from '../components/RecipeDisplay'

export default {
    components:{
        RecipeDisplay
    }

};
</script>
