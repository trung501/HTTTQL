import React, { useState, useContext } from "react";
import { useEffect } from "react";
// import apiAdmin from "../service/Admin/apiAdmin";
import axiosClient from "service/axiosClient";
import { useHistory } from "react-router-dom";
// import DateTimePicker from 'react-datetime-picker';
import { GlobalState } from "layouts/Slidenav";
import "../../assets/css/btn_vul.css";
import DatePicker from "react-datepicker";
import "react-datepicker/dist/react-datepicker.css";
import Modal from "react-bootstrap/Modal";
import "./style.css";
import { confirmAlert } from 'react-confirm-alert';
import 'react-confirm-alert/src/react-confirm-alert.css';
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
  const [maHV, setmaHV] = useState();
  const [STT, setSTT] = useState();
  const [HTRN, setHTRN] = useState(0);
  const [DiaDiem, setDiaDiem] = useState();
  const [TGRa, setTGRa] = useState(new Date());
  const [TGVao, setTGVao] = useState(new Date());
  const [listDSDK, setlistDSDK] = useState([]);
  const [selectedDate, setSelectedDate] = useState(new Date());
  const [show, setShow] = useState(false);
  const [showModal, setShowModal] = useState(false);
  const handleClose = () => setShowModal(false);
  const handleShow = () => setShowModal(true);
  const [hm, setHm] = useState({
    gioRa: "",
    gioVao: "",
    phutRa: "",
    phutVao: ""
  });

  const handleChange = (date) => {
    setSelectedDate(date);
  };
  const handleTimeVao = (date) => {
    setTGVao(date);
  };
  const handleTimeRa = (date) => {
    setTGRa(date);
  };
  useEffect(() => {
    async function getDSDK() {
      const day = selectedDate.getDate();
      const month = selectedDate.getMonth() + 1;
      const year = selectedDate.getFullYear();
      const dateString = `${day}-${month}-${year}`;
      const res = await axiosClient.get(
        `/Person/get-list-dang-ky/?donViID=${id}&timeBetween=${dateString}`
      );
      setlistDSDK((listDSDK) => [...res.data]);
    }
    getDSDK();
  }, [id, selectedDate]);
  function getMaHVShow(maHv) {
    setShow(true);
    setmaHV(maHV);
  }

 async function xoaDSDK(maDK){
  const res = await axiosClient.delete(`/Person/delete-dang-ky/?sttDangKy=${maDK}`)
  if (res.status === 200) {
    alert("X??a th??nh c??ng");
    getDSDK()
  } else {
    alert("???? x???y ra l???i")
  }
 }
 const handleDelete = (maDK) => {
  console.log(maDK)
  confirmAlert({
    message: 'B???n c?? ch???c ch???n mu???n x??a kh??ng?',
    buttons: [
      {
        label: 'C??',
        onClick: () => xoaDSDK(maDK)
      },
      {
        label: 'Kh??ng',
        onClick: () => {}
      }
    ]
  });
};
  function getTrangThai(TRANGTHAIXD) {
    switch (TRANGTHAIXD) {
      case 0:
        return "Ch??a x??t duy???t";
      case 1:
        return "?????i ?????i ???? x??t duy???t";
      case 2:
        return "Ti???u ??o??n ???? x??t duy???t";
      case 3:
      case 4:
      case 5:
        return "H???c vi???n ???? x??t duy???t";
      case -1:
      case -2:
      case -3:
        return "Kh??ng ???????c duy???t";
      default:
        return "Kh??ng x??c ?????nh";
    }
  }
