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
    <div>
      <NavigationBar/>
    </div>
    <Router>
      <Routes>
        <Route path="login" element={<Login/>} />
      </Routes>
    </Router>
    
     
      
    </>
  )
}

export default App;
