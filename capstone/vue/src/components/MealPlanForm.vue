<template>
    <div class="add-plan-popup">
        <button>ADD NEW MEAL PLAN</button>
        <div class="popup-content">
            <h2>Add New Plan</h2>
            <form @submit.prevent="">
                <div class="group">
                    <label>MEAL PLAN NAME</label>
                    <input type="text">
                </div>

                <div class="group">
                    <label>IS SHARABLE?</label>
                    <input type="radio" v-model="isSharable" value=true>
                    <label>Yes</label>
                    <input type="radio" v-model="isSharable" value=false>
                    <label>No</label>
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

</style>