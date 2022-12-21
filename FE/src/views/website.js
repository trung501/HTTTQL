import React, { useState } from "react";
import Modal from 'react-bootstrap/Modal';
import "../assets/css/switch.css"
import "../assets/css/btn_vul.css"
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
  Form,
} from "react-bootstrap";
import { Link } from "react-router-dom";

function Website() {
  const [listTargets, setlistTargets] = useState([]);
  const [id,setId] = useState()
  useEffect(() => {
    async function getItem() {
      const res = await axiosClient.get("targets");
      console.log(res);
      setlistTargets((listTargets) => [...res.data.items]);
    }
    getItem();
  }, []);
  const [url,setUrl] = useState()
  const [name,setName] = useState()
  console.log(url,name);

   const handleAddtarget =(e)=>{
    e.preventDefault()
    const data = {address:url,
      name:name}
    axiosClient.put("targets", data).then(res=>{
      // console.log(res)
    })
   }

   const [show, setShow] = useState(false);
   const handleClose = () => setShow(false);
   const handleShow = () => setShow(true);
   function getId(id){
    setShow(true)
    setId(id)
   }
   const UpdateTarget = async()=>{
    const target = await axiosClient.post("/targets",{
      name:name,
      address:url,
      id:id
    })
    
    setShow(false)
   }
   async function createScan(id){
    console.log(id)
    const res = await axiosClient.post("/scans",{
      target_id:id
    })
    console.log(res)
   }
  return (
      
    <>
         <Modal show={show} onHide={handleClose}>
        <Modal.Header closeButton>
          <Modal.Title>Chỉnh sửa mục tiêu</Modal.Title>
        </Modal.Header>
        <Modal.Body>
        <Form>
                <div className="form-group">
                  <input
                    className="form-control url"
                    placeholder="Website URL (e.g.. yourdomain.com)"
                    value={url}
                    onChange={e=>setUrl(e.target.value)}
                  />
                </div>
                <div class="form-group">
                  <input
                    className="form-control url"
                    placeholder="Website name"
                    value={name}
                    onChange={e=>setName(e.target.value)}
                  />
                </div>
           
              </Form> 
        </Modal.Body>
        <Modal.Footer>
          <Button variant="secondary" onClick={handleClose}>
            Close
          </Button>
          <Button variant="primary" onClick={ UpdateTarget}>
            Save Changes
          </Button>
        </Modal.Footer>
      </Modal>
      <button type="button" class="btn btn-add-target" >
          THÊM MỚI
        </button>
      <br></br>
      <br></br>
      <Container fluid>
        <Row>
          <Col md="12">
            <Card>
              <Card.Header>
                <Card.Title as="h4">Thêm trang web</Card.Title>
              </Card.Header>
              <Card.Body>
              {/* <div >
                  <p>
                  Rà soát xác minh mục tiêu cho phép bạn xác nhận quyền sở hữu trang web bạn muốn rà soát
                  </p>
              </div> */}
              <div>
              <span style={{ fontWeight: 'bold' }}>Tên miền của bạn</span>
              <Form>
                <Row>
                {/* <div >
                  <select class="form-control name-domain" >
                  <option value="http://">http://</option>
                  <option value="https://">https://</option>
                  </select>
                </div> */}
                <Col md="6">
                <div className="form-group">
                  <input
                    className="form-control url"
                    placeholder="Website URL (e.g.. yourdomain.com)"
                    value={url}
                    onChange={e=>setUrl(e.target.value)}
                  />
                </div>
                </Col>
                <Col md="6">
                <div class="form-group">
                  <input
                    className="form-control url"
                    placeholder="Website name"
                    value={name}
                    onChange={e=>setName(e.target.value)}
                  />
                </div>
                </Col>
                
                </Row> 
              </Form> 
              </div>
              <div>
{/*                 
                <div>
                <span style={{ fontWeight: 'bold' }}>Xác minh phương thức</span>
                </div>
                <br/>
                <div>
                  <span style={{ marginLeft:20,  marginTop: 20, color: 'navy'}}>Bước 1</span>
                </div>
                <div>
                  <span style={{ marginLeft:20, fontSize:13, marginTop: 20}}>Tải về</span>
                  <span style={{ marginLeft:10, fontSize:13, color: 'skyblue'}}>VulHunterVerify.html</span>

                  </div>
                  <div>
                  <span style={{ marginLeft:20,  marginTop: 20, color: 'navy'}}>Bước 2</span>
                </div>
                <div>
                  <span style={{ fontWeight: 'bold', marginLeft:20, fontSize:13, marginTop: 20}}>Upload</span>
                  <span style={{ marginLeft:10, fontSize:13}}>Tập tin đến trang web của bạn</span>

                  </div>
                  <div>
                  <span style={{ marginLeft:20,  marginTop: 20, color: 'navy'}}>Bước 3</span>
                </div>
                <div>
                  <span style={{ fontWeight: 'bold', marginLeft:20, fontSize:13, marginTop: 20}}>Click verify</span>
                  <span style={{ marginLeft:10, fontSize:13}}>bên dưới</span>

                  </div> */}
                  <Button
                    onClick={handleAddtarget}
                    className="btn-fill pull-right verify-website"
                    type="submit"
                    variant="info"
                  >
                   THÊM TRANG WEB
                  </Button>
                
              </div>
              </Card.Body>
            </Card>
            </Col>
        </Row>
        <Row>
          <Col md="12">
            
            <Card className="strpied-tabled-with-hover">

              <Card.Body className="table-full-width table-responsive px-0">
                <Table className="table-hover table-striped">
                  <thead>
                    <tr>
                      <th className="border-0">ID</th>
                      <th className="border-1">Url</th>
                      <th className="border-2">Tên</th>
                      <th className="border-3">Thời gian tạo</th>
                      <th className="border-3">Action</th>
                    </tr>
                  </thead>
                  <tbody>
                    {listTargets &&
                      listTargets.map((item) => {
                        return (
                          <tr key={item.id}>
                            <td>{item.id}</td>
                            <td>{item.address}</td>
                            <td>{item.name}</td>
                            <td>{item.created_at}</td>
                            <td>
                            <Button className="btn-table"
                            onClick={(e)=>createScan(item.id)}
                            type="button"
                             >
                              Bắt đầu quét
                            </Button>
                            <Button type="button" 
                              className="btn-table btn-left" 
                              onClick={(e)=>getId(item.id)}>
                              Chỉnh sửa
                            </Button>
                            <Link to={`/admin/result?target_id=${item.id}`}> 
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

export default Website;
