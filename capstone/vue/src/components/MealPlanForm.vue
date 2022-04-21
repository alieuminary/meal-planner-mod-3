<template>
    <div class="add-plan-popup">
        <button>Add New Meal Plan</button>
        <div class="popup-content">
            <form class="form-new-plan" @submit.prevent="">
                <h2>Create a New Meal Plan Below</h2>
                <div class="group">
                    <label>MEAL PLAN NAME</label>
                    <input type="text">
                </div>

                <div class="group">
                    <h3>IS SHARABLE?</h3>
                    <label>Yes</label>
                    <input type="radio" v-model="isSharable" value=true>
                    <label>No</label>
                    <input type="radio" v-model="isSharable" value=false>
                    <button type="submit">CREATE</button>
                    <button type="button">CLOSE</button>
                </div>
            </form>
        </div>
    </div>
</template>

<script>

export default {
    name: "meal-plan-form",
    data(){
        return{
            isSharable: true
        };
    },
}
</script>

<style scoped>
.form-new-plan {
  display: flex;
  flex-direction: column;
  align-items: center;
  width: auto;
  line-height: 4;
  margin: 0;
  padding: 2rem 5rem 0 5rem;
}
</style>