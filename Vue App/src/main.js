import Vue from 'vue'
import App from './App.vue'
import router from './router'
import BootstrapVue from 'bootstrap-vue'
import VueAxios from 'vue-axios'
import axios from 'axios'
import 'bootstrap/dist/css/bootstrap.css'
import 'bootstrap-vue/dist/bootstrap-vue.css'
import moment from 'vue-moment'

Vue.config.productionTip = false

Vue.use(BootstrapVue);
Vue.use(VueAxios, axios);
Vue.use(moment);
//Used vue-moment instead of moment
//Vue.prototype.moment = moment

new Vue({
  router,
  render: h => h(App)
}).$mount('#app')
