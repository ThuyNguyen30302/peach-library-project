import React, { useState, forwardRef, useImperativeHandle } from 'react';
import { Modal } from 'antd';
import CommonGrid from "../grid/CommonGrid";

const BaseModal = forwardRef((props, ref) => {
  const [visible, setVisible] = useState(false);
  const [content, setContent] = useState(null);
  const [title, setTitle] = useState('');
  const [width, setWidth] = useState('850px');

  useImperativeHandle(ref, () => ({
    onOpen(content, title, width) {
      setContent(content);
      setTitle(title);
      setWidth(width);
      setVisible(true);
    },
    onClose() {
      setVisible(false);
    }
  }));

  return (
    <Modal
      title={title}
      visible={visible}
      // forceRender={true}
      destroyOnClose={true}
      onCancel={() => setVisible(false)}
      width={width}
      footer={null}
    >
      {content}
    </Modal>
  );
});

BaseModal.displayName = 'BaseModal';
export default BaseModal;
