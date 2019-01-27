//Core files
import Vue from 'vue'
import App from './App.vue'
import router from './router'

//Initialize all the Javascript Libraries here
import BootstrapVue from 'bootstrap-vue'
import VueAxios from 'vue-axios'
import axios from 'axios'
import datePicker from 'vue-bootstrap-datetimepicker';
import jQuery from "jquery";
import VeeValidate from 'vee-validate';

//Javascript Libraries Styling
import 'bootstrap/dist/css/bootstrap.css'
import 'bootstrap-vue/dist/bootstrap-vue.css'
import 'pc-bootstrap4-datetimepicker/build/css/bootstrap-datetimepicker.css';
import "@fortawesome/fontawesome-free/css/fontawesome.css";
import "@fortawesome/fontawesome-free/css/regular.css";
import "@fortawesome/fontawesome-free/css/solid.css";

//Development mode
Vue.config.productionTip = false;

//Install Javascript Libraries
//Must be called before new Vue()
Vue.use(BootstrapVue);
Vue.use(VueAxios,axios);
Vue.use(require('vue-moment'));
Vue.use(datePicker);
Vue.use(VeeValidate, { fieldsBagName: "formFields"}, );

//Setting the icons for the datetimepicker
jQuery.extend(true, jQuery.fn.datetimepicker.defaults, {
  icons: {
    time: "far fa-clock",
    date: "far fa-calendar",
    up: "fas fa-arrow-up",
    down: "fas fa-arrow-down",
    previous: "fas fa-chevron-left",
    next: "fas fa-chevron-right",
    today: "fas fa-calendar-check",
    clear: "far fa-trash-alt",
    close: "far fa-times-circle"
  }
});
window.$ = window.jQuery = require("jquery");

Vue.prototype.$hostname = 'https://localhost:5001'

new Vue({
  router,
  render: h => h(App)
}).$mount('#app')

