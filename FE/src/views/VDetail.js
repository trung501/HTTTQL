import React from "react"
import { useState } from "react"
import { useEffect } from "react";
import axiosClient from "service/axiosClient";

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

const Detail = ({data})=>{
    console.log(data)
    const [detail,setDetail] = useState([])
    React.useEffect(()=>{
        async function getDetail(){
            console.log(data)
            const url = `vulnerabilities/${data}`
            const res = await axiosClient.get(url)
            console.log(res)
            setDetail((detail) => [...res.data.items]);
        }
        getDetail();
    },[data])
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
export default Detail