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
            <img src="https://d17fnq9dkz9hgj.cloudfront.net/uploads/2013/09/cat-black-superstitious-fcs-cat-myths-162286659.jpg"></img>

        </div>
        )
    }
}

export default Home;