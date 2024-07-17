import React, {useState, forwardRef, useImperativeHandle, useEffect} from 'react';
import {Button, Form, message, Spin} from "antd";
import {AUTHOR_CREATE_API} from "../../../pages/author/api/AuthorApi";
import {useRequest} from "../../../custom-hook/useRequest";
import _ from "lodash";
import '../../../style/button-style.scss';


const validateMessages = {
  required: '${label} là bắt buộc!',
}

const itemsLayout = {
  labelCol: {flex: '120px'},
};


const BaseForm = forwardRef((props, ref) => {
  const {get, post} = useRequest()
  const [loading, setLoading] = useState(false);
  const [form] = Form.useForm();

  const buttons = [{
    title: "Đóng", tooltip: "Đóng", onClick: async () => {
      props.onClose() ?? onClose();
    }, className: "btn-close",
  }, {
    title: "Lưu", tooltip: "Lưu", onClick: async () => {
      props.onSave ? props.onSave() : onSave();
    }, className: "btn-save",
  }];

  useImperativeHandle(ref, () => ({
    onMask: () => onMask(),
    unMask: () => unMask(),
    formRef: form,
    validateFields: form.validateFields,
    getFieldsValue: form.getFieldsValue,
    getFieldValue: form.getFieldValue,
    setFieldsValue: form.setFieldsValue,
    setFieldValue: form.setFieldValue,
  }));

  const onMask = () => {
    setLoading(true)
  };

  const unMask = () => {
    setLoading(false)
  };

  useEffect(() => {
    props?.apiDetail && fetchData();
  }, []);

  const beforeSetValue = (data) => {
    return data;
  };

  const fetchData = async () => {
    onMask();
    try {
      get(props?.apiDetail + '/' + props?.id)
        .then((res) => {
          if (res?.success) {
              const value = props?.beforeSetValue ? props.beforeSetValue(res?.data) : beforeSetValue(res?.data);
              form.setFieldsValue(value);
          } else if (res.success) {
          } else {
          }
        })
        .catch((error) => {
          console.log(error);
        });
    } catch (error) {
      console.log(error);
    }
    unMask();
  }

  const beforeSave = (data) => {
    return data;
  };

  const onSave = async () => {
    onMask();
    try {
      let values = await form.validateFields();
      values = props.beforeSave ? props.beforeSave(values) : beforeSave(values);
      const apiSave = !props.id?props.apiSave:props.apiSave + '/' + props.id;
      post(apiSave, values)
        .then((res) => {
          if (res?.success) {
            props.reloadData && props.reloadData();
            props.onClose && props.onClose();
            message.success('Thành công');
          } else {
            message.error('Thất bại! ' + res?.message);
          }
        })
        .catch((error) => {
          message.error('Thất bại');
          console.log(error);
        });
    } catch (error) {
      message.error('Thất bại');
    }
    unMask();
  };

  const onClose = () => {
    props.onClose && props.onClose();
  };

  const renderBody = (value) => {

  }

  return (<Spin spinning={loading} tip="Đang tải dữ liệu...">
    <div className="base-form">
      <Form form={form}
            labelAlign="left"
            layout={'horizontal'}
            colon={false}
            validateMessages={validateMessages}
            {...itemsLayout}
            {...props}
            validateTrigger={'onBlur'}
      >
        {props.children ?? renderBody()}
      </Form>
      {props?.buttons ?? <div className={'my-btn-form flex justify-center gap-3'}>
        {buttons.map((button, index) => <Button key={index}
                                                tooltip={button.tooltip}
                                                className={button.className}
                                                onClick={() => button.onClick()}>{button.title}</Button>)}
      </div>}
    </div>
  </Spin>);
});

export default BaseForm;
