<template>
  <div class="register">
    <b-container>
      <br>
      <br>
      <b-form class="register-form col-lg-6">
        <br>
        <h3>Register New Account</h3>
        <br>
        <b-form-group
          id="nameLbl"
          :invalid-feedback="errors.first('Name')"
          :state="!errors.has('Name')"
          label="Name"
          label-for="nameTbx"
        >
          <b-form-input
            id="nameTbx"
            :state="!errors.has('Name')"
            v-validate="'required|alpha_num|min:5|max:30'"
            name="Name"
            type="text"
            placeholder="Enter name"
            v-model="userRegistrationForm.Name"
          ></b-form-input>
        </b-form-group>
        <b-form-group
          id="usernameLbl"
          :invalid-feedback="errors.first('Username')"
          :state="!errors.has('Username')"
          label="Username"
          label-for="userTbx"
        >
          <b-form-input
            id="userTbx"
            :state="!errors.has('Username')"
            v-validate="'required|alpha_num|min:5|max:30'"
            name="Username"
            type="text"
            placeholder="Enter username"
            v-model="userRegistrationForm.Username"
          ></b-form-input>
        </b-form-group>
        <b-form-group
          id="emaikLbl"
          :invalid-feedback="errors.first('Email')"
          :state="!errors.has('Email')"
          label="Email"
          label-for="emailTbx"
        >
          <b-form-input
            id="emailTbx"
            :state="!errors.has('Email')"
            v-validate="'email'"
            name="Email"
            type="email"
            placeholder="Enter email"
            v-model="userRegistrationForm.Email"
          ></b-form-input>
        </b-form-group>
        <b-form-group
          id="contactLbl"
          :invalid-feedback="errors.first('Contact Number')"
          :state="!errors.has('Contact Number')"
          label="Contact Number"
          label-for="contactTbx"
        >
          <b-form-input
            id="contactTbx"
            :state="!errors.has('Contact Number')"
            v-validate="'required|numeric|min:8|max:8'"
            name="Contact Number"
            type="text"
            placeholder="Enter contact"
            v-model="userRegistrationForm.ContactNumber"
          ></b-form-input>
        </b-form-group>
        <b-form-group
          id="passwordLbl"
          :invalid-feedback="errors.first('Password')"
          :state="!errors.has('Password')"
          label="Password"
          label-for="passwordTbx"
        >
          <b-form-input
            id="passwordTbx"
            :state="!errors.has('Password')"
            v-validate="'required|min:12'"
            name="Password"
            type="password"
            placeholder="Enter password"
            v-model="userRegistrationForm.Password"
            ref="password"
          ></b-form-input>
        </b-form-group>
        <b-form-group
          id="cfmpasswordLbl"
          :invalid-feedback="errors.first('Confirm Password')"
          :state="!errors.has('Confirm Password')"
          label="Confirm Password"
          label-for="cfmpasswordTbx"
        >
          <b-form-input
            id="cfmpasswordTbx"
            :state="!errors.has('Confirm Password')"
            v-validate="'required|min:12|confirmed:password'"
            name="Confirm Password"
            type="password"
            placeholder="Confirm password"
            v-model="userRegistrationForm.cfmPassword"
          ></b-form-input>
        </b-form-group>
        <br>
        <b-button variant="success" v-on:click="onRegisterUser">Register</b-button>
      </b-form>
    </b-container>
  </div>
</template>

<script>
export default {
  data() {
    return {
      userRegistrationForm: {
        Username: "",
        Name: "",
        Email: "",
        ContactNumber: "",
        Password: "",
        cfmPassword: ""
      }
    };
  },
  methods: {
    onRegisterUser() {
      this.$data.userRegistrationForm.CreatedDate = new Date().toLocaleString();
      this.$validator
        .validateAll()
        .then(result => {
          var regForm = {
            Username: this.$data.userRegistrationForm.Username,
            Name: this.$data.userRegistrationForm.Name,
            Email: this.$data.userRegistrationForm.Email,
            ContactNumber: this.$data.userRegistrationForm.Contact,
            Password: this.$data.userRegistrationForm.Password
          };
          if (result) {
            var cur = this;
            this.axios({
              method: "post",
              url: this.$hostname + "/api/users",
              data: regForm
            }).then(function(response) {
              if (response.status == "201") {
                localStorage.setItem("loginAlert", "true");
                cur.$router.push("/login");
              }
            });
          }
        })
        .catch(() => {});
    }
  },
  mounted() {
    //Clean validation initial load
    $("#nameTbx").removeClass("is-valid");
    $("#userTbx").removeClass("is-valid");
    $("#emailTbx").removeClass("is-valid");
    $("#contactTbx").removeClass("is-valid");
    $("#passwordTbx").removeClass("is-valid");
    $("#cfmpasswordTbx").removeClass("is-valid");
  }
};
</script>
<style>
@import url("../assets/form.css");
</style>