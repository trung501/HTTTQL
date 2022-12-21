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
import newUser from "views/newUser.js";
import UserProfile from "views/UserProfile.js";
import TableListAdmin from "views/TableListAdmin.js";
import TableListUser from "views/TableListUsers";
import Typography from "views/Typography.js";
import Icons from "views/Icons.js";
import Maps from "views/Maps.js";
import Notifications from "views/Notifications.js";
import Waiting from "views/waiting.js";
import Accepted from "views/accepted.js";
import Setting from "views/setting.js";
import SignUp from "views/signup.js"
import SignIn from "views/signin.js"
import Result from "views/result.js"
import Vulnerability from "views/vulnerability.js"
import Website from "views/website.js"


const dashboardRoutes = [
  {
    path: "/dashboard",
    name: "Tổng quan",
    icon: "nc-icon nc-chart-pie-35",
    component: Dashboard,
    layout: "/admin"
  },
  {
    path: "/user",
    name: "newUser",
    icon: "nc-icon nc-circle-09",
    component: newUser,
    layout: "/admin"
  },
  {
    path: "/user",
    name: "User Profile",
    icon: "nc-icon nc-circle-09",
    component: UserProfile,
    layout: "/admin"
  },
  {
    path: "/tableAdmin",
    name: "List Admins",
    icon: "nc-icon nc-notes",
    component: TableListAdmin,
    layout: "/admin"
  },
  {
    path: "/tableUser",
    name: "List Users",
    icon: "nc-icon nc-notes",
    component: TableListUser,
    layout: "/admin"
  },

  {
    path: "/typography",
    name: "Typography",
    icon: "nc-icon nc-paper-2",
    component: Typography,
    layout: "/admin"
  },
  {
    path: "/icons",
    name: "Icons",
    icon: "nc-icon nc-atom",
    component: Icons,
    layout: "/admin"
  },
  {
    path: "/maps",
    name: "Maps",
    icon: "nc-icon nc-pin-3",
    component: Maps,
    layout: "/admin"
  },
  {
    path: "/notifications",
    name: "Notifications",
    icon: "nc-icon nc-bell-55",
    component: Notifications,
    layout: "/admin"
  },
  {
    path: "/website",
    name: "Đối tượng rà soát",
    icon: "nc-icon nc-alien-33",
    component: Website,
    layout: "/admin"
  },
  {
    path: "/result",
    name: "Rà soát lỗ hổng",
    icon: "nc-icon nc-compass-05",
    component: Result,
    layout: "/admin"
  },
  {
    path: "/vulnerability",
    name: "Chi tiết lỗ hổng",
    icon: "nc-icon nc-zoom-split",
    component: Vulnerability,
    layout: "/admin"
  },
  {
    path: "/vulnerability/:id",
    name: "Chi tiết lỗ hổng",
    icon: "nc-icon nc-zoom-split",
    component: Vulnerability,
    layout: "/admin"
  },
  {
    path: "/waiting",
    name: "Đang chờ",
    icon: "nc-icon nc-watch-time",
    component: Waiting,
    layout: "/admin"
  },
  {
    path: "/accepted",
    name: "Đã chấp nhận",
    icon: "nc-icon nc-check-2",
    component: Accepted,
    layout: "/admin"
  },
  {
    path: "/setting",
    name: "Cài đặt",
    icon: "nc-icon nc-settings-gear-64",
    component: Setting,
    layout: "/admin"
  },
];

export default dashboardRoutes;
