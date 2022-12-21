import axios from "axios";
import React, { useState } from "react";
import { Link ,useHistory} from "react-router-dom";
import {auth} from "service/api/loginApi";
import "../assets/css/login.css"
function SignUp(){
    const [email,setEmail] = useState()
    const [password,setPassword] = useState()
    console.log(password,email);
    const history = useHistory()
    const handleSignUp =(e)=>{
    e.preventDefault()
    const data = {email:email,
      password:password}
      axios.post('http://185.213.27.86:5000/api/v1/auth/register',data).then(res=>{
        console.log(res)
      // localStorage.setItem("token",res.data.session_id)
        history.push('/login')
    })
   }
    return(
    <>
     <div className="container_signup">
     <form  className='form signup'>
        <div className='control'>
        <h3>Sign Up</h3>
        <div className="mb-3">
          <label>Email address</label>
          <input
            type="email"
            value={email}
            onChange={e=>setEmail(e.target.value)}
            className="form-control"
            placeholder="Enter email"
            
          />
        </div>
        <div className="mb-3">
          <label>Password</label>
          <input
            type="password"
            className="form-control"
            placeholder="Enter password"
            onChange={e=>setPassword(e.target.value)}
            value={password}
          />
        </div>
        <div className="d-grid">
          <button type="submit" onClick={handleSignUp} className="btn btn-primary">
            Sign Up
          </button>
        </div>
        <p className="forgot-password text-right">
          Already registered <Link to="/login">sign in?</Link>
        </p>
        </div>
      </form>
     </div>
    

    </>
    )
}
export default SignUp;