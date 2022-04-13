<template>
  <div id="login" class="text-center">
    <form class="form-signin" @submit.prevent="login">
      <h1 class="h3 mb-3 font-weight-normal">Log In</h1>
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
        placeholder="Username"
        v-model="user.username"
        required
        autofocus
      />
      <label for="password" class="sr-only">Password</label>
      <input
        type="password"
        id="password"
        class="form-control"
        placeholder="Password"
        v-model="user.password"
        required
      />
      <router-link :to="{ name: 'register' }">Need an account?</router-link>
      <button type="submit">Log in</button>  
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
  width: 60%;
  background: white;
  margin: auto;
  padding: 25px;  
}
.sr-only{
  display: flex;
  justify-content: space-evenly;
}

.form-signin {
  display: flex;
  flex-direction: column;
  width: 100%;
  line-height: 5em;
}

button {
  display: block;
  align-items:center;
  width: 100%;
  padding: 10px 0px;
  font-size: 24px;
  font-weight: bold;
  background-color:#BFAC9B;
}

label {
  font-size: 24px;
  text-transform: uppercase;
  font-weight: bold;

}

input {
  font-size: 16px;
  width: 100%;
  line-height: 3em;
  margin-bottom: 10px;
  text-align: center;
}

</style>