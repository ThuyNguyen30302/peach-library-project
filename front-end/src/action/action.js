import * as Constant from '../constant/constant';
import { IFilterGlobal, IValueFilterGlobal } from '../common/components/FilterGlobalComponent';

export const routeChanged = () => ({ type: Constant.ROUTE_CHANGED });

export const logout = () => ({ type: Constant.LOG_OUT });

export const logoutSuccessFull = () => ({ type: Constant.LOG_OUT_SUCCESSFUL });

export const loginSuccessFull = (authData) => {
    return {
        type: Constant.LOG_IN_SUCCESSFUL,
        authData,
    };
};

export const setMenus = (menu) => {
    return {
        type: Constant.MENU_LAYOUT,
        menu,
    };
};
export const setRights = (payload) => {
    return {
        type: Constant.SET_RIGHT,
        payload,
    };
};
export const setRoutes = (routes) => {
    return {
        type: Constant.ROUTES_LAYOUT,
        routes,
    };
};

export function toggleMenuDesktop(show) {
    return {
        type: Constant.TOGGLE_MENU_DESKTOP,
        show,
    };
}

export function changeDialog(dialog) {
    return {
        type: Constant.CHANGE_DIALOG,
        dialog,
    };
}

export function changeSideMenu(menu) {
    return {
        type: Constant.CHANGE_SIDEMENU,
        menu,
    };
}

export function setHeaderMenu(menu) {
    return {
        type: Constant.SET_HEADER_MENU,
        menu,
    };
}

export function setActivityInstanceAllow(item) {
    return {
        type: Constant.ACTIVITY_INSTANCE_ALLOW,
        item,
    };
}

export function changeListAlertMessage(listAlertMessage) {
    return {
        type: Constant.LOAD_LIST_ALERT_MESSAGE,
        listAlertMessage,
    };
}

export const setEmployeeSelected = (item) => ({
    type: Constant.SET_EMPLOYEEE_SELECTED,
    item,
});

export const setCookieTimeoutConfig = (sessionTimeoutConfig, waitingTimeConfig) => ({
    type: Constant.SET_COOKIE_TIMEOUT_CONFIG,
    sessionTimeoutConfig,
    waitingTimeConfig,
});

export const setConfigGlobalFilter = (config) => {
    return {
        type: Constant.GLOBAL_FILTER,
        config,
    };
};

export const setValueGlobalFilter = (value: IValueFilterGlobal) => {
    return {
        type: Constant.SET_VALUE_GLOBAL_FILTER,
        value,
    };
};

