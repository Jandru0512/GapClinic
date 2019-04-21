import instance from './instance';
import { appointments } from '../configurations/services';

export const list = () => instance.get(appointments.list);

export const get = id =>
    instance.get(appointments.get, {
        params: {
            appointmentId: id,
        },
    });

export const create = appointment => instance.post(appointments.create, appointment);

export const update = appointment => instance.post(appointments.update, appointment);

export const remove = id =>
    instance.delete(appointments.remove, {
        params: {
            appointmentId: id,
        },
    });

export const appointmentTypes = () => instance.get(appointments.appointmentTypes);

export const patients = () => instance.get(appointments.patients);
