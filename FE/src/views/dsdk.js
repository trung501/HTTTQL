import React, { useState } from "react";
import { useEffect } from "react";
// import apiAdmin from "../service/Admin/apiAdmin";
import axiosClient from "service/axiosClient";
import { useHistory } from "react-router-dom";
import DateTimePicker from 'react-datetime-picker';
import "../assets/css/btn_vul.css"

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

function TableListAdmin() {
  const [listDSDK, setlistDSDK] = useState([]);
  const [value, onChange] = useState(new Date());
  useEffect(() => {
    async function getItem() {
      const res = await axiosClient.get(`get-list-dang-ky/?donViID=${id}&timeBetween=${value}`);
      console.log(res.data);
      setlistDSDK((listDSDK) => [...res.data]);
    }
    getItem();

    // getAcc();
    //deleteAcc(id);
  }, []);
  async function deleteItem(id) {
    // console.log('You clicked submit.');
    // console.log(id)
    await axiosClient.delete(`users/${id}/delete`);
      setlistDSDK(
        listUsers.filter((user) => {
          return user.id !== id;
        })
      )
  }

  
    // function deleteItem(id) {
    //   console.log(id);
    //   axiosClient.delete(`users/${id}/delete`);
    //   setlistUsers(
    //     listUsers.filter((user) => {
    //       return user.id !== id;
    //     })
    //   )
    // }

    // getAcc();
    //deleteAcc(id);


  // async function deleteAcc(id) {
  //   const respon = await apiAdmin.deleteItem(id);
  //   console.log(respon);
  //   return history.push("/admin/user");
  // }
  const history = useHistory();
  const goDetail = () => history.push("/admin/user");

  //console.log(listUsers);

  // async function deleteItem(id) {
  //   //console.log(id);

  //   const response = await axiosClient.delete(`users/${id}/delete`);
  //   //console.log(response);
  //   history.push("/admin/user");

  // setlistUsers(
  //   listUsers.filter((user) => {
  //     return user.id !== id;
  //   })
  // );
  // history.push("/admin/user");
  // }

  // const addAccount=async(id,email,running,finished,total_alert,total_scan)=>{
  //   let respon=await axiosClient.post('',{
  //     id:id,
  //     email:email,
  //     running:running,
  //     finished:finished,
  //     total_alert:total_alert,
  //     total_scan:total_scan
  //   });
  //   setlistUsers([respon.data.items,...listUsers]);
  // }

  return (
    <>
      <Container fluid>
        <Row>
          <Col md="12">
            <Card className="strpied-tabled-with-hover">
              <Card.Header>
              <Col md="3">
                <div className="date">
                  <DateTimePicker onChange={onChange} value={value} />
                </div>
                </Col>
              </Card.Header>
              <Card.Body className="table-full-width table-responsive px-0">
                <Table className="table-hover table-striped">
                  <thead>
                    <tr>
                      <th className="border-0">STT</th>
                      <th className="border-0">Hình thức ra ngoài</th>
                      <th className="border-0">Địa điểm</th>
                      <th className="border-0">Thời gian đi</th>
                      <th className="border-0">Thời gian về</th>
                      <th className="border-0">Mã học viên</th>
                      <th className="border-0">Trạng thái</th>
                    </tr>
                  </thead>
                  <tbody>
                    {listUsers &&
                      listUsers.map((item) => {
                        return (
                          <tr key={item.STT}>
                            <td>{item.STT}</td>
                            <td>{item.HinhThucRN}</td>
                            <td>{item.DiaDiem}</td>
                            <td>{item.ThoiGianDi}</td>
                            <td>{item.ThoiGianVe}</td>
                            <td>{item.MaHV}</td>
                            <td>{item.TRANGTHAIXD}</td>
                            <td>
                              <Button type="button" onClick={()=>goDetail()}>
                                Detail
                              </Button>
                              <Button onClick={() => deleteItem(item.id)}>
                                Delete
                              </Button>
                              <Button>Update</Button>
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

export default TableListAdmin;
