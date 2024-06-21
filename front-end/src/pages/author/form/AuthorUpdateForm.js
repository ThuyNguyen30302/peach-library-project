import React, {useRef} from 'react';
import {Form, Input} from "antd";
// import ToastUtil from "../../../util/ToastUtil";
import {useRequest} from "../../../custom-hook/useRequest";
import BaseForm from "../../../common/core/Form/BaseForm";

const AuthorUpdateForm = (props) => {
  const formRef = useRef(null);
  const {post} = useRequest()

  const renderBody = () => {
    return <>
      <Form.Item
        name="name"
        label="Tên thật tác giả"
        rules={[{
          required: true,
          // message: "Tài khoản là bắt buộc!"
        }]}
      >
        <Input />
      </Form.Item>
      <Form.Item
        name="nickName"
        label="Bút danh"
        rules={[{
          required: true,
          // message: "Tài khoản là bắt buộc!"
        }]}
      >
        <Input />
      </Form.Item>
    </>
  };

  console.log(props)
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

export default AuthorUpdateForm;