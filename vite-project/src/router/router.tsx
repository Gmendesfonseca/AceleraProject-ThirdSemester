import { Navigate, RouteObject } from 'react-router-dom';
import { Home } from '../pages/Home/HomeView';
import { Chat } from '../pages/Chat/ChatView';
import SignInSide from '../pages/Login/SignInView';
import Profile from '../pages/Profile/ProfileView';
import { Settings } from '../pages/Settings/SettingsView';
import { RegisterInstitution } from '../pages/Register/RegisterInstitution';
import { RegisterStudent } from '../components/Register/AddMembers/FormStudent';
import { RegisterProfessor } from '../components/Register/AddMembers/FormProfessor';
import { ChangePassword } from '../pages/Login/ChangePassword/ChangePassword';
import { RegisterMenu } from '../pages/Register/RegisterMenu';
import { RegisterBranch } from '../components/Register/AddMembers/FormBranch';

export type RouteType = {
  path: string;
  element?: JSX.Element;
  options?: Omit<RouteObject, 'path' | 'element' | 'children'>;
  permissions?: string[];
  children?: RouteType[];
} & Partial<RouteObject>;

export function routesResolver(
  routes: RouteType[],
  accountPermissions: string[],
): RouteObject[] {
  return routes.reduce<RouteObject[]>((acc, route) => {
    const { path, element, options, children, permissions } = route;

    if (permissions) {
      const hasPermission = permissions.some((permission) =>
        accountPermissions.includes(permission),
      );
      if (!hasPermission) {
        return [
          ...acc,
          {
            path,
            element: <SignInSide />,
            children: children
              ? routesResolver(children, accountPermissions)
              : undefined,
            ...options,
          } as RouteObject,
        ];
      }
    }

    return [
      ...acc,
      {
        path,
        element,
        children: children
          ? routesResolver(children, accountPermissions)
          : undefined,
        ...options,
      } as RouteObject,
    ];
  }, []);
}

export function createRoutes() {
  const routes: RouteType[] = [
    {
      path: '/',
      element: <Navigate to="/login" replace />,
    },
    {
      path: '/login',
      element: <SignInSide />,
    },
    {
      path: '/home',
      element: <Home />,
    },
    {
      path: '/profile',
      element: <Profile />,
    },
    {
      path: '/register',
      element: <RegisterMenu />,
    },
    {
      path: '/headoffice/register',
      element: <RegisterInstitution />,
    },
    {
      path: '/branch/list',
      element: <RegisterInstitution />,
    },
    {
      path: '/branch/register',
      element: <RegisterBranch />,
    },
    {
      path: '/student/list',
      element: <RegisterStudent />,
    },
    {
      path: '/student/register',
      element: <RegisterStudent />,
    },
    {
      path: '/professor/list',
      element: <RegisterProfessor />,
    },
    {
      path: '/professor/register',
      element: <RegisterProfessor />,
    },
    {
      path: '/forgot-password',
      element: <ChangePassword />,
    },
    {
      path: '/settings',
      element: <Settings />,
    },
    {
      path: '/chat',
      element: <Chat />,
    },
    {
      path: '/friends',
      element: <Chat />,
    },
    {
      path: '/groups',
      element: <Chat />,
    },
    {
      path: '/marketplace',
      element: <Chat />,
    },
  ];

  return routes;
}