<template>
    <div>
      <input type="text" placeholder='What would you like to buy?'>
       <div class="todo-list">
        
        <ul>
        <li v-for="ingredient in filteredIngredients" v-bind:key="ingredient.name"
            v-bind:class="{ finished: ingredient.done }">
          <input type="checkbox" v-model="ingredient.done" />
          {{ ingredient.name }}
        </li>
      </ul>
    </div>
  </div>
</template>


<script>
export default {
    name: "grocery-list",
    data(){
        return {
            newIngredient: [],
            filterText: '',
            ingredientList: [
                {
                    name: 'Salt',
                    done: false
                },
                {
                    name: 'Lime',
                    done: false
                },
                {
                    name: 'butter',
                    done: false
                },
                {
                    name: 'chicken',
                    done: false
                },
            ]
        }
    

},
  computed: {
    filteredIngredients() {
      return this.ingredientList.filter((ingredient) => {
        return ingredient.name.includes(this.filterText);
      });
    }
  }
}
</script>

<style>
.todo-list {
    width:450px;
    background: #fff;
    margin: 50px auto;
    font-family: 'Roboto Condensed', sans-serif;
    border-radius: 10px;
}

ul {
    list-style-type: none;
    margin:0px;
    padding:0px;
}
li {
    font-size: 24px;
    border-bottom:1px solid #f2f2f2;
    padding:10px 20px;
}

    
</style>