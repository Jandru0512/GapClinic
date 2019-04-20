import { lazy } from 'react';
import { createRoute } from '../utils/general';
import { LOGGED, GUEST } from './constants';

const AsyncRegister = lazy(() => import('../pages/Register.js'));
const AsyncLogin = lazy(() => import('../pages/Login.js'));
const AsyncUsers = lazy(() => import('../pages/Users.js'));
const AsyncUser = lazy(() => import('../pages/User.js'));

export default [
  createRoute('/', AsyncUsers, LOGGED, true),
  createRoute('/register', AsyncRegister, GUEST),
  createRoute('/login', AsyncLogin),
  createRoute('/user/:id?', AsyncUser, LOGGED),
];
