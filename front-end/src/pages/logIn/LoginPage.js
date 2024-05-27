import React, {useRef, useState} from 'react'
import {Link, useNavigate} from 'react-router-dom';
import {Button, Divider, Form, Input} from 'antd';
import {useRequest} from "../../custom-hook/useRequest";
import BaseForm from "../../common/core/BaseForm";
import _ from "lodash";

const layout = {
  labelCol: { span: 24 },
  wrapperCol: { span: 24 },
};
const validateMessages = {
  required: '${label} là bắt buộc!',
};

const LogIn = (props) => {
  const navigate = useNavigate();
  const formRef = useRef();

  const [signInForm, setLogInForm] = useState({ username: '', password: '' });
  const {login} = useRequest();

  // async function onSignIn() {
  //   try {
  //     const { data } = await signInAPI(signInForm);
  //
  //     window.localStorage.setItem('token', data);
  //
  //     const role = jwtDecode(data)?.role;
  //
  //     if (role === 0 || role === 1) {
  //       navigate('/manage/dashboard');
  //     }
  //     else {
  //       navigate('/');
  //     }
  //   }
  //   catch (e) {
  //     alert('Dang nhap that bai');
  //   }
  // }

  const renderBody = () => {
    return <>
      <div className="logo">
        <img src="/uploads/logo/Logo.png" alt=""/>
      </div>
      <h1 className={"title font-weight-bold"}>Đăng nhập</h1>
      <Form.Item
        name="account"
        label="Tên tài khoản"
        rules={[
          {
            required: true,
          },
        ]}
      >
        <Input value={signInForm.username} onChange={e => setLogInForm({...signInForm, username: e.target.value})}/>
      </Form.Item>
      <Form.Item
        label="Mật khẩu"
        name="password"
        rules={[{required: true}]}
      >
        <Input.Password value={signInForm.password}
                        onChange={e => setLogInForm({...signInForm, password: e.target.value})}/>
      </Form.Item>
      <div className="btn-group d-flex flex-column mt-3">
        <Button className={'btn-submit'} htmlType="submit" onClick={props.onSubmit}>
          Đăng nhập
        </Button>
        <Divider plain>Hoặc</Divider>
        <Link to={'/sign-up'}>
          <Button className={'btn-submit'}>
            Đăng ký tại quầy
          </Button>
        </Link>
      </div>
    </>;
  }

  return (
    <section className="container py-5 h-100">
      <div className="row form-ant" style={{backgroundColor: "#fff"}}>
        {/*<div className="img-form d-none d-lg-block col-lg-6 p-0">*/}
        {/*  <img src="/uploads/logo/Logo-full-trans.png" className={"h-100"}/>*/}
        {/*</div>*/}
        <BaseForm
          {...layout}
          ref={formRef}
          validateMessages={validateMessages}
          name="control-hooks"
          className={"p-5 col-12 col-lg-6 form-body-ant"}
        >
          {renderBody()}
        </BaseForm>
      </div>
    </section>
  );
}

export default LogIn;