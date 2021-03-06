import { createMenu, createComponent } from '../utils/general';
import { GUEST, LOGGED } from './constants';
import { HeaderUser } from '../components/Layout';

const menus = {
    primary: [createMenu('/', 'Usuarios', 'team', LOGGED), createMenu('/appointments', 'Citas', 'calendar', LOGGED)],
    header: [createComponent(() => HeaderUser, LOGGED)],
};

export default menus;
