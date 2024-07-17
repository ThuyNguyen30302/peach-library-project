import React from 'react';
import {Form, Input, Button, Card, message} from 'antd';
import {LockOutlined} from '@ant-design/icons';
import {useRequest} from "../../custom-hook/useRequest";
import {Link, useNavigate} from "react-router-dom";
import {useSelector} from "react-redux";

const ChangePasswordView = () => {
  const [form] = Form.useForm();
  const {changePassword} = useRequest(); // Giả sử bạn có hàm này trong useRequest
  const navigate = useNavigate();
  const authData = useSelector(state => state.root.get('authData'));

  const onFinish = async (values) => {
    const response = await changePassword(authData?.id, values.currentPassword, values.newPassword);
    if (response) {
      navigate("/");
    }
  };

  const validatePassword = (_, value) => {
    if (!value) {
      return Promise.reject('Vui lòng nhập mật khẩu mới!');
    }
    if (value.length < 6) {
      return Promise.reject('Mật khẩu phải có ít nhất 6 ký tự!');
    }
    if (!/\d/.test(value)) {
      return Promise.reject('Mật khẩu phải chứa ít nhất một số!');
    }
    if (!/[A-Z]/.test(value)) {
      return Promise.reject('Mật khẩu phải chứa ít nhất một chữ hoa!');
    }
    if (!/[a-z]/.test(value)) {
      return Promise.reject('Mật khẩu phải chứa ít nhất một chữ thường!');
    }
    // if (/[^A-Za-z0-9]/.test(value)) {
    //   return Promise.reject('Mật khẩu không được chứa ký tự đặc biệt!');
    // }
    return Promise.resolve();
  };

  return (
    <div style={{
      display: 'flex',
      justifyContent: 'center',
      alignItems: 'center',
      minHeight: '100vh',
      backgroundColor: '#f0f2f5'
    }}>
      <Card
        title="Đổi mật khẩu"
        style={{
          width: 400,
          boxShadow: '0 4px 8px rgba(0,0,0,0.1)'
        }}
      >
        <Form
          form={form}
          name="change_password"
          onFinish={onFinish}
          layout="vertical"
        >
          <Form.Item
            name="currentPassword"
            label="Mật khẩu hiện tại"
            rules={[{
              required: true,
              message: 'Vui lòng nhập mật khẩu hiện tại!',
            }]}
          >
            <Input.Password prefix={<LockOutlined/>} placeholder="Nhập mật khẩu hiện tại"/>
          </Form.Item>

          <Form.Item
            name="newPassword"
            label="Mật khẩu mới"
            rules={[
              {
                validator: validatePassword,
              },
            ]}
          >
            <Input.Password prefix={<LockOutlined/>} placeholder="Nhập mật khẩu mới"/>
          </Form.Item>

          <Form.Item
            name="confirmPassword"
            label="Xác nhận mật khẩu mới"
            dependencies={['newPassword']}
            rules={[
              {required: true, message: 'Vui lòng xác nhận mật khẩu mới!'},
              ({getFieldValue}) => ({
                validator(_, value) {
                  if (!value || getFieldValue('newPassword') === value) {
                    return Promise.resolve();
                  }
                  return Promise.reject(new Error('Hai mật khẩu không khớp!'));
                },
              }),
            ]}
          >
            <Input.Password prefix={<LockOutlined/>} placeholder="Xác nhận mật khẩu mới"/>
          </Form.Item>

          <Form.Item>
            <Button type="primary" htmlType="submit" style={{width: '100%'}}>
              Đổi mật khẩu
            </Button>
          </Form.Item>

          <div style={{textAlign: 'center', color: "#1677ff", textDecoration: "underline"}}>
            <Link to={"/"}>Trở lại</Link>
          </div>
        </Form>
      </Card>
    </div>
  );
};

export default ChangePasswordView;