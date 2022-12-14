import React, { useState, useContext } from "react";
import { useEffect } from "react";
import axiosClient from "service/axiosClient";
import { useHistory } from "react-router-dom";
import { GlobalState } from "layouts/Slidenav";
import "../../assets/css/btn_vul.css";
import DatePicker from "react-datepicker";
import "react-datepicker/dist/react-datepicker.css";
import "./style.css";
import { confirmAlert } from 'react-confirm-alert';
import 'react-confirm-alert/src/react-confirm-alert.css';
import Modal from "react-bootstrap/Modal";
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
    const { id, setId } = useContext(GlobalState);
    const [STT, setSTT] = useState();
    const [maHV, setMaHV] = useState();
    const [liDo, setLiDo] = useState();
    const [TGBD, setTGBD] = useState(new Date());
    const [TGKT, setTGKT] = useState(new Date());
    const [listDSCT, setlistDSCT] = useState([]);
    const [selectedDate, setSelectedDate] = useState(new Date());
    const [show, setShow] = useState(false);
    const [showModalAdd, setshowModalAdd] = useState(false);
    const handleCloseAdd = () => setshowModalAdd(false);
    const handleShowAdd = () => setshowModalAdd(true);
    const [showModalEdit, setshowModalEdit] = useState(false);
    const handleCloseEdit = () => setshowModalEdit(false);
    const handleShowEdit = () => setshowModalEdit(true);
    const handleChange = (date) => {
      setSelectedDate(date);
    };
    const handleTimeBD = (date) => {
      setTGBD(date);
    };
    const handleTimeKT = (date) => {
      setTGKT(date);
    };

  useEffect(() => {
    async function getDSCT() {
      const day = selectedDate.getDate();
      const month = selectedDate.getMonth() + 1;
      const year = selectedDate.getFullYear();
      const dateString = `${day}-${month}-${year}`;
      const res = await axiosClient.get(
        `/Person/get-list-cam-trai-in-week/?donViID=${id}&timeBetween=${dateString}`      );
      console.log(res)
      setlistDSCT((listDSCT) => [...res.data]);
    }
    getDSCT();
  }, [id, selectedDate]);
  const handleAddDSCT = (e) => {
    console.log("th??m");
    e.preventDefault();
    setshowModalAdd(true);
  };
  const handleAddDSCT1 = (e) => {
    e.preventDefault();
    if (
      TGBD === "" ||
      TGKT === "" ||
      maHV === "" ||
      liDo === ""
    ) {
      alert("Nh???p thi???u n???i dung");}
      else{
        const ngayBD = TGBD.getDate();
    const thangBD = TGBD.getMonth() + 1;
    const namBD = TGBD.getFullYear();
    const ngayKT = TGKT.getDate();
    const thangKT = TGKT.getMonth() + 1;
    const namKT = TGKT.getFullYear();
    const timeBD = `${ngayBD}-${thangBD}-${namBD}`;
    const timeKT = `${ngayKT}-${thangKT}-${namKT}`;
    console.log(liDo)
    console.log(timeBD)
    console.log(timeKT)
    console.log(maHV)
    const data = {
      reason: liDo,
      time_start: timeBD,
      time_end: timeKT,
      ma_HV: maHV,
    };
    axiosClient.post("/Person/post-them-hoc-vien-cam-trai/", data).then((res) => {
        if (res.status === 200) {
            alert("Th??m th??nh c??ng");
            getDSCT()
          } else {
            if (res.status === 500) alert("???? x???y ra l???i");
          }
    });
    setshowModalAdd(false);
      }
    
  };

