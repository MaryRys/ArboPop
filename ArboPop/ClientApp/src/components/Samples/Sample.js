import React from 'react';
import samplesData from '../../Data/samplesData/samplesData';
import SingleSample from './singleSample';

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
                <h1>Samples</h1>
                {sampleComponents}
            </div>
        )
    }
}

export default Sample;