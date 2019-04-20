import React, { useState, useEffect } from 'react';
import { get, documentTypes as listDocuments } from '../../../services/users';
import Axios from 'axios';

function useForm(id) {
  const [patient, setPatient] = useState(null);
  const [documentTypes, setDocumentTypes] = useState(null);
  const [loading, setLoading] = useState(false);

  useEffect(() => {
    setLoading(true);
    Axios.all([get(id), listDocuments()])
      .then(([users, documents]) => {
        setLoading(false);
        setPatient(users.data || {});
        setDocumentTypes(documents.data || []);
      })
      .catch(e => {
        setLoading(false);
        console.log(e);
      });
  }, []);

  return { patient, documentTypes, loading };
}

export default useForm;
