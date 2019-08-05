import React from 'react';
import { Card, CardText, CardBody, Row,
    CardTitle, CardSubtitle, Col } from 'reactstrap';

class SingleComplaint extends React.Component {
  render() {
    const { complaint } = this.props;
    return (
        <div>
        <Row>
        <Col sm="6">
        <Card>
          <CardBody>
            <CardTitle>{complaint.bitingSource}</CardTitle>
            <CardSubtitle>{complaint.zipcode}</CardSubtitle>
          </CardBody>
          <img width="100%" src="https://placeholdit.imgix.net/~text?txtsize=33&txt=318%C3%97180&w=318&h=180" alt="Card image cap" />
          <CardBody>
            <CardText>{complaint.notes}</CardText>
          </CardBody>
        </Card>
        </Col>
        </Row>
      </div>
    );
  }
}

export default SingleComplaint;