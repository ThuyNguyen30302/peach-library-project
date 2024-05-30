import React, {useRef, useState} from 'react'
import {Link, useNavigate} from 'react-router-dom';
import {Button, Divider, Form, Input} from 'antd';
import {useRequest} from "../../custom-hook/useRequest";
import BaseForm from "../../common/core/BaseForm";
import "./style-login-page.scss";
import _ from "lodash";
import {LockOutlined, UserOutlined} from "@ant-design/icons";

const itemsLayout = {
    // labelCol: {span: 6},
    // wrapperCol: {span: 18},
};
const validateMessages = {
    required: '${label} là bắt buộc!',
};

const LoginPage = (props) => {
    const navigate = useNavigate();
    const formRef = useRef();

    const [signInForm, setLogInForm] = useState({username: '', password: ''});
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
    const onSubmit = async () => {
        try {
            const values = await formRef.current.validateFields();
            formRef.current && props.onSubmit(formRef.current, values)
        } catch (error) {
            console.error("Validation Failed:", error);
        }
    }

    const renderBody = () => {
        return <div className={'w-full'}>
            <div className="logo-login block xl:hidden">
                <div className={"w-full flex justify-center items-center"}>
                    <img src="/uploads/logo/Logo-full-trans.png" className={"w-2/5"} alt=""/>
                </div>
            </div>
            <h1 className={"title text-3xl xl:text-5xl"}>Đăng nhập</h1>
            <Form.Item
                name="account"
                // label="Tên tài khoản"
                rules={[{
                    required: true,
                    message: "Tài khoản là bắt buộc!"
                }]}
            >
                <Input value={signInForm.username}
                       addonBefore={<UserOutlined/>}
                       onChange={e => setLogInForm({...signInForm, username: e.target.value})}/>
            </Form.Item>
            <Form.Item
                // label="Mật khẩu"
                name="password"
                rules={[{
                    required: true,
                    message: "Mật khẩu là bắt buộc!"
                },
                ]}
            >
                <Input.Password value={signInForm.password}
                                addonBefore={<LockOutlined/>}
                                onChange={e => setLogInForm({...signInForm, password: e.target.value})}/>
            </Form.Item>
            <div className="btn-group d-flex flex-column mt-3 text-center">
                <Button className={'btn-submit btn-login'} htmlType="submit" onClick={() => onSubmit()}>
                    Đăng nhập
                </Button>
                <Divider plain>Hoặc</Divider>
                {/*<Link to={'/sign-up'}>*/}
                {/*<Button className={'btn-submit'}>*/}
                Đăng ký tại quầy
                {/*</Button>*/}
                {/*</Link>*/}
            </div>
        </div>;
    }

    return (
        <div className="log-in-form-contain xl:h-screen w-screen"
             style={{
                 backgroundColor: "#fff", backgroundImage: 'url(/uploads/login/login-background.jpeg)',
             }}>
            <div className="log-in-form grid grid-cols-2 box-shadow-main-page">
                <div className={"col-span-2 xl:col-span-1 left-part"}>
                    <div className={'left-part-form w-9/12'}>
                        <BaseForm
                            {...itemsLayout}
                            ref={formRef}
                            validateMessages={validateMessages}
                            name="control-hooks"
                            buttons={<></>}
                        >
                            {renderBody()}
                        </BaseForm>
                    </div>
                </div>
                <div className="logo-login col-span-1 hidden xl:block right-part">
                    <div className={"flex justify-center items-center"}>
                        <img src="/uploads/logo/Logo-full-trans.png" className={"w-4/5"} alt={''}/>
                    </div>
                </div>
            </div>
        </div>
    );
}

export default LoginPage;