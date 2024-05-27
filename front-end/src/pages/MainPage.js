import _ from 'lodash';
import React, {useEffect, useState} from 'react';
import {useSelector} from 'react-redux';
import {useNavigate, useLocation, Routes, Route, Navigate, Link} from 'react-router-dom';
import {Layout, Menu, Breadcrumb, Button, theme} from 'antd';
import Loading from '../component/Loading';
import {LOADING_TITLE} from '../constant/constant';
import {useRequest} from '../custom-hook/useRequest';
import useMergeState from '../custom-hook/useMergeState';
import components from '../AppComponent';
import Logo from "../layouts/Logo";
import Home from "../Home";
import Active from "../Active";
import {MenuFoldOutlined, MenuUnfoldOutlined} from "@ant-design/icons";

const {Header, Content, Sider} = Layout;

const MainPage = () => {
  const navigate = useNavigate();
  const location = useLocation();

  const [state, setState] = useMergeState({
    loading: true,
    isAuthenticated: null,
    rights: [],
    envSetting: ''
  });

  const {authData, rights} = useSelector((stateRedux) => ({
    authData: stateRedux?.root?.get('authData'),
    rights: stateRedux?.root?.get('rights'),
  }));

  const {
    token: {colorBgContainer, borderRadiusLG},
  } = theme.useToken();
  const [collapsed, setCollapsed] = useState(false);

  const findRouteByKey = (key, routes) => {
    for (const route of routes) {
      if (route.key === key) return route;
      if (route.children) {
        const foundInChild = findRouteByKey(key, route.children);
        if (foundInChild) return foundInChild;
      }
    }
    return null;
  };
  const initRoute = findRouteByKey(location.pathname, components);
  console.log(initRoute)
  const [route, setRoute] = useState(initRoute??components[0]);

  const {checkLogin} = useRequest();

  useEffect(() => {
    const loadData = async () => {
      await Promise.all([
        checkLogin(),
      ]).then(([resCheckLogin]) => {
        setState({
          loading: false,
          envSetting: _.get(resCheckLogin, 'envSetting')
        });
      });
    };
    loadData();
  }, [route]);

  const onSelectRoute = ({ key }) => {
    const selectedRoute = findRouteByKey(key, components);
    if (selectedRoute) {
      setRoute(selectedRoute);
      navigate(selectedRoute?.key);
    }
  };

  const renderBody = () => {
    if (state.loading) {
      return <Loading text={LOADING_TITLE} />;
    }

    // if (_.isEmpty(authData)) {
    //   const returnUrl = location.pathname;
    //   navigate('/login', { state: { returnUrl } });
    //   return null;
    // }

    // const menuItems = _.map(Object.values(components), item => {
    //   if (item?.children) {
    //     return {
    //       key: item?.key,
    //       icon: item?.icon,
    //       label: item?.label,
    //       children: item?.children
    //     };
    //   }
    //   return {
    //     key: item?.key,
    //     icon: item?.icon,
    //     label: item?.label
    //   };
    // });

    const renderBreadcrumb = (route) => {
      const breadcrumbs = [];

      if (route.children) {
        // Nếu route có children, tạo breadcrumb cho từng child
        route.children.forEach((child, index) => {
          breadcrumbs.push(
            <Breadcrumb.Item key={index}>
              <Link to={child.key}>{child.label}</Link>
            </Breadcrumb.Item>
          );

          // Nếu child cũng có children, gọi đệ quy để tạo breadcrumb cho mỗi mức con của child
          if (child.children) {
            breadcrumbs.push(renderBreadcrumb(child));
          }
        });
      }

      return breadcrumbs;
    };

    const breadcrumbItems = location.pathname.split('/').filter(i => i).map((path, index) => {
      const route = findRouteByKey(path, components);
      return route ? (
        <Breadcrumb.Item key={index}>
          <Link to={route.key}>{route.label}</Link>
          {/* Nếu route có children, tạo breadcrumb cho từng child */}
          {route.children && renderBreadcrumb(route)}
        </Breadcrumb.Item>
      ) : (
        <span key={index}>{path}</span>
      );
    });

    const renderComponent = () => {
      if (route.name === 'home') { return <Home/>}
      if (route.name === 'active') { return <Active/>}
      if (route.name === 'active1') { <Active/>}
      if (route.name === 'active2') {<Active/>}
    }

    return (
      <Layout style={{minHeight: '100vh'}}>
        <Sider trigger={null} theme="light" className="sidebar" collapsible collapsed={collapsed}>
          <div style={{display: 'flex', alignItems: 'center', justifyContent: 'center', cursor: 'pointer'}}
               onClick={() => navigate('/home')}>
            <Logo />
          </div>
          <Menu
            theme="light"
            mode="inline"
            items={components}
            className={"menu-bar"}
            onClick={onSelectRoute}
            selectedKeys={[route.key]}
          />
        </Sider >
        <Layout className="site-layout">
          <Header style={{
            background: colorBgContainer,
            display: "flex",
            justifyContent: "space-between",
            alignItems: "center",
            paddingLeft: 10,
            paddingRight: 10
          }}>
            <Button
              icon={collapsed ? <MenuUnfoldOutlined/> : <MenuFoldOutlined/>}
              onClick={() => setCollapsed(!collapsed)}
            />
          </Header>
          {/*<Breadcrumb style={{margin: '16px'}}>*/}
          {/*  {breadcrumbItems}*/}
          {/*</Breadcrumb>*/}
          <Content style={{margin: '0 16px'}}>
            <div style={{padding: 24, minHeight: 360}}>
              {/*{route && <route.component />}*/}
              {renderComponent()}
            </div>
          </Content>
        </Layout>
      </Layout>
    );
  };

  return (
    <div className="main">
      {renderBody()}
    </div>
  );
};

export default MainPage;
