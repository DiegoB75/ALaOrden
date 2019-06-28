export default class CartManager {

    static addToCart(cart, product, quantity) {
      if (!cart.isEmpty) {
        let item = cart.find(x => x.idProduct === product.idProduct);
        if (typeof item === 'undefined') {
          cart.push({idProduct: product.idProduct, product, quantity});
        } else {
          item.quantity += quantity;
        }
      }
      else{
        cart.push({idProduct: product.idProduct, product, quantity});
      }
      return [...cart];
    }
  
    static removeFromCart(cart, idProduct) {
      return cart.filter(x => x.idProduct !== idProduct);
    }
  
    static updateCart(cart, idProduct, quantity) {
      let item = cart.find(x => x.idProduct === idProduct);
      item.quantity = quantity;
      return cart;
    }
  }