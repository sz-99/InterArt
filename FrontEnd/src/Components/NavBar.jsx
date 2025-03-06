import React from "react";
import { Navbar, Nav, Container } from "react-bootstrap"; 
import logo from "../assets/InterArtLogo.png";

const NavigationBar = () => {
    return(
        <Navbar bg="primary" variant="dark" expand="lg">
            <Container>
                <Navbar.Brand href="/">
                <img src={logo} alt="InterArt Logo" width="40" height="30" className="d-inline-block align-top"/>
                {" "}
                </Navbar.Brand>

                <Navbar.Toggle aria-controls="basic-navbar-nav" />
                <Navbar.Collapse id="basic-navbar-nav">
                    <Nav className="ms-auto">
                        <Nav.Link href="/">Home</Nav.Link>
                        <Nav.Link href="/gallery">Gallery</Nav.Link>
                        <Nav.Link href="/about">About</Nav.Link>
                        <Nav.Link href="/login">Login</Nav.Link>
                    </Nav>
                </Navbar.Collapse>
            </Container>
        </Navbar>

    );
};
export default NavigationBar;