<template>
  <div>
    <div class="bg-cover">
      <b-navbar toggleable="md" type="dark">
        <b-navbar-toggle target="nav_collapse"></b-navbar-toggle>
        <b-navbar-brand href="#">NTUEvents</b-navbar-brand>
        <b-collapse is-nav id="nav_collapse">
          <b-navbar-nav>
            <b-nav-item to="/main">Home</b-nav-item>
            <b-nav-item to="/login">Login</b-nav-item>
            <b-nav-item to="/register">Register</b-nav-item>
            <b-nav-item to="/user">User</b-nav-item>
            <b-nav-item to="/events">Events</b-nav-item>
          </b-navbar-nav>
          <!-- Right aligned nav items
          <b-navbar-nav class="ml-auto">
          </b-navbar-nav>-->
        </b-collapse>
      </b-navbar>
      <div class="bg-content text-center">
        <h1 class="title">EVENTS</h1>
        <h4
          class="title-body"
        >Need a break? Find the latest events from all clubs and societies in NTU here now!</h4>
      </div>
    </div>
    <br>
    <b-container>
      <section class="upcoming-event">
        <h4>Upcoming Events</h4>
        <div class="item">
          <div class="event-icon">
            <i class="fas fa-list fa-lg"></i>
            <div class="icon-name">LIST</div>
          </div>
          <div class="event-icon">
            <i class="far fa-calendar fa-lg"></i>
            <div class="icon-name">MONTH</div>
          </div>
        </div>
      </section>
      <hr>
      <section>
        <br>
        <div class="event-item">
          <b-media no-body>
            <b-media-aside vertical-align="left">
              <div class="event-date">
                <p class="date_mth">JAN</p>
                <hr class="date-divider">
                <p class="date_day">11</p>
              </div>
            </b-media-aside>
            <b-media-aside vertical-align="center">
              <b-img
                src="https://images.pexels.com/photos/1268558/pexels-photo-1268558.jpeg?auto=compress&cs=tinysrgb&dpr=2&h=750&w=1260"
                width="350"
                height="256"
                alt="placeholder"
              />
            </b-media-aside>
            <b-media-body class="ml-5 event-body">
              <h3 class="mt-0">JAC New Year Party 2019</h3>
              <div class="event-detail">
                <p class="event-location">Spottiswoode condominum 48</p>
                <p class="event-time">6 - 10pm</p>
              </div>
              <p class="event-desc">
                To welcome the new academic year, we’ll be hosting a party! There’ll be delicious Japanese food from Miz restaurant,
                fun games and prizes to be won! We hope to see you there!
              </p>
              <hr>
              <b-button class="btn-details">
                View Event Details
                <i class="fas fa-arrow-right"></i>
              </b-button>
            </b-media-body>
          </b-media>
        </div>
        <br>
        <hr>
        <br>
        <div class="event-item">
          <b-media no-body>
            <b-media-aside vertical-align="left">
              <div class="event-date">
                <p class="date_mth">FEB</p>
                <hr class="date-divider">
                <p class="date_day">17</p>
              </div>
            </b-media-aside>
            <b-media-aside vertical-align="center">
              <b-img
                src="http://surfnsweat.ntusportsclub.sg/images/img_8895-crop-u2764.jpg?crc=4203607046"
                width="350"
                height="256"
                alt="placeholder"
              />
            </b-media-aside>
            <b-media-body class="ml-5 event-body">
              <h3 class="mt-0">Surf n Sweat</h3>
              <div class="event-detail">
                <p class="event-location">Palawan Beach, Sentosa</p>
                <p class="event-time">Whole day</p>
              </div>
              <p class="event-desc">
                Surf N Sweat is Singapore's largest annual beach sporting event, proudly organised by Nanyang Technological University Sports Club.
                We'll be making waves at Palawan Beach, Sentosa, so prepare yourself for a day of adrenaline pumping and exhilarating activities happening on both sand and sea!
              </p>
              <hr>
              <b-button class="btn-details">
                View Event Details
                <i class="fas fa-arrow-right"></i>
              </b-button>
            </b-media-body>
          </b-media>
        </div>
        <br>
        <hr>
        <br>
        <div class="event-item">
          <b-media no-body>
            <b-media-aside vertical-align="left">
              <div class="event-date">
                <p class="date_mth">MAR</p>
                <hr class="date-divider">
                <p class="date_day">9</p>
              </div>
            </b-media-aside>
            <b-media-aside vertical-align="center">
              <b-img
                src="http://bikerally.ntusportsclub.sg/images/regpic.jpg"
                width="350"
                height="256"
                alt="placeholder"
              />
            </b-media-aside>
            <b-media-body class="ml-5 event-body">
              <h3 class="mt-0">Bike Rally 2019</h3>
              <div class="event-detail">
                <p class="event-location">TBC</p>
                <p class="event-time">TBC</p>
              </div>
              <p class="event-desc">
                Bike Rally is a nationwide, non-competitive cycling event organised by Nanyang Technological University (NTU) Sports Club.
                It aims to connect both amateur and professional cyclists through their shared love for cycling.
              </p>
              <hr>
              <b-button class="btn-details">
                View Event Details
                <i class="fas fa-arrow-right"></i>
              </b-button>
            </b-media-body>
          </b-media>
        </div>
        <br>
        <hr>
        <br>
      </section>
      <section class="prev-event">
        <b-button class="btn-details">
          <i class="fas fa-arrow-left"></i> View previous events
        </b-button>
      </section>
      <br>
    </b-container>
    <div class="bg-footer">
        <div class="footer-content">
          <div class="col-md-12">
            <small>NTUEvents © 2018, All Rights Reserved</small>
          </div>
        </div>
    </div>
  </div>
