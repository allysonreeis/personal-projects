import style from './NavBar.module.css';
export function NavBar() {
    return (
        <nav className={style.navbar}>
            <ul>
                <li>Home</li>
                <li>About</li>
            </ul>
        </nav>
    );
}