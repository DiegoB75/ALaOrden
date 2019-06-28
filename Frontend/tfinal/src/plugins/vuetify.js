import Vue from 'vue'
import Vuetify,{VLayout} from 'vuetify/lib'
import 'vuetify/src/stylus/app.styl'
Vue.use(Vuetify, {
  theme: {
    primary: '#2445c9',
    secondary: '#63e08d',
    accent: '#e38046',
    error: '#f22707',
    info: '#f2ff42',
    success: '#39e363',
    warning: '#fa021b'
  },
  options: {
    customProperties: true
  },
  iconfont: 'md',
  components: {
    VLayout
  }
})
