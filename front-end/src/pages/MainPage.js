import _ from 'lodash';
import React, {Suspense, useEffect, useState} from 'react';
import {useSelector} from 'react-redux';
import {useNavigate, useLocation, Link} from 'react-router-dom';
import {Layout, Menu, Breadcrumb, Button, theme} from 'antd';
import Loading from '../component/Loading';
import {LOADING_TITLE} from '../constant/constant';
import {useRequest} from '../custom-hook/useRequest';
import useMergeState from '../custom-hook/useMergeState';
import {noRouteComponents, routeComponents} from '../AppComponent';
import Logo from "../layouts/Logo";
import {HomeOutlined, MenuFoldOutlined, MenuUnfoldOutlined} from "@ant-design/icons";
import UserProfile from "../layouts/UserProfile";
import {AppStore} from "../store";
import {loginSuccessFull} from "../action/action";

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
    const normalizePath = (path) => path.split('/').filter(Boolean).join('/');
    const staticKey = normalizePath(key);

    for (const route of routes) {
      const staticRouteKey = normalizePath(route.key);

      const routeRegex = new RegExp(`^${staticRouteKey.replace(/:[^/]+/g, '[^/]+')}$`);
      if (routeRegex.test(staticKey)) return route;

      if (route.children) {
        const foundInChild = findRouteByKey(key, route.children);
        if (foundInChild) return foundInChild;
      }
    }
    return null;
  };

  const findRouteByName = (name, routes) => {
    const normalizePath = (path) => path.split('/').filter(Boolean).join('/');
    const staticName = normalizePath(name);

    for (const route of routes) {
      const staticRouteName = normalizePath(route.name);

      const routeRegex = new RegExp(`^${staticRouteName.replace(/:[^/]+/g, '[^/]+')}$`);
      if (routeRegex.test(staticName)) return route;

      if (route.children) {
        const foundInChild = findRouteByName(name, route.children);
        if (foundInChild) return foundInChild;
      }
    }
    return null;
  };

  const initRoute = findRouteByKey(location.pathname, routeComponents);

  const [route, setRoute] = useState(initRoute ?? routeComponents[0]);

  const {checkLogin} = useRequest();

  useEffect(() => {
    const loadData = async () => {
      await Promise.all([
        checkLogin(),
      ]).then(([resCheckLogin]) => {
        AppStore.dispatch(loginSuccessFull(authData));
        setState({
          loading: false,
          // envSetting: _.get(resCheckLogin, 'envSetting')
        });
      });
    };
    loadData();
  }, [route]);

  const onSelectRoute = ({key}) => {
    const selectedRoute = findRouteByKey(key, routeComponents);
    if (selectedRoute) {
      setRoute(selectedRoute);
      navigate(selectedRoute?.key);
    }
  };

  const renderBody = () => {
    if (state.loading) {
      return <Loading text={LOADING_TITLE}/>;
    }

    // if (_.isEmpty(authData)) {
    //   const returnUrl = location.pathname;
    //   navigate('/login', { state: { returnUrl } });
    //   return null;
    // }

    const renderBreadcrumb = () => {
      const splitPath = location.pathname.split('/');
      const breadcrumbs = []
      _.forEach(splitPath, (item, i) => {
        if (i !== 0 && !_.isEmpty(item)) {
          const routeItem = findRouteByName(item, routeComponents) || findRouteByName(item, noRouteComponents);
          routeItem && breadcrumbs.push({
            key: routeItem.key,
            label: routeItem.label
          })
        }
      })
      return <>
                <span className={'ml-1'}><Link to={'/'}
                                               onClick={() => setRoute(routeComponents[0])}><HomeOutlined/></Link></span>
        {_.map(breadcrumbs, (breadcrumb, i) => {
          return <> <span className={'mx-2'}>/</span> {breadcrumb.label}</>;
        })}
      </>;
    };

    const renderComponent = (route) => {
      const Component = route.component;
      return <Suspense fallback={<Loading/>}>
        <Component/>
      </Suspense>
    }

    const getRouteComponent = () => {
      const route = findRouteByKey(location.pathname, routeComponents) || findRouteByKey(location.pathname, noRouteComponents);
      if (route) {
        return renderComponent(route);
      }
      return <div>Not Found</div>; // Handle not found routes
    };

    return (
      <Layout style={{minHeight: '100vh'}}>
        <Sider theme="light" className="sidebar" collapsible collapsed={collapsed}
               onCollapse={(value) => setCollapsed(value)}>
          <div style={{display: 'flex', alignItems: 'center', justifyContent: 'center', cursor: 'pointer'}}
               onClick={() => {
                 setRoute(routeComponents[0]);
                 navigate('/');
               }}>
            <Logo/>
          </div>
          <Menu
            theme="light"
            mode="inline"
            items={routeComponents}
            className={"menu-bar box-shadow-main-page"}
            onClick={onSelectRoute}
            selectedKeys={[route.key]}
          />
        </Sider>
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
            <div></div>
            <UserProfile/>
          </Header>
          <Breadcrumb style={{margin: '16px'}}>
            {renderBreadcrumb()}
          </Breadcrumb>
          <Content style={{margin: '0 16px'}}>
            <div style={{padding: 24, height: '100%'}} className={'content box-shadow-main-page'}>
              {getRouteComponent()}
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
