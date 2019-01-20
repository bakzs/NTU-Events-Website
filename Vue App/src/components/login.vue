<template>
  <div class="login">
    <b-container>
      <b-form class="login-form">
        <h3 class="text-center">NTUEvents</h3>
        <br>
        <b-alert
          :show="dismissCountDown"
          dismissible
          fade
          variant="danger"
          @dismissed="dismissCountDown=0"
          @dismiss-count-down="countDownChanged"
        >{{dismissMessage}}</b-alert>
        <b-form-group
          id="usernameLbl"
          class="form-label-group"
          :invalid-feedback="errors.first('Username')"
          :state="!errors.has('Username')"
          label="Username"
          label-for="userTbx"
        >
          <b-form-input
            id="userTbx"
            :state="!errors.has('Username')"
            v-validate="'required|alpha_num|min:5|max:30'"
            type="text"
            v-model="input.username"
            placeholder="Enter username"
            name="Username"
          ></b-form-input>
        </b-form-group>
        <b-form-group
          id="passwordLbl"
          class="form-label-group"
          :invalid-feedback="errors.first('Password')"
          :state="!errors.has('Password')"
          label="Password"
          label-for="passwordTbx"
        >
          <b-form-input
            id="passwordTbx"
            :state="!errors.has('Password')"
            v-validate="'required|min:5|max:50'"
            type="password"
            v-model="input.password"
            placeholder="Enter password"
            name="Password"
          ></b-form-input>
        </b-form-group>
        <br>
        <b-button type="submit" @click.stop.prevent="login()" variant="primary">Submit</b-button>
      </b-form>
    </b-container>
  </div>
</template>
<script>
export default {
  name: "Login",
  data() {
    return {
      input: {
        username: "",
        password: ""
      },
      dismissMessage: "",
      dismissSecs: 2,
      dismissCountDown: 0,
      showDismissibleAlert: false
    };
  },
  methods: {
    countDownChanged(dismissCountDown) {
      this.dismissCountDown = dismissCountDown;
    },
    login() {
      this.$validator
        .validateAll()
        .then(result => {
          if (result) {
            this.axios({
              method: "post",
              url: "https://localhost:44362/api/accounts",
              data: input
            })
              .then(function(response) {
                this.$router.push("/main/");
              })
              .catch(function(error) {
                alert("Error");
                this.dismissMessage =
                  "The username and / or password is incorrect";
                this.dismissCountDown = this.dismissSecs;
                $("#userTbx")
                  .removeClass("is-valid")
                  .addClass("is-invalid");
                $("#passwordTbx")
                  .removeClass("is-valid")
                  .addClass("is-invalid");
              });
          }
        })
        .catch(() => {});
    }
  },
  mounted() {
    //Clean validation initial load
    $("#userTbx").removeClass("is-valid");
    $("#passwordTbx").removeClass("is-valid");
  }
};
</script>
<style>
@import url("../assets/login.css");
</style>