function handleEditDSDK (
  STT,
  HTRN,
  DiaDiem,
  // TGRa,
  // TGVao,
  // gioRa,
  // gioVao,
  // phutRa,
  // phutVao
){
    setShowModal(true);
    setSTT(STT)
    setHTRN(HTRN);
    setDiaDiem(DiaDiem);
    // setTGRa(TGRa);
    // setTGVao(TGVao);
    // setHm({ ...hm, gioRa: gioRa});
    // setHm({ ...hm, phutRa: phutRa});
    // setHm({ ...hm, gioVao: gioVao});
    // setHm({ ...hm, phutVao: phutVao});
  };
  const handleEditDSDK1 = (e) => {
    e.preventDefault();
    if (
      TGRa === "" ||
      TGVao === "" ||
      hm.gioRa === "" ||
      hm.gioVao === "" ||
      hm.phutRa === "" ||
      hm.phutVao === "" ||
      DiaDiem === "null"
    ) {
      alert("Nh???p thi???u n???i dung");
    } else{
      console.log(HTRN)
      const ngayRa = TGRa.getDate();
    const thangRa = TGRa.getMonth() + 1;
    const namRa = TGRa.getFullYear();
    const ngayVao = TGVao.getDate();
    const thangVao = TGVao.getMonth() + 1;
    const namVao = TGVao.getFullYear();
    const timeRa = `${namRa}-${thangRa}-${ngayRa} ${hm.gioRa}:${hm.phutRa}`;
    const timeVao = `${namVao}-${thangVao}-${ngayVao} ${hm.gioVao}:${hm.phutVao}`;
    const data = {
      STT: STT,
      dia_diem: DiaDiem,
      hinh_thuc_RN: parseInt(HTRN, 10),
      time_start: timeRa,
      time_end: timeVao,
    };
    axiosClient.put("/Person/post-thay_doi-thong-tin-dang-ky/", data).then((res) => {
      if (res.status === 200) {
        alert("Ch???nh s???a th??nh c??ng");
        getDSDK()
      } else {
        alert("???? x???y ra l???i")
      }
    });
    setShowModal(false);
    }
    
  };

  return (
    <>
      <Modal
        style={{ transform: "none" }}
        show={showModal}
        onShow={handleShow}
        onHide={handleClose}
      >
        <Modal.Header closeButton>
          <Modal.Title>Ch???nh s???a danh s??ch ????ng k??</Modal.Title>
        </Modal.Header>
        <Modal.Body>
          <Form>
            <div className="form-group">
              <label>H??nh th???c ra ngo??i</label>
              <div>
                <select
                  class="form-control name-domain"
                  onChange={(event) => setHTRN(event.target.value)}
                >
                  <option value="0">Tranh th???</option>
                  <option value="1">Ra ngo??i</option>
                </select>
              </div>
            </div>
            <div class="form-group">
              <label>?????a ??i???m</label>
              <input
                className="form-control url"
                value={DiaDiem}
                onChange={(e) => setDiaDiem(e.target.value)}
              />
            </div>
            <div class="form-group">
              <label>Th???i gian ra</label>
              <div style={{ display: "flex", gap: 12 }}>
                <DatePicker
                  dateFormat="dd/MM/yyyy"
                  selected={TGRa}
                  onChange={handleTimeRa}
                />
                <input 
                value={hm.gioRa} 
                placeholder="gi???" 
                style={{ width: 120 }} 
                onChange={(e) => setHm({...hm, gioRa:e.target.value})} />
                <input 
                type = "text"
                value={hm.phutRa} 
                placeholder="ph??t" 
                style={{ width: 120 }} 
                onChange={(e) => setHm({...hm, phutRa: e.target.value})}/>
                </div>
            </div>
            <div class="form-group">
              <label>Th???i gian v??o</label>
              <div style={{ display: "flex", gap: 12 }}>
                <DatePicker
                  dateFormat="dd/MM/yyyy"
                  selected={TGVao}
                  onChange={handleTimeVao}
                />
                <input type="text" value={hm.gioVao} placeholder="gi???" style={{ width: 120 }} onChange={(e) => setHm({...hm, gioVao: e.target.value})}/>
                <input type="text" value={hm.phutVao} placeholder="ph??t" style={{ width: 120 }} onChange={(e) => setHm({...hm, phutVao:e.target.value})}/>
              </div>
            </div>
          </Form>
        </Modal.Body>
        <Modal.Footer>
          <Button
            variant="secondary"
            onClick={handleEditDSDK1}
            className="btn-table btn-left"
          >
            L??u thay ?????i
          </Button>
          <Button onClick={handleClose} variant="secondary" type="submit">
            H???y
          </Button>
        </Modal.Footer>
      </Modal>
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
              </Card.Header>
              <Card.Body className="table-full-width table-responsive px-0">
                <Table className="table-hover table-striped">
                  <thead>
                    <tr>
                      <th className="border-0">STT</th>
                      <th className="border-0">H??nh th???c ra ngo??i</th>
                      <th className="border-0">?????a ??i???m</th>
                      <th className="border-0">Th???i gian ??i</th>
                      <th className="border-0">Th???i gian v???</th>
                      <th className="border-0">M?? h???c vi??n</th>
                      <th className="border-0">H??? t??n</th>
                      <th className="border-0">Tr???ng th??i</th>
                      <th className="border-0">Thao t??c</th>
                    </tr>
                  </thead>
                  <tbody>
                    {listDSDK &&
                      listDSDK.map((item) => {
                        return (
                          <tr key={item.STT}>
                            <td>{item.STT}</td>
                            <td>{item.HinhThucRN}</td>
                            <td>{item.DiaDiem}</td>
                            <td>{item.ThoiGianDi}</td>
                            <td>{item.ThoiGianVe}</td>
                            <td>{item.MaHV}</td>
                            <td>{item.HoTen}</td>
                            <td>{getTrangThai(item.TRANGTHAIXD)}</td>
                            <td>
                              <Button
                                type="button"
                                className="btn-table btn-left"
                                onClick={(e)=>
                                   handleEditDSDK(
                                    item.STT,
                                    (item.HinhThucRN==="Tranh th???"?0:1),
                                    item.DiaDiem
                                    // item.TGRa,
                                    // item.TGVao,

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
