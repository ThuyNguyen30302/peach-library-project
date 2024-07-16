import React, {useEffect, useRef, useState} from 'react';
import {Form, Input, Select} from "antd";
import BaseForm from "../../../common/core/Form/BaseForm";
import CustomDatePicker from "../../../common/DatePicker/CustomDatePicker";
import dayjs from "dayjs";
import moment from "moment";
import useMergeState from "../../../custom-hook/useMergeState";
import _ from "lodash";

const itemsLayout = {
  labelCol: {flex: '130px'},
};

const CheckOutCreateForm = (props) => {
  const formRef = useRef(null);

  const beforeSave = (data) => {
    const startTime = _.get(data, 'startTime');
    const endTime = _.get(data, 'endTime');
    _.set(data, 'startTime', startTime.format('YYYY-MM-DD'));
    _.set(data, 'endTime', endTime.format('YYYY-MM-DD'));
    return data;
  }

  const onChangeStartTime = (date, dateString) => {
    formRef.current.setFieldValue('endTime', dayjs(date).add(7, 'day'));
  }


  const renderBody = () => {
    return <div className="grid grid-cols-2 gap-x-4">
      <Form.Item
        name="memberId"
        label="Thành viên"
        rules={[{
          required: true,
        }]}
        className={'col-span-1'}
      >
        <Select options={props.comboOptionMember}/>
      </Form.Item>
      <Form.Item
        name="bookCopyId"
        label="Sách"
        rules={[{
          required: true,
        }]}
        className={'col-span-1'}
      >
        <Select options={props.comboOptionBook}/>
      </Form.Item>
      <Form.Item
        name="startTime"
        label="Ngày mượn"
        rules={[{
          required: true,
        }]}
        className={'col-span-1'}
      >
        <CustomDatePicker type={'date'}
                          format={'DD-MM-YYYY'}
                          style={{width: '100%'}}
                          onChange={onChangeStartTime}
        />
      </Form.Item>
      <Form.Item
        name="endTime"
        label="Hạn trả"
        rules={[{
          required: true,
        }]}
        className={'col-span-1'}
        getValueProps={(e) => {
          return ({value: e})
        }}
      >
        <CustomDatePicker type={'date'}
                          format={'DD-MM-YYYY'}
                          style={{width: '100%'}}/>
      </Form.Item>
    </div>
  };

  return (
    <div>
      <BaseForm
        ref={formRef}
        apiSave={props?.apiSave}
        reloadData={props.reloadData}
        onClose={() => props.onClose()}
        beforeSave={beforeSave}
        {...itemsLayout}
      >
        {renderBody()}
      </BaseForm>
    </div>
  );
};

export default CheckOutCreateForm;