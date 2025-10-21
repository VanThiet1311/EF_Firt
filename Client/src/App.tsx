import './index.css'
import {Router} from './routers';
import { RouterProvider } from 'react-router-dom';
const App = () => {
  return (
    <div >
      <RouterProvider router={Router} />
    </div>
  );
};

export default App;

