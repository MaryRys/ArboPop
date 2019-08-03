import React from "react";
import { 
  BrowserRouter, Route, Switch, Redirect 
} from "react-router-dom";
import firebase from 'firebase/app';
import 'firebase/auth';
import connection from '../../Data/userData/connection';
import MyNavbar from '../MyNavbar/MyNavbar'
import Home from '../Home/Home';
import Register from '../Register/Register';
import Auth from '../Auth/Auth';
import authRequests from '../../Data/authData/authRequests';
import userRequests from '../../Data/userData/userRequests';

connection();

const PublicRoute = ({ component: Component, loginStatus, ...rest }) => {
  const routeChecker = props => (loginStatus === false
    ? (<Component { ...props }/>)
    : (<Redirect to={{ pathname: '/home', state: { from: props.location } } } />));
  return <Route {...rest} render={props => routeChecker(props)} />;
};

const PrivateRoute = ({ component: Component, loginStatus, ...rest }) => {
  const routeChecker = props => (loginStatus === true
    ? (<Component { ...props } />)
    : (<Redirect to={{ pathname: '/login', state: { from: props.location } } } />));
  return <Route {...rest} render={props => routeChecker(props)} />;
};

class App extends React.Component {

  state = {
    loginStatus: true,
    user: [],
  }

  getUser() {
    const uid = authRequests.getCurrentUid();
    userRequests.getSingleUser(uid)
      .then((user) => {
        this.setState({ user });
      })
      .catch(err => console.error('error getting User, err'));
  }
  
  componentDidMount() {
    connection();
    this.removeListener = firebase.auth().onAuthStateChanged((user) => {
      if (user) {
        this.setState({
          loginStatus: true
        });
      } else {
        this.setState({
          loginStatus: false,
        });
      }
    });
  }
  
  componentWillUnmount() {
    this.removeListener();
  }

  isAuthenticated = (username) => {
    this.setState({ loginStatus: true });
  }

  render(){
    return (
      <BrowserRouter>
      <MyNavbar />
      <React.Fragment>
        <Switch>
            <PublicRoute path='/login' exact component={Auth} loginStatus={this.state.loginStatus} isAuthenticated={this.isAuthenticated}/>
            <PublicRoute path='/register' exact component={Register} loginStatus={this.state.loginStatus}/>
            <PrivateRoute path='/home' exact component={Home} loginStatus={this.state.loginStatus}/>
        </Switch>
      </React.Fragment>
      </BrowserRouter>
    )
  }
}

export default App;