import { Button, Form, Icon, Input } from 'antd';
import PropTypes from 'prop-types';
import React from 'react';
import { Title } from '../Shared';

function Login(props) {
  const { loading } = props;
  const { getFieldDecorator } = props.form;
  const handleSubmit = e => {
    e.preventDefault();
    props.form.validateFields((err, values) => {
      if (!err) {
        props.authentication(values.userName, values.password);
      }
    });
  };

  return (
    <Form onSubmit={handleSubmit} className="custom-form-login">
      <Title text="Iniciar Sesión" />
      <Form.Item>
        {getFieldDecorator('userName', {
          rules: [
            { required: true, message: 'Nombre de usuario requerido.' },
            { type: 'email', message: 'Correo electrónico no válido.' },
          ],
        })(
          <Input
            prefix={<Icon type="user" className="custom-prefix-icon" />}
            placeholder="Ingrese correo electrónico"
            size="large"
          />,
        )}
      </Form.Item>
      <Form.Item>
        {getFieldDecorator('password', {
          rules: [{ required: true, message: 'Contraseña requerida.' }],
        })(
          <Input
            prefix={<Icon type="lock" className="custom-prefix-icon" />}
            type="password"
            size="large"
            placeholder="Ingrese la contraseña."
          />,
        )}
      </Form.Item>
      <Form.Item>
        <Button
          type="primary"
          size="large"
          htmlType="submit"
          loading={loading}
          className="custom-button">
          Iniciar Sesión
        </Button>
      </Form.Item>
    </Form>
  );
}

const formShape = {
  validateFields: PropTypes.func,
  getFieldDecorator: PropTypes.func,
};

Login.propTypes = {
  form: PropTypes.shape(formShape).isRequired,
  loading: PropTypes.bool,
  authentication: PropTypes.func,
};

export default Form.create({ name: 'normal_login' })(Login);
