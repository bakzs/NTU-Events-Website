<template>
  <div class="user">
   <b-container>
      <br>
      <h3>User Profile</h3>
      <br>
      <b-form>
        <b-form-group id="usernameLbl" label="Username" label-for="userTbx">
          <b-form-input id="userTbx" type="text" placeholder="User1" disabled></b-form-input>
        </b-form-group>
        <b-form-group id="emaikLbl" label="Email" label-for="emailTbx">
          <b-form-input id="emailTbx" type="email" placeholder="User@email.com" disabled></b-form-input>
        </b-form-group>
        <b-form-group id="contactLbl" label="Contact Number" label-for="contactTbx">
          <b-form-input id="contactTbx" type="text" placeholder="91234567" disabled></b-form-input>
        </b-form-group>
        <b-form-group id="passwordLbl" label="Password" label-for="passwordTbx">
          <b-button type="submit" variant="outline-danger">Change Password</b-button>
        </b-form-group>
        <br>   
        <b-button type="submit" variant="info">Edit Profile</b-button>
        <b-button type="submit" variant="success" style="display:none;">Save</b-button>
        <b-button type="submit" variant="danger">Delete Account</b-button>
      </b-form>
   </b-container>
  </div>
</template>

