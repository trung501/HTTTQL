import axios from "axios";
import React, { useState } from "react";
import { Link ,useHistory} from "react-router-dom";
import "../assets/css/login.css"
function SignIn(){
  const [username,setUsername] = useState()
  const [password,setPassword] = useState()
  console.log(password,username);
  const history = useHistory()
   const handleLogin =(e)=>{
    e.preventDefault()
    const data = {username:username,
      password:password}
    axios.post('http://117.4.247.68:15333/authenticator/login/',data).then(res=>{
      console.log(res)
      localStorage.setItem("token","HTTTQL "+res.data.access)
      history.push('/admin/dashboard')
    })
   }
    return(
    <>
    <div className="container_signin">
    <form  className='form signup'>
        <div className='control'>
        <h3>Sign In</h3>
        <div className="mb-3">
          <label>Username</label>
          <input
            type="username"  
            value={username}
            onChange={e=>setUsername(e.target.value)}
            className="form-control email"
            placeholder="Enter username"
          />
        </div>
        <div className="mb-3">
          <label>Password</label>
          <input
            type="password"
            
            className="form-control password"
            placeholder="Enter password"
            onChange={e=>setPassword(e.target.value)}
            value={password}
          />
        </div>
        <div className="mb-3">
          <div className="custom-control custom-checkbox">
            <input
              type="checkbox"
              className="custom-control-input"
              id="customCheck1"
            />
            <label className="custom-control-label" htmlFor="customCheck1">
              Remember me
            </label>
          </div>
        </div>
        <div className="d-grid">
          <button type="submit" onClick={handleLogin} className="btn btn-primary submit">
            Submit
          </button>
        </div>
        </div>
        

      </form>
    </div>
   

    </>
    )
}
export default SignIn;
