<template>
  <div class="topic-list">
    <table>
      <thead>
        <tr>
          <th>MEAL PLAN</th>
          <th>EDIT</th>
          <th>DELETE</th>
        </tr>
      </thead>
      <tbody>
        <tr v-for="plan in this.$store.state.myMealPlans" v-bind:key="plan.plannerId">
          <td width="80%">
            <!-- <router-link
              v-bind:to="{ name: 'Messages', params: { id: topic.id } }"
            >{{ topic.title }}</router-link> -->
            {{plan.name}}
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
  methods: {
    getPlans() {
      recipesService.getPlannerByUserId(1).then(response => {
        this.$store.commit("SET_MY_MEAL_PLANS", response.data);
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
    }
  },
  created() {
    this.getPlans();
  }
};
</script>