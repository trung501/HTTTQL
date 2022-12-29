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
import dsdk from "views/admin/dsdk.js";
import dsCxd from "views/admin/dsCxd.js";
import dsDD from "views/admin/dsDD.js";
import GTRV from "views/admin/GTRV.js";
import dsKDxd from "views/admin/dsKDxd.js";
import qdct from "views/admin/qdct.js";
import dsHV from "views/admin/dsHV.js";
import dsRV from "views/admin/dsRV.js";
import kqrl from "views/admin/kqrl.js";
import dsVP from "views/admin/dsVP.js";
import dsDRN from "views/admin/dsDRN.js";
import ttk from "views/admin/ttk.js";

import Test from "views/daidoi/Test";
import dsdkDD from "views/daidoi/dsdk.js";
import dsCxdDD from "views/daidoi/dsCxd.js";
import dsDDDD from "views/daidoi/dsDD.js";
import GTRVDD from "views/daidoi/GTRV.js";
import dsKDxdDD from "views/daidoi/dsKDxd.js";
import qdctDD from "views/daidoi/qdct.js";
import dsHVDD from "views/daidoi/dsHV.js";
import dsRVDD from "views/daidoi/dsRV.js";
import kqrlDD from "views/daidoi/kqrl.js";
import dsVPDD from "views/daidoi/dsVP.js";
import dsDRNDD from "views/daidoi/dsDRN.js";
import ttkDD from "views/daidoi/ttk.js";



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
    path: "/dsHV",
    name: "Danh sách học viên",
    component: Test,
    layout: "/daidoi"
  },
  {
    path: "/dsdk",
    name: "Danh sách đăng kí",
    component: dsdk,
    layout: "/admin"
  },
  {
    path: "/dsdk",
    name: "Danh sách đăng kí",
    component: Test,
    layout: "/daidoi"
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
    path: "/GTRV",
    name: "Giấy tờ ra vào",
    component: GTRV,
    layout: "/admin"
  },
  {
    path: "/dsRV",
    name: "Danh sách ra vào",
    component: dsRV,
    layout: "/admin"
  },
  {
    path: "/dsDRN",
    name: "Danh sách đang ra ngoài",
    component: dsDRN,
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
    name: "Quản lý tài khoản",
    component: ttk,
    layout: "/admin"
  },
  {
    path: "/ttk",
    name: "Quản lý tài khoản",
    component: ttk,
    layout: "/VB"
  },
];

export default dashboardRoutes;
