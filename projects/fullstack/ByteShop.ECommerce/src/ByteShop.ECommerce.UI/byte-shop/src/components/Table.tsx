import styles from './Table.module.css';

export function Table() {
    return (
        <table className={styles.table}>
            <thead>
                <tr>
                    <th><input type="checkbox" /></th>
                    <th>Name</th>
                    <th>Created At</th>
                    <th>Status</th>
                    <th>Action</th>
                </tr>
            </thead>

            <tbody>
                <tr>
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
                        <tr key={i}>
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