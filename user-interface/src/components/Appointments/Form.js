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

const Form = ({ form, history, appointment, appointmentTypes, patients, onSubmit, loading }) => {
  const { getFieldDecorator } = form;

  const submit = e => {
    e.preventDefault();
    onSubmit(form);
  }

  const disabledDate = current => {
    return current <= moment();
  }

  return (
    <Fragment>
      <Title text="Cita" />
      <FormAntd onSubmit={submit} layout="horizontal" hideRequiredMark>
        <FormAntd.Item key="appointmentTypeId" label="Tipo de cita" {...formItemLayout}>
          {getFieldDecorator('appointmentTypeId', {
            initialValue: appointment.appointmentTypeId,
            rules: [
              {
                required: true,
                message: 'Seleccione el tipo de cita.'
              }
            ]
          })(<Select>
            {appointmentTypes.map(appointmentType =>
              <Select.Option value={appointmentType.appointmentTypeId}>{appointmentType.name}</Select.Option>
            )}
          </Select>)}
        </FormAntd.Item>
        <FormAntd.Item key="patientId" label="Paciente" {...formItemLayout}>
          {getFieldDecorator('patientId', {
            initialValue: appointment.patientId,
            rules: [
              {
                required: true,
                message: 'Seleccione el paciente.'
              }
            ]
          })(<Select>
            {patients.map(patient =>
              <Select.Option value={patient.patientId}>{patient.name} {patient.lastName}</Select.Option>
            )}
          </Select>)}
        </FormAntd.Item>
        <FormAntd.Item key="status" label="Estado" {...formItemLayout}>
          {getFieldDecorator('status', {
            initialValue: appointment.status
          })(<Switch defaultChecked />)}
        </FormAntd.Item>
        <FormAntd.Item key="date" label="Fecha de la cita" {...formItemLayout}>
          {getFieldDecorator('date', {
            initialValue: moment(appointment.date)
          })(<DatePicker
            showTime={{ format: 'HH:mm' }}
            Format="YYYY/MM/DD HH:mm"
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
