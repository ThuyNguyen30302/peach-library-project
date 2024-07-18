import React, {useRef} from 'react';
import {DatePicker, Form, Input, Select} from "antd";
import BaseForm from "../../../common/core/Form/BaseForm";
import CustomDatePicker from "../../../common/DatePicker/CustomDatePicker";
import _ from "lodash";
import dayjs from "dayjs";

const itemsLayout = {
  // labelCol: {flex: '130px'},
};

const MemberDetailForm = (props) => {
  const formRef = useRef(null);

  const beforeSetValue = (data) => {
    _.set(data, 'dob', dayjs(_.get(data, 'dob')));

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
          <Input readOnly/>
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
          <Input readOnly
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
          <Input readOnly onKeyPress={(event) => {
            if (!/[0-9]/.test(event.key)) {
              event.preventDefault();
            }
          }}
          />
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
          <Select open={false} readOnly name="status" options={props.comboMemberStatus}/>
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
          <Input readOnly/>
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
          <DatePicker readOnly
                      showTime={false}
                      format={"DD-MM-YYYY"}
                      style={{width: "100%"}}
                      inputReadOnly={true}
                      open={false}
                      allowClear={false}
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
          <Input readOnly/>
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
        id={props?.id}
        beforeSetValue={beforeSetValue}
        {...itemsLayout}
        variant={"borderless"}
        onClose={() => props.onClose()}
        buttons={[{
          title: "Đóng",
          tooltip: "Đóng",
          onClick: async () => {
            props.onClose();
          }, className: "btn-close",
        }]}
      >
        {renderBody()}
      </BaseForm>
    </div>
  );
};

export default MemberDetailForm;