import React from 'react';
import { Link } from 'react-router-dom';
import { Button } from 'reactstrap';
import './Home.scss';

class Home extends React.Component {
    render(){
        return(
        <div className="Home">
            <h1>You are Home</h1>
            <Button color="primary">primary</Button>

        </div>
        )
    }
}

export default Home;