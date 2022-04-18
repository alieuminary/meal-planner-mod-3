<template>
    <div>
        <button>Add Recipe</button>
        <div class="recipe-container"
        v-for="recipe in recipes"
        v-bind:key="recipe.id">

        <h3>{{ recipe.name }}</h3>
        <h5>Category: {{ recipe.category }}</h5> 
        
        <h5>Instructions:</h5> {{ recipe.instructions }}
        <div id="recipe-modify-container">
            <button class="recipe-modify-btns direction-btn">Recipe Instructions</button>
            <button class="recipe-modify-btns modify-btn">Modify Ingredients</button>
            <button class="recipe-modify-btns delete-btn">Delete</button>
        </div>

        </div>
</div>
</template>


<script>

//import { defineComponent } from '@vue/composition-api'

export default {
    name: "recipe-display",
    data() {
        return {
            recipes: [
                {
                    name: "Quesadilla",
                    category: "Mexican",
                    ingredient: [
                        "lime",
                        "cheese",
                        "lettuce",
                    ],
                    instructions: "Sed ut perspiciatis unde omnis iste natus error sit voluptatem accusantium doloremque laudantium, totam rem aperiam, eaque ipsa quae ab illo inventore veritatis et quasi architecto beatae vitae dicta sunt explicabo."

                },
                {
                    name: "General Tso Chicken",
                    category: "Chinese",
                    ingredient: [
                        "lime",
                        "cheese",
                        "lettuce",
                    ],
                    instructions: "Sed ut perspiciatis unde omnis iste natus error sit voluptatem accusantium doloremque laudantium, totam rem aperiam, eaque ipsa quae ab illo inventore veritatis et quasi architecto beatae vitae dicta sunt explicabo."

                },
                {
                    name: "Paella",
                    category: "Spanish",
                    ingredient: [
                        "lime",
                        "cheese",
                        "lettuce",
                    ],
                    instructions: "Sed ut perspiciatis unde omnis iste natus error sit voluptatem accusantium doloremque laudantium, totam rem aperiam, eaque ipsa quae ab illo inventore veritatis et quasi architecto beatae vitae dicta sunt explicabo."

                }
            ]
            
            
        }
    }

}
</script>

<style scoped>

.recipe-container{
  display: flex; 
  flex-direction: column;
  border: 1px black solid;
  border-radius: 6px;
  padding: 1rem;
  margin: 10px;
    
}

#recipe-modify-container {
    display: flex;
    flex-direction: row;
    justify-content: center;
}

.recipe-modify-btns {
    
    background-color: transparent;
    border: 2px solid black;
    color: black;
    padding: .25em;
    margin: .5em;
    font-size: 16px;
    cursor: pointer;
}



.delete-btn:hover {
    background: #f44336;

}

button {
    border: 2px solid black;
    padding: .25em;
    margin: .5em;
    font-size: 20px;
    
}



</style>