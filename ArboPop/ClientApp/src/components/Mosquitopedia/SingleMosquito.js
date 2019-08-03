import React from 'react';
// import './SingleMosquito.scss';

class SingleMosquito extends React.Component {
  render() {
    const { mosquito } = this.props;
    return (
      <div className="MosquitoItem">
        <div className="container">
          <div className="row">
                <h4>{mosquito.commonName}</h4>
                <h4>{mosquito.scientificName}</h4>
                <p>{mosquito.breedingHabitat}</p>
                <p>{mosquito.confirmed}</p>
          </div>
        </div>
      </div>
    );
  }
}

export default SingleMosquito;