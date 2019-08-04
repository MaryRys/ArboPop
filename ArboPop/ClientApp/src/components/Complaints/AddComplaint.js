import React from 'react';
import { Button, Form, FormGroup, Label, Input, FormText } from 'reactstrap';
import './AddComplaint.scss';

class AddComplaint extends React.Component{
    state = {
        creationDate: '',
        biteInput: '',
        zipInput: '',
        timeInput: '',
        notesInput: '',
        fileInput: '',
    }

    render(){

        const getValue = (e) => {
            this.setState({ [e.target.id]: e.target.value} );
          }

        return(
            <div className="complaintFormContainer">
                <div className="container">
                    <Form>
                        <FormGroup>
                        <Label>Biting Source</Label>
                        <Input  id="biteInput" placeholder="Watering hole" onChange={getValue}/>
                        </FormGroup>
                        <FormGroup>
                        <Label>Zipcode</Label>
                        <Input id="zipInput" placeholder="37200" onChange={getValue}/>
                        </FormGroup>
                        <FormGroup>
                        <Label for="exampleSelect">Time of Day</Label>
                        <Input type="select" name="timeInput" id="timeInput" onChange={getValue}>
                            <option>Early morning</option>
                            <option>Afternoon</option>
                            <option>Evening</option>
                            <option>Night time</option>
                        </Input>
                        </FormGroup>
                        <FormGroup>
                        <Label for="exampleText">Additional Notes</Label>
                        <Input type="textarea" name="notesInput" id="notesInput" onChange={getValue}/>
                        </FormGroup>
                        <FormGroup>
                        <Label for="exampleFile">File</Label>
                        <Input type="file" name="fileInput" id="fileInput" onChange={getValue}/>
                        <FormText color="muted">
                            Upload an image or other file to give more information on the problem (optional).
                        </FormText>
                        </FormGroup>
                        <Button>Submit</Button>
                    </Form>
                </div>
            </div>
        )
    }
}

export default AddComplaint;