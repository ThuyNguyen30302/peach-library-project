import React, {useEffect, useRef, useState} from 'react';
import {Checkbox, DatePicker, Form, Input, Select, Spin} from "antd";
import BaseForm from "../../../common/core/Form/BaseForm";
import CustomDatePicker from "../../../common/DatePicker/CustomDatePicker";
import dayjs from "dayjs";
import moment from "moment";
import useMergeState from "../../../custom-hook/useMergeState";
import _ from "lodash";
import {BOOK_COMBO_OPTION_CAN_BORROW_API, BOOK_COMBO_OPTION_CAN_BORROW_FOR_UPDATE_API} from "../../book/api/BookApi";
import {MEMBER_COMBO_OPTION_API, MEMBER_COMBO_OPTION_CAN_BORROW_API} from "../../member/api/MemberApi";
import {useRequest} from "../../../custom-hook/useRequest";
import {useSelector} from "react-redux";

const itemsLayout = {
  labelCol: {flex: '130px'},
};

const UpdateRequestBorrowForm = (props) => {
  const formRef = useRef(null);
  const {get} = useRequest();

  const [state, setState] = useMergeState({
    comboOptionBook: [],
    comboOptionMember: [],
    loading: true,
  });

  useEffect(() => {
    loadCombo();
  }, []);

  const loadCombo = async () => {
    Promise.all([
      get(BOOK_COMBO_OPTION_CAN_BORROW_FOR_UPDATE_API + "/" + props.id),
      get(MEMBER_COMBO_OPTION_API),
    ]).then(([resComboBook, resComboMember]) => {
      if (resComboBook?.success && resComboMember?.success) {
        const responseComboBook = resComboBook?.data;
        const responseComboMember = resComboMember?.data;
        if (responseComboBook && responseComboMember) {
          setState({
            comboOptionBook: responseComboBook,
            comboOptionMember: responseComboMember,
            loading: false
          });
        }
      }
    });
  };

  const beforeSetValue = (data) => {
    _.set(data, "startTime", dayjs(_.get(data, 'startTime')));
    _.set(data, "endTime", dayjs(_.get(data, 'endTime')));

    return data;
  };
  const beforeSave = (data) => {
    console.log(data)
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
        <Select filterOption={(input, option) => (option?.label ?? '').toLowerCase().includes(input.toLowerCase())}
                showSearch options={state.comboOptionMember}
                disabled={true}/>
      </Form.Item>
      <Form.Item
        name="bookCopyId"
        label="Sách"
        rules={[{
          required: true,
        }]}
        className={'col-span-1'}
      >
        <Select filterOption={(input, option) => (option?.label ?? '').toLowerCase().includes(input.toLowerCase())}
                showSearch options={state.comboOptionBook}/>
      </Form.Item>
      <Form.Item
        name="startTime"
        label="Ngày mượn"
        rules={[{
          required: true,
        }]}
        className={'col-span-1'}
      >
        <DatePicker showTime={false}
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
      >
        <DatePicker showTime={false}
                    format={'DD-MM-YYYY'}
                    style={{width: '100%'}}
        />
      </Form.Item>
    </div>
  };

  if (state.loading) {
    return (
      <div className="ag-theme-alpine"
           style={{height: '100%', width: '100%', display: 'flex', justifyContent: 'center', alignItems: 'center'}}>
        <Spin size="large"/>
      </div>
    );
  }

  return (
    <div>
      <BaseForm
        ref={formRef}
        reloadData={props.reloadData}
        apiDetail={props.apiDetail}
        apiSave={props.apiSave}
        id={props?.id}
        beforeSetValue={beforeSetValue}
        beforeSave={beforeSave}
        {...itemsLayout}
        onClose={() => props.onClose()}
      >
        {renderBody()}
      </BaseForm>
    </div>
  );
};

export default UpdateRequestBorrowForm;