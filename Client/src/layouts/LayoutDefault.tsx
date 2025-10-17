import { Outlet } from "react-router-dom";
const LayoutDefault = () => {
  return (
    <div>
      <header></header>
         <Outlet />
      <footer></footer>
    </div>
  );
};

export default LayoutDefault;
