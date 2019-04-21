import React, { useState } from 'react';
import { withRouter } from 'react-router-dom';
import PropTypes from 'prop-types';
import { Form } from '../components/Appointments';
import { useForm } from '../components/Appointments/Hooks';
import { message } from '../utils';
import { update, create } from '../services/appointments';
import { Spin } from 'antd';

const Appointment = ({ match, history }) => {
  const id = match.params.id;
  const { appointment, appointmentTypes, patients, loading } = useForm(id);
  const [loadingForm, setLoadingForm] = useState(false);

  const response = (msg, redirect = false) => {
    message(msg);
    setLoadingForm(false);

    if (redirect) {
      history.push('/appointments');
    }
  }

  const onSubmit = form => {

    form.validateFields((err, values) => {
      if (!err) {
        if (appointment && appointment.patientId) {
          const newAppointment = {
            ...appointment,
            appointmentTypeId: values.appointmentTypeId,
            patientId: values.patientId,
            status: values.status,
            date: values.date.format()
          };
          update(newAppointment)
            .then(res => {
              response('Cita modificada con éxito.', true);
            })
            .catch(err => {
              response(err.response.data);
            });
        } else {
          create(values)
            .then(res => {
              response('Cita creada con éxito.', true);
            })
            .catch(err => {
              response(err.response.data);
            });
        }
      }
    });
  };

  if (!appointment || !appointmentTypes || !patients) {
    return <Spin
      size="large"
      spinning={loading}
      className="custom-layout-spin" />
  }
  return <Form
    appointment={appointment}
    appointmentTypes={appointmentTypes}
    patients={patients}
    onSubmit={onSubmit}
    loading={loadingForm} />;
};

Appointment.propTypes = {
  match: PropTypes.object,
};

export default withRouter(Appointment);
