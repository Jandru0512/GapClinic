import React from 'react';
import PropTypes from 'prop-types';
import { List } from '../components/Users';

const Users = props => {
  const { history } = props;
  return <List history={history} />;
};

Users.propTypes = {
  history: PropTypes.object,
};

export default Users;
