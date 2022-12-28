import React, { useState,useContext } from "react";
import { useEffect } from "react";
// import apiAdmin from "../service/Admin/apiAdmin";
import axiosClient from "service/axiosClient";
import { useHistory } from "react-router-dom";
import { GlobalState } from "layouts/Slidenav";
import { Pagination } from "@mui/material";

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
  const {id,setId}= useContext(GlobalState)
  console.log(id)
  const [listHV, setlistHV] = useState([]);
  useEffect(() => {
    async function getItem() {
      const res = await axiosClient.get(`/Person/get-list-danh-sach-khong-duoc-duyet/?page=0&size=12&donViID=${id}`);
      console.log(res)
      setlistHV((listHV)=>[...res.data]);
    }
    getItem();

    // getAcc();
    //deleteAcc(id);
  }, [id]);
  async function deleteItem(id) {
    // console.log('You clicked submit.');
    // console.log(id)
    await axiosClient.delete(`users/${id}/delete`);
      setlistHV(
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
              </Card.Header>
              <Card.Body className="table-full-width table-responsive px-0">
                <Table className="table-hover table-striped">
                  <thead>
                    <tr>
                      <th className="border-0">Mã học viên</th>
                      <th className="border-0">Loại học viên</th>
                      <th className="border-0">Họ tên</th>
                      <th className="border-0">Ngày sinh</th>
                      <th className="border-0">Cấp bậc</th>
                      <th className="border-0">Chức vụ</th>
                      <th className="border-0">Đại đội</th>
                      <th className="border-0">Lớp</th>
                      <th className="border-0">Quê quán</th>
                    </tr>
                  </thead>
                  <tbody>
                    {listHV &&
                      listHV.map((item) => {
                        return (
                          <tr key={item.MaHV}>
                            <td>{item.MaHV}</td>
                            <td>{item.TENLOAI}</td>
                            {/* <td>{item.PERSONID}</td> */}
                            <td>{item.HoTen}</td>
                            <td>{item.NgSinh}</td>
                            <td>{item.CapBac}</td>
                            <td>{item.ChucVu}</td>
                            <td>{item.TenDD}</td>
                            <td>{item.TenLop}</td>
                            <td>{item.QueQuan}</td>
                            {/* <td>
                              <Button type="button" onClick={()=>goDetail()}>
                                Detail
                              </Button>
                              <Button onClick={() => deleteItem(item.id)}>
                                Delete
                              </Button>
                              <Button>Update</Button>
                            </td> */}
                          </tr>
                        );
                      })}
                  </tbody>
                </Table>
              </Card.Body>
            </Card>
          </Col>
        </Row>
        <Pagination count={10} variant="outlined" />
        {/* <Pagination count={10} variant="outlined" color="primary" />
        <Pagination count={10} variant="outlined" color="secondary" />
        <Pagination count={10} variant="outlined" disabled /> */}
      </Container>
    </>
  );
}

export default TableListAdmin;
