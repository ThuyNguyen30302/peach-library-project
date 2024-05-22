import "./App.scss";
import React, {useState} from "react";
import Logo from "./layouts/Logo";
import MenuList from "./layouts/MenuList";
import {Button, Breadcrumb, Layout, theme} from "antd";
import {MenuFoldOutlined, MenuUnfoldOutlined} from "@ant-design/icons";
import AppSwitch from "./AppSwitch";
import {Provider} from "react-redux";
import {AppStore} from "./store";
import {BrowserRouter as Router} from 'react-router-dom';

const {Header, Sider, Content} = Layout;

export const App = () => {
  // const [collapsed, setCollapsed] = useState(false);
  // const {
  //   token: {colorBgContainer, borderRadiusLG},
  // } = theme.useToken();

  return (
      <Provider store={AppStore}>
        <Router>
          <AppSwitch/>
        </Router>
      </Provider>
    // <Layout>
    //   <Sider trigger={null} theme="light" className="sidebar" collapsible collapsed={collapsed}>
    //     <Logo/>
    //     <MenuList/>
    //   </Sider>
    //   <Layout>
    //     <Header style={{
    //       background: colorBgContainer,
    //       display: "flex",
    //       justifyContent: "space-between",
    //       alignItems: "center",
    //       paddingLeft: 10,
    //       paddingRight: 10
    //     }}>
    //       <Button
    //         icon={collapsed ? <MenuUnfoldOutlined/> : <MenuFoldOutlined/>}
    //         onClick={() => setCollapsed(!collapsed)}
    //       />
    //     </Header>
    //   </Layout>
    // </Layout>
  );
};

export default App;
