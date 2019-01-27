<template>
  <div>
    <!-- Navbar -->
    <b-navbar toggleable="md" type="dark" fixed="top">
      <div class="container">
        <b-navbar-brand href="#">NTUEvents</b-navbar-brand>
        <b-navbar-nav class="ml-auto">
          <b-navbar-toggle target="nav_collapse"></b-navbar-toggle>
        </b-navbar-nav>
        <b-collapse is-nav id="nav_collapse">
          <b-navbar-nav>
            <b-nav-item class="active" to="/main">Home</b-nav-item>
            <!-- Remove links -->
            <b-nav-item to="/login">Login</b-nav-item>
            <b-nav-item to="/register">Register</b-nav-item>
            <b-nav-item to="/user">User Profile</b-nav-item>
            <b-nav-item to="/events">Events</b-nav-item>
          </b-navbar-nav>
        </b-collapse>
      </div>
    </b-navbar>
    <!-- End of Navbar -->
    <!-- Cover page -->
    <div class="bg-cover">
      <div class="bg-content">
        <h1>EVENTS</h1>
        <p
          class="title-body"
        >Need a break? Find the latest events from all clubs and societies in NTU here now!</p>
      </div>
    </div>
    <!-- End of Cover page -->
    <br>
    <!--Upcoming Event Section-->
    <section class="upcoming-event">
      <b-container>
        <h4>Upcoming Events</h4>
        <div class="event-header-item">
          <div class="event-icon">
            <i class="fas fa-list fa-lg"></i>
            <div class="event-icon-name">LIST</div>
          </div>
          <div class="event-icon">
            <i class="far fa-calendar fa-lg"></i>
            <div class="event-icon-name">MONTH</div>
          </div>
        </div>
        <hr>
      </b-container>
    </section>
    <!-- End of Upcoming Event Section -->
    <!--Main Event List Section-->
    <section class="event-list">
      <b-container>
        <template v-for="event in events">
          <div class="row event1-item" :key="event.eventId">
            <div class="col-lg-12">
              <div class="event-panel">
                <div class="row">
                  <div class="col-md-2">
                    <div class="event-date">
                      <p class="date_mth_day">{{event.startDay}}</p>
                      <hr class="date-divider">
                      <p class="date_day">{{event.startDayWeek}}</p>
                    </div>
                  </div>
                  <div class="col-md-4">
                    <img
                      width="350"
                      height="256"
                      :src="event.imageSource"
                    >
                  </div>
                  <div class="col-md-6">
                    <div class="event-row event-header">{{event.name}}</div>
                    <div class="event-detail">
                      <p class="event-location">{{event.venue}}</p>
                    </div>
                    <hr>
                    <div
                      class="event-row event-desc"
                   >{{event.description}}</div>
                    <b-button class="btn-details" :href="event.website">
                      Find out more
                      <i class="fas fa-arrow-right"></i>
                    </b-button>
                  </div>
                </div>
              </div>
            </div>
          </div>
        </template>
      </b-container>
    </section>
    <!--End of Main Event List Section-->
    <!-- Prev Event Section-->
    <section class="prev-event">
      <b-container>
        <b-button class="btn-details">
          <i class="fas fa-arrow-left"></i> View previous events
        </b-button>
      </b-container>
    </section>
    <!-- End of Prev Event Section -->
    <br>
    <footer class="copyright">NTUEvents © 2018, All Rights Reserved</footer>
  </div>
</template>

<script>
export default {
  data() {
    return {
      events: []
    };
  },
  methods: {
    getAllEvents() {
      this.axios
        .get(this.$hostname + "/api/events")
        .then(response => {
          this.events = response.data;
          //Update array and format date time using MomentJs
          for (let item of this.events) {
            item.startDay = this.$moment(new Date(item.startDate)).format(
              "MMM DD"
            );
            item.endDay = this.$moment(new Date(item.endDate)).format("MMM DD");
            item.startDayWeek = this.$moment(new Date(item.startDate)).format(
              "dddd"
            );
            item.endDayWeek = this.$moment(new Date(item.endDate)).format(
              "dddd"
            );
          }
        })
        .catch(function(error) {
          console.log(error);
        });
    },
    formatDate(date) {
      let dateObj = this.$moment(date, "YYYY-MM-DD");
      return dateObj.format("MMM Do YY");
    }
  },
  computed: {},
  mounted() {
    this.getAllEvents();
  }
};
</script>

<style>
@import url("../assets/style.css");
</style>
