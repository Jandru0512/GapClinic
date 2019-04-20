import React, { useState } from 'react';
import { withRouter } from 'react-router-dom';
import PropTypes from 'prop-types';
import { Form } from '../components/Users';
import { useForm } from '../components/Users/Hooks';
import { message } from '../utils';
import { update, create } from '../services/users';
import { Spin } from 'antd';

const User = ({ match, history }) => {
  const id = match.params.id;
  const { patient, documentTypes, loading } = useForm(id);
  const [loadingForm, setLoadingForm] = useState(false);

  const response = (msg, redirect = false) => {
    message(msg);
    setLoadingForm(false);

    if (redirect) {
      history.push('/');
    }
  }

  const onSubmit = form => {

    form.validateFields((err, values) => {
      if (!err) {
        if (patient && patient.patientId) {
          const newPatient = {
            ...patient,
            documentTypeId: values.documentTypeId,
            document: values.document,
            name: values.name,
            lastName: values.lastName,
            email: values.email,
            status: values.status,
            birthDate: values.birthdate.format()
          };
          update(newPatient)
            .then(res => {
              response('Usuario modificado con éxito.', true);
            })
            .catch(err => {
              response('Error al modificar el usuario');
            });
        } else {
          create(values)
            .then(res => {
              response('Usuario creado con éxito.', true);
            })
            .catch(err => {
              response('Error al crear el usuario');
            });
        }
      }
    });
  };

  if (!patient || !documentTypes) {
    return <Spin
      size="large"
      spinning={loading}
      className="custom-layout-spin" />
  }
  return <Form
    patient={patient}
    documentTypes={documentTypes}
    onSubmit={onSubmit}
    loading={loadingForm} />;
};

User.propTypes = {
  match: PropTypes.object,
};

export default withRouter(User);
