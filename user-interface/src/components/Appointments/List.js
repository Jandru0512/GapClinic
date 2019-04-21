import React, { Fragment } from 'react';
import { Row, Col, Button, Table, Tooltip, Popconfirm } from 'antd';
import { list, remove } from '../../services/appointments';
import { Title } from '../Shared';
import { message } from '../../utils';
import { useList } from './Hooks';

const onDelete = async (id, setDataSource) => {
    try {
        await remove(id);
        const { data } = await list();
        setDataSource(data);
        message('Cita cancelada con éxito');
    } catch (e) {
        message(e.response.data);
    }
};

const columns = (history, setDataSource) => [
    {
        title: 'Paciente',
        dataIndex: 'name',
        key: 'name',
    },
    {
        title: 'Fecha',
        dataIndex: 'date',
        keu: 'date',
    },
    {
        title: 'Hora',
        dataIndex: 'hour',
        keu: 'hour',
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
                        onClick={() => history.push(`/appointment/${record.appointmentId}`)}
                    />
                </Tooltip>
                <Tooltip key="Delete" title="Eliminar">
                    <Popconfirm
                        title="¿Está seguro que desea cancelar la cita?"
                        placement="bottomRight"
                        onConfirm={() => onDelete(record.appointmentId, setDataSource)}>
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
                    <Title text="Citas" />
                </Col>
                <Col>
                    <Button
                        size="large"
                        type="primary"
                        onClick={() => history.push('/appointment/0')}>
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
