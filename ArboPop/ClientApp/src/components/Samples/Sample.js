import React from 'react';
import samplesData from '../../Data/samplesData/samplesData';
import SingleSample from './singleSample';
import AddSample from './AddSample';
import './Sample.scss';

class Sample extends React.Component{
    state = {
        samples: []
    }

    populateSamples = () => {
        samplesData.getAllSamples()
        .then((res) => {
            var samples = res.data;
            this.setState({ samples });
        })
        .catch((err) => console.error(err));
    }

    addNewSample = (newSample) => {
        samplesData.addSample(newSample)
        .then(() => {
            this.populateSamples();
        })
        .catch((err) => console.error(err));
    }

    componentDidMount(){
        this.populateSamples();
    }

    render(){
        const { samples } = this.state;
        const sampleComponents = samples.map(sample => (
            <SingleSample
            sample={sample}
            key={sample.id}/>));

        return(
            <div className="samplesContainer">
                <div className="row">
                    <AddSample 
                    addSample={this.addNewSample}/>
                    <div>
                        <h1>Samples</h1>
                        <div className="allSamples">
                        {sampleComponents}
                        </div>
                    </div>
                </div>
            </div>
        )
    }
}

export default Sample;