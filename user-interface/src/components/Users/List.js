import React, { Fragment } from 'react';
import { Row, Col, Button, Table, Tooltip, Popconfirm } from 'antd';
import { list, remove } from '../../services/users';
import { Title } from '../Shared';
import { message } from '../../utils';
import { useList } from './Hooks';

const onDelete = async (id, setDataSource) => {
  await remove(id);
  const { data } = await list();
  setDataSource(data);
  message('Usuario eliminado con éxito');
};

const columns = (history, setDataSource) => [
  {
    title: 'Documento',
    dataIndex: 'document',
    key: 'document',
  },
  {
    title: 'Nombre',
    dataIndex: 'name',
    keu: 'name',
  },
  {
    title: 'Apellido',
    dataIndex: 'lastName',
    keu: 'lastName',
  },
  {
    title: 'Acciones',
    key: '',
    align: 'right',
    width: 45 * 2,
    render: (value, record) => (
      <>
        <Tooltip key="Edit" title="Editar">
          <Button
            type="primary"
            shape="circle"
            icon="edit"
            onClick={() => history.push(`/user/${record.patientId}`)}
          />
        </Tooltip>
        <Tooltip key="Delete" title="Eliminar">
          <Popconfirm
            title="¿Está seguro que desea eliminar el usuario?"
            placement="bottomRight"
            onConfirm={() => onDelete(record.patientId, setDataSource)}>
            <Button type="danger" shape="circle" icon="delete" />
          </Popconfirm>
        </Tooltip>
      </>
    ),
  },
];

const List = ({ history }) => {
  const { dataSource, setDataSource } = useList();

  return (
    <Fragment>
      <Row type="flex" align="middle" justify="space-between">
        <Col>
          <Title text="Usuarios" />
        </Col>
        <Col>
          <Button
            size="large"
            type="primary"
            onClick={() => history.push('/user/0')}>
            Agregar
          </Button>
        </Col>
      </Row>
      <Table
        className="custom-table"
        scroll={{ x: true }}
        columns={columns(history, setDataSource)}
        dataSource={dataSource}
      />
    </Fragment>
  );
};

export default List;
