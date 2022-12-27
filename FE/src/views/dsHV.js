import React, { useState,useContext } from "react";
import { useEffect } from "react";
// import apiAdmin from "../service/Admin/apiAdmin";
import axiosClient from "service/axiosClient";
import { useHistory } from "react-router-dom";
import { GlobalState } from "layouts/Slidenav";
import { Pagination } from "@mui/material";
import Modal from 'react-bootstrap/Modal';
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
  Form,
} from "react-bootstrap";

function TableListAdmin() {
  const {id,setId}= useContext(GlobalState)
  const [maHV,setmaHV] = useState()
  const [hoTen,setHoTen] = useState()
  const [loaiHV,setLoaiHV] = useState()
  const [ngaySinh,setNgaySinh] = useState()
  const [capBac,setCapBac] = useState()
  const [chucVu,setChucVu] = useState()
  const [daiDoi,setDaiDoi] = useState()
  const [lop,setLop] = useState()
  const [queQuan,setQueQuan] = useState()
  const [listHV, setlistHV] = useState([]);
  const [show, setShow] = useState(false);
  const handleClose = () => setShow(false);
  const handleShow = () => setShow(true);
  useEffect(() => {
    async function getItem() {
      const res = await axiosClient.get(`/Person/get-list-hoc-vien/?page=0&size=12&donViID=${id}`);
      console.log(res)
      setlistHV((listHV)=>[...res.data]);
    }
    getItem();
  }, [id]);
  function getTTHV(maHv, hoTen, loaiHV, ngaySinh, capBac, chucVu, daiDoi, lop, queQuan){
    setShow(true)
    setmaHV(maHv)
    setHoTen(hoTen)
    setLoaiHV(loaiHV)
    setNgaySinh(ngaySinh)
    setCapBac(capBac)
    setChucVu(chucVu)
    setDaiDoi(daiDoi)
    setLop(lop)
    setQueQuan(queQuan)
  }
  return (
    <>
      <Modal show={show} onHide={handleClose}>
        <Modal.Header closeButton>
          <Modal.Title>Chi tiết học viên</Modal.Title>
        </Modal.Header>
        <Modal.Body>
        <Form>
                <div className="form-group">
                <label>Mã học viên</label>
                  <input disabled
                    className="form-control url"
                    value={maHV}
                    onChange={e=>setUrl(e.target.value)}
                  />
                </div>
                <div className="form-group">
                <label>Loại học viên</label>
                  <input disabled
                    className="form-control url"
                    value={loaiHV}
                    onChange={e=>setUrl(e.target.value)}
                  />
                </div>

                <div class="form-group">
                <label>Họ tên</label>
                  <input disabled
                    className="form-control url"
                    value={hoTen}
                    onChange={e=>setName(e.target.value)}
                  />
                </div>
                <div class="form-group">
                <label>Ngày sinh</label>
                  <input disabled
                    className="form-control url"
                    value={ngaySinh}
                    onChange={e=>setName(e.target.value)}
                  />
                </div>
                <div class="form-group">
                <label>Cấp bậc</label>
                  <input disabled
                    className="form-control url"
                    value={capBac}
                    onChange={e=>setName(e.target.value)}
                  />
                </div>
                <div class="form-group">
                <label>Chức vụ</label>
                  <input disabled
                    className="form-control url"
                    value={chucVu}
                    onChange={e=>setName(e.target.value)}
                  />
                </div>
                <div class="form-group">
                <label>Đại đội</label>
                  <input disabled
                    className="form-control url"
                    value={daiDoi}
                    onChange={e=>setName(e.target.value)}
                  />
                </div>
                <div class="form-group">
                <label>Lớp</label>
                  <input disabled
                    className="form-control url"
                    value={lop}
                    onChange={e=>setName(e.target.value)}
                  />
                </div>
                <div class="form-group">
                <label>Quê quán</label>
                  <input disabled
                    className="form-control url"
                    value={queQuan}
                    onChange={e=>setName(e.target.value)}
                  />
                </div>
           
              </Form> 
        </Modal.Body>
        <Modal.Footer>
          <Button variant="secondary" onClick={handleClose} className="btn-table btn-left">
            Close
          </Button>
        </Modal.Footer>
      </Modal>
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
                      {/* <th className="border-0">Loại học viên</th> */}
                      <th className="border-0">Họ tên</th>
                      <th className="border-0">Ngày sinh</th>
                      <th className="border-0">Cấp bậc</th>
                      <th className="border-0">Chức vụ</th>
                      <th className="border-0">Đại đội</th>
                      <th className="border-0">Lớp</th>
                    </tr>
                  </thead>
                  <tbody >
                    {listHV &&
                      listHV.map((item) => {
                        return (
                          <tr key={item.MaHV}  onClick={(e)=>getTTHV(item.MaHV, item.HoTen, item.TENLOAI,  item.NgSinh, item.CapBac, item.ChucVu, item.TenDD, item.TenLop, item.QueQuan)}>
                            <td>{item.MaHV}</td>
                            {/* <td>{item.TENLOAI}</td> */}
                            {/* <td>{item.PERSONID}</td> */}
                            <td>{item.HoTen}</td>
                            <td>{item.NgSinh}</td>
                            <td>{item.CapBac}</td>
                            <td>{item.ChucVu}</td>
                            <td>{item.TenDD}</td>
                            <td>{item.TenLop}</td>
                            <td>
                            <Button
                                type="button"
                                className="btn-table btn-left"
                                onClick={(e) => getMaHV(item.id)}
                              >
                                Thêm DSDK
                              </Button>
                            </td>
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
      </Container>
    </>
  );
}

export default TableListAdmin;
