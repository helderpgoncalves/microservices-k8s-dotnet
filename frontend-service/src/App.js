import NavbarComponent from "./components/Navbar";
import Produtos from "./components/Produtos";
import Users from "./components/Users";
import Tutorial from "./components/Tutorial";
function App() {
  return (
    <>
      <NavbarComponent />
      <Tutorial />
      <section id="produtos">
        <Produtos />
      </section>
      <section id="users">
        <Users />
      </section>
    </>
  );
}

export default App;
