import React from 'react';
import PropTypes from 'prop-types';
import { List } from '../components/Appointments';

const Appointments = props => {
  const { history } = props;
  return <List history={history} />;
};

Appointments.propTypes = {
  history: PropTypes.object,
};

export default Appointments;
