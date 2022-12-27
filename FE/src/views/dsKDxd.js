import React, { useState, useContext } from "react";
import { useEffect } from "react";
// import apiAdmin from "../service/Admin/apiAdmin";
import axiosClient from "service/axiosClient";
import { useHistory } from "react-router-dom";
// import DateTimePicker from 'react-datetime-picker';
import { GlobalState } from "layouts/Slidenav";
import "../assets/css/btn_vul.css"
import DatePicker from "react-datepicker";
import "react-datepicker/dist/react-datepicker.css";

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
  const [listDSDK, setlistDSDK] = useState([]);
  const [selectedDate, setSelectedDate] = useState(new Date());

  const handleChange = (date) => {
    setSelectedDate(date);
  }
  useEffect(() => {
    async function getDSDK() {
      const day = selectedDate.getDate();
      const month = selectedDate.getMonth() + 1;
      const year = selectedDate.getFullYear();
      const dateString = `${day}-${month}-${year}`;
      console.log(dateString)
      const res = await axiosClient.get(`/Person/get-list-dang-ky/?donViID=${id}&timeBetween=${dateString}`);
      console.log(res)
      setlistDSDK((listDSDK) => [...res.data]);
      console.log(listDSDK)
    }
    getDSDK();

  }, [id, selectedDate]);
  function getTrangThai(TRANGTHAIXD){
    switch (TRANGTHAIXD) {
      case 0:
        return 'Chưa xét duyệt';
      case 1:
        return 'Đại đội đã xét duyệt';
      case 2:
        return 'Tiểu đoàn đã xét duyệt';
      case 3: case 4: case 5:
        return 'Học viện đã xét duyệt';
        case -1: case -2: case -3:
          return 'Không được duyệt';
      default:
        return 'Không xác định';
    }
  }
  async function deleteItem(id) {
    await axiosClient.delete(`users/${id}/delete`);
      setlistDSDK(
        listUsers.filter((user) => {
          return user.id !== id;
        })
      )
  }
  const history = useHistory();
  const goDetail = () => history.push("/admin/user");
  return (
    <>
      <Container fluid>
        <Row>
          <Col md="12">
            <Card className="strpied-tabled-with-hover">
              <Card.Header>
              <Col md="3">
                <DatePicker
                 dateFormat="dd/MM/yyyy"
                 selected={selectedDate}
                 onChange={handleChange}
                 />
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
                            <td>{getTrangThai(item.TRANGTHAIXD)}</td>
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
