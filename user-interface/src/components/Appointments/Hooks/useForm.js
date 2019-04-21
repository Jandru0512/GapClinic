import React, { useState, useEffect } from 'react';
import { get, appointmentTypes as listTypes, patients as listPatients } from '../../../services/appointments';
import Axios from 'axios';

function useForm(id) {
  const [appointment, setAppointment] = useState(null);
  const [patients, setPatients] = useState(null);
  const [appointmentTypes, setAppointmentTypes] = useState(null);
  const [loading, setLoading] = useState(false);

  useEffect(() => {
    setLoading(true);
    Axios.all([get(id), listTypes(), listPatients()])
      .then(([appointments, documents, users]) => {
        setLoading(false);
        setAppointment(appointments.data || {});
        setAppointmentTypes(documents.data || []);
        setPatients(users.data || []);
      })
      .catch(e => {
        setLoading(false);
        console.log(e);
      });
  }, []);

  return { appointment, appointmentTypes, patients, loading };
}

export default useForm;
