import { useState, useEffect } from 'react';
import { store } from '../../../configurations';

function useAuthenticated() {
  const [authentication, setAuthentication] = useState(
    store.getState().authentication,
  );

  useEffect(() => {
    const unsubscribe = store.subscribe(() => {
      const newAuthentication = store.getState().authentication;
      if (authentication !== newAuthentication) {
        setAuthentication(newAuthentication);
      }
    });
    return unsubscribe;
  }, [authentication]);
  return { ...(authentication || {}) };
}

export default useAuthenticated;
