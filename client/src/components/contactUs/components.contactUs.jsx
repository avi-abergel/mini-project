import React, { useState } from "react";
import { addUserMessage } from "../services/services";

export const ContactUs = (props) => {
  const [fullName, setFullName] = useState("");
  const [email, setEmail] = useState("");
  const [message, setMessage] = useState("");

  const handleSubmittion = (event) => {
    if (fullName === "" || email === "" || message === "") {
      alert("please fill all inputs");
    } else {
      const userMessage = { fullName, email, message };
      userMessage.fullName = fullName;
      userMessage.email = email;
      userMessage.message = message;
      addUserMessage(userMessage);
      userMessage.fullName = "";
      userMessage.email = "";
      userMessage.message = "";
    }
  };

  return (
    <div>
      <h1>Contact Us</h1>
      <div className="input-group input-group-sm mb-3">
        <div className="input-group-prepend">
          <span className="input-group-text" id="inputGroup-sizing-sm">
            Full Name
          </span>
        </div>
        <input
          type="text"
          className="form-control"
          aria-label="Small"
          aria-describedby="inputGroup-sizing-sm"
          value={fullName}
          onChange={(event) => setFullName(event.target.value)}
        />
      </div>
      <div className="input-group input-group-sm mb-3">
        <div className="input-group-prepend">
          <span className="input-group-text" id="inputGroup-sizing-sm">
            E-mail
          </span>
        </div>
        <input
          type="text"
          className="form-control"
          aria-label="Small"
          aria-describedby="inputGroup-sizing-sm"
          value={email}
          onChange={(event) => setEmail(event.target.value)}
        />
      </div>
      <div className="input-group input-group-sm mb-3">
        <div className="input-group-prepend">
          <span className="input-group-text" id="inputGroup-sizing-sm">
            Message
          </span>
        </div>
        <input
          type="text"
          className="form-control"
          aria-label="Small"
          aria-describedby="inputGroup-sizing-sm"
          value={message}
          onChange={(event) => setMessage(event.target.value)}
        />
      </div>
      <button
        type="submit"
        className="btn btn-primary"
        onClick={() => handleSubmittion()}
      >
        Submit
      </button>
    </div>
  );
};