function handleEditDSCT (STT, MaHV, liDo) {
    console.log("th??m");
    setshowModalEdit(true);
    setSTT(STT);
    setMaHV(MaHV);
    setLiDo(liDo)
  };
  const handleEditDSCT1 = (e) => {
    e.preventDefault();
    if (
      TGBD === "" ||
      TGKT === "" ||
      maHV === "" ||
      liDo === ""
    ) {
      alert("Nh???p thi???u n???i dung");}
      else{
        const ngayBD = TGBD.getDate();
    const thangBD = TGBD.getMonth() + 1;
    const namBD = TGBD.getFullYear();
    const ngayKT = TGKT.getDate();
    const thangKT = TGKT.getMonth() + 1;
    const namKT = TGKT.getFullYear();
    const timeBD = `${ngayBD}-${thangBD}-${namBD}`;
    const timeKT = `${ngayKT}-${thangKT}-${namKT}`;
    console.log(liDo)
    console.log(timeBD)
    console.log(timeKT)
    console.log(maHV)
    const data = {
      reason: liDo,
      time_start: timeBD,
      time_end: timeKT,
      ma_HV: maHV,
    };
    axiosClient.put("/Person/put-thay-doi-thong-tin-cam-trai/", data).then((res) => {
        if (res.status === 200) {
            alert("Ch???nh s???a th??nh c??ng");
            getDSCT()
          } else {
            if (res.status === 500) alert("???? x???y ra l???i");
          }
    });
    setshowModalEdit(false);
      }
    
  };



  return (
    <>
    {/* B???t ?????u edit */}
    <Modal
        style={{ transform: "none" }}
        show={showModalEdit}
        onShow={handleShowEdit}
        onHide={handleCloseEdit}
      >
        <Modal.Header closeButton>
          <Modal.Title>Ch???nh s???a danh s??ch c???m tr???i</Modal.Title>
        </Modal.Header>
        <Modal.Body>
          <Form>
            <div className="form-group">
              <label>M?? h???c vi??n</label>
              <div>
              <input
                className="form-control url"
                value={maHV}
                onChange={(e) => setMaHV(e.target.value)}
              />
              </div>
            </div>
            <div class="form-group">
              <label>Th???i gian b???t ?????u</label>
                <DatePicker
                  dateFormat="dd/MM/yyyy"
                  selected={TGBD}
                  onChange={handleTimeBD}
                  />
            </div>
            <div class="form-group">
              <label>Th???i gian k???t th??c</label>
            
                <DatePicker
                  dateFormat="dd/MM/yyyy"
                  selected={TGKT}
                  onChange={handleTimeKT}
                  />
            </div>
            <div class="form-group">
              <label>L?? do</label>
              <input
                className="form-control url"
                value={liDo}
                onChange={(e) => setLiDo(e.target.value)}
              />
            </div>
          </Form>
        </Modal.Body>
        <Modal.Footer>
          <Button
            variant="secondary"
            onClick={handleEditDSCT1}
            className="btn-table btn-left"
          >
            Ch???nh s???a
          </Button>
          <Button onClick={handleCloseEdit} variant="secondary" type="submit">
            ????ng
          </Button>
        </Modal.Footer>
      </Modal>
    {/* K???t th??c edit */}

    {/* B???t ?????u th??m */}
     <Modal
        style={{ transform: "none" }}
        show={showModalAdd}
        onShow={handleShowAdd}
        onHide={handleCloseAdd}
      >
        <Modal.Header closeButton>
          <Modal.Title>Th??m danh s??ch c???m tr???i</Modal.Title>
        </Modal.Header>
        <Modal.Body>
          <Form>
            <div className="form-group">
              <label>M?? h???c vi??n</label>
              <div>
              <input
                className="form-control url"
                value={maHV}
                onChange={(e) => setMaHV(e.target.value)}
              />
              </div>
            </div>
            <div class="form-group">
              <label>Th???i gian b???t ?????u</label>
                <DatePicker
                  dateFormat="dd/MM/yyyy"
                  selected={TGBD}
                  onChange={handleTimeBD}
                  />
            </div>
            <div class="form-group">
              <label>Th???i gian k???t th??c</label>
            
                <DatePicker
                  dateFormat="dd/MM/yyyy"
                  selected={TGKT}
                  onChange={handleTimeKT}
                  />
            </div>
            <div class="form-group">
              <label>L?? do</label>
              <input
                className="form-control url"
                value={liDo}
                onChange={(e) => setLiDo(e.target.value)}
              />
            </div>
          </Form>
        </Modal.Body>
        <Modal.Footer>
          <Button
            variant="secondary"
            onClick={handleAddDSCT1}
            className="btn-table btn-left"
          >
            Th??m
          </Button>
          <Button onClick={handleCloseAdd} variant="secondary" type="submit">
            ????ng
          </Button>
        </Modal.Footer>
      </Modal>
      {/* K???t th??c th??m */}
      
      <Container fluid>
        <Row>
          <Col md="12">
            <Card className="strpied-tabled-with-hover">
              <Card.Header>
                <Col md="3">
                  <div style={{ display: "flex", gap: 12 }}>
                  <p>Ng??y trong tu???n</p>
                  <DatePicker
                    dateFormat="dd/MM/yyyy"
                    selected={selectedDate}
                    onChange={handleChange}
                  />
                  </div>
                  
                </Col>
                {/* <button
                  type="button"
                  class="btn btn-add-target  btn-table btn-left"
                  onClick={handleAddDSCT}
                >
                  TH??M M???I
                </button> */}
              </Card.Header>
              <Card.Body className="table-full-width table-responsive px-0">
                <Table className="table-hover table-striped">
                  <thead>
                    <tr>
                    <th className="border-0">STT</th>
                      <th className="border-0">M?? h???c vi??n</th>
                      <th className="border-0">Th???i gian b???t ?????u</th>
                      <th className="border-0">Th???i gian k???t th??c</th>
                      <th className="border-0">L?? do</th>
                      {/* <th className="border-0">Thao t??c</th> */}
                    </tr>
                  </thead>
                  <tbody>
                  {listDSCT &&
                      listDSCT.map((item) => {
                        return (
                          <tr key={item.STT}>
                            <td>{item.STT}</td>
                            <td>{item.MaHV}</td>
                            <td>{item.TG_BatDau}</td>
                            <td>{item.TG_KetThuc}</td>
                            <td>{item.LIDO}</td>
                            {/* <td>
                              <Button
                                type="button"
                                className="btn-table btn-left"
                                onClick={(e)=>
                                   handleEditDSCT(
                                    item.STT,
                                    item.MaHV,
                                    item.LIDO
                                   )}
                              >
                                Ch???nh s???a
                              </Button>
                              <Button
                                type="button"
                                className="btn-table btn-left"
                                onClick={(e) => handleDelete(item.STT)}
                              >
                                X??a
                              </Button>
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
      </Container>
    </>
  );
}
export default TableListAdmin;
