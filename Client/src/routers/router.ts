import { lazy , Suspense } from 'react';
import { createBrowserRouter } from 'react-router-dom';
const Login = lazy(() => import('../pages/Login'));
import { PATH_ROUTER } from '../configs/path';

const router =  createBrowserRouter([
    {
        path:'/',
        element:"layoudefay",
        children:[
            {
                path:PATH_ROUTER.LOGIN,
                element:(
                    <Suspense>
                        <Login />
                    </Suspense>
                )
            }
        ]
    }
])