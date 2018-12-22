<template>
  <div id="app">
      <b-navbar toggleable="md" type="dark" variant="info">
        <b-navbar-toggle target="nav_collapse"></b-navbar-toggle>
        <b-navbar-brand href="#">NTUEvents</b-navbar-brand>
        <b-collapse is-nav id="nav_collapse">
          <b-navbar-nav>
            <b-nav-item to="/main">Home</b-nav-item>
            <b-nav-item to="/events">Events</b-nav-item>
            <b-nav-item to="/user">User</b-nav-item>
          </b-navbar-nav>

          <!-- Right aligned nav items
          <b-navbar-nav class="ml-auto">
          </b-navbar-nav>-->
        </b-collapse>
      </b-navbar>
    <router-view/>
  </div>
</template>

<script>
import MainPage from "./components/main";

export default {
  name: "app",
  components: {
    MainPage
  }
};
</script>

<style>
</style>
