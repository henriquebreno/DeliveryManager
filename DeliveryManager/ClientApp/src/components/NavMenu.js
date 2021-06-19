import React, { Component } from 'react';
import { Link,NavLink } from 'react-router-dom';
import { Glyphicon, Nav, Navbar, NavItem } from 'react-bootstrap';
import { LinkContainer } from 'react-router-bootstrap';
import '../css/NavMenu.css';
import Logo from '../img/logo-icon.png';
import "@fontsource/port-lligat-sans";	
import { Speedometer2, PersonLinesFill, List, HouseFill} from 'react-bootstrap-icons';

export class NavMenu extends Component {
  displayName = NavMenu.name


render() {
    return (
		<aside class="app-sidebar" id="sidebar">
			<div class="sidebar-header">
				<a class="sidebar-brand" href="">
					<img src={Logo} alt="app logo" />
				</a>

				<span className="logo-name">DeliveryManager</span>
				<button type="button" class="sidebar-toggle"> <i class="fa fa-times"></i> </button>
			</div>
			<div class="sidebar-menu">
				<ul class="sidebar-nav">
					<li class="" >
						<NavLink to={'/dashboard'} activeClassName="active">
							<div class="icon"> <Speedometer2 className="fa"/> </div>
							<div class="title">Dashboard</div>
						</NavLink>						
					</li>
					<li class="">
						<NavLink to={'/'} exact activeClassName="active">
							<div class="icon"> <HouseFill className="fa" /> </div>
							<div class="title">Home</div>
						</NavLink>		
					</li>

					<li class="">
						<NavLink  to="/fetchclient" activeClassName="active">
							<div class="icon"><PersonLinesFill className="fa" /> </div>							
							<div class="title">Clientes</div>
						</NavLink>						
					</li>
					<li className="">
						<NavLink to="/fetchcardapio" activeClassName="active">
							<div class="icon"> <List className="fa"/></div>
							<div class="title">Cardápio</div>
						</NavLink>
					</li>


				</ul>
			</div>
		</aside>
    );
  }
}
