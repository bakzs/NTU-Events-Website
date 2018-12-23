<template>
  <div class="register">
   <b-container>
      <br>
      <h3>Register New Account</h3>
      <br>
      <b-form>
        <b-form-group id="usernameLbl" label="Username" label-for="userTbx">
          <b-form-input id="userTbx" type="text" placeholder="Enter username"></b-form-input>
        </b-form-group>
        <b-form-group id="emaikLbl" label="Email" label-for="emailTbx">
          <b-form-input id="emailTbx" type="email" placeholder="Enter email"></b-form-input>
        </b-form-group>
        <b-form-group id="passwordLbl" label="Password" label-for="passwordTbx">
          <b-form-input id="passwordTbx" type="password" placeholder="Enter password"></b-form-input>
        </b-form-group>
        <b-form-group id="cfmpasswordLbl" label="Confirm Password" label-for="cfmpasswordTbx">
          <b-form-input id="cfmpasswordTbx" type="password" placeholder="Enter password"></b-form-input>
        </b-form-group>
        <b-form-group id="contactLbl" label="Contact Number" label-for="contactTbx">
          <b-form-input id="contactTbx" type="text" placeholder="Enter Contact Number"></b-form-input>
        </b-form-group>
        <br />
        <b-button type="submit" variant="success">Register</b-button>
      </b-form>
   </b-container>
  </div>
</template>
