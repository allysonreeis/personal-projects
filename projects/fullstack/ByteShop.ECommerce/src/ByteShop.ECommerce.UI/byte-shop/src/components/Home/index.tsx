import styles from './styles.module.css'

export function Home() {
  return (
    <section className={styles.home}>
      <nav>
        <div>
          <img
            src="/src/assets/Dribbble_logo_perple.png"
            alt="logo"
            className={styles.logo}
          />
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
        <input type="text" placeholder="Busque aqui" />
        <button>Login</button>
        <button>Sign Up</button>
      </nav>
    </section>
  )
}
