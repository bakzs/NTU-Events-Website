<template>
  <div class="login">
    <br>
    <div class="container">
      <h3>Login</h3>
      <br />
      <b-form>
        <b-form-group id="usernameLbl" label="Username" label-for="userTbx">
          <b-form-input id="userTbx" type="text" placeholder="Enter username"></b-form-input>
        </b-form-group>
        <b-form-group id="passwordLbl" label="Password" label-for="passwordTbx">
          <b-form-input id="passwordTbx" type="password" placeholder="Enter password"></b-form-input>
        </b-form-group>
        <br />
        <b-button type="submit" variant="success">Submit</b-button>
      </b-form>
    </div>
  </div>
</template>
