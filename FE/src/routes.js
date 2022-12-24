/*!

=========================================================
* Light Bootstrap Dashboard React - v2.0.1
=========================================================

* Product Page: https://www.creative-tim.com/product/light-bootstrap-dashboard-react
* Copyright 2022 Creative Tim (https://www.creative-tim.com)
* Licensed under MIT (https://github.com/creativetimofficial/light-bootstrap-dashboard-react/blob/master/LICENSE.md)

* Coded by Creative Tim

=========================================================

* The above copyright notice and this permission notice shall be included in all copies or substantial portions of the Software.

*/
import Dashboard from "views/Dashboard.js";
import dsdk from "views/dsdk.js";
import dsCxd from "views/dsCxd.js";
import dsDD from "views/dsDD.js";
import dsKDxd from "views/dsKDxd.js";
import qdct from "views/qdct.js";
import dsHV from "views/dsHV.js";
import dsRV from "views/dsRV.js";
import kqrl from "views/kqrl.js";
import dsVP from "views/dsVP.js";
import ttk from "views/ttk.js";



const dashboardRoutes = [
  {
    path: "/dashboard",
    name: "Tổng quan",
    component: Dashboard,
    layout: "/admin"
  },
  {
    path: "/dsHV",
    name: "Danh sách học viên",
    component: dsHV,
    layout: "/admin"
  },
  {
    path: "/dsdk",
    name: "Danh sách đăng kí",
    component: dsdk,
    layout: "/admin"
  },
  {
    path: "/dsCxd",
    name: "Danh sách chờ xét duyệt",
    component: dsCxd,
    layout: "/admin"
  },
  {
    path: "/dsDD",
    name: "Danh sách đã duyệt",
    component: dsDD,
    layout: "/admin"
  },
  {
    path: "/dsKDxd",
    name: "Danh sách không được xét duyệt",
    component: dsKDxd,
    layout: "/admin"
  },

  {
    path: "/qdct",
    name: "Quyết định cấm trại",
    component: qdct,
    layout: "/admin"
  },
  {
    path: "/dsRV",
    name: "Danh sách ra vào",
    component: dsHV,
    layout: "/admin"
  },
  {
    path: "/kqrl",
    name: "Kết quả rèn luyện",
    component: kqrl,
    layout: "/admin"
  },
  {
    path: "/dsVP",
    name: "Danh sách vi phạm",
    component: dsVP,
    layout: "/admin"
  },
  {
    path: "/ttk",
    name: "Tạo tài khoản",
    component: ttk,
    layout: "/admin"
  },
];

export default dashboardRoutes;
