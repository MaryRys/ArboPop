import React from 'react';
import { Card, CardText, CardBody,
    CardTitle, CardSubtitle } from 'reactstrap';

class singleSample extends React.Component{

    render(){
        const { sample } = this.props;

        return(
            <div>
                <Card>
                    <CardBody>
                    <CardTitle>Date: {sample.date}</CardTitle>
                    <CardSubtitle>Zipcode: {sample.zipcode}</CardSubtitle>
                    <CardText>Total caught: {sample.totalNum}</CardText>
                    <CardText>Number of species: {sample.numOfSpecies}</CardText>
                    <CardText>Trap type: {sample.trapType}</CardText>
                    <CardText>Lure: {sample.lure}</CardText>
                    {/* <Button>Button</Button> */}
                    </CardBody>
                </Card>
            </div>
        )
    }
}

export default singleSample;