import { useState, useEffect } from 'react';
import { useAuthenticated } from '../../Authentication/Hooks';
import { GUEST, LOGGED } from '../../../configurations/constants';
import { menus as myMenus } from '../../../configurations/';

function useMenu(position) {
  const { authenticated } = useAuthenticated();
  const [menus, setMenus] = useState(myMenus[position]);

  useEffect(() => {
    setMenus(
      myMenus[position].filter(menu => {
        return (
          menu.when === undefined ||
          (authenticated === false && menu.when === GUEST) ||
          (authenticated === true && menu.when === LOGGED)
        );
      }),
    );
  }, [authenticated, position]);

  return menus;
}

export default useMenu;
