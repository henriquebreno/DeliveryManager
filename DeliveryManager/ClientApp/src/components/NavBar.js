import React, { Component } from 'react';
import { Link,NavLink } from 'react-router-dom';
import { Glyphicon, Nav, Navbar, NavItem } from 'react-bootstrap';
import { LinkContainer } from 'react-router-bootstrap';
import '../css/NavBar.css'
import Logo from '../img/logo-icon.png';
import "@fontsource/port-lligat-sans";	
import { Speedometer2, PersonLinesFill, List, HouseFill} from 'react-bootstrap-icons';

export class NavBar extends Component {
    displayName = NavBar.name


render() {
    return (
            <nav class="navbar navbar-default" id="navbar">
                <div class="container-fluid">
                    <div class="navbar-collapse collapse in">
                        <ul class="nav navbar-nav navbar-mobile">
                            <li>
                                <button type="button" class="sidebar-toggle"> <i class="fa fa-bars"></i> </button>
                            </li>
                            <li class="logo"> <a class="navbar-brand" href="#">Viavi Restaurant System</a></li>
                            <li>
                                <button type="button" class="navbar-toggle">

                                    <img class="profile-img" src="http://viavilab.com/codecanyon/restaurant_script_demo/images/profile.png" />
                                </button>
                            </li>
                        </ul>
                        <ul class="nav navbar-nav navbar-left">
                            <li class="navbar-title">DeliveryManager</li>
                        </ul>

                        <ul class="nav navbar-nav navbar-right">
                            <a href="http://viavilab.com/codecanyon/restaurant_script_demo/" target="_blank"  ><i class="fa fa-desktop" ></i> Visit Website</a>

                            <li class="dropdown profile"> <a href="#" class="dropdown-toggle" data-toggle="dropdown">

                                <img class="profile-img" src="http://viavilab.com/codecanyon/restaurant_script_demo/images/profile.png" />

                                <div class="title">Profile</div>
                            </a>
                                <div class="dropdown-menu">
                                    <div class="profile-info">
                                        <h4 class="username">Admin</h4>
                                    </div>
                                    <ul class="action">
                                        <li><a href="http://viavilab.com/codecanyon/restaurant_script_demo/admin/profile">Profile</a></li>
                                        <li><a href="http://viavilab.com/codecanyon/restaurant_script_demo/admin/logout" class="btn_logout btn_top_action">Logout</a></li>
                                    </ul>
                                </div>
                            </li>
                        </ul>

                    </div>
                </div>
            </nav>
    );
  }
}
