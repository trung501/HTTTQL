import React from "react";
import ChartistGraph from "react-chartist";

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
  Form,
  OverlayTrigger,
  Tooltip,
} from "react-bootstrap";

function Dashboard() {
  return (
    <>
      <Container fluid>
      <Row>
          <Col md="12">
            <Card>
              <Card.Header>
                <Card.Title as="h4">Phần mềm quản lý vào ra cho học viên của Học viện Kỹ thuật Quân sự</Card.Title>
              </Card.Header>
              <Card.Body>
                  
                <div className="typography-line">
                  <p>
                    Theo khảo sát việc đăng ký ra vào bằng sổ sách có hiệu quả không cao, khả năng đối chiếu thông tin thấp, dễ xảy ra sai phạm và khó quản lý.
                  </p>
                  <p>Phần mềm quản lý vào ra cho học viên giúp khắc phục những nhược điểm còn tồn tại theo cách quản lý thủ công. Những ưu điểm của hệ thông bao gồm:</p>
                </div>
               
              </Card.Body>
            </Card>
          </Col>
        </Row>
      </Container>
    </>
  );
}

export default Dashboard;
