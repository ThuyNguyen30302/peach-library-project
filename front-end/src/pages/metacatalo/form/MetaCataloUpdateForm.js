import React, {useRef} from 'react';
import {Form, Input} from "antd";
import BaseForm from "../../../common/core/Form/BaseForm";

const MetaCataloUpdateForm = (props) => {
  const formRef = useRef(null);

  const handleInput = (e) => {
    e.target.value = e.target.value.toUpperCase();
  };

  const renderBody = () => {
    return <div className={'grid grid-cols-2 gap-x-4'}>
      <Form.Item
        name="name"
        label="Tên"
        rules={[{
          required: true,
        }]}
        className={'col-span-1'}
      >
        <Input />
      </Form.Item>
      <Form.Item
        name="code"
        label="Mã"
        rules={[{
          required: true,
        }]}
        className={'col-span-1'}
      >
        <Input onInput={handleInput} />
      </Form.Item>
      <Form.Item
        name="description"
        label="Mô tả"
        className={'col-span-2'}
      >
        <Input.TextArea />
      </Form.Item>
    </div>
  };

  return (
    <div>
      <BaseForm
        ref={formRef}
        reloadData={props.reloadData}
        apiDetail={props.apiDetail}
        apiSave={props.apiSave}
        id={props?.id}
        onClose={() => props.onClose()}
      >
        {renderBody()}
      </BaseForm>
    </div>
  );
};

export default MetaCataloUpdateForm;