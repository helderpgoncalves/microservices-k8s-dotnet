import {
  Navbar,
  NavDropdown,
  Nav,
  Button,
  Form,
  FormControl,
  Offcanvas,
  Container,
} from "react-bootstrap";

function NavbarComponent() {
  return (
    <Navbar bg="dark" expand={false} sticky variant="dark">
      <Container fluid>
        <Navbar.Brand href="#">Trabalho Prático</Navbar.Brand>
        <Navbar.Toggle aria-controls="offcanvasNavbar" />
        <Navbar.Offcanvas
          id="offcanvasNavbar"
          aria-labelledby="offcanvasNavbarLabel"
          placement="start"
        >
          <Offcanvas.Header closeButton>
            <Offcanvas.Title id="offcanvasNavbarLabel">Menu</Offcanvas.Title>
          </Offcanvas.Header>
          <Offcanvas.Body>
            <Nav className="justify-content-end flex-grow-1 pe-3">
              <Nav.Link href="#">Home</Nav.Link>
              <Nav.Link href="#produtos">Produtos</Nav.Link>
              <Nav.Link href="#users">Users</Nav.Link>
            </Nav>
          </Offcanvas.Body>
        </Navbar.Offcanvas>
      </Container>
    </Navbar>
  );
}

export default NavbarComponent;
