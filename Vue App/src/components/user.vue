<template>
  <div class="user">
    <b-container>
      <br>
      <h3>User Profile</h3>
      <br>
      <b-form v-if=displayUserProfile>
        <b-form-group id="usernameLbl" label="Username" label-for="userTbx">
          <b-form-input id="userTbx" type="text" v-model="userEditForm[0].username" required :disabled=canBeEdited aria-describedby="userTbxHelp userTbxFeedback" placeholder="Enter a username"></b-form-input>
          <b-form-text id="userTbxHelp" v-if="!canBeEdited && canChangePassword">
            Username length is limited to 15 characters
          </b-form-text>
        </b-form-group>
        <b-form-group id="emaikLbl" label="Email" label-for="emailTbx">
          <b-form-input id="emailTbx" type="email" v-model="userEditForm[0].email" required :disabled=canBeEdited aria-describedby="emailTbxHelp" placeholder="Enter your email"></b-form-input>
          <b-form-text id="emailTbxHelp" v-if="!canBeEdited && canChangePassword">
            Please enter a valid email address
          </b-form-text>
        </b-form-group>
        <b-form-group id="nameLbl" label="Name" label-for="name">
          <b-form-input id="name" type="text" v-model="userEditForm[0].name" required :disabled=canBeEdited placeholder="Enter your name"></b-form-input>
        </b-form-group>
        <b-form-group id="contactLbl" label="Contact Number" label-for="contactTbx">
          <b-form-input id="contactTbx" type="tel" v-model="userEditForm[0].contactNumber" :disabled=canBeEdited aria-describedby="contactTbxHelp" placeholder="Enter your contact number"></b-form-input>
          <b-form-text id="contactTbxHelp" v-if="!canBeEdited && canChangePassword">
            Please enter a valid contact number
          </b-form-text>
        </b-form-group>
      </b-form>
      <b-form v-if=!canChangePassword>
        <b-form-group id="currentPasswordLbl" label="Current Password" label-for="currentPassword">
          <b-form-input id="currentPassword" type="password" v-model="passwordChangeForm.currentPassword" required placeholder="Enter current password"></b-form-input>
        </b-form-group>
        <b-form-group id="newPasswordLbl" label="New Password" label-for="newPassword">
          <b-form-input id="newPassword" type="password" v-model="passwordChangeForm.newPassword" required placeholder="Enter new password"></b-form-input>
        </b-form-group>
        <b-form-group id="newPasswordCfmLbl" label="Confirm New Password" label-for="newPasswordCfm">
          <b-form-input id="newPasswordCfm" type="password" v-model="passwordChangeForm.newPasswordCfm" required placeholder="Confirm new password"></b-form-input>
        </b-form-group>
      </b-form>
      <br>
      <b-button id="editProfileBtn" variant="info" v-on:click="onEdit" v-if="canBeEdited && canChangePassword">Edit Profile</b-button>
      <b-button v-on:click="onSubmitNewUserProfile" variant="success" v-if="!canBeEdited && canChangePassword">Save User Profile</b-button>
      <b-button v-on:click="onSubmitNewPassword" variant="success" v-if="canBeEdited && !canChangePassword">Save Password</b-button>
      <b-button variant="outline-danger" v-on:click="onChangePassword" v-if="canChangePassword && canBeEdited">Change Password</b-button>
    </b-container>
  </div>
</template>

<script>
import axios from 'axios';

export default {
  data() {
    return {
      //Dummy userId
      userId: 1,
      items: [],
      userEditForm: null,
      passwordChangeForm: {
        currentPassword: "",
        newPassword: "",
        newPasswordCfm: ""
      },
      displayUserProfile: true,
      canBeEdited: true,
      canChangePassword: true,
      //Create finalUserEditForm
      finalUserEditForm: {}
    }
  },
  methods: {
    onEdit(){
      this.$data.canBeEdited = false;
    },
    onChangePassword(){
      this.$data.canChangePassword = false;
      this.$data.displayUserProfile = false;
    },
    onSubmitNewUserProfile(){
      if(this.$data.userEditForm[0].username.length > 15){
        alert('Username length is limited to 15 characters. Please change the username');
        return;
      }
      if(this.$data.userEditForm[0].contactNumber.length > 10){
        alert('Contact number length is limited to 10 characters. Please change the contact number');
        return;
      }

      this.$data.userEditForm[0].UpdatedBy = this.$data.userEditForm[0].userId;
      this.$data.userEditForm[0].UpdatedDate = new Date().toLocaleString();

      axios
        .put('https://localhost:44362/api/users/' + this.$data.userId, this.$data.userEditForm[0])
        .then(response => {
          console.log(response);
        })
        .catch(error => {
          alert('Error encountered while updating user profile')
          console.log(error);
        });
      
      alert('You have successfully changed your user profile!')
    },
    onSubmitNewPassword(){
      //CLient-side validation
      if(this.$data.passwordChangeForm.newPassword !== this.$data.passwordChangeForm.newPasswordCfm){
        alert('The new passwords do not match.')
        return;
      }

      this.$data.userEditForm[0].Password = this.$data.passwordChangeForm.newPassword;
      this.$data.userEditForm[0].UpdatedBy = this.$data.userEditForm[0].userId;
      this.$data.userEditForm[0].UpdatedDate = new Date().toLocaleString();

      axios
        .put('https://localhost:44362/api/users/' + this.$data.userId, this.$data.userEditForm[0])
        .then(response => {
          console.log(response);
        })
        .catch(error => {
          alert('Error encountered while updating password')
          console.log(error);
        });

      alert('You have successfully changed your password!')
    },
  },
  mounted(){
      axios
        .get('https://localhost:44362/api/users/' + this.$data.userId)
        .then(
          response => {
            this.$data.userEditForm = response.data;
          }
        )
        .catch(
          error => {
            alert('Error encountered while retrieving user profile')
            console.log(error);
          }
        )
  }
}
</script>

<style scoped>
</style>