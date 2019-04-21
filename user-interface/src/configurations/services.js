export const authentication = {
    login: '/Authentication/Authenticate',
};

export const users = {
    list: '/Patient/List',
    get: '/Patient/Get',
    remove: '/Patient/Delete',
    create: '/Patient/Create',
    update: '/Patient/Update',
    documentTypes: '/DocumentType/List'
};

export const appointments = {
    list: '/Appointment/List',
    get: '/Appointment/Get',
    remove: '/Appointment/Delete',
    create: '/Appointment/Create',
    update: '/Appointment/Update',
    appointmentTypes: '/AppointmentType/List',
    patients: '/Patient/List'
};