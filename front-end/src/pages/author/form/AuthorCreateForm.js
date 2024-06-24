import React, {useRef} from 'react';
import {Form, Input} from "antd";
import BaseForm from "../../../common/core/Form/BaseForm";

const AuthorCreateForm = (props) => {
  const formRef = useRef(null);

  const renderBody = () => {
    return <>
      <Form.Item
        name="name"
        label="Tên thật tác giả"
        rules={[{
          required: true,
        }]}
      >
        <Input />
      </Form.Item>
      <Form.Item
        name="nickName"
        label="Bút danh"
        rules={[{
          required: true,
        }]}
      >
        <Input />
      </Form.Item>
    </>
  };

  return (
    <div>
      <BaseForm
        ref={formRef}
        apiSave={props?.apiSave}
        reloadData={props.reloadData}
        onClose={() => props.onClose()}
      >
        {renderBody()}
      </BaseForm>
    </div>
  );
};

export default AuthorCreateForm;