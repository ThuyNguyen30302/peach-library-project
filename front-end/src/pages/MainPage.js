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

    const findRouteByName = (name, routes) => {
        for (const route of routes) {
            if (route.name === name) return route;
            if (route.children) {
                const foundInChild = findRouteByName(name, route.children); // Corrected this line
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
                setState({
                    loading: false,
                    envSetting: _.get(resCheckLogin, 'envSetting')
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
                    const routeItem = findRouteByName(item, routeComponents);
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

        return (
            <Layout style={{minHeight: '100vh'}}>
                <Sider trigger={null} theme="light" className="sidebar" collapsible collapsed={collapsed}>
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
                        <Button
                            icon={collapsed ? <MenuUnfoldOutlined/> : <MenuFoldOutlined/>}
                            onClick={() => setCollapsed(!collapsed)}
                        />
                    </Header>
                    <Breadcrumb style={{margin: '16px'}}>
                        {renderBreadcrumb()}
                    </Breadcrumb>
                    <Content style={{margin: '0 16px'}}>
                        <div style={{padding: 24, height: '100%'}} className={'content box-shadow-main-page'}>
                            {/*{route && <route.component />}*/}
                            {renderComponent(route)}
                            {/*{renderComponent(noRouteComponents)}*/}
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
