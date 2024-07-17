import React, {useRef} from 'react';
import {DatePicker, Form, Input, Select} from "antd";
import BaseForm from "../../../common/core/Form/BaseForm";
import CustomDatePicker from "../../../common/DatePicker/CustomDatePicker";
import _ from "lodash";
import dayjs from "dayjs";

const itemsLayout = {
  labelCol: {flex: '130px'},
};

const MemberUpdateForm = (props) => {
  const formRef = useRef(null);

  const beforeSetValue = (data) => {
    _.set(data, 'dob', dayjs(_.get(data, 'dob')));

    return data;
  };

  const beforeSave = (data) => {
    _.set(data, "dob", dayjs(data.dob).format("YYYY-MM-DD"));
    return data;
  };

  const renderBody = () => {
    return (
      <div className={"grid grid-cols-2 gap-x-4"}>
        <Form.Item
          name="name"
          label="Tên thành viên"
          rules={[
            {
              required: true,
            },
          ]}
          className={"col-span-1"}
        >
          <Input />
        </Form.Item>
        <Form.Item
          name="cardNumber"
          label="CCCD/CMND"
          rules={[
            {
              required: true,
            },
          ]}
          className={"col-span-1"}
        >
          <Input
            onKeyPress={(event) => {
              if (!/[0-9]/.test(event.key)) {
                event.preventDefault();
              }
            }}
          />
        </Form.Item>
        <Form.Item
          name="phoneNumber"
          label="SĐT"
          rules={[
            {
              required: true,
            },
          ]}
          className={"col-span-1"}
        >
          <Input
            onKeyPress={(event) => {
              if (!/[0-9]/.test(event.key)) {
                event.preventDefault();
              }
            }}
          />
        </Form.Item>
        <Form.Item
          name="userName"
          label="Tên tài khoản"
          rules={[
            {
              required: true,
            },
          ]}
          className={"col-span-1"}
        >
          <Input />
        </Form.Item>
        <Form.Item
          name="status"
          label="Trạng thái"
          rules={[
            {
              required: true,
            },
          ]}
          className={"col-span-1"}
        >
          <Select name="status" options={props.comboMemberStatus} />
        </Form.Item>
        <Form.Item
          name="email"
          label="E-mail"
          rules={[
            {
              type: "email",
              message: "E-mail không hợp lệ!",
            },
            {
              required: true,
            },
          ]}
        >
          <Input />
        </Form.Item>
        <Form.Item
          name="dob"
          label="Ngày sinh"
          rules={[
            {
              required: true,
            },
          ]}
          className={"col-span-1"}
        >
          <DatePicker
            showTime={false}
            format={"DD-MM-YYYY"}
            style={{ width: "100%" }}
          />
        </Form.Item>
        <Form.Item
          name="address"
          label="Địa chỉ"
          rules={[
            {
              required: true,
            },
          ]}
          className={"col-span-1"}
        >
          <Input />
        </Form.Item>
      </div>
    );
  };

  return (
    <div>
      <BaseForm
        ref={formRef}
        reloadData={props.reloadData}
        apiDetail={props.apiDetail}
        apiSave={props.apiSave}
        beforeSetValue={beforeSetValue}
        beforeSave={beforeSave}
        id={props?.id}
        {...itemsLayout}
        onClose={() => props.onClose()}
      >
        {renderBody()}
      </BaseForm>
    </div>
  );
};

export default MemberUpdateForm;