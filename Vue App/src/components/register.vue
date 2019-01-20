<template>
  <div class="register">
   <b-container>
      <br>
      <h3>Register New Account</h3>
      <br>
      <b-form>
        <b-form-group id="usernameLbl" label="Username" label-for="userTbx">
          <b-form-input id="userTbx" type="text" placeholder="Enter username" v-model="userRegistrationForm.Username"></b-form-input>
          <b-form-text id="userTbxHelp">
            Username length is limited to 15 characters
          </b-form-text>
        </b-form-group>
        <b-form-group id="nameLbl" label="Name" label-for="nameTbx">
          <b-form-input id="nameTbx" type="text" placeholder="Enter name" v-model="userRegistrationForm.Name"></b-form-input>
        </b-form-group>
        <b-form-group id="emaikLbl" label="Email" label-for="emailTbx">
          <b-form-input id="emailTbx" type="email" placeholder="Enter email" v-model="userRegistrationForm.Email"></b-form-input>
          <b-form-text id="emailTbxHelp">
            Please enter a valid email address
          </b-form-text>
        </b-form-group>
        <b-form-group id="passwordLbl" label="Password" label-for="passwordTbx">
          <b-form-input id="passwordTbx" type="password" placeholder="Enter password" v-model="userRegistrationForm.Password"></b-form-input>
        </b-form-group>
        <b-form-group id="cfmpasswordLbl" label="Confirm Password" label-for="cfmpasswordTbx">
          <b-form-input id="cfmpasswordTbx" type="password" placeholder="Confirm password" v-model="userRegistrationForm.cfmPassword"></b-form-input>
        </b-form-group>
        <b-form-group id="contactLbl" label="Contact Number" label-for="contactTbx">
          <b-form-input id="contactTbx" type="text" placeholder="Enter Contact Number" v-model="userRegistrationForm.ContactNumber"></b-form-input>
          <b-form-text id="contactTbxHelp">
            Please enter a valid contact number
          </b-form-text>
        </b-form-group>
        <br />
        <b-button variant="success" v-on:click="onRegisterUser">Register</b-button>
      </b-form>
   </b-container>
  </div>
</template>

<script>
export default {
  data(){
    return{
      userRegistrationForm:{
        Username: "",
        Name:"",
        Email: "",
        ContactNumber: "",
        Password: "",
        cfmPassword: ""
      }
    }
  },
  methods:{
    onRegisterUser(){
      if(this.$data.userRegistrationForm.Username.length > 15){
        alert('Username length is limited to 15 characters. Please change the username');
        return;
      }
      if(this.$data.userRegistrationForm.ContactNumber.length > 10){
        alert('Contact number length is limited to 10 characters. Please change the contact number');
        return;
      }
      if(this.$data.userRegistrationForm.Password !== this.$data.userRegistrationForm.cfmPassword){
        alert('The new passwords do not match.')
        return;
      }

      this.$data.userRegistrationForm.CreatedDate = new Date().toLocaleString();

      axios
        .put(this.$hostname + '/api/users/', this.$data.userRegistrationForm)
        .then(response => {
          console.log(response);
        })
        .catch(error => {
          alert('Error encountered while creating user profile')
          console.log(error);
        });

      alert('You have successfully created a user profile!')
    }
  }
}
</script>

<style scoped>

</style>
