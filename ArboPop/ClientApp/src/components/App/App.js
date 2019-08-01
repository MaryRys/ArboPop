import React from "react";
import { BrowserRouter, Route, Switch, Redirect } from "react-router-dom";
import MyNavbar from '../MyNavbar/MyNavbar'
import Home from '../Home/Home';

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
    // pendingUser: true,
  }
  
  componentDidMount() {
  //   connection();
  //   this.removeListener = firebase.auth().onAuthStateChanged((user) => {
  //     if (user) {
  //       this.setState({
  //         loginStatus: true,
  //         pendingUser: false,
  //       });
  //     } else {
  //       this.setState({
  //         loginStatus: false,
  //         pendingUser: false,
  //       });
  //     }
  //   });
  }
  
  componentWillUnmount() {
    this.removeListener();
  }

  render(){
    return (
      <BrowserRouter>
      <MyNavbar />
      <React.Fragment>
        <Switch>
            <PrivateRoute path='/' exact component={Home} loginStatus={this.state.loginStatus}/>
            <PrivateRoute path='/home' exact component={Home} loginStatus={this.state.loginStatus}/>
            <PublicRoute path='/' exact component={Home} loginStatus={this.state.loginStatus}/>
        </Switch>
      </React.Fragment>
      </BrowserRouter>
    )
  }
}

export default App;