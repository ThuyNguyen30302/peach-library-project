import React from 'react';
import {Breadcrumb, Layout, Menu, theme, Tooltip} from "antd";
import Logo from "../layouts/Logo";
import UserProfile from "../layouts/UserProfile";
import Home from "./home/Home";
import MemberHome from "./home/MemberHome";
import {useNavigate} from "react-router-dom";

const {Header, Content} = Layout;

const MemberMainPage = () => {
  const navigate = useNavigate();

  const {
    token: {colorBgContainer, borderRadiusLG},
  } = theme.useToken();

  return (
    <Layout style={{minHeight: '100vh'}}>
      <Layout className="site-layout">
        <Header style={{
          background: colorBgContainer,
          display: "flex",
          justifyContent: "space-between",
          alignItems: "center",
          paddingLeft: 10,
          paddingRight: 10
        }}
                className={'box-shadow-main-page'}
        >
          <div style={{display: 'flex', alignItems: 'center', justifyContent: 'center', cursor: 'pointer'}}
               title={"Peach Library"}
               onClick={() => {
                 navigate('/');
               }}>
            <Logo/>
          </div>
          <UserProfile/>
        </Header>
        <Content style={{marginTop: '16px'}}>
          <div style={{padding: 24, height: '100%'}} className={'content box-shadow-main-page'}>
            <MemberHome/>
          </div>
        </Content>
      </Layout>
    </Layout>
  );
};

export default MemberMainPage;