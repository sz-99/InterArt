import { useState } from 'react'
import React from 'react'
import Login from "./Components/Login"
import NavigationBar from "./Components/NavBar.jsx"
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
      <div className="card">
        <button onClick={() => setCount((count) => count + 1)}>
          count is {count}
        </button>
        
      </div>
      <div>
        <Login/>
      </div>
    </>
  )
}

export default App;
