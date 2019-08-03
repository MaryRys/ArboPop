import React from 'react';
import SingleMosquito from './SingleMosquito';
import mosquitoData from '../../Data/MosquitoData/mosquitoData';

class Mosquito extends React.Component{
    state = {
        mosquitoes: [],
    }

    populateMosquitoes = () => {
        mosquitoData.getAllMosquitoes()
        .then((res) => {
            var mosquitoes = res.data;
            this.setState({ mosquitoes });
        })
        .catch((err) => console.error(err));
    }

    componentDidMount(){
        this.populateMosquitoes();
    }

    render() {
        const { mosquitoes } = this.state;
        const mosquitoesComponents = mosquitoes.map(mosquito => (
            <SingleMosquito 
            mosquito={mosquito}
            key={mosquito.id}/>));

            return(
            <div className="mosquitoContainer">
                { mosquitoesComponents }
            </div>
        )
            
        
    }
}

export default Mosquito;