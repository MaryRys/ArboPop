import React from 'react';
import {Button} from 'reactstrap';
import authRequests from '../../Data/authData/authRequests';

const defaultUser = {
    email: 'email@example.com',
    password: '*******',
  };

class Auth extends React.Component{
        state = {
          newUser: defaultUser,
        }
      
        formFieldStringState = (name, e) => {
          e.preventDefault();
          const tempUser = { ...this.state.newUser };
          tempUser[name] = e.target.value;
          this.setState({ newUser: tempUser });
        }
      
        emailChange = e => this.formFieldStringState('email', e);
      
        passwordChange = e => this.formFieldStringState('password', e);
      
        loginUser = (e) => {
          const { newUser } = this.state;
          e.preventDefault();
          authRequests.loginUser(newUser).then(() => {
            this.props.isAuthenticated();
          }).catch(err => console.error('error in auth', err));
        }

    render(){
        const { newUser } = this.state;
        return (
            <div className='Auth'>
              <div className="col-4 offset-4">
                <form>
                  <div className="form-group">
                    <label htmlFor="email">Email:</label>
                    <input
                      type="text"
                      className="form-control"
                      id="email"
                      aria-describedby="titleHelp"
                      value={newUser.email}
                      onChange={this.emailChange}
                    />
                  </div>
                  <div className="form-group">
                    <label htmlFor="password">Password:</label>
                    <input
                      type="password"
                      className="form-control"
                      id="password"
                      aria-describedby="passwordHelp"
                      value={newUser.password}
                      onChange={this.passwordChange}
                    />
                    <Button onClick={this.loginUser}>Log in</Button>
                  </div>
                </form>
               </div>
            </div>
    )};

}

export default Auth;