import { lazy, Suspense } from "react";
import { createBrowserRouter } from "react-router-dom";
import { PATH_ROUTER } from "../configs/path";
const Login = lazy(() => import("../pages/Login"));
const LayoutDefault = lazy(() => import("../layouts/LayoutDefault"));
const Router = createBrowserRouter([
  {
    path: "/",
    element: <LayoutDefault />,
    children: [
      {
        path: PATH_ROUTER.LOGIN,
        element: (
          <Suspense fallback={<div>Loading...</div>}>
            <Login />
          </Suspense>
        ),
      },
        {
        path: PATH_ROUTER.HOME,
        element: (
          <Suspense fallback={<div>Loading...</div>}>
            <Login />
          </Suspense>
        ),
      },
    ],
  },
]);
export default Router;
