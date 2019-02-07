<template>
  <div class="user">
    <br>
    <br>
    <b-container>
      <b-form class="register-form col-lg-7">
        <b-card header-variant="card_header" bg-variant="light">
          <div slot="header">
            <h3>User Profile</h3>
          </div>
          <b-form v-if="displayUserProfile">
            <div v-for="user in items" :key="user.id">
              <b-alert :show="showSuccessAlert" variant="success">{{dismissMessage}}</b-alert>
              <b-row>
                <div class="col-lg-3 col-form-label">
                  <b-form-group id="usernameLbl" label="Username" label-for="userTbx"></b-form-group>
                </div>
                <div class="col-lg-9">
                  <b-form-input
                    id="userTbx"
                    type="text"
                    required
                    :disabled="!canBeEdited"
                    v-model="user.username"
                    placeholder="Enter your username"
                  ></b-form-input>
                </div>
              </b-row>
              <b-row>
                <div class="col-lg-3 col-form-label">
                  <b-form-group id="nameLbl" label="Name" label-for="name"></b-form-group>
                </div>
                <div class="col-lg-9">
                  <b-form-input
                    id="name"
                    type="text"
                    required
                    :disabled="!canBeEdited"
                    v-model="user.name"
                    placeholder="Enter your name"
                  ></b-form-input>
                </div>
              </b-row>
              <b-row>
                <div class="col-lg-3 col-form-label">
                  <b-form-group id="emaikLbl" label="Email" label-for="emailTbx"></b-form-group>
                </div>
                <div class="col-lg-9">
                  <b-form-input
                    id="emailTbx"
                    type="email"
                    required
                    :disabled="!canBeEdited"
                    v-model="user.email"
                    placeholder="Enter your email"
                  ></b-form-input>
                </div>
              </b-row>
              <b-row>
                <div class="col-lg-3 col-form-label">
                  <b-form-group id="contactLbl" label="Contact Number" label-for="contactTbx"></b-form-group>
                </div>
                <div class="col-lg-9">
                  <b-form-input
                    id="contactTbx"
                    type="tel"
                    :disabled="!canBeEdited"
                    v-model="user.contactNumber"
                    placeholder="Enter your contact number"
                  ></b-form-input>
                </div>
              </b-row>
            </div>
          </b-form>
          <b-form v-if="canChangePassword">
            <b-row>
              <div class="col-lg-3 col-form-label">
                <b-form-group
                  id="currentPasswordLbl"
                  label="Current Password"
                  label-for="currentPassword"
                ></b-form-group>
              </div>
              <div class="col-lg-9">
                <b-form-input
                  id="currentPassword"
                  type="password"
                  required
                  placeholder="Enter current password"
                ></b-form-input>
              </div>
            </b-row>
            <b-row>
              <div class="col-lg-3 col-form-label">
                <b-form-group id="newPasswordLbl" label="New Password" label-for="newPassword"></b-form-group>
              </div>
              <div class="col-lg-9">
                <b-form-input
                  id="newPassword"
                  type="password"
                  required
                  placeholder="Enter new password"
                  v-model="newPassword"
                ></b-form-input>
              </div>
            </b-row>
            <b-row>
              <div class="col-lg-3 col-form-label">
                <b-form-group
                  id="newPasswordCfmLbl"
                  label="Confirm New Password"
                  label-for="newPasswordCfm"
                ></b-form-group>
              </div>
              <div class="col-lg-9">
                <b-form-input
                  id="newPasswordCfm"
                  type="password"
                  required
                  placeholder="Confirm new password"
                ></b-form-input>
              </div>
            </b-row>
          </b-form>
          <br>
          <div class="btn-block">
            <b-button
              id="editProfileBtn"
              variant="outline-info"
              v-on:click="onEdit"
              class="mr-2"
              v-if="!canBeEdited && !canChangePassword"
            >Edit Profile</b-button>
            <b-button
              variant="outline-danger"
              v-on:click="onChangePassword"
              class="ml-2"
              v-if="!canChangePassword && !canBeEdited"
            >Change Password</b-button>
            <b-button
              v-on:click="onSubmitNewUserProfile"
              variant="outline-success"
              v-if="canBeEdited && !canChangePassword"
            >Save User Profile</b-button>
            <b-button
              v-on:click="onSubmitNewPassword"
              variant="outline-success"
              v-if="!canBeEdited && canChangePassword"
            >Save Password</b-button>
            <div class="float-right">
              <b-button v-on:click="getBack" variant="outline-secondary">Back</b-button>
            </div>
          </div>
        </b-card>
      </b-form>
    </b-container>
  </div>
</template>
<script>
export default {
  data() {
    return {
      userId: this.$route.params.userId,
      items: [],
      displayUserProfile: true,
      canBeEdited: false,
      canChangePassword: false,
      showSuccessAlert: false,
      dismissMessage: "",
      newPassword: ""
    };
  },
  methods: {
    onEdit() {
      this.showSuccessAlert = false;
      this.canBeEdited = true;
    },
    onChangePassword() {
      this.canChangePassword = true;
      this.displayUserProfile = false;
    },
    onSubmitNewUserProfile() {
      this.$validator.validateAll().then(result => {
        this.items.updatedBy = this.userId;
        this.items.updatedDate = new Date().toLocaleString();
        console.log(this.items);
        if (result) {
          var cur = this;
          this.axios({
            method: "put",
            url: this.$hostname + "/api/users/" + this.userId,
            data: this.items[0]
          })
            .then(function(response) {
              cur.showSuccessAlert = true;
              cur.canBeEdited = false;
              cur.dismissMessage = "Profile updated!";
            })
            .catch(error => {
              alert("Error encountered while updating user profile");
              console.log(error);
            });
        }
      });
    },
    onSubmitNewPassword() {
      //get updated password
      console.log(this.newPassword);
      var cur = this;
      cur.displayUserProfile = true;
      cur.canChangePassword = false;
      cur.showSuccessAlert = true;
      cur.dismissMessage = "Password updated!";
    },
    getBack() {
      if (!this.canBeEdited && !this.canChangePassword) {
        this.$router.push("/main");
      } else if (this.canBeEdited && !this.canChangePassword) {
        this.canBeEdited = false;
      } else if (!this.canBeEdited && this.canChangePassword) {
        this.canChangePassword = false;
        this.displayUserProfile = true;
      }
    }
  },
  mounted() {
    this.axios
      .get(this.$hostname + "/api/users/" + this.userId)
      .then(response => {
        this.items = response.data;
      })
      .catch(error => {
        alert("Error encountered while retrieving user profile");
        console.log(error);
      });
  }
};
</script>

<style>
</style>