import { useState } from 'react'
import React from 'react'
import NavigationBar from "./Components/NavBar.jsx"
import Login from "./Components/Login.jsx"
import { BrowserRouter as Router, Route, Routes} from "react-router-dom";
import './App.css'
import 'bootstrap/dist/css/bootstrap.min.css'
import "./styles/styles.css";



function App() {
  const [count, setCount] = useState(0)

  return (
    <>
    <Router>
      <Routes>
        <Route path="user/login" element={<Login/>} />
      </Routes>
    </Router>
    <div>
      <NavigationBar/>
    </div>
      <div className="card">
        <button onClick={() => setCount((count) => count + 1)}>
          count is {count}
        </button>
      </div>
      
    </>
  )
}

export default App;
