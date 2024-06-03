import { NavBar } from "@/components/NavBar";
import { Table } from "@/components/Table";

export default function Category() {
    return (
        <div>
            <NavBar />
            <h1>Categories</h1>
            <p>View all your Categories or Create a new one</p>
            <Table />
        </div>
    );
}