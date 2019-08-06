import React from 'react';
import { Button, Form, FormGroup, Label, Input } from 'reactstrap';
import './addSample.scss';

class AddSample extends React.Component{
    state = {
        date: '',
        zipcode: '',
        numOfSpecies: '',
        totalNum: '',
        trapType: '',
        lure: '',
    }

    addSampleEvent = (e) => {
        e.preventDefault();
        const { addSample } = this.props;
        const mySample = {   date: this.state.date, 
                                zipcode: this.state.zipcode, 
                                numOfSpecies: this.state.numOfSpecies, 
                                totalNum: this.state.totalNum, 
                                trapType: this.state.trapType,
                                lure: this.state.lure }
        addSample(mySample);
    }

    render(){

        const getValue = (e) => {
            this.setState({ [e.target.id]: e.target.value} );
          }

        return(
            <div className="sampleFormContainer">
                <div className="container">
                    <Form>
                        <FormGroup>
                        <Label>Biting source</Label>
                        <Input  id="date" placeholder="2019-08-05" onChange={getValue}/>
                        </FormGroup>
                        <FormGroup>
                        <Label>Zipcode</Label>
                        <Input id="zipcode" placeholder="37200" onChange={getValue}/>
                        </FormGroup>
                        <FormGroup>
                        <Label>Number of species</Label>
                        <Input  id="numOfSpecies" placeholder="1" onChange={getValue}/>
                        </FormGroup>
                        <FormGroup>
                        <Label>Total number of mosquitoes</Label>
                        <Input  id="totalNum" placeholder="20" onChange={getValue}/>
                        </FormGroup>
                        <FormGroup>
                        <Label>Trap type</Label>
                        <Input  id="trapType" placeholder="gavid" onChange={getValue}/>
                        </FormGroup>
                        <FormGroup>
                        <Label>Lure used</Label>
                        <Input  id="lure" placeholder="water" onChange={getValue}/>
                        </FormGroup>
                        <Button onClick={this.addSampleEvent}>Submit</Button>
                    </Form>
                </div>
            </div>
        )
    }
}

export default AddSample;