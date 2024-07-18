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
            <button>
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
      </section>
    </div>
  )
}
