import styles from './styles.module.css'

export function Home() {
  return (
    <div className={styles.maincontainer}>
      <section className={styles.home}>
        <nav>
          <div className={styles.navlinks}>
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

          <div className={styles.navbuttons}>
            <input type="text" placeholder="Busque aqui" />
            <button className={styles['button-transparent']}>Login</button>
            <button className={styles['button-solid']}>Sign Up</button>
          </div>
        </nav>
      </section>
    </div>
  )
}
