import React, {useRef} from 'react';
import {Form, Input} from "antd";
import BaseForm from "../../../common/core/Form/BaseForm";

const itemsLayout = {
  labelCol: {flex: '130px'},
};

const CheckOutCreateForm = (props) => {
  const formRef = useRef(null);

  const handleInput = (e) => {
    e.target.value = e.target.value.toUpperCase();
  };

  const renderBody = () => {
    return <>
      <Form.Item
        name="name"
        label="Tên nhà phát hành"
        rules={[{
          required: true,
        }]}
      >
        <Input />
      </Form.Item>
      <Form.Item
        name="code"
        label="Mã"
        rules={[{
          required: true,
        }]}
      >
        <Input onInput={handleInput} />
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
        {...itemsLayout}
      >
        {renderBody()}
      </BaseForm>
    </div>
  );
};

export default CheckOutCreateForm;