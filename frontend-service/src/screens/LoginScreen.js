import React from "react";
import "./LoginScreen.css";

const LoginScreen = () => {
  const [email, setEmail] = React.useState("");
  const [password, setPassword] = React.useState("");

  const handleSubmit = (event) => {
    event.preventDefault();
    console.log(email, password);
  };

  return (
    <div className="login-screen">
      <form onSubmit={handleSubmit} className="login-form">
        <h1 className="login-title">Login</h1>
        <label>
          Email:
          <input
            className="input-email"
            type="email"
            value={email}
            onChange={(event) => setEmail(event.target.value)}
          />
        </label>
        <label className>
          Password:
          <input
            className="input-password"
            type="password"
            value={password}
            onChange={(event) => setPassword(event.target.value)}
          />
        </label>
        <button className="login-button" type="submit" value="Submit">
          Login
        </button>
        <a className="create-account" href="/">
          Criar Conta
        </a>
      </form>
    </div>
  );
};

export default LoginScreen;
