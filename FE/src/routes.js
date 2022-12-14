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

import dsdkLop from "views/lop/dsdk.js";
import dsCxdLop from "views/lop/dsCxd.js";
import dsDDLop from "views/lop/dsDD.js";
import GTRVLop from "views/lop/GTRV.js";
import dsKDxdLop from "views/lop/dsKDxd.js";
import qdctLop from "views/lop/qdct.js";
import dsHVLop from "views/lop/dsHV.js";
import dsRVLop from "views/lop/dsRV.js";
import kqrlLop from "views/lop/kqrl.js";
import dsVPLop from "views/lop/dsVP.js";
import dsDRNLop from "views/lop/dsDRN.js";
import ttkLop from "views/lop/ttk.js";

import dsdkTD from "views/tieudoan/dsdk.js";
import dsCxdTD from "views/tieudoan/dsCxd.js";
import dsDDTD from "views/tieudoan/dsDD.js";
import GTRVTD from "views/tieudoan/GTRV.js";
import dsKDxdTD from "views/tieudoan/dsKDxd.js";
import qdctTD from "views/tieudoan/qdct.js";
import dsHVTD from "views/tieudoan/dsHV.js";
import dsRVTD from "views/tieudoan/dsRV.js";
import kqrlTD from "views/tieudoan/kqrl.js";
import dsVPTD from "views/tieudoan/dsVP.js";
import dsDRNTD from "views/tieudoan/dsDRN.js";
import ttkTD from "views/tieudoan/ttk.js";

import dsdkVB from "views/vebinh/dsdk.js";
import dsCxdVB from "views/vebinh/dsCxd.js";
import dsDDVB from "views/vebinh/dsDD.js";
import GTRVVB from "views/vebinh/GTRV.js";
import dsKDxdVB from "views/vebinh/dsKDxd.js";
import qdctVB from "views/vebinh/qdct.js";
// import dsHVVB from "views/vebinh/dsHV.js";
import dsRVVB from "views/vebinh/dsRV.js";
import kqrlVB from "views/vebinh/kqrl.js";
import dsVPVB from "views/vebinh/dsVP.js";
import dsDRNVB from "views/vebinh/dsDRN.js";
import ttkVB from "views/vebinh/ttk.js";


