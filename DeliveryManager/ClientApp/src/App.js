import React, { Component } from 'react';
import { Route } from 'react-router';
import { Layout } from './components/Layout';
import { Home } from './components/Home';
import { FetchCardapio } from './components/FetchCardapio';
import { FetchClient } from './components/FetchClient';
import { AddClient } from './components/AddClient';

export default class App extends Component {
  displayName = App.name

  render() {
    return (
      <Layout>
        <Route exact path='/' component={Home} />
        <Route path='/fetchclient' component={FetchClient} />
        <Route path='/fetchcardapio' component={FetchCardapio} />
        <Route path='/addclient' component={AddClient} />
        <Route path='/Clientes/Edit/:clientId' component={AddClient} />
      </Layout>
    );
  }
}
