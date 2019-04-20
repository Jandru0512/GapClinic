import React, { useState, useEffect } from 'react';
import { list } from '../../../services/users';

function useList() {
  const [dataSource, setDataSource] = useState([]);
  const [loading, setLoading] = useState(false);

  useEffect(() => {
    setLoading(true);
    list()
      .then(response => {
        setLoading(false);
        setDataSource(response.data);
      })
      .catch(e => {
        setLoading(false);
        console.log(e);
      });
  }, []);

  return { dataSource, setDataSource, loading };
}

export default useList;
