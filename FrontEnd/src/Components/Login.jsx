import { useState } from "react";
import axios from "axios";

const Login = () =>{
    const [email, setEmail] = useState("");
    const [password, setPassword] = useState("");
    const [error, setError] = useState("");
    const [success, setSuccess] = useState("");

    const handleLogin = async (e) => {
        e.preventDefault();

        setError("");
        setSuccess("");

        try
        {
            const response = await axios.post("https://localhost:7188/User/login", {
                email, password
            });
            if(response.status === 200)
            {
                setSuccess("LoginSucessful. Redirecting...");
                localStorage.setItem("token", response.data.token);
            }
           
        } catch(err)
        {
            setError("Invalid email or password.");
        }
    };

    return (
        <div style={{ maxWidth: "300px", margin: "auto", padding: "20px", textAlign: "center" }}>
            <h2>Login</h2>
            {error && <p style={{color: "red"}}>{error}</p>}
            {success && <p style={{color: "green"}}>{success}</p>}
            <form onSubmit={handleLogin}>
                <input
                    type="email"
                    placeholder="Email"
                    value={email}
                    onChange={(e)=> setEmail(e.target.value)}
                    required
                    style={{display:"block", width: "100%", padding: "8px", margin: "5px 0"}}
                />
                <input 
                    type="password"
                    placeholder="Password"
                    value={password}
                    onChange={(e)=> setPassword(e.target.value)}
                    required
                    style={{display:"block", width: "100%", padding: "8px", margin: "5px 0"}}
                />
                <button type="submit" style={{padding: "10px", width: "100%"}}>Login</button>
            </form>
        </div>
    );
};
export default Login;