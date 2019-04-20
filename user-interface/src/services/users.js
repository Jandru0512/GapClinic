import instance from './instance';
import { users } from '../configurations/services';

export const list = () => instance.get(users.list);

export const get = id =>
  instance.get(users.get, {
    params: {
      patientId: id,
    },
  });

export const create = patient => instance.post(users.create, patient);

export const update = patient => instance.post(users.update, patient);

export const remove = id =>
  instance.delete(users.remove, {
    params: {
      patientId: id,
    },
  });

export const documentTypes = () => instance.get(users.documentTypes);
