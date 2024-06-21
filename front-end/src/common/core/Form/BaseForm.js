import React, {useState, forwardRef, useImperativeHandle, useEffect} from 'react';
import {Button, Form, Spin} from "antd";
import {AUTHOR_CREATE_API} from "../../../pages/author/api/AuthorApi";
import {useRequest} from "../../../custom-hook/useRequest";

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
    }, className: "my-btn-close",
  }, {
    title: "Lưu", tooltip: "Lưu", onClick: async () => {
      props.onSave ? props.onSave() : onSave();
    }, className: "my-btn-save",
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

  const fetchData = async () => {
    onMask();
    try {
      get(props?.apiDetail + '/' + props?.id)
        .then((res) => {
          if (res?.success) {
              form.setFieldsValue(res.data);
            // props.reloadData && props.reloadData();
            // props.onClose && props.onClose();
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

  const onSave = async () => {
    onMask();
    try {
      const values = await form.validateFields();
      const apiSave = !props.id?props.apiSave:props.apiSave + '/' + props.id;
      post(apiSave, values)
        .then((res) => {
          if (res?.success) {
            console.log(props)
            props.reloadData && props.reloadData();
            props.onClose && props.onClose();
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
  };

  const onClose = () => {
    props.onClose && props.onClose();
  };

  const renderBody = (value) => {

  }

  return (<Spin spinning={loading} tip="Đang tải dữ liệu...">
    <Form form={form} {...props}
          labelAlign="left"
          layout={'horizontal'}
          colon={false}
          validateMessages={validateMessages}
          {...itemsLayout}
          validateTrigger={'onBlur'}>
      {props.children ?? renderBody()}
    </Form>
    {props?.buttons ?? <div className={'my-btn-form'}>
      {buttons.map((button, index) => <Button key={index}
                                              tooltip={button.tooltip}
                                              className={button.className}
                                              onClick={() => button.onClick()}>{button.title}</Button>)}
    </div>}
  </Spin>);
});

export default BaseForm;