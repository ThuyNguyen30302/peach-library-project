import React, {useState, forwardRef, useImperativeHandle} from 'react';
import {Button, Form, Spin} from "antd";

const BaseForm = forwardRef((props, ref) => {
  const [loading, setLoading] = useState(false);
  const [form] = Form.useForm();
  const buttons = [{
    title: "Đóng", tooltip: "Đóng", onClick: async () => {
      props.onClose() ?? onClose()
    }, className: "my-btn-close",
  }, {
    title: "Lưu", tooltip: "Lưu", onClick: async () => {
      props.onSave() ?? onSave()
    }, className: "my-btn-save",
  }];

  useImperativeHandle(ref, () => ({
    onMask: () => setLoading(true),
    unMask: () => setLoading(false),
    formRef: form,
  }));

  const onSave = () => {
  };

  const onClose = () => {
  };

  const renderBody = (value) => {

  };

  return (<Spin spinning={loading}>
    <Form form={form} {...props}>
      {props.children ?? renderBody()}
    </Form>
    <div className={'my-btn-form'}>{buttons.map((button, index) => <Button key={index}
                                                                           tooltip={button.tooltip}
                                                                           className={button.className}
                                                                           onClick={() => button.onClick()}>{button.title}</Button>)}</div>
  </Spin>);
});

export default BaseForm;
