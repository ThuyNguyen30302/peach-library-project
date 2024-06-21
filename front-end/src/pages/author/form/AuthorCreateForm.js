import React, {useRef} from 'react';
import {Form, Input} from "antd";
// import ToastUtil from "../../../util/ToastUtil";
import {useRequest} from "../../../custom-hook/useRequest";
import {AUTHOR_CREATE_API} from "../api/AuthorApi";
import BaseForm from "../../../common/core/Form/BaseForm";

const AuthorCreateForm = (props) => {
  const formRef = useRef(null);
  const {post} = useRequest()

  // const onSave = async () => {
  //   formRef.current?.onMask();
  //   try {
  //     const values = await formRef.current?.validateFields();
  //     post(AUTHOR_CREATE_API, values)
  //       .then((res) => {
  //         if (res?.success) {
  //           console.log('creat form', props)
  //           // ToastUtil.ToastCreateSuccess('Lưu thành công!');
  //           props.reloadData && props.reloadData();
  //           props.onClose && props.onClose();
  //         } else if (res.success) {
  //           // ToastUtil.ToastError('Thao tác không có quyền thực hiện');
  //         }  else {
  //           // ToastUtil.ToastError('Tạo mới không thành công!');
  //         }
  //       })
  //       .catch((error) => {
  //         console.log(error);
  //       })
  //       .finally(() => {
  //         formRef.current?.unMask();
  //       });
  //   } catch (error) {
  //     console.log(error);
  //   }
  //   formRef.current?.unMask();
  // };

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

  return (
    <div>
      <BaseForm
        ref={formRef}
        apiSave={props?.apiSave}
        reloadData={props.reloadData}
        onClose={() => props.onClose()}
      >
        {renderBody()}
      </BaseForm>
    </div>
  );
};

export default AuthorCreateForm;