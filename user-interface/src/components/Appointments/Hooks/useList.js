import React, { useState, useEffect } from 'react';
import { list } from '../../../services/appointments';

function useList() {
  const [dataSource, setDataSource] = useState([]);
  const [loading, setLoading] = useState(false);

  useEffect(() => {
    setLoading(true);
    list()
      .then(response => {
        setLoading(false);
        console.log(response.data);
        setDataSource(response.data.map(x => ({
          ...x,
          name: `${x.patient.name} ${x.patient.lastName}`,
          hour: x.date.split('T')[1],
          date: x.date.split('T')[0]
        })));
      })
      .catch(e => {
        setLoading(false);
        console.log(e);
      });
  }, []);

  return { dataSource, setDataSource, loading };
}

export default useList;
