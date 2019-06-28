import Vue from 'vue'
import Vuetify,{VLayout} from 'vuetify/lib'
import 'vuetify/src/stylus/app.styl'
Vue.use(Vuetify, {
  theme: {
    primary: '#FB8C00',
    secondary: '#FB8C00',
    accent: '#FB8C00',
    error: '#FB8C00',
    info: '#FB8C00',
    success: '#FB8C00',
    warning: '#FB8C00'
  },
  options: {
    customProperties: true
  },
  iconfont: 'md',
  components: {
    VLayout
  }
})
