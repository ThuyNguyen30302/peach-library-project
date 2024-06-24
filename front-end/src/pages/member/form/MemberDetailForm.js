import React, {useRef} from 'react';
import {Form, Input} from "antd";
import BaseForm from "../../../common/core/Form/BaseForm";

const itemsLayout = {
  // labelCol: {flex: '130px'},
};

const MemberDetailForm = (props) => {
  const formRef = useRef(null);

  const renderBody = () => {
    return <>
      <Form.Item
        name="name"
        label="Tên nhà phát hành"
        rules={[{
          required: true,
        }]}
      >
        <Input readOnly/>
      </Form.Item>
      <Form.Item
        name="code"
        label="Mã"
        rules={[{
          required: true,
        }]}
      >
        <Input readOnly />
      </Form.Item>
    </>
  };

  return (
    <div>
      <BaseForm
        ref={formRef}
        reloadData={props.reloadData}
        apiDetail={props.apiDetail}
        apiSave={props.apiSave}
        id={props?.id}
        {...itemsLayout}
        variant={"borderless"}
        onClose={() => props.onClose()}
      >
        {renderBody()}
      </BaseForm>
    </div>
  );
};

export default MemberDetailForm;