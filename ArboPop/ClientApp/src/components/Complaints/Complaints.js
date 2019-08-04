import React from 'react';
import { Button, Form, FormGroup, Label, Input, FormText } from 'reactstrap';
import SingleComplaint from './singleComplaint';
import complaintsData from '../../Data/complaintsData/complaintsData';
import './Complaints.scss'

class Complaint extends React.Component{
    state = {
        complaints: [],
    }

    populateComplaints = () => {
        complaintsData.getAllComplaints()
        .then((res) => {
            var complaints = res.data;
            this.setState({ complaints });
        })
        .catch((err) => console.error(err));
    }

    componentDidMount(){
        this.populateComplaints();
    }

    render() {
        const { complaints } = this.state;

        const complaintsComponents = complaints.map(complaint => (
            <SingleComplaint
            complaint={complaint}
            key={complaint.id}/>));

            return(
            <div>
                <div className="complaintFormContainer">
                    <div className="container">
                    <Form>
                        <FormGroup>
                        <Label>Biting Source</Label>
                        <Input  id="biteInput" placeholder="Watering hole" />
                        </FormGroup>
                        <FormGroup>
                        <Label>Zipcode</Label>
                        <Input id="zipInput" placeholder="37200" />
                        </FormGroup>
                        <FormGroup>
                        <Label for="exampleSelect">Time of Day</Label>
                        <Input type="select" name="select" id="timeInput">
                            <option>Early morning</option>
                            <option>Afternoon</option>
                            <option>Evening</option>
                            <option>Night time</option>
                        </Input>
                        </FormGroup>
                        <FormGroup>
                        <Label for="exampleText">Additional Notes</Label>
                        <Input type="textarea" name="text" id="exampleText" />
                        </FormGroup>
                        <FormGroup>
                        <Label for="exampleFile">File</Label>
                        <Input type="file" name="file" id="exampleFile" />
                        <FormText color="muted">
                            This is some placeholder block-level help text for the above input.
                            It's a bit lighter and easily wraps to a new line.
                        </FormText>
                        </FormGroup>
                        <Button>Submit</Button>
                    </Form>
                    </div>
                </div>
                <div className="complaintsContainer">
                    <div className="container">
                    <h1>All Reports</h1>
                    { complaintsComponents }
                    </div>
                </div>
            </div>
        )
            
        
    }
}

export default Complaint;