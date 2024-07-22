import styles from './styles.module.css'
import { ShoppingCart } from '@phosphor-icons/react'
import logo from '../../assets/logo.svg'

export function Home() {
  return (
    <div className={styles.maincontainer}>
      <section className={styles.home}>
        <nav>
          <div className={styles.navlinks}>
            <img src={logo} alt="logo" className={styles.logo} />
            <ul>
              <li>
                <a href="#">Home</a>
              </li>
              <li>
                <a href="#">Shop</a>
              </li>
              <li>
                <a href="#">About</a>
              </li>
              <li>
                <a href="#">Contact</a>
              </li>
            </ul>
          </div>

          <div className={styles.navbuttons}>
            <input type="text" placeholder="Busque aqui" />
            <button className={styles.cart}>
              <ShoppingCart size={20} />
            </button>
            <button
              title="Login access your account"
              className={styles['button-transparent']}
            >
              Login
            </button>
            <button
              title="Create your account"
              className={styles['button-solid']}
            >
              Sign Up
            </button>
          </div>
        </nav>

        <div className={styles.banner}>
          <div className={styles['banner-text']}>
            <h1>Shop with us</h1>
            <p>Get the best products at the best prices</p>
            <button className={styles['button-solid']}>Shop Now</button>
          </div>
          <div className={styles['banner-image']}>
            <img
              src="https://plus.unsplash.com/premium_photo-1661304671477-37c77d0c6930?q=80&w=1770&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D"
              alt="banner"
            />
          </div>
        </div>
      </section>
    </div>
  )
}
