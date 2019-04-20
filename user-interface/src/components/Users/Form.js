import React, { Fragment } from 'react';
import { withRouter } from 'react-router-dom';
import { Form as FormAntd, InputNumber, Input, Button, Col, Row, Select, Switch, DatePicker } from 'antd';
import { Title } from '../Shared';
import moment from 'moment';

const formItemLayout = {
  labelCol: {
    xs: { span: 24 },
    sm: { span: 4 },
  },
  wrapperCol: {
    xs: { span: 24 },
    sm: { span: 8 },
  },
};

const Form = ({ form, history, patient, documentTypes, onSubmit, loading }) => {
  const { getFieldDecorator } = form;

  const submit = e => {
    e.preventDefault();
    onSubmit(form);
  }

  const disabledDate = current => {
    return current > moment().endOf('day');
  }

  return (
    <Fragment>
      <Title text="Usuario" />
      <FormAntd onSubmit={submit} layout="horizontal" hideRequiredMark>
        <FormAntd.Item key="documentTypeId" label="Tipo de documento" {...formItemLayout}>
          {getFieldDecorator('documentTypeId', {
            initialValue: patient.documentTypeId,
            rules: [
              {
                required: true,
                message: 'Seleccione el tipo de documento.'
              }
            ]
          })(<Select>
            {documentTypes.map(documentType =>
              <Select.Option value={documentType.documentTypeId}>{documentType.name}</Select.Option>
            )}
          </Select>)}
        </FormAntd.Item>
        <FormAntd.Item key="document" label="Documento" {...formItemLayout}>
          {getFieldDecorator('document', {
            initialValue: patient.document,
            rules: [
              {
                required: true,
                message: 'Documento requerido.',
              },
              {
                type: 'number',
                message: 'El documento debe ser numérico.'
              }
            ],
          })(<InputNumber className="custom-number-input" />)}
        </FormAntd.Item>
        <FormAntd.Item key="name" label="Nombres" {...formItemLayout}>
          {getFieldDecorator('name', {
            initialValue: patient.name,
            rules: [
              {
                required: true,
                message: 'Nombre requerido.',
              },
            ],
          })(<Input />)}
        </FormAntd.Item>
        <FormAntd.Item key="lastName" label="Apellidos" {...formItemLayout}>
          {getFieldDecorator('lastName', {
            initialValue: patient.lastName,
            rules: [
              {
                required: true,
                message: 'Apellidos requeridos.',
              },
            ],
          })(<Input />)}
        </FormAntd.Item>
        <FormAntd.Item key="email" label="Correo electrónico" {...formItemLayout}>
          {getFieldDecorator('email', {
            initialValue: patient.email,
            rules: [
              {
                type: 'email',
                message: 'Formato no válido.'
              }
            ]
          })(<Input />)}
        </FormAntd.Item>
        <FormAntd.Item key="status" label="Estado" {...formItemLayout}>
          {getFieldDecorator('status', {
            initialValue: patient.status
          })(<Switch defaultChecked />)}
        </FormAntd.Item>
        <FormAntd.Item key="birthdate" label="Fecha de nacimiento" {...formItemLayout}>
          {getFieldDecorator('birthdate', {
            initialValue: moment(patient.birthDate)
          })(<DatePicker
            Format="YYYY/MM/DD"
            disabledDate={disabledDate}
          />)}
        </FormAntd.Item>
        <Row gutter={8}>
          <Col
            sm={{ span: 3, offset: 3 }}
            xs={{ span: 24 }}
            className="custom-align-right">
            <Button
              size="large"
              className="custom-full-width"
              onClick={() => history.goBack()}>
              Cancel
            </Button>
          </Col>
          <Col sm={{ span: 3 }} xs={{ span: 24 }}>
            <Button
              htmlType="submit"
              type="primary"
              size="large"
              loading={loading}
              className="custom-full-width">
              Save
            </Button>
          </Col>
        </Row>
      </FormAntd>
    </Fragment>
  );
};

export default withRouter(FormAntd.create({})(Form));
