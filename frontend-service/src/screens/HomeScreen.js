import React from "react";
import NavbarComponent from "../components/Navbar";
import Tutorial from "../components/Tutorial";
import Produtos from "../components/Produtos";
import Users from "../components/Users";

const HomeScreen = () => {
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
};

export default HomeScreen;
