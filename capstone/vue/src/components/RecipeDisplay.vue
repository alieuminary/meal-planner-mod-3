<template>
    <div>
        <div class="recipe"
        v-for="recipe in recipes"
        v-bind:key="recipe.id">

        <h4>{{ recipe.name }}</h4>
        <h4>Category: </h4> {{ recipe.category }}
        <h4>Instructions:</h4> {{ recipe.instructions }}
        



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
       
</style>