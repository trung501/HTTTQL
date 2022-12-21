import React from "react";
import { useEffect } from "react";

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

// get data
import axiosClient from "service/axiosClient";
function Accepted() {
  useEffect(()=>{
    async function getItem(){
      const res = await axiosClient.get('users/accepted')
      console.log(res)
    }
    getItem()
  },[])


  return (
    <>
      <Container fluid>
        <Row>
          <Col md="12">
            <Card className="strpied-tabled-with-hover">

              <Card.Body className="table-full-width table-responsive px-0">
                <Table className="table-hover table-striped">
                  <thead>
                    <tr>
                      <th className="border-0">ID</th>
                      <th className="border-0">Email</th>
                      <th className="border-0">Số rà soát đang chạy</th>
                      <th className="border-0">Số rà soát đã chạy</th>
                    </tr>
                  </thead>
                  <tbody>
                    <tr>
                    </tr>
                  </tbody>
                </Table>
              </Card.Body>
            </Card>
          </Col>
        </Row>
      </Container>
    </>
  );
}

export default Accepted;
