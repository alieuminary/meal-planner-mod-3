<template>
  <div class="topic-list">
    <table>
      <thead>
        <tr>
          <th @click="getPlans(userId)">MEAL PLAN</th>
          <th>EDIT</th>
          <th>DELETE</th>
        </tr>
      </thead>
      <tbody>
        <!-- <tr v-for="plan in this.$store.state.myMealPlans" v-bind:key="plan.plannerId"> -->
        <tr v-for="plan in plans" v-bind:key="plan.plannerId">
          <td width="50%">
            <router-link 
              :to="{ name: 'PlanRecipes', params: { id: plan.plannerId } }">{{plan.name}}</router-link>
          </td>
          <td>
            <router-link
            :to="{ name: 'EditPlan', params: {id: plan.plannerId}}"
            >Edit Plan</router-link>
          </td>
          <td>
            <a href="#" @click="deletePlanner(plan.plannerId)">Delete</a>
          </td>
        </tr>
      </tbody>
    </table>
  </div>
</template>

<script>
import recipesService from "@/services/RecipesService.js";

export default {
  name: "topic-list",
  props:['userId'],
  data(){
        return{
          isActive: false,
          plans:[],
          rpList: [],
          recipes:[],
          

        };
    },
  methods: {
    toggle(){
      this.isActive = !this.isActive
    },
    getPlans(userId) {
      recipesService.getPlannerByUserId(userId).then(response => {
        // this.$store.commit("SET_MY_MEAL_PLANS", response.data);
        this.plans = response.data
      });
    },
    deletePlanner(plannerId) {
      recipesService
        .deletePlanner(plannerId)
        .then((res) => {
          if (res.status === 200) {
            this.getPlans();
          }
        })
        .catch((err) => {
          alert(`Error occurred: ${err.message}`);
        });
    },
    getRp(plannerId){
      recipesService.getRpByPlannerId(plannerId).then(response =>{
            return response.data;
        })
    }
  },
  created() {
    recipesService.getAllRps().then(response => {
          this.rpList = response.data;
        });
    this.getPlans(this.userId);
  }
};
</script>

<style scoped>
span{
  color: white;
}
</style>