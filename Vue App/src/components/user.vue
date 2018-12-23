<template>
  <div class="user">
   <b-container>
      <br>
      <h3>User Profile</h3>
      <br>
      <b-form @submit="onSubmit(userEditForm)">
        <b-form-group id="usernameLbl" label="Username" label-for="userTbx">
          <b-form-input id="userTbx" type="text" v-model="userEditForm.username" required :disabled=isEditable></b-form-input>
        </b-form-group>
        <b-form-group id="emaikLbl" label="Email" label-for="emailTbx">
          <b-form-input id="emailTbx" type="email" v-model="userEditForm.email" required :disabled=isEditable></b-form-input>
        </b-form-group>
        <b-form-group id="contactLbl" label="Contact Number" label-for="contactTbx">
          <b-form-input id="contactTbx" type="tel" v-model="userEditForm.contact" required :disabled=isEditable></b-form-input>
        </b-form-group>
        <br>
        <b-button variant="outline-danger" v-on:click="onChangePassword" v-if=!isPasswordChange>Change Password</b-button>
        <br>
        <br>
        <b-form-group id="currentPasswordLbl" label="Current Password" label-for="currentPassword" v-if=isPasswordChange>
          <b-form-input id="currentPassword" type="password" v-model="userEditForm.currentPassword" required></b-form-input>
        </b-form-group>
        <b-form-group id="newPasswordLbl" label="New Password" label-for="newPassword" v-if=isPasswordChange>
          <b-form-input id="newPassword" type="password" v-model="userEditForm.newPassword" required></b-form-input>
        </b-form-group>
        <b-form-group id="newPasswordCfmLbl" label="Confirm New Password" label-for="newPasswordCfm" v-if=isPasswordChange>
          <b-form-input id="newPasswordCfm" type="password" v-model="userEditForm.newPasswordCfm" required></b-form-input>
        </b-form-group>
        <br>
        <b-button id="editProfileBtn" variant="info" v-on:click="onEdit" v-if=isEditable>Edit Profile</b-button>
        <b-button type="submit" variant="success" v-if=!isEditable>Save</b-button>
        <b-button variant="danger" v-if=isEditable>Delete Account</b-button>
      </b-form>
   </b-container>
  </div>
</template>

<script>
import axios from 'axios';

export default {
  data() {
    return {
      userEditForm: {
        username: "User1",
        email: "User@email.com",
        contact: 91234567,
        currentPassword: "",
        newPassword: "",
        newPasswordCfm: ""
      },
      isEditable: true,
      isPasswordChange: false,
      //Create finalUserEditForm
      finalUserEditForm: {

      }
    }
  },
  methods: {
    onEdit() {
      this.$data.isEditable = false;
    },
    onChangePassword() {
      this.$data.isPasswordChange = true;
    },
    onSubmit(userEditForm) {
      //CLient-side validation
      if(this.$data.newPassword !== this.$data.newPasswordCfm){
        alert('The new passwords do not match')
      }
      //Post form using axios
      return axios.post('https://localhost:44362/api/users/1', finalUserEditForm)
    }
  }
}
</script>

<style scoped>
</style>