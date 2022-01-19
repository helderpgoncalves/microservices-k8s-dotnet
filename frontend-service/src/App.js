import React, { useState } from "react";
import HomeScreen from "./screens/HomeScreen";
import LoginScreen from "./screens/LoginScreen";
const App = () => {
  const [isLogged, setIsLogged] = useState(false);
  return <>{isLogged ? <HomeScreen /> : <LoginScreen />}</>;
};

export default App;
