import styles from './styles.module.css'

export function ProductCard() {
  return (
    <div className={styles.productcard}>
      <div className={styles['product-image']}>
        <img
          src="https://plus.unsplash.com/premium_photo-1661304671477-37c77d0c6930?q=80&w=1770&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D"
          alt="product"
        />
      </div>
      <div className={styles['product-info']}>
        <h3>Product Name</h3>
        <p>Product Description</p>
        <div className={styles['product-price']}>
          <span>$100</span>
          <button className={styles['button-solid']}>Add to Cart</button>
        </div>
      </div>
    </div>
  )
}
