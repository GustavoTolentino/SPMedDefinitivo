import React from 'react';
import ReactDOM from 'react-dom';
import Login from './pages/login/Login';
import Consulta from './pages/consulta/Consulta';
import './index.css';
import App from './App';
import reportWebVitals from './reportWebVitals';
import { BrowserRouter as Router, Switch, Route, Redirect } from "react-router-dom";

export const routing = (
  <Router>
    <Switch>
      <Route exact path="/" component={Login} />
      <Route exact path="/Consulta" component={Consulta} />
      <Route exact path="*" component={Login} />
    </Switch>
  </Router>
)

ReactDOM.render(
  routing,
  document.getElementById('root')
);
