import styles from './Table.module.css';

export function Table() {
    return (
        <table className={styles.table}>
            <thead>
                <tr className={styles.rowShadow}>
                    <th><input type="checkbox" /></th>
                    <th><button>Name</button></th>
                    <th><button>Created At</button></th>
                    <th><button>Status</button></th>
                    <th>Action</th>
                </tr>
            </thead>

            <tbody>
                <tr className={styles.rowShadow}>
                    <td><input type="checkbox" /></td>
                    <td>Eletronics</td>
                    <td>2021-10-10</td>
                    <td>Active</td>
                    <td>
                        <button>Edit</button>
                        <button>Delete</button>
                    </td>
                </tr>
                {
                    [...Array(10)].map((_, i) => (
                        <tr className={styles.rowShadow} key={i}>
                            <td><input type="checkbox" /></td>
                            <td>Eletronics</td>
                            <td>2021-10-10</td>
                            <td>Active</td>
                            <td>
                                <button>Edit</button>
                                <button>Delete</button>
                            </td>
                        </tr>
                    ))
                }
            </tbody>
        </table>
    );
}