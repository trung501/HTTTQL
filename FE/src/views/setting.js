import React from "react";
import "../assets/css/switch.css"

// react-bootstrap components
import {
  Badge,
  Button,
  Card,
  Navbar,
  Nav,
  Table,
  Container,
  Row,
  Col,
} from "react-bootstrap";

function Setting() {
  return (
    <>
      <Container fluid>
        <Row>
          <Col md="12">
            <Card className="strpied-tabled-with-hover">

              <Card.Body className="table-full-width table-responsive px-0">
              <div>
              <label className="switch">
              <input type="checkbox" />
              <span className="slider round"></span>
              </label>
              <label><p className="acunetix">Acunetix</p></label>
              </div>

              <div>
              <label className="switch">
              <input type="checkbox" />
              <span className="slider round"></span>
              
              </label>
              <label><p className="nuclei">Nuclei</p></label>
              </div>
              
              
              

              </Card.Body>
            </Card>
          </Col>
        </Row>
      </Container>
    </>
  );
}

export default Setting;
