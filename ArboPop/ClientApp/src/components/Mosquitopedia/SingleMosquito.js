import React from 'react';
import { Card, CardImg, CardText, CardBody,
    CardTitle, CardSubtitle, Button, Row, Col } from 'reactstrap';
// import './SingleMosquito.scss';

class SingleMosquito extends React.Component {
  render() {
    const { mosquito } = this.props;
    return (
      <div className="MosquitoItem">
          <div>
            <Row>
                <Card>
                    <Col sm="6">
                        <CardImg top width="100%" src="https://imagesvc.meredithcorp.io/v3/mm/image?url=https%3A%2F%2Fpeopledotcom.files.wordpress.com%2F2018%2F10%2Fbug.jpg&w=400&c=sc&poi=face&q=85" alt="Card image cap" />
                        <CardBody>
                        <CardTitle>{mosquito.scientificName}</CardTitle>
                        <CardSubtitle>{mosquito.commonName}</CardSubtitle>
                        <CardText>{mosquito.breedingHabitat}</CardText>
                        <CardText>{mosquito.confirmed}</CardText>
                        <Button>Learn More</Button>
                        </CardBody>
                    </Col>
                </Card>
            </Row>
        </div>
      </div>
    );
  }
}

export default SingleMosquito;