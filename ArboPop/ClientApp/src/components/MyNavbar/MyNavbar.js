import React from 'react';
import {
  Collapse,
  Navbar,
  NavbarToggler,
  NavbarBrand,
  Nav,
  NavItem,
  NavLink } from 'reactstrap';
import { NavLink as RRNavLink } from 'react-router-dom';

class MyNavbar extends React.Component {
  state = {
    isOpen: false
  };
  
  toggle() {
    this.setState({
      isOpen: !this.state.isOpen
    });
  }

  render() {
    return (
      <div>
        <Navbar color="light" light expand="md">
          <NavbarBrand href="/">ArboPop</NavbarBrand>
          <NavbarToggler onClick={this.toggle} />
          <Collapse isOpen={this.state.isOpen} navbar>
            <Nav className="ml-auto" navbar>
              <NavItem>
                <NavLink href="/reporting/">Reporting</NavLink>
              </NavItem>
              <NavItem>
                <NavLink href="/sample">Submit Sample</NavLink>
              </NavItem>
              <NavItem>
                <NavLink tag={RRNavLink} to="/mosquitoes">Mosquitopedia</NavLink>
              </NavItem>
            </Nav>
          </Collapse>
        </Navbar>
      </div>
    );
  }
}

export default MyNavbar;