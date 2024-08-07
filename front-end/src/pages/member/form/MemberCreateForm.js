import React, {useEffect, useRef, useState} from 'react';
import {Form, Input, Select} from "antd";
import BaseForm from "../../../common/core/Form/BaseForm";
import _ from "lodash";
import CustomDatePicker from "../../../common/DatePicker/CustomDatePicker";

const itemsLayout = {
  labelCol: {flex: '120px'},
};

const MemberCreateForm = (props) => {
  const formRef = useRef(null);

  const handlePhoneNumberChange = (event) => {
    const value = event.target.value;
    formRef.current?.setFieldsValue({userName: value});
  };

  const renderBody = () => {
    return <div className={'grid grid-cols-2 gap-x-4'}>
      <Form.Item
        name="name"
        label="Tên thành viên"
        rules={[{
          required: true,
        }]}
        className={'col-span-1'}
      >
        <Input/>
      </Form.Item>
      <Form.Item
        name="cardNumber"
        label="CCCD/CMND"
        rules={[{
          required: true,
        }]}
        className={'col-span-1'}
      >
        <Input onKeyPress={(event) => {
          if (!/[0-9]/.test(event.key)) {
            event.preventDefault();
          }
        }}/>
      </Form.Item>
      <Form.Item
        name="phoneNumber"
        label="SĐT"
        rules={[{
          required: true,
        }]}
        className={'col-span-1'}
      >
        <Input onChange={handlePhoneNumberChange}
               onKeyPress={(event) => {
                 if (!/[0-9]/.test(event.key)) {
                   event.preventDefault();
                 }
               }}/>
      </Form.Item>
      <Form.Item
        name="userName"
        label="Tên tài khoản"
        rules={[{
          required: true,
        }]}
        className={'col-span-1'}
      >
        <Input/>
      </Form.Item>
      <Form.Item
        name="password"
        label="Mật khẩu"
        rules={[{
          required: true,
        }]}
        className={'col-span-1'}
      >
        <Input.Password />
      </Form.Item>
      <Form.Item
        name="status"
        label="Trạng thái"
        rules={[{
          required: true,
        }]}
        className={'col-span-1'}
      >
        <Select name="status" options={props.comboMemberStatus} />
      </Form.Item>
      <Form.Item
        name="email"
        label="E-mail"
        rules={[
          {
            type: 'email',
            message: 'E-mail không hợp lệ!',
          },
          {
            required: true,
          },
        ]}
      >
        <Input/>
      </Form.Item>
      <Form.Item
        name="age"
        label="Ngày sinh"
        rules={[{
          required: true,
        }]}
        className={'col-span-1'}
      >
        <CustomDatePicker type={'date'}
                          format={'DD-MM-YYYY'}
                          allowClear={false} showTime={false} />
      </Form.Item>
      <Form.Item
        name="address"
        label="Địa chỉ"
        rules={[{
          required: true,
        }]}
        className={'col-span-2'}
      >
        <Input />
      </Form.Item>
    </div>
  };

  return (
    <div>
      <BaseForm
        ref={formRef}
        initialValues={{
          status: 'ACTIVE'
        }}
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

export default MemberCreateForm;