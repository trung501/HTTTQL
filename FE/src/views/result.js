import React, { useState } from "react";
import "../assets/css/switch.css"
import "../assets/css/btn_vul.css"
import { useEffect } from "react";
import axiosClient from "service/axiosClient";
import {Link,useLocation} from 'react-router-dom'
import queryString from 'query-string'

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
  Alert,
} from "react-bootstrap";

function Result() {
  const { search } = useLocation();
  console.log(search);
  const values = queryString.parse(search)
  console.log(values);
  console.log(values.target_id);
  const [listResults, setlistResults] = useState([]);
  const [id,setId] = useState()
  const [ref,setref] = useState()

  useEffect(() => {
    async function getItem() {
      const url = values.target_id ? `targets/${values.target_id}/scans`:"scans"
      const res = await axiosClient.get(url);

      console.log(res.data.items);
      setlistResults((listResults) => [...res.data.items]);
      console.log(listResults);
    }
    getItem();
  }, [values.target_id]);
  async function getReport(id){
    setId(id)
    const res = await axiosClient.get(`scans/${id}/report`,{
      headers:
      {
          'Content-Disposition': "attachment; filename=report.docx",
          'Content-Type': 'application/vnd.openxmlformats-officedocument.spreadsheetml.sheet'
      },
      responseType: 'arraybuffer',
    })
    const path = window.URL.createObjectURL(new Blob([res.data]));
    const link = document.createElement('a');
    link.href = path;
    link.setAttribute('download', 'report.docx'); //or any other extension
    document.body.appendChild(link);
    link.click();
   }
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
                      <th className="border-0">Tên miền</th>
                      <th className="border-0">Trạng thái</th>
                      <th className="border-0">Thời gian</th>
                      <th className="border-0">Kết quả rà soát</th>
                      <th className="border-0">Action</th>
                    </tr>
                  </thead>
                  <tbody>
                  
                    {listResults &&
                      listResults.map((item) => {
                        return (
                          <tr key={item.id}>
                            <td>{item.id}</td>
                            <td>{item.address}</td>
                            <td>{String(item.is_running)}</td>
                            <td>{item.created_at}</td>
                            <tr style={{backgroundColor:"#f2f2f200"}}>
                         

                            <button type="button" title="Nguy hiểm cao" class="btn btn-danger btn-circle btn-sm">{item.high}</button>
                          
                            <button type="button" title="Nguy hiểm trung bình" class="btn btn-warning btn-circle btn-sm">{item.medium}</button>
                            <button type="button" title="Nguy hiểm thấp" class="btn btn-primary btn-circle btn-sm">{item.low}</button>
                            <button type="button" title="Nguy cơ" class="btn btn-success btn-circle btn-sm">{item.information}</button>
                            </tr>
                            <td>
                            <Button type="button" 
                            className="btn-table"
                            onClick={(e)=>getReport(item.id)}>
                                Báo cáo
                              </Button>
                              <Link to={`/admin/vulnerability?task_id=${item.id}`}> 
                              <Button type="button" 
                              className="btn-table btn-left" 
                              > 
                              Chi tiết
                              </Button>
                            </Link>
                            </td>
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

export default Result;
