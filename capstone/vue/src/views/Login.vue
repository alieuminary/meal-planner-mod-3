<template>
  <div id="login" class="text-center">
    <h1>The Ultimate SMPL Cooking App</h1>
    <h2>
      Conquer meal planning and live a healthier life with Shawn’s Meal Planning App–the all-in-one app for recipe saving, meal planning, and grocery shopping.
    </h2>
    <form class="form-signin" @submit.prevent="login">
      <h1 class="h3 mb-3 font-weight-normal">Sign In</h1>
      <div
        class="alert alert-danger"
        role="alert"
        v-if="invalidCredentials"
      >Invalid username and password!</div>
      <div
        class="alert alert-success"
        role="alert"
        v-if="this.$route.query.registration"
      >Thank you for registering, please sign in.</div>
      <label for="username" class="sr-only">Username</label>
      <input
        type="text"
        id="username"
        class="form-control"
        placeholder="enter username ..."
        v-model="user.username"
        required
        autofocus
      />
      <label for="password" class="sr-only">Password</label>
      <input
        type="password"
        id="password"
        class="form-control"
        placeholder="enter password ..."
        v-model="user.password"
        required
      />
      <router-link :to="{ name: 'register' }">Need an account?</router-link>
      <button type="submit">Sign in</button>  
    </form>
  </div>
</template>

<script>
import authService from "../services/AuthService";

export default {
  name: "login",
  components: {},
  data() {
    return {
      user: {
        username: "",
        password: ""
      },
      invalidCredentials: false
    };
  },
  methods: {
    login() {
      authService
        .login(this.user)
        .then(response => {
          if (response.status == 200) {
            this.$store.commit("SET_AUTH_TOKEN", response.data.token);
            this.$store.commit("SET_USER", response.data.user);
            this.$router.push("/");
          }
        })
        .catch(error => {
          const response = error.response;

          if (response.status === 401) {
            this.invalidCredentials = true;
          }
        });
    }
  }
};
</script>

<style scoped>
#login {
  width: 80%;
  margin: auto;
  padding: 0px;  
}

.form-signin {
  display: flex;
  flex-direction: column;
  width: auto;
  line-height: 4em;
  margin: 25px 0px;
  padding: 50px 100px;
}

.form-signin h1 {
  font-family: 'Montserrat', sans-serif;  
  font-weight: 500;
  color: #54782c;
};
</style>