</template>

<style>
/* Custom CSS design */
@import url("https://fonts.googleapis.com/css?family=Roboto");

* {
  font-family: "Roboto", sans-serif;
}

.bg-cover {
  background: linear-gradient(rgba(0, 0, 0, 0.3), rgba(0, 0, 0, 0.3)),
    url("https://images.pexels.com/photos/9044/pexels-photo.jpg?cs=srgb&dl=bokeh-city-dark-9044.jpg&fm=jpg");
  background-repeat: no-repeat;
  background-size: cover;
  background-position: center center;
  position: relative;
  color: #fff;
  height: 60vh;
}

.bg-content {
  margin-top: 10vh;
  padding: 10px;
}

.bg-footer {
  background: linear-gradient(rgba(0, 0, 0, 0.3), rgba(0, 0, 0, 0.3)),
    url("https://images.pexels.com/photos/9044/pexels-photo.jpg?cs=srgb&dl=bokeh-city-dark-9044.jpg&fm=jpg");
  background-repeat: no-repeat;
  background-size: cover;
  background-position: center center;
  position: relative;
  color: #fff;
  height: 20vh;
}

.navbar {
  font-size: 18px;
}

.title {
  letter-spacing: 40px;
  padding-left: 1em;
  font-size: 60px;
}

.title-body {
  margin-top: 5vh;
  font-style: italic;
  font-size: 20px;
}

.upcoming-event {
  margin: 20px 0px 30px 30px;
}

div.item {
  float: right;
  margin-top: -40px;
  text-align: center;
}

.icon-name {
  display: block;
  font-size: 10px;
}

.event-icon {
  display: inline-block;
  margin: 0 10px;
}

.event-item {
  /*top right bottom left*/
  margin: 0px 20px 0px 20px;
}

.event-date {
  text-align: center;
  margin: 0px 30px 0px 10px;
}

.date_mth {
  letter-spacing: 2px;
  font-weight: 400;
  font-size: 18px;
  color: grey;
}

.date_day {
  letter-spacing: -4px;
  margin-top: -10px;
  font-weight: 800;
  font-size: 42px;
  color: grey;
}

.date-divider {
  margin-top: -5px;
  margin-left: 5px;
  background-color: grey;
  width: 30%;
}

.event-detail {
  color: grey;
  font-size: 16px;
}

.event-time {
  margin-top: -15px;
}

.event-body {
  overflow: hidden;
  position: relative;
  width: 100%;
}

.event-desc {
  overflow: hidden;
  text-overflow: ellipsis;
}

.footer-content{
  position: absolute;
  right: 0;
  bottom: 0;
  left: 0;
  padding: 1rem;
  text-align: center;
  font-size: 20px;
}

.btn-details,
.btn-details:active {
  /*!important override bootstrap button custom styles*/
  background-color: transparent !important;
  color: grey !important;
  border: none !important;
  outline: none !important;
  box-shadow: none !important;
}

.btn-details:hover {
  color: black !important;
}
</style>
