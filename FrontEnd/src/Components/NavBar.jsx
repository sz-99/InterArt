import React from "react";
import logo from "../assets/InterArtLogo.png";

const NavigationBar = () => {
  return (
    <nav className="bg-blue-700 text-black p-4 shadow-lg fixed top-0 w-full z-50">
      <div className="container mx-auto flex justify-between items-center">
        {/* Logo centered */}
        <div className="flex-1 flex justify-center">
          <a href="/" className="flex items-center">
            <img src={logo} alt="InterArt Logo" className="w-8 h-8" />
          </a>
        </div>

        {/* Nav Links - flex across screen */}
        <div className="flex-1 flex justify-evenly text-xl font-bold">
          <a href="/" className="hover:text-gray-800 transition">Home</a>
          <a href="/gallery" className="hover:text-gray-800 transition">Gallery</a>
          <a href="/about" className="hover:text-gray-800 transition">About</a>
          <a href="/login" className="hover:text-gray-800 transition">Login</a>
        </div>
      </div>
    </nav>
  );
};

export default NavigationBar;