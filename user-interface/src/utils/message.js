import { Modal } from 'antd';

const showMessage = (message, type = 'info', duration = 2) => {
  Modal[type]({
    content: message,
    okText: 'Ok',
  });
};

export default showMessage;