const dashboardRoutes = [
  {
    path: "/dashboard",
    name: "T???ng quan",
    component: Dashboard,
    layout: "/admin"
  },
  // DSHV
  {
    path: "/dsHV",
    name: "Danh s??ch h???c vi??n",
    component: dsHV,
    layout: "/admin"
  },
  {
    path: "/dsHV",
    name: "Danh s??ch h???c vi??n",
    component: dsHVDD,
    layout: "/daidoi"
  },
  {
    path: "/dsHV",
    name: "Danh s??ch h???c vi??n",
    component: dsHVLop,
    layout: "/lop"
  },
  {
    path: "/dsHV",
    name: "Danh s??ch h???c vi??n",
    component: dsHVTD,
    layout: "/tieudoan"
  },
  //DSDK
  {
    path: "/dsdk",
    name: "Danh s??ch ????ng k??",
    component: dsdkLop,
    layout: "/lop"
  },
  //DSCXD
  {
    path: "/dsCxd",
    name: "Danh s??ch ch??? x??t duy???t",
    component: dsCxd,
    layout: "/admin"
  },
  {
    path: "/dsCxd",
    name: "Danh s??ch ch??? x??t duy???t",
    component: dsCxdDD,
    layout: "/daidoi"
  },
  {
    path: "/dsCxd",
    name: "Danh s??ch ch??? x??t duy???t",
    component: dsCxdTD,
    layout: "/tieudoan"
  },
//ds ???? duy???t
  {
    path: "/dsDD",
    name: "Danh s??ch ???? duy???t",
    component: dsDD,
    layout: "/admin"
  },
  {
    path: "/dsDD",
    name: "Danh s??ch ???? duy???t",
    component: dsDDLop,
    layout: "/lop"
  },
  {
    path: "/dsDD",
    name: "Danh s??ch ???? duy???t",
    component: dsDDDD,
    layout: "/daidoi"
  },
  {
    path: "/dsDD",
    name: "Danh s??ch ???? duy???t",
    component: dsDDTD,
    layout: "/tieudoan"
  },
  {
    path: "/dsDD",
    name: "Danh s??ch ???? duy???t",
    component: dsDDVB,
    layout: "/vebinh"
  },

  //ds k ??c x??t duy???t
  {
    path: "/dsKDxd",
    name: "Danh s??ch kh??ng ???????c x??t duy???t",
    component: dsKDxd,
    layout: "/admin"
  },
  {
    path: "/dsKDxd",
    name: "Danh s??ch kh??ng ???????c x??t duy???t",
    component: dsKDxdLop,
    layout: "/lop"
  },
  {
    path: "/dsKDxd",
    name: "Danh s??ch kh??ng ???????c x??t duy???t",
    component: dsKDxdDD,
    layout: "/daidoi"
  },
  {
    path: "/dsKDxd",
    name: "Danh s??ch kh??ng ???????c x??t duy???t",
    component: dsKDxdTD,
    layout: "/tieudoan"
  },
// Q??CT
  {
    path: "/qdct",
    name: "Quy???t ?????nh c???m tr???i",
    component: qdct,
    layout: "/admin"
  },
  {
    path: "/qdct",
    name: "Quy???t ?????nh c???m tr???i",
    component: qdctLop,
    layout: "/lop"
  },
  {
    path: "/qdct",
    name: "Quy???t ?????nh c???m tr???i",
    component: qdctDD,
    layout: "/daidoi"
  },
  {
    path: "/qdct",
    name: "Quy???t ?????nh c???m tr???i",
    component: qdctTD,
    layout: "/tieudoan"
  },

//GTRV
  {
    path: "/GTRV",
    name: "Gi???y t??? ra v??o",
    component: GTRV,
    layout: "/admin"
  },
  {
    path: "/GTRV",
    name: "Gi???y t??? ra v??o",
    component: GTRVLop,
    layout: "/lop"
  },
  {
    path: "/GTRV",
    name: "Gi???y t??? ra v??o",
    component: GTRVDD,
    layout: "/daidoi"
  },
  {
    path: "/GTRV",
    name: "Gi???y t??? ra v??o",
    component: GTRVTD,
    layout: "/tieudoan"
  },
  {
    path: "/GTRV",
    name: "Gi???y t??? ra v??o",
    component: GTRVVB,
    layout: "/vebinh"
  },

  // DSRV
  {
    path: "/dsRV",
    name: "Danh s??ch ra v??o",
    component: dsRV,
    layout: "/admin"
  },
  {
    path: "/dsRV",
    name: "Danh s??ch ra v??o",
    component: dsRVLop,
    layout: "/lop"
  },
  {
    path: "/dsRV",
    name: "Danh s??ch ra v??o",
    component: dsRVDD,
    layout: "/daidoi"
  },
  {
    path: "/dsRV",
    name: "Danh s??ch ra v??o",
    component: dsRVTD,
    layout: "/tieudoan"
  },
  {
    path: "/dsRV",
    name: "Danh s??ch ra v??o",
    component: dsRVVB,
    layout: "/vebinh"
  },
  // DS DRN
  {
    path: "/dsDRN",
    name: "Danh s??ch ??ang ra ngo??i",
    component: dsDRN,
    layout: "/admin"
  },
  {
    path: "/dsDRN",
    name: "Danh s??ch ??ang ra ngo??i",
    component: dsDRNLop,
    layout: "/lop"
  },
  {
    path: "/dsDRN",
    name: "Danh s??ch ??ang ra ngo??i",
    component: dsDRNDD,
    layout: "/daidoi"
  },
  {
    path: "/dsDRN",
    name: "Danh s??ch ??ang ra ngo??i",
    component: dsDRNTD,
    layout: "/tieudoan"
  },
  {
    path: "/dsDRN",
    name: "Danh s??ch ??ang ra ngo??i",
    component: dsDRNVB,
    layout: "/vebinh"
  },


  // KQRL
  {
    path: "/kqrl",
    name: "K???t qu??? r??n luy???n",
    component: kqrl,
    layout: "/admin"
  },
  {
    path: "/kqrl",
    name: "K???t qu??? r??n luy???n",
    component: kqrlLop,
    layout: "/lop"
  },
  {
    path: "/kqrl",
    name: "K???t qu??? r??n luy???n",
    component: kqrlDD,
    layout: "/daidoi"
  },
  {
    path: "/kqrl",
    name: "K???t qu??? r??n luy???n",
    component: kqrlTD,
    layout: "/tieudoan"
  },
  //DSVP
  {
    path: "/dsVP",
    name: "Danh s??ch vi ph???m",
    component: dsVP,
    layout: "/admin"
  },
  {
    path: "/dsVP",
    name: "Danh s??ch vi ph???m",
    component: dsVPLop,
    layout: "/lop"
  },
  {
    path: "/dsVP",
    name: "Danh s??ch vi ph???m",
    component: dsVPDD,
    layout: "/daidoi"
  },
  {
    path: "/dsVP",
    name: "Danh s??ch vi ph???m",
    component: dsVPTD,
    layout: "/tieudoan"
  },
  {
    path: "/dsVP",
    name: "Danh s??ch vi ph???m",
    component: dsVPVB,
    layout: "/vebinh"
  },
  {
    path: "/ttk",
    name: "Qu???n l?? t??i kho???n",
    component: ttk,
    layout: "/admin"
  },
  // {
  //   path: "/ttk",
  //   name: "Qu???n l?? t??i kho???n",
  //   component: ttkDD,
  //   layout: "/daidoi"
  // },
  // {
  //   path: "/ttk",
  //   name: "Qu???n l?? t??i kho???n",
  //   component: ttkTD,
  //   layout: "/tieudoan"
  // },

];

export default dashboardRoutes;
