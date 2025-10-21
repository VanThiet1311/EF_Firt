import { Outlet } from "react-router-dom";
const LayoutDefault = () => {
  return (
    <div>
      <header>Header</header>
         <Outlet />
      <footer>Footer</footer>
    </div>
  );
};

export default LayoutDefault;
