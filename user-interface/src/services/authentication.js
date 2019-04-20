import instance from './instance';
import { authentication } from '../configurations/services';

export const authenticationService = credentials =>
  instance.post(authentication.login, credentials);
