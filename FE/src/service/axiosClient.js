import axios from "axios";

const axiosClient = axios.create({
    baseURL: 'http://117.4.247.68:15333',
    headers: {'content-type': 'application/json', 'Authorization':`${localStorage.getItem('token')}`}
  });
  export default axiosClient;