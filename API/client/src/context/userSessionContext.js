import { createContext, useState } from "react";

const UserSessionContext = () => {
  const tempUserSession = {
    sessionId: "sessionId",
    user: {
      firstName: "John",
      lastName: "Doe",
      email: "jdoe@gmail.com",
    },
    expiresAt: null,
  };
  const [userSession, setUserSession] = useState(tempUserSession); //Get user session from localStorage or cookies.
  return createContext({ session: userSession, setSession: setUserSession });
};

export default UserSessionContext;
