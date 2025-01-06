import { createBrowserRouter } from "react-router";
import HomePage from "../pages/HomePage";
import UserPage from "../pages/UserPage";

export const router = createBrowserRouter([
  {
    path: "/",
    element: <HomePage />,
  },
  {
    path: "/user/:slug",
    element: <UserPage />,
  },
]);
