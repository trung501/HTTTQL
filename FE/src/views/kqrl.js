import React, { useState } from "react";
import { useEffect } from "react";
import axiosClient from "service/axiosClient";
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
import { data } from "jquery";

function TableListUser() {
  const [listUsers, setlistUsers] = useState([]);
  useEffect(() => {
    async function getItem() {
      const res = await axiosClient.get("/users/list");
      //console.log(res.data.items);
      setlistUsers((listUsers) => [...res.data.items, ...listUsers]);
     
    }
    getItem();
  }, []);
 
  console.log(listUsers);
  return (
    <>
      <Container fluid>
        <Row>
          <Col md="12">
            <Card className="strpied-tabled-with-hover">
              <Card.Header>
                <Card.Title as="h4">Danh sách người dùng quản trị</Card.Title>
                <p className="card-category">
                 Thông tin 
                </p>
              </Card.Header>
              <Card.Body className="table-full-width table-responsive px-0">
                <Table className="table-hover table-striped">
                  <thead>
                    <tr>
                      <th className="border-0">ID</th>
                      <th className="border-0">Email</th>
                      <th className="border-0">is_accepted</th>
                      <th className="border-0">running</th>
                      <th className="border-0">finished</th>
                      <th className="border-0">total_alert</th>
                      <th className="border-0">total_scan</th>
                    </tr>
                  </thead>
                  <tbody>
                    {listUsers &&
                      listUsers.map((item) => {
                        return (
                          <tr key={item.id}>
                            <td>{item.id}</td>
                            <td>{item.email}</td>
                            <td>{String(item.is_accepted)}</td>
                            <td>{item.running}</td>
                            <td>{item.finished}</td>
                            <td>{item.total_scan}</td>
                            <td>{item.total_alert}</td>
                          </tr>
                        );
                      })}
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

export default TableListUser;
