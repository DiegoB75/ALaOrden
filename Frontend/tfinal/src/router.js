import Vue from 'vue'
import Router from 'vue-router'
import Home from './views/Home.vue'
import Usuario from './crud/Usuario.vue'
import Marca from './crud/Marca.vue'
import Transaccion from './crud/Transaccion.vue'
import Sede from './crud/Sede.vue'
import ProductoFranquicia from './crud/ProductoFranquicia.vue'
import Producto from './crud/Producto.vue'
import Pedido from './crud/Pedido.vue'
import Franquicia from './crud/Franquicia.vue'
import Direccion from './crud/Direccion.vue'
import DetallePedido from './crud/DetallePedido.vue'
import Cupon from './crud/Cupon.vue'
import Categoria from './crud/Categoria.vue'
import CarritoItem from './crud/CarritoItem.vue'

Vue.use(Router)

export default new Router({
  mode: 'history',
  base: process.env.BASE_URL,
  routes: [
    {
      path:'/prueba',
      name:'prueba',
      component: () => import('./componentsApp/delivery/Delivery.vue')
    },
    {
      path:'/prueba2',
      name:'prueba2',
      component: () => import('./componentsApp/category/Categories.vue')
    },
    {
      path: '/',
      name: 'home',
      component: Home
    },
    {
      path: '/usuarios',
      name: 'usuarios',
      component: Usuario
    },
    {
      path: '/marcas',
      name: 'marcas',
      component: Marca
    },
    {
      path: '/transacciones',
      name: 'transacciones',
      component: Transaccion
    },
    {
      path: '/sedes',
      name: 'sedes',
      component: Sede
    },
    {
      path: '/productofranquicias',
      name: 'productofranquicias',
      component: ProductoFranquicia
    },
    {
      path: '/productos',
      name: 'productos',
      component: Producto
    },
    {
      path: '/pedidos',
      name: 'pedidos',
      component: Pedido
    },
    {
      path: '/franquicias',
      name: 'franquicias',
      component: Franquicia
    },
    {
      path: '/direcciones',
      name: 'direcciones',
      component: Direccion
    },
    {
      path: '/detallepedidos',
      name: 'detallepedidos',
      component: DetallePedido
    },
    {
      path: '/cupones',
      name: 'cupones',
      component: Cupon
    },
    {
      path: '/categorias',
      name: 'categorias',
      component: Categoria
    },
    {
      path: '/carritoitems',
      name: 'carritoitems',
      component: CarritoItem
    }
  ]
})
