import React from 'react';
import SingleComplaint from './singleComplaint';
import AddComplaint from './AddComplaint';
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

    addNewComplaint = (newComplaint) => {
        complaintsData.addComplaint(newComplaint)
        .then(() => {
            this.PopulateComplaints();
        })
        .catch((err) => console.error(err));
    }

    componentDidMount() {
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
                <AddComplaint 
                addComplaint={this.addNewComplaint}
                />
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