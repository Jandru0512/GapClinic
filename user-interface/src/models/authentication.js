import instance from '../services/instance';
import { authenticationService } from '../services/authentication';
import { message } from '../utils';

const authentication = {
  state: {
    token: null,
    authentication: {},
    authenticated: false,
  },
  reducers: {
    setAuthenticated: (state, payload) => ({
      ...state,
      ...payload,
      authenticated: !!payload.token,
    }),
    setLogout: () => ({
      token: null,
      authentication: {},
      authenticated: false,
    }),
  },
  effects: {
    async authentication(credentials) {
      try {
        const { data } = await authenticationService(credentials);
        this.setAuthenticated(data);
        instance.setToken(data.token);
      } catch (e) {
        message('Credenciales incorrectos', 'error');
        this.setAuthenticated({ user: {}, token: null });
      }
    },
    logout() {
      instance.removeToken();
      this.setLogout();
    },
  },
};

export default authentication;
