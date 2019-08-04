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
import Mosquito from '../Mosquitopedia/Mosquito';
import Complaint from '../Complaints/Complaints';
import authRequests from '../../Data/authData/authRequests';
import userRequests from '../../Data/userData/userRequests';

connection();

const PublicRoute = ({ component: Component, loginStatus, ...rest }) => {
  const routeChecker = props => (loginStatus === false
    ? (<Component { ...props } {...rest}/>)
    : (<Redirect to={{ pathname: '/home', state: { from: props.location } } } />));
  return <Route render={props => routeChecker(props)} />;
  };

const PrivateRoute = ({ component: Component, loginStatus, ...rest }) => {
  const routeChecker = props => (loginStatus === true
    ? (<Component { ...props } {...rest} />)
    : (<Redirect to={{ pathname: '/login', state: { from: props.location } } } />));
  return <Route render={props => routeChecker(props)} />;
};

class App extends React.Component {

  state = {
    loginStatus: true,
    user: [],
    currentPath: window.location.pathname 
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
            <PublicRoute path='/login' exact component={Auth} currentPath={this.state.currentPath} loginStatus={this.state.loginStatus} isAuthenticated={this.isAuthenticated}/>
            <PublicRoute path='/register' exact component={Register} currentPath={this.state.currentPath} loginStatus={this.state.loginStatus}/>
            <PrivateRoute path='/mosquitoes' component={Mosquito} currentPath={this.state.currentPath} loginStatus={true}/>
            <PrivateRoute path='/home' exact component={Home} loginStatus={this.state.loginStatus}/>
            <PrivateRoute path='/reporting' component={Complaint} loginStatus={this.state.loginStatus}/>
        </Switch>
      </React.Fragment>
      </BrowserRouter>
    )
  }
}

export default App;