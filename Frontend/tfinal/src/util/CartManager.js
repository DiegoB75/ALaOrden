export default class CartManager {

    static addToCart(cart, producto, cantidad) {
      if (!cart.isEmpty) {
        let item = cart.find(x => x.idProducto === producto.idProducto);
        if (typeof item === 'undefined') {
          cart.push({idProducto: producto.idProducto, producto, cantidad});
        } else {
          item.cantidad += cantidad;
        }
      }
      else{
        cart.push({idProducto: producto.idProducto, producto, cantidad});
      }
      return [...cart];
    }
  
    static removeFromCart(cart, idProducto) {
      return cart.filter(x => x.idProducto !== idProducto);
    }
  
    static updateCart(cart, idProducto, cantidad) {
      let item = cart.find(x => x.idProducto === idProducto);
      item.cantidad = cantidad;
      return cart;
    }
  }