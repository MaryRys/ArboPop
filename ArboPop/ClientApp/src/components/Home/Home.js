import React from 'react';
import { Button } from 'reactstrap';
import 'firebase/auth';
import firebase from 'firebase/app';
import './Home.scss';

class Home extends React.Component {
    logOut = () => {
        firebase.auth().signOut();
    }
    
    render() {
    return(<div>
        You're home
        <Button onClick={this.logOut}>Log out</Button>
    </div>);
    }
}

export default Home;