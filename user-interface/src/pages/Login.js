import React from 'react';
import { connect } from 'react-redux';
import { Login as LoginForm } from '../components/Authentication';

const Login = props => {
  return <LoginForm {...props} />;
};

const mapState = state => ({
  loading: state.loading.effects.authentication.authentication,
});

const mapDispatch = dispatch => ({
  authentication: (username, password) =>
    dispatch.authentication.authentication({ username, password }),
});

export default connect(
  mapState,
  mapDispatch,
)(Login);
