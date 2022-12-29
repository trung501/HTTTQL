import React, { useState } from "react";
import { useEffect } from "react";
// import apiAdmin from "../service/Admin/apiAdmin";
import axiosClient from "service/axiosClient";
import { useHistory } from "react-router-dom";



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
  const [listAccount, setlistAccount] = useState([]);
  const [showModal, setShowModal] = useState(false);
  const handleClose = () => setShowModal(false);
  const handleShow = () => setShowModal(true);
  const [personID, setPersonID] =useState()
  const [username, setUsername] = useState()
  const [roleID, setRoleID] = useState()
  useEffect(() => {
    async function getItem() {
      const res = await axiosClient.get("/Person/get-list-account/?page=1&size=12");

      setlistAccount((listAccount) => [...res.data]);
    }
    getItem();

  }, []);
  function setRole(personID, username){
    setShowModal(true);
    setPersonID(personID);
    setUsername(username);
  }
  function setRole1(){

    const data ={
      username: username,
      personID: personID,
      roleID: roleID
    }
    axiosClient.post("/Person/post-tao-giay-to-RN-hoc-vien/", data).then((res)=>{
      if (res.status === 200) {
        alert("Thêm thành công");
        getDSDK()
      } else {
        alert("Đã xảy ra lỗi")
      }
    })
    setShowModal(false);
  }


  return (
    <>
        <Modal
        style={{ transform: "none" }}
        show={showModal}
        onShow={handleShow}
        onHide={handleClose}
      >
        <Modal.Header closeButton>
        </Modal.Header>
        <Modal.Body>
          <Form>

            <div class="form-group">
              <label>Số vé</label>
              <input
                className="form-control url"
                value={soVe}
                onChange={(e) => setSoVe(e.target.value)}
              />
            </div>
          </Form>
        </Modal.Body>
        <Modal.Footer>
        <Button
            variant="secondary"
            onClick={handleAddGTRN1}
            className="btn-table btn-left"
          >
            Thêm giấy tờ
          </Button>
          <Button onClick={handleClose} variant="secondary" type="submit">
            Hủy
          </Button>
        </Modal.Footer>
      </Modal>
      <Container fluid>
        <Row>
          <Col md="12">
            <Card className="strpied-tabled-with-hover">
              <Card.Header>
                <Card.Title as="h4">Danh sách người dùng</Card.Title>
                <p className="card-category">
                  <Button>Add new users</Button>
                </p>
              </Card.Header>
              <Card.Body className="table-full-width table-responsive px-0">
                <Table className="table-hover table-striped">
                  <thead>
                    <tr>
                      <th className="border-0">ID</th>
                      <th className="border-0">Tên đăng nhập</th>
                      <th className="border-0">Họ tên</th>
                      <th className="border-0">Quyền</th>
                      <th className="border-0">Người tạo quyền</th>
                      <th className="border-0">Tiểu đoàn</th>
                      <th className="border-0">Đại đội</th>
                      <th className="border-0">Lớp</th>
                      <th className="border-0">Thao tác</th>
                    </tr>
                  </thead>
                  <tbody>
                    {listAccount &&
                      listAccount.map((item) => {
                        return (
                          <tr key={item.id}>
                            <td>{item.id}</td>
                            <td>{item.username}</td>
                            <td>{item.HoTen}</td>
                            <td>{item.roleID}</td>
                            <td>{item.userSetRole}</td>
                            <td>{item.TenTD}</td>
                            <td>{item.TenDD}</td>
                            <td>{item.TenLop}</td>
                            <td>
                              <Button onClick={() => setRole(item.id)}>
                                Set Role
